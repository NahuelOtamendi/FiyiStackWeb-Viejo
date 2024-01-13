using FiyiStackWeb.Areas.FiyiStack.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using FiyiStackWeb.Areas.BasicCore.Models;
using System;

namespace FiyiStackWeb.Areas.FiyiStack.Pages
{
    [FiyiStackFilter]
    public class ContactMeModel : PageModel
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
                                                        Entrar al tablero
                                                    </span>
                                                </a>
                                            </li>";
            }

            ViewData["og:title"] = $@"<meta property=""og:title"" content=""Contáctanos - FiyiStack"">";
            ViewData["og:description"] = $@"<meta property=""og:description"" content=""Contáctanos, te responderemos lo antes posible"">";
            ViewData["description"] = $@"<meta name=""description"" content=""Contáctanos, te responderemos lo antes posible"">";
            ViewData["robot"] = $@"<meta name=""robots"" content=""index"">";
            ViewData["title"] = $@"Contáctanos - FiyiStack";

            VisitorCounterModel VisitorCounterModel = new VisitorCounterModel()
            {
                Active = true,
                Page = "/ContactUs",
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
