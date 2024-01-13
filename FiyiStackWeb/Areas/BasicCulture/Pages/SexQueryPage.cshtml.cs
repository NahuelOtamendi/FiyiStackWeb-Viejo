using FiyiStackWeb.Areas.CMSCore.Models;
using FiyiStackWeb.Areas.BasicCulture.Models;
using FiyiStackWeb.Areas.BasicCulture.Filters;
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

//Last modification on: 14/02/2023 13:05:17

namespace FiyiStackWeb.Areas.BasicCulture.Pages
{
    /// <summary>
    /// Stack:             9 <br/>
    /// Name:              C# Razor Page. <br/>
    /// Function:          Allow you to show HTML files using Razor Page technology. <br/>
    /// Last modification: 14/02/2023 13:05:17
    /// </summary>
    [SexFilter]
    public partial class SexQueryPageModel : PageModel
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