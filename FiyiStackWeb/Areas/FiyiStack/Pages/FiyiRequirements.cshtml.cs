using FiyiStackWeb.Areas.BasicCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace FiyiStackWeb.Areas.FiyiStack.Products.Pages
{
    public class FiyiRequirementsModel : PageModel
    {
        public void OnGet()
        {
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

            ViewData["og:title"] = $@"<meta property=""og:title"" content=""FiyiRequirements: The example code of FiyiStack"">";
            ViewData["og:description"] = $@"<meta property=""og:description"" content=""FiyiRequirements is the example code made with the C# low-code generator FiyiStack"">";
            ViewData["description"] = $@"<meta name=""description"" content=""FiyiRequirements is the example code made with the C# low-code generator FiyiStack"">";
            ViewData["robot"] = $@"<meta name=""robots"" content=""index"">";
            ViewData["title"] = $@"FiyiRequirements: The example code of FiyiStack";

            VisitorCounterModel VisitorCounterModel = new VisitorCounterModel()
            {
                Active = true,
                Page = "/FiyiRequirements",
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
