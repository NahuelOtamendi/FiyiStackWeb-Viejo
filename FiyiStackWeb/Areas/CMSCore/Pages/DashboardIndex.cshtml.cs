using FiyiStackWeb.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using FiyiStackWeb.Areas.CMSCore.Models;
using Microsoft.Data.SqlClient;
using System;

namespace FiyiStackWeb.Areas.CMSCore.Pages
{
    [DashboardFilter]
    public class DashboardIndexModel : PageModel
    {
        public void OnGet()
        {
            int UserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            UserModel UserModel = new UserModel().Select1ByUserIdToModel(UserId);

            int NumberOfUsers = UserModel.Count();

            string Menues = new RoleMenuModel().SelectMenuesByRoleIdToStringForLayoutDashboard(UserModel.RoleId);
            
            //string _ConnectionString = ConnectionStrings.ConnectionStrings.Production(); // Change it for Production

            //int totalSubscriber = 0;
            //try
            //{
            //     totalSubscriber = GetTotalSubscriptionCount(_ConnectionString);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}

            ViewData["FantasyName"] = UserModel.FantasyName;
            ViewData["Menues"] = Menues;
            ViewData["NumberOfUsers"] = NumberOfUsers;
            //ViewData["totalSubscriber"] = totalSubscriber;
        }
        static int GetTotalSubscriptionCount(string connectionString)
        {
            string countQuery = "SELECT COUNT(*) FROM dbo.Subscription";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(countQuery, connection))
                {
                    int totalCount = (int)command.ExecuteScalar();
                    return totalCount;
                }
            }
        }
    }
}
