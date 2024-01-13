using Microsoft.AspNetCore.Http;
using FiyiStackWeb.Areas.BasicCore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using FiyiStackWeb.PayPalConfiguration;
using System.Threading.Tasks;
using PayPal.Api;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Numerics;
using Microsoft.Data.SqlClient;
using DocumentFormat.OpenXml.Drawing.Charts;
using static FiyiStackWeb.Pages.CheckoutController;
using Microsoft.AspNetCore.Mvc;

namespace FiyiStackWeb.Pages
{
    public class CheckoutController : Controller
    {

        [HttpPost]
        public IActionResult CreatePaypalOrder([FromBody] RequestData data)
        {

            // Handle POST request logic here
            // You can access data properties like data.Field1, data.Field2, etc.





            string planRes = GetPayPalPlans(data.SubPlanId);
            // Parse the JSON content
            JObject jsonPlan = JObject.Parse(planRes);

            // Extract plan name and price
            string planName = jsonPlan["name"].ToString();
            string planPrice = jsonPlan["billing_cycles"][0]["pricing_scheme"]["fixed_price"]["value"].ToString();
            Subscription subscription = new Subscription
            {
                SubscriptionID = "SUB123",
                UserID = 123,
                PlanID = data.SubPlanId,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(1),
                Status = "Active",
                PlanName = planName,
                NextBillingDate = DateTime.UtcNow.AddMonths(1)
            };
            LogSubscription(subscription);
            var response = new
            {
                Success = true,
                Message = "Post request handled successfully",
                PlanId = data.SubPlanId,
                PlanDetails = planName
            };

            return new JsonResult(response);
        }
        private readonly HttpClient _httpClient;

