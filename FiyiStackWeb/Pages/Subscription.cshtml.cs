using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using static FiyiStackWeb.Pages.CheckoutController;

namespace FiyiStackWeb.Pages
{
    public class SubscriptionModel : PageModel
    {
        public List<Subscription> Subscriptions { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public const int PageSize = 15; // Set the number of items per page

        public void OnGet(int page = 1) // Accept page as a parameter
        {
            string _ConnectionString = ConnectionStrings.ConnectionStrings.Production(); // Change it for Production

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                string countQuery = "SELECT COUNT(*) FROM dbo.Subscription"; // Query to get total row count
                using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                {
                    int totalRows = Convert.ToInt32(countCommand.ExecuteScalar());
                    TotalPages = (int)Math.Ceiling((double)totalRows / PageSize);
                }

                int skip = (page - 1) * PageSize; // Calculate skip for pagination
                string query = $@"SELECT SubscriptionID, UserID, PlanID, StartDate, EndDate, Status, PlanName, NextBillingDate,Name,Email
                                  FROM dbo.Subscription 
                                  ORDER BY StartDate DESC 
                                  OFFSET {skip} ROWS FETCH NEXT {PageSize} ROWS ONLY";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Subscriptions = new List<Subscription>();

                        while (reader.Read())
                        {
                            Subscription subscription = new Subscription
                            {
                                SubscriptionID = reader.GetString(0),
                                UserID = reader.GetInt32(1),
                                PlanID = reader.GetString(2),
                                StartDate = reader.GetDateTime(3),
                                EndDate = reader.GetDateTime(4),
                                Status = reader.GetString(5),
                                PlanName = reader.GetString(6),
                                NextBillingDate = reader.GetDateTime(7),
                                Name = reader.IsDBNull(8) ? null : reader.GetString(8),
                                Email = reader.IsDBNull(9) ? null : reader.GetString(9)
                            }; 

                            Subscriptions.Add(subscription);
                        }
                    }
                }
            }

            CurrentPage = page; // Set the current page for the pagination links
        }
    }
}
