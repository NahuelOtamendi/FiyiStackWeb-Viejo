using Microsoft.AspNetCore.Mvc;
using FiyiStackWeb.Areas.CMSCore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FiyiStackWeb.Areas.CMSCore.Pages
{
    public class PermissionsPageModel : PageModel
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