        public CheckoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();

        }
        public string GetPayPalPlans(string PlanId)
        {
            PayPalConfiguration.PayPalConfiguration PaypalConfig = new PayPalConfiguration.PayPalConfiguration();
            string paypalURL = PaypalConfig.Paypal_URL;
            string AuthToken = GetPayPalAuthToken().Trim();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Prefer", "return=representation");

            HttpResponseMessage response = _httpClient.GetAsync(paypalURL + "/v1/billing/plans/" + PlanId).Result;

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                // Handle the content (JSON response) as needed
                return content;
            }
            else
            {
                // Handle error response
                //return StatusCode((int)response.StatusCode, "Failed to fetch PayPal plans");
                string errorContent = response.Content.ReadAsStringAsync().Result;
                // Return the actual error content received from PayPal
                return errorContent + " Status Code:" + (int)response.StatusCode;

            }
        }

        public string GetPayPalAuthToken()
        {
            PayPalConfiguration.PayPalConfiguration PaypalConfig = new PayPalConfiguration.PayPalConfiguration();

            string clientId = PaypalConfig.ClientID;
            string clientSecret = PaypalConfig.ClientSecret;
            string paypalURL = PaypalConfig.Paypal_URL;

            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            var content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = _httpClient.PostAsync(paypalURL + "/v1/oauth2/token", content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                // Deserialize the response to extract the access token
                // You will need to use a JSON deserialization library
                // For example: Newtonsoft.Json.JsonConvert.DeserializeObject
                // Extract the access_token from the responseContent and return it
                // Example: return tokenResponse.access_token;
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
                return tokenResponse.access_token;
            }
            else
            {
                throw new Exception("Failed to get PayPal authentication token.");
            }
        }

        private class TokenResponse
        {
            public string access_token { get; set; }
            // Add other properties as needed
        }

        public class RequestData
        {
            public string SubPlanId { get; set; }
            // Add more properties as needed
        }
        #region Webhook
        [HttpPost]
        public async Task<IActionResult> PayPalWebhook()
        {
            // Get the request body as a JSON object
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string requestBody = await reader.ReadToEndAsync();
                var webhookData = JsonConvert.DeserializeObject<JObject>(requestBody);

                // Extract the event type from the webhook payload
                string eventType = webhookData["event_type"].ToString();

                if (eventType == "PAYMENT.SALE.COMPLETED" || eventType == "BILLING.SUBSCRIPTION.ACTIVATED")
                {

                    // Event is a successful subscription event
                    // Extract the custom_id (user ID) or other data as needed
                    string customId="0";
                    DateTime startDate;
                    DateTime nextBillingDate;
                    DateTime endDate;
                    string status ;
                    string subscriptionId;

                    if (eventType == "PAYMENT.SALE.COMPLETED") {
                        
                         startDate = DateTime.Parse(webhookData["resource"]["update_time"].ToString());
                         nextBillingDate = startDate.AddMonths(1);
                         endDate = startDate.AddMonths(1);
                         subscriptionId = webhookData["resource"]["billing_agreement_id"].ToString();
                        Subscription subscription_update = new Subscription
                        {
                            SubscriptionID = subscriptionId,
                            StartDate = startDate,
                            EndDate = endDate,
                            NextBillingDate = nextBillingDate,


                        };
                        LogSubscription(subscription_update);
                        return Ok();

                    }
                    else { 
                        customId = webhookData["resource"]["custom_id"].ToString();
                        startDate = DateTime.Parse(webhookData["resource"]["start_time"].ToString());
                        nextBillingDate = startDate.AddMonths(1);
                        endDate = startDate.AddMonths(1);
                        subscriptionId = webhookData["resource"]["id"].ToString();
                       
                    }

                     status = webhookData["resource"]["status"].ToString();


                    string subscriber_email = webhookData["resource"]["subscriber"]["email_address"].ToString();
                    string subscriber_name = webhookData["resource"]["subscriber"]["name"]["given_name"].ToString() + " " + webhookData["resource"]["subscriber"]["name"]["surname"].ToString();
                    string planId = webhookData["resource"]["plan_id"].ToString();
                    string planRes = GetPayPalPlans(planId);
                    // Parse the JSON content
                    JObject jsonPlan = JObject.Parse(planRes);
                    // Extract plan name and price
                    string planName = jsonPlan["name"].ToString();

                    string planPrice = jsonPlan["billing_cycles"][0]["pricing_scheme"]["fixed_price"]["value"].ToString();

                    

                    Subscription subscription = new Subscription
                    {
                        SubscriptionID = subscriptionId,
                        UserID = int.Parse(customId),
                        PlanID = planId,
                        Email = subscriber_email,
                        Name = subscriber_name,
                        StartDate = startDate,
                        EndDate = endDate,
                        NextBillingDate = nextBillingDate,
                        Status = status,
                        PlanName = planName

                    };
                    LogSubscription(subscription);
                    // Perform actions for successful subscription event
                }
                else if (eventType == "BILLING.SUBSCRIPTION.CANCELLED")
                {
                    string subscriptionId = webhookData["resource"]["id"].ToString();
                    CancelSubscription(subscriptionId);
                }
                return Ok();
            }
        }
        public void LogSubscription(Subscription subscription)
        {
            string _ConnectionString = ConnectionStrings.ConnectionStrings.Production();// Change it for Production

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                // Check if the record already exists
                string selectQuery = "SELECT COUNT(*) FROM dbo.Subscription WHERE SubscriptionID = @SubscriptionID";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@SubscriptionID", subscription.SubscriptionID);

                    int existingCount = Convert.ToInt32(selectCommand.ExecuteScalar());

                    if (existingCount > 0)
                    {
                        // Update the existing record
                        string updateQuery = @"UPDATE dbo.Subscription
                                            SET StartDate = @StartDate, EndDate = @EndDate,
                                                NextBillingDate = @NextBillingDate
                                            WHERE SubscriptionID = @SubscriptionID";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@SubscriptionID", subscription.SubscriptionID);
                            updateCommand.Parameters.AddWithValue("@StartDate", subscription.StartDate);
                            updateCommand.Parameters.AddWithValue("@EndDate", subscription.EndDate);
                            updateCommand.Parameters.AddWithValue("@NextBillingDate", subscription.NextBillingDate);

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Insert a new record
                        string insertQuery = @"INSERT INTO dbo.Subscription 
                                            (SubscriptionID, UserID, PlanID, StartDate, EndDate, Status, PlanName, NextBillingDate,Email,Name)
                                            VALUES
                                            (@SubscriptionID, @UserID, @PlanID, @StartDate, @EndDate, @Status, @PlanName, @NextBillingDate,@Email,@Name)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@SubscriptionID", subscription.SubscriptionID);
                            insertCommand.Parameters.AddWithValue("@UserID", subscription.UserID);
                            insertCommand.Parameters.AddWithValue("@PlanID", subscription.PlanID);
                            insertCommand.Parameters.AddWithValue("@StartDate", subscription.StartDate);
                            insertCommand.Parameters.AddWithValue("@EndDate", subscription.EndDate);
                            insertCommand.Parameters.AddWithValue("@Status", subscription.Status);
                            insertCommand.Parameters.AddWithValue("@PlanName", subscription.PlanName);
                            insertCommand.Parameters.AddWithValue("@NextBillingDate", subscription.NextBillingDate);
                            insertCommand.Parameters.AddWithValue("@Email", subscription.Email);
                            insertCommand.Parameters.AddWithValue("@Name", subscription.Name);

                            try
                            {
                                // Your code to execute the SQL query
                                // For example, executing insertCommand.ExecuteNonQuery();

                                int rowsAffected = insertCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    Console.WriteLine("Query was successful. Rows affected: " + rowsAffected);
                                }
                                else
                                {
                                    Console.WriteLine("Query was executed, but no rows were affected.");
                                }
                            }
                            catch (SqlException ex)
                            {
                                // Handle the exception
                                Console.WriteLine("An SQL error occurred: " + ex.Message);
                            }
                            catch (Exception ex)
                            {
                                // Handle other types of exceptions
                                Console.WriteLine("An error occurred: " + ex.Message);
                            }

                        }
                    }
                }
            }
        }
        public void CancelSubscription(string subscriptionId)
        {
            string _ConnectionString = ConnectionStrings.ConnectionStrings.Development();// Change it for Production

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                // Update the subscription status to "Cancelled"
                string updateQuery = @"UPDATE dbo.Subscription
                               SET Status = 'Cancelled'
                               WHERE SubscriptionID = @SubscriptionID";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@SubscriptionID", subscriptionId);

                    try
                    {
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Subscription cancelled successfully. Rows affected: " + rowsAffected);
                        }
                        else
                        {
                            Console.WriteLine("Subscription not found or no rows were affected.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Handle the exception
                        Console.WriteLine("An SQL error occurred: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        // Handle other types of exceptions
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        public class Subscription
        {
            public string SubscriptionID { get; set; }
            public int UserID { get; set; }
            public string PlanID { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Status { get; set; }
            public string PlanName { get; set; }
            public DateTime NextBillingDate { get; set; }

        }

        #endregion

    }
    public class CheckoutModel : PageModel
    {
        public void OnGet(string AccountType, string SubPlanId)
        {
            if (SubPlanId is null)
            {
                throw new ArgumentNullException(nameof(SubPlanId));
            }
            PayPalConfiguration.PayPalConfiguration PaypalConfig = new PayPalConfiguration.PayPalConfiguration();
            //Get UserId from Session
            int UserId = HttpContext.Session.GetInt32("UserId") ?? 0;

            if (UserId == 0)
            {
                //User not found
                ViewData["EnterButton"] = $@"<li class='nav-item'>
                                                <a href='/Login' class='btn btn-white mt-1 ml-2'>
                                                    <i class='fas fa-user'></i> 
                                                    <span class='nav-link-inner--text'>
                                                        Login
                                                    </span>
                                                </a>
                                            </li>";
            }
            else
            {
                //User found
                ViewData["EnterButton"] = $@"<li class='nav-item'>
                                                <a href='/CMSCore/DashboardIndex' class='btn btn-white mt-1 ml-2'>
                                                    <i class='fas fa-user'></i> 
                                                    <span class='nav-link-inner--text'>
                                                        Enter dashboard
                                                    </span>
                                                </a>
                                            </li>";
            }
            ViewData["SubPlanId"] = SubPlanId;
            ViewData["ClientId"] = PaypalConfig.ClientID;
            ViewData["Mode"] = PaypalConfig.Mode;
            ViewData["UserId"] = UserId;
            if (AccountType == "AmateurAccount")
            {
                ViewData["AccountType"] = "Amateur account";
                ViewData["Price"] = "5";

            }
            else
            {
                ViewData["AccountType"] = "PRO account";
                ViewData["Price"] = "8";
            }

            VisitorCounterModel VisitorCounterModel = new VisitorCounterModel()
            {
                Active = true,
                Page = "/Checkout",
                DateTime = DateTime.Now,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                UserCreationId = 1,
                UserLastModificationId = 1,
            };

            VisitorCounterModel.Insert();
        }
    }
}
