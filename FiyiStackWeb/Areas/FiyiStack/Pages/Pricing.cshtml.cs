using FiyiStackWeb.Areas.FiyiStack.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System;
using FiyiStackWeb.Areas.BasicCore.Models;

namespace FiyiStackWeb.Areas.FiyiStack
{
    [FiyiStackFilter]
    public class PricingModel : PageModel
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

            ViewData["og:title"] = $@"<meta property=""og:title"" content=""Precios - FiyiStack"">";
            ViewData["og:description"] = $@"<meta property=""og:description"" content=""Obtén FiyiStack. Elige tu mejor opción y obtén una fabrica de software"">";
            ViewData["description"] = $@"<meta name=""description"" content=""Obtén FiyiStack. Elige tu mejor opción y obtén una fabrica de software"">";
            ViewData["robot"] = $@"<meta name=""robots"" content=""index"">";
            ViewData["title"] = $@"Precios - FiyiStack";

            VisitorCounterModel VisitorCounterModel = new VisitorCounterModel()
            {
                Active = true,
                Page = "/Pricing",
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
