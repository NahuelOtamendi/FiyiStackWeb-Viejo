using FiyiStackWeb.Areas.CMSCore.Models;
using FiyiStackWeb.Areas.FiyiStack.Models;
using FiyiStackWeb.Areas.FiyiStack.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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

//Last modification on: 24/03/2023 17:29:07

namespace FiyiStackWeb.Areas.FiyiStack.Pages
{
    /// <summary>
    /// Stack:             9 <br/>
    /// Name:              C# Razor Page. <br/>
    /// Function:          Allow you to show HTML files using Razor Page technology. <br/>
    /// Last modification: 24/03/2023 17:29:07
    /// </summary>
    [BlogFilter]
    public partial class BlogNonQueryPageModel : PageModel
    {
        public void OnGet()
        {
            int UserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            UserModel UserModel = new UserModel().Select1ByUserIdToModel(UserId);

            string Menues = new RoleMenuModel().SelectMenuesByRoleIdToStringForLayoutDashboard(UserModel.RoleId);

            ViewData["FantasyName"] = UserModel.FantasyName;
            ViewData["Menues"] = Menues;
        }
    }
}