using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FiyiStackWeb.Areas.BasicCore.Models;
using FiyiStackWeb.Areas.CMSCore.DTOs;
using FiyiStackWeb.Areas.CMSCore.Filters;
using FiyiStackWeb.Areas.CMSCore.Interfaces;
using FiyiStackWeb.Areas.CMSCore.Models;
using FiyiStackWeb.Library;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using FiyiStackWeb.Areas.FiyiStack.Models;

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

//Last modification on: 21/02/2023 18:02:07

namespace FiyiStackWeb.Areas.CMSCore.Controllers
{
    /// <summary>
    /// Stack:             6<br/>
    /// Name:              C# Web API Controller. <br/>
    /// Function:          Allow you to intercept HTPP calls and comunicate with his C# Service using dependency injection.<br/>
    /// Last modification: 21/02/2023 18:02:07
    /// </summary>
    [ApiController]
    [UserFilter]
    public partial class UserValuesController : ControllerBase
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IUser _IUser;
        
        public UserValuesController(IWebHostEnvironment WebHostEnvironment, IConfiguration configuration, IUser IUser) 
        {
            _WebHostEnvironment = WebHostEnvironment;
            _configuration = configuration;
            _IUser = IUser;
        }

        #region Queries
        [HttpGet("~/api/CMSCore/User/1/Select1ByUserIdToJSON/{UserId:int}")]
        public UserModel Select1ByUserIdToJSON(int UserId)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                return _IUser.Select1ByUserIdToModel(UserId);
            }
            catch (Exception ex) 
            { 
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return null;
            }
        }

        [HttpGet("~/api/CMSCore/User/1/SelectAllToJSON")]
        public List<UserModel> SelectAllToJSON()
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                return _IUser.SelectAllToList();
            }
            catch (Exception ex) 
            { 
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return null;
            }
        }

        [HttpPost("~/api/CMSCore/User/1/SelectAllPagedToJSON")]
        public userSelectAllPaged SelectAllPagedToJSON([FromBody] userSelectAllPaged userSelectAllPaged)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                 return _IUser.SelectAllPagedToModel(userSelectAllPaged);
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return null;
            }
        }
        #endregion

        #region Non-Queries
        //[Produces("text/plain")] For production mode, uncomment this line
        [HttpPost("~/api/CMSCore/User/1/InsertOrUpdateAsync")]
        public async Task<IActionResult> InsertOrUpdateAsync()
        {
            try
            {
                //Get UserId from Session
                int UserIdSession = HttpContext.Session.GetInt32("UserId") ?? 0;

                if(UserIdSession == 0)
                {
                    return StatusCode(401, "User not found in session");
                }
                
                #region Pass data from client to server
                //UserId
                int UserId = Convert.ToInt32(HttpContext.Request.Form["cmscore-user-userid-input"]);
                
                string FantasyName = HttpContext.Request.Form["cmscore-user-fantasyname-input"];
                string Email = HttpContext.Request.Form["cmscore-user-email-input"];
                string Password = "";
                if (HttpContext.Request.Form["cmscore-user-password-input"] != "")
                {
                    Password = Security.EncodeString(HttpContext.Request.Form["cmscore-user-password-input"]); 
                }
                int RoleId = 0; 
                if (Convert.ToInt32(HttpContext.Request.Form["cmscore-user-roleid-input"]) != 0)
                {
                    RoleId = Convert.ToInt32(HttpContext.Request.Form["cmscore-user-roleid-input"]);
                }
                else
                { return StatusCode(400, "It's not allowed to save zero values in RoleId"); }
                string RegistrationToken = HttpContext.Request.Form["cmscore-user-registrationtoken-input"];
                
                #endregion

                int NewEnteredId = 0;
                int RowsAffected = 0;

                if (UserId == 0)
                {
                    //Insert
                    UserModel UserModel = new UserModel()
                    {
                        Active = true,
                        UserCreationId = UserIdSession,
                        UserLastModificationId = UserIdSession,
                        DateTimeCreation = DateTime.Now,
                        DateTimeLastModification = DateTime.Now,
                        FantasyName = FantasyName,
                        Email = Email,
                        Password = Password,
                        RoleId = RoleId,
                        RegistrationToken = RegistrationToken,
                        
                    };
                    
                    NewEnteredId = _IUser.Insert(UserModel);
                }
                else
                {
                    //Update
                    UserModel UserModel = new UserModel(UserId);
                    
                    UserModel.UserLastModificationId = UserId;
                    UserModel.DateTimeLastModification = DateTime.Now;
                    UserModel.FantasyName = FantasyName;
                    UserModel.Email = Email;
                    UserModel.Password = Password;
                    UserModel.RoleId = RoleId;
                    UserModel.RegistrationToken = RegistrationToken;
                                       

                    RowsAffected = _IUser.UpdateByUserId(UserModel);
                }
                

                //Look for sent files
                if (HttpContext.Request.Form.Files.Count != 0)
                {
                    int i = 0; //Used to iterate in HttpContext.Request.Form.Files
                    foreach (var File in Request.Form.Files)
                    {
                        if (File.Length > 0)
                        {
                            var FileName = HttpContext.Request.Form.Files[i].FileName;
                            var FilePath = $@"{_WebHostEnvironment.WebRootPath}/Uploads/CMSCore/User/";

                            using (var FileStream = new FileStream($@"{FilePath}{FileName}", FileMode.Create))
                            {
                                
                                await File.CopyToAsync(FileStream); // Read file to stream
                                byte[] array = new byte[FileStream.Length]; // Stream to byte array
                                FileStream.Seek(0, SeekOrigin.Begin);
                                FileStream.Read(array, 0, array.Length);
                            }

                            i += 1;
                        }
                    }
                }

                if (UserId == 0)
                {
                    return StatusCode(200, NewEnteredId); 
                }
                else
                {
                    return StatusCode(200, RowsAffected);
                }
            }
            catch (Exception ex) 
            { 
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }

        //[Produces("text/plain")] For production mode, uncomment this line
        [HttpDelete("~/api/CMSCore/User/1/DeleteByUserId/{UserId:int}")]
        public IActionResult DeleteByUserId(int UserId)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                int RowsAffected = _IUser.DeleteByUserId(UserId);
                return StatusCode(200, RowsAffected);
            }
            catch (Exception ex) 
            { 
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }

        //[Produces("text/plain")] For production mode, uncomment this line
        [HttpPost("~/api/CMSCore/User/1/DeleteManyOrAll/{DeleteType}")]
        public IActionResult DeleteManyOrAll([FromBody] Ajax Ajax, string DeleteType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                _IUser.DeleteManyOrAll(Ajax, DeleteType);

                return StatusCode(200, Ajax.AjaxForString);
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }

        //[Produces("text/plain")] For production mode, uncomment this line
        [HttpPost("~/api/CMSCore/User/1/CopyByUserId/{UserId:int}")]
        public IActionResult CopyByUserId(int UserId)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                int NewEnteredId = _IUser.CopyByUserId(UserId);

                return StatusCode(200, NewEnteredId);
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }

        //[Produces("text/plain")] For production mode, uncomment this line
        [HttpPost("~/api/CMSCore/User/1/CopyManyOrAll/{CopyType}")]
        public IActionResult CopyManyOrAll([FromBody] Ajax Ajax, string CopyType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                int[] NewEnteredIds = _IUser.CopyManyOrAll(Ajax, CopyType);
                string NewEnteredIdsAsString = "";

                for (int i = 0; i < NewEnteredIds.Length; i++)
                {
                    NewEnteredIdsAsString += NewEnteredIds[i].ToString() + ",";
                }
                NewEnteredIdsAsString = NewEnteredIdsAsString.TrimEnd(',');

                return StatusCode(200, NewEnteredIdsAsString);
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("~/api/CMSCore/User/1/Login")]

        public IActionResult Login()
        {
            try
            {
                string FantasyNameOrEmail = HttpContext.Request.Form["fantasynameoremail"];
                string Password = HttpContext.Request.Form["password"];

                UserModel UserModel = _IUser.Login(FantasyNameOrEmail, Password);

                if (UserModel.UserId != 0)
                {
                    HttpContext.Session.SetInt32("UserId", UserModel.UserId);
                    return StatusCode(200, "/CMSCore/DashboardIndex");
                }
                else
                {
                    return StatusCode(200, "User not found");
                }
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = 1,
                    UserLastModificationId = 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("~/api/CMSCore/User/1/ChangePassword")]

        public IActionResult ChangePassword()
        {
            try
            {
                int UserId = HttpContext.Session.GetInt32("UserId") ?? 0;
                string ActualPassword = HttpContext.Request.Form["actual-password"];
                string NewPassword = HttpContext.Request.Form["new-password"];

                string Message = _IUser.ChangePassword(UserId, ActualPassword, NewPassword);

                return StatusCode(200, Message);
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = 1,
                    UserLastModificationId = 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("~/api/CMSCore/User/1/Register")]

        public async Task<IActionResult> Register()
        {
            try
            {
                string FantasyName = HttpContext.Request.Form["fantasy-name"];
                string Email = HttpContext.Request.Form["email"];
                string Password = HttpContext.Request.Form["password"];

                #region Google ReCaptcha validation
                string GoogleRecaptchaToken = HttpContext.Request.Form["google-recaptcha"];

                string SecretKey = _configuration.GetValue<string>("AppSettings:RecaptchaSecretKey");

                var Dictionary = new Dictionary<string, string>
                {
                    { "secret", SecretKey },
                    { "response", GoogleRecaptchaToken }
                };
                var PostContent = new FormUrlEncodedContent(Dictionary);
                HttpResponseMessage GoogleRecaptchaResponse = null;
                string StringContentResponse = "";

                // Call Google Recaptcha API and validate the token
                using (var HttpClient = new HttpClient())
                {
                    GoogleRecaptchaResponse = await HttpClient.PostAsync("https://www.google.com/recaptcha/api/siteverify", PostContent);
                    StringContentResponse = await GoogleRecaptchaResponse.Content.ReadAsStringAsync();
                }

                if (!GoogleRecaptchaResponse.IsSuccessStatusCode)
                {
                    return StatusCode(400, "Unable to verify Google ReCaptcha token - Error S03");
                }
                if (string.IsNullOrEmpty(StringContentResponse))
                {
                    return StatusCode(400, "Invalid Google ReCaptcha verification response - Error S04");
                }
                var googleReCaptchaResponse = JsonConvert.DeserializeObject<googleReCaptchaResponse>(StringContentResponse);

                if (!googleReCaptchaResponse.Success)
                {
                    var errors = string.Join(",", googleReCaptchaResponse.ErrorCodes);
                    return StatusCode(400, "Error during Google ReCaptcha verification - Error S05");
                }
                if (!googleReCaptchaResponse.Action.Equals("signup", StringComparison.OrdinalIgnoreCase))
                {
                    // This is important just to verify that the exact action has been performed from the UI
                    return StatusCode(400, "Error during Google ReCaptcha verification - Error S06");
                }
                // Captcha was success , let's check the score, in our case, for example, anything less than 0.5 is considered as a bot user which we would not allow ...
                // the passing score might be higher or lower according to the sensitivity of your action
                if (googleReCaptchaResponse.Score < 0.5)
                {
                    return StatusCode(400, "This is a potential bot. Signup request rejected - Error S07");
                } 
                #endregion

                string Message = _IUser.Register(FantasyName, Email, Password);

                return StatusCode(200, Message);
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = 1,
                    UserLastModificationId = 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("~/api/CMSCore/User/1/RecoverPassword")]

        public IActionResult RecoverPassword()
        {
            try
            {
                string Email = HttpContext.Request.Form["email"];

                string Message = _IUser.RecoverPassword(Email);

                return StatusCode(200, Message);
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = 1,
                    UserLastModificationId = 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("~/api/CMSCore/User/1/Logout")]

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return StatusCode(200, "/Index");
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = 1,
                    UserLastModificationId = 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }

        }
        #endregion

        #region Other actions
        //[Produces("text/plain")] For production mode, uncomment this line
        [HttpPost("~/api/CMSCore/User/1/ExportAsPDF/{ExportationType}")]
        public IActionResult ExportAsPDF([FromBody] Ajax Ajax, string ExportationType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                DateTime Now = _IUser.ExportAsPDF(Ajax, ExportationType);

                return StatusCode(200, new Ajax() { AjaxForString = Now.ToString("yyyy_MM_dd_HH_mm_ss_fff") });
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }

        //[Produces("text/plain")] For production mode, uncomment this line
        [HttpPost("~/api/CMSCore/User/1/ExportAsExcel/{ExportationType}")]
        public IActionResult ExportAsExcel([FromBody] Ajax Ajax, string ExportationType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                DateTime Now = _IUser.ExportAsExcel(Ajax, ExportationType);

                return StatusCode(200, new Ajax() { AjaxForString = Now.ToString("yyyy_MM_dd_HH_mm_ss_fff") });
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }

        //[Produces("text/plain")] For production mode, uncomment this line
        [HttpPost("~/api/CMSCore/User/1/ExportAsCSV/{ExportationType}")]
        public IActionResult ExportAsCSV([FromBody] Ajax Ajax, string ExportationType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                DateTime Now = _IUser.ExportAsCSV(Ajax, ExportationType);

                return StatusCode(200, new Ajax() { AjaxForString = Now.ToString("yyyy_MM_dd_HH_mm_ss_fff") });
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        //Payment endpoint
        [HttpPost("~/api/CMSCore/User/1/PaymentEndpoint/{Email}/{UserAccountTypeId:int}")]
        public IActionResult PaymentEndpoint(string Email, int UserAccountTypeId)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                //???

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? "",
                    Source = ex.Source ?? "",
                    Comment = "",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32("UserId") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                };
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }
        }
    }
}