using FiyiStackWeb.Areas.BasicCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace FiyiStackWeb.Areas.FiyiStack.Products.Pages
{
    public class CanariasBlogModel : PageModel
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

            ViewData["og:title"] = $@"<meta property=""og:title"" content=""CanariasBlog: El código de ejemplo de FiyiStack. Disfruta compartiendo contenido, consigue seguidores y hazte un profesional de los posts."">";
            ViewData["og:description"] = $@"<meta property=""og:description"" content=""CanariasBlog es el código de ejemplo hecho con FiyiStack, el generador C# low-code."">";
            ViewData["description"] = $@"<meta name=""description"" content=""CanariasBlog es el código de ejemplo hecho con FiyiStack, el generador C# low-code."">";
            ViewData["robot"] = $@"<meta name=""robots"" content=""index"">";
            ViewData["title"] = $@"CanariasBlog: El código de ejemplo de FiyiStack. Disfruta compartiendo contenido, consigue seguidores y hazte un profesional de los posts.";

            VisitorCounterModel VisitorCounterModel = new VisitorCounterModel()
            {
                Active = true,
                Page = "/CanariasBlog",
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
