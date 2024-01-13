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

//Last modification on: 21/02/2023 17:59:08

namespace FiyiStackWeb.Areas.CMSCore.Controllers
{
    /// <summary>
    /// Stack:             6<br/>
    /// Name:              C# Web API Controller. <br/>
    /// Function:          Allow you to intercept HTPP calls and comunicate with his C# Service using dependency injection.<br/>
    /// Last modification: 21/02/2023 17:59:08
    /// </summary>
    [ApiController]
    [RoleFilter]
    public partial class RoleValuesController : ControllerBase
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IRole _IRole;

        public RoleValuesController(IWebHostEnvironment WebHostEnvironment, IRole IRole) 
        {
            _WebHostEnvironment = WebHostEnvironment;
            _IRole = IRole;
        }

        #region Queries
        [HttpGet("~/api/CMSCore/Role/1/Select1ByRoleIdToJSON/{RoleId:int}")]
        public RoleModel Select1ByRoleIdToJSON(int RoleId)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                return _IRole.Select1ByRoleIdToModel(RoleId);
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

        [HttpGet("~/api/CMSCore/Role/1/SelectAllToJSON")]
        public List<RoleModel> SelectAllToJSON()
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                return _IRole.SelectAllToList();
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

        [HttpPost("~/api/CMSCore/Role/1/SelectAllPagedToJSON")]
        public roleSelectAllPaged SelectAllPagedToJSON([FromBody] roleSelectAllPaged roleSelectAllPaged)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                 return _IRole.SelectAllPagedToModel(roleSelectAllPaged);
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
        [HttpPost("~/api/CMSCore/Role/1/InsertOrUpdateAsync")]
        public async Task<IActionResult> InsertOrUpdateAsync()
        {
            try
            {
                //Get UserId from Session
                int UserId = HttpContext.Session.GetInt32("UserId") ?? 0;

                if(UserId == 0)
                {
                    return StatusCode(401, "User not found in session");
                }
                
                #region Pass data from client to server
                //RoleId
                int RoleId = Convert.ToInt32(HttpContext.Request.Form["cmscore-role-roleid-input"]);
                
                string Name = HttpContext.Request.Form["cmscore-role-name-input"];
                
                #endregion

                int NewEnteredId = 0;
                int RowsAffected = 0;

                if (RoleId == 0)
                {
                    //Insert
                    RoleModel RoleModel = new RoleModel()
                    {
                        Active = true,
                        UserCreationId = UserId,
                        UserLastModificationId = UserId,
                        DateTimeCreation = DateTime.Now,
                        DateTimeLastModification = DateTime.Now,
                        Name = Name,
                        
                    };
                    
                    NewEnteredId = _IRole.Insert(RoleModel);
                }
                else
                {
                    //Update
                    RoleModel RoleModel = new RoleModel(RoleId);
                    
                    RoleModel.UserLastModificationId = UserId;
                    RoleModel.DateTimeLastModification = DateTime.Now;
                    RoleModel.Name = Name;
                                       

                    RowsAffected = _IRole.UpdateByRoleId(RoleModel);
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
                            var FilePath = $@"{_WebHostEnvironment.WebRootPath}/Uploads/CMSCore/Role/";

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

                if (RoleId == 0)
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
        [HttpDelete("~/api/CMSCore/Role/1/DeleteByRoleId/{RoleId:int}")]
        public IActionResult DeleteByRoleId(int RoleId)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                int RowsAffected = _IRole.DeleteByRoleId(RoleId);
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
        [HttpPost("~/api/CMSCore/Role/1/DeleteManyOrAll/{DeleteType}")]
        public IActionResult DeleteManyOrAll([FromBody] Ajax Ajax, string DeleteType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                _IRole.DeleteManyOrAll(Ajax, DeleteType);

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
        [HttpPost("~/api/CMSCore/Role/1/CopyByRoleId/{RoleId:int}")]
        public IActionResult CopyByRoleId(int RoleId)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                int NewEnteredId = _IRole.CopyByRoleId(RoleId);

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
        [HttpPost("~/api/CMSCore/Role/1/CopyManyOrAll/{CopyType}")]
        public IActionResult CopyManyOrAll([FromBody] Ajax Ajax, string CopyType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                int[] NewEnteredIds = _IRole.CopyManyOrAll(Ajax, CopyType);
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
        #endregion

        #region Other actions
        //[Produces("text/plain")] For production mode, uncomment this line
        [HttpPost("~/api/CMSCore/Role/1/ExportAsPDF/{ExportationType}")]
        public IActionResult ExportAsPDF([FromBody] Ajax Ajax, string ExportationType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                DateTime Now = _IRole.ExportAsPDF(Ajax, ExportationType);

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
        [HttpPost("~/api/CMSCore/Role/1/ExportAsExcel/{ExportationType}")]
        public IActionResult ExportAsExcel([FromBody] Ajax Ajax, string ExportationType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                DateTime Now = _IRole.ExportAsExcel(Ajax, ExportationType);

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
        [HttpPost("~/api/CMSCore/Role/1/ExportAsCSV/{ExportationType}")]
        public IActionResult ExportAsCSV([FromBody] Ajax Ajax, string ExportationType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                DateTime Now = _IRole.ExportAsCSV(Ajax, ExportationType);

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
    }
}