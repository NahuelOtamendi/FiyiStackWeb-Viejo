using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System;
using FiyiStackWeb.Areas.BasicCore.Models;

namespace FiyiStackWeb.Areas.FiyiStack.Pages
{
    public class LearnMoreModel : PageModel
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

            ViewData["og:title"] = $@"<meta property=""og:title"" content=""Aprenda más - FiyiStack"">";
            ViewData["og:description"] = $@"<meta property=""og:description"" content=""FiyiStack es un generador low-code que trabaja con C#, .NET Core 3.1, Microsoft SQL Server, Node.js, JavaScript, TypeScript y más"">";
            ViewData["description"] = $@"<meta name=""description"" content=""FiyiStack es un generador low-code que trabaja con C#, .NET Core 3.1, Microsoft SQL Server, Node.js, JavaScript, TypeScript y más"">";
            ViewData["robot"] = $@"<meta name=""robots"" content=""index"">";
            ViewData["title"] = $@"Aprenda más - FiyiStack";

            VisitorCounterModel VisitorCounterModel = new VisitorCounterModel()
            {
                Active = true,
                Page = "/LearnMore",
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
