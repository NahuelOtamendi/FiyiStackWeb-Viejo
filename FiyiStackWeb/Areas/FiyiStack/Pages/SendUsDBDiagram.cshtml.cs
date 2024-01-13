using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using FiyiStackWeb.Areas.BasicCore.Models;

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * 
 * Coded by fiyistack.com
 * Copyright © 2023
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

//Last modification on: 23/07/2023 22:31:08

namespace FiyiStackWeb.Areas.FiyiStack.Pages
{
    /// <summary>
    /// Stack:             9 <br/>
    /// Name:              C# Razor Page. <br/>
    /// Function:          Allow you to show HTML files using Razor Page technology. <br/>
    /// Last modification: 23/07/2023 22:31:08
    /// </summary>
    public partial class SendUsDBDiagramPageModel : PageModel
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

            ViewData["og:title"] = $@"<meta property=""og:title"" content=""Envíanos tu diagrama de BD - FiyiStack"">";
            ViewData["og:description"] = $@"<meta property=""og:description"" content=""Si necesitas ayuda con tu diagrama de base de datos, envíanosla y la convertiremos en un proyecto FiyiStack"">";
            ViewData["description"] = $@"<meta name=""description"" content=""Si necesitas ayuda con tu diagrama de base de datos, envíanosla y la convertiremos en un proyecto FiyiStack"">";
            ViewData["robot"] = $@"<meta name=""robots"" content=""index"">";
            ViewData["title"] = $@"Envíanos tu diagrama de BD - FiyiStack";

            VisitorCounterModel VisitorCounterModel = new VisitorCounterModel()
            {
                Active = true,
                Page = "/SendUsDBDiagram",
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