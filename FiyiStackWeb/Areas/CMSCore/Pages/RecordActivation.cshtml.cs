using Microsoft.AspNetCore.Mvc;
using FiyiStackWeb.Areas.CMSCore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Microsoft.AspNetCore.Http;

namespace FiyiStackWeb.Areas.CMSCore.Pages
{
    public class RecordActivationModel : PageModel
    {
        public void OnGet()
        {
            //Get RegistrationToken from QueryString
            string RegistrationToken = HttpContext.Request.QueryString.Value.Replace("?RegistrationToken=", "");

            UserModel UserModel = new UserModel().Select1ByRegistrationTokenToModel(RegistrationToken);
            if (UserModel.UserId != 0)
            {
                //Update user
                UserModel.Active = true;
                UserModel.RegistrationToken = "";
                UserModel.UpdateByUserId();

                //Save UserId in Session
                HttpContext.Session.SetInt32("UserId", UserModel.UserId);

                ViewData["message"] = $@"<button class=""btn btn-success mb-4"" type=""button"">
                                            Registration completed
                                        </button>";

                ViewData["link-button"] = $@"<a href=""/CMSCore/DashboardIndex"" class=""btn btn-primary text-white my-4"">
                                                  <i class=""fas fa-file""></i> Go to Dashboard
                                               </a>";
            }
            else
            {
                ViewData["message"] = $@"<button class=""btn btn-danger mb-4"" type=""button"">
                                            Bad registration
                                        </button>";
            }
        }
    }
}
