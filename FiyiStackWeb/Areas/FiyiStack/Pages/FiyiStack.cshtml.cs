using FiyiStackWeb.Areas.BasicCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace FiyiStackWeb.Areas.FiyiStack.Products.Pages
{
    public class FiyiStackModel : PageModel
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

                //User not found
                ViewData["LoginButton"] = $@"<a href='/Login' class='btn btn-outline-white mt-1 ml-2'>
                                                    <i class='fas fa-user'></i> 
                                                    <span class='nav-link-inner--text'>
                                                        Login
                                                    </span>
                                                </a>";
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

            ViewData["og:title"] = $@"<meta property=""og:title"" content=""FiyiStack: El generador low-code C#"">";
            ViewData["og:description"] = $@"<meta property=""og:description"" content=""Aprenda a usar FiyiStack, diseñe un diagrama de base de datos y conviértalo en código listo para ejecutar"">";
            ViewData["description"] = $@"<meta name=""description"" content=""Aprenda a usar FiyiStack, diseñe un diagrama de base de datos y conviértalo en código listo para ejecutar"">";
            ViewData["robot"] = $@"<meta name=""robots"" content=""index"">";
            ViewData["title"] = $@"FiyiStack: El generador low-code C#";

            VisitorCounterModel VisitorCounterModel = new VisitorCounterModel()
            {
                Active = true,
                Page = "/FiyiStack",
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
