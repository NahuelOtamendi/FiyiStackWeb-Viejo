using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FiyiStackWeb.Areas.BasicCore.Models;
using FiyiStackWeb.Areas.BasicCulture.DTOs;
using FiyiStackWeb.Areas.BasicCulture.Filters;
using FiyiStackWeb.Areas.BasicCulture.Interfaces;
using FiyiStackWeb.Areas.BasicCulture.Models;
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

//Last modification on: 21/02/2023 17:48:26

namespace FiyiStackWeb.Areas.BasicCulture.Controllers
{
    /// <summary>
    /// Stack:             6<br/>
    /// Name:              C# Web API Controller. <br/>
    /// Function:          Allow you to intercept HTPP calls and comunicate with his C# Service using dependency injection.<br/>
    /// Last modification: 21/02/2023 17:48:26
    /// </summary>
    [ApiController]
    [PlanetFilter]
    public partial class PlanetValuesController : ControllerBase
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IPlanet _IPlanet;

        public PlanetValuesController(IWebHostEnvironment WebHostEnvironment, IPlanet IPlanet) 
        {
            _WebHostEnvironment = WebHostEnvironment;
            _IPlanet = IPlanet;
        }

        #region Queries
        [HttpGet("~/api/BasicCulture/Planet/1/Select1ByPlanetIdToJSON/{PlanetId:int}")]
        public PlanetModel Select1ByPlanetIdToJSON(int PlanetId)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                return _IPlanet.Select1ByPlanetIdToModel(PlanetId);
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

        [HttpGet("~/api/BasicCulture/Planet/1/SelectAllToJSON")]
        public List<PlanetModel> SelectAllToJSON()
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                return _IPlanet.SelectAllToList();
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

        [HttpPost("~/api/BasicCulture/Planet/1/SelectAllPagedToJSON")]
        public planetSelectAllPaged SelectAllPagedToJSON([FromBody] planetSelectAllPaged planetSelectAllPaged)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                 return _IPlanet.SelectAllPagedToModel(planetSelectAllPaged);
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
        [HttpPost("~/api/BasicCulture/Planet/1/InsertOrUpdateAsync")]
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
                //PlanetId
                int PlanetId = Convert.ToInt32(HttpContext.Request.Form["basicculture-planet-planetid-input"]);
                
                string Name = HttpContext.Request.Form["basicculture-planet-name-input"];
                string Code = HttpContext.Request.Form["basicculture-planet-code-input"];
                
                #endregion

                int NewEnteredId = 0;
                int RowsAffected = 0;

                if (PlanetId == 0)
                {
                    //Insert
                    PlanetModel PlanetModel = new PlanetModel()
                    {
                        Active = true,
                        UserCreationId = UserId,
                        UserLastModificationId = UserId,
                        DateTimeCreation = DateTime.Now,
                        DateTimeLastModification = DateTime.Now,
                        Name = Name,
                        Code = Code,
                        
                    };
                    
                    NewEnteredId = _IPlanet.Insert(PlanetModel);
                }
                else
                {
                    //Update
                    PlanetModel PlanetModel = new PlanetModel(PlanetId);
                    
                    PlanetModel.UserLastModificationId = UserId;
                    PlanetModel.DateTimeLastModification = DateTime.Now;
                    PlanetModel.Name = Name;
                    PlanetModel.Code = Code;
                                       

                    RowsAffected = _IPlanet.UpdateByPlanetId(PlanetModel);
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
                            var FilePath = $@"{_WebHostEnvironment.WebRootPath}/Uploads/BasicCulture/Planet/";

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

                if (PlanetId == 0)
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
        [HttpDelete("~/api/BasicCulture/Planet/1/DeleteByPlanetId/{PlanetId:int}")]
        public IActionResult DeleteByPlanetId(int PlanetId)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                int RowsAffected = _IPlanet.DeleteByPlanetId(PlanetId);
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
        [HttpPost("~/api/BasicCulture/Planet/1/DeleteManyOrAll/{DeleteType}")]
        public IActionResult DeleteManyOrAll([FromBody] Ajax Ajax, string DeleteType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                _IPlanet.DeleteManyOrAll(Ajax, DeleteType);

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
        [HttpPost("~/api/BasicCulture/Planet/1/CopyByPlanetId/{PlanetId:int}")]
        public IActionResult CopyByPlanetId(int PlanetId)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                int NewEnteredId = _IPlanet.CopyByPlanetId(PlanetId);

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
        [HttpPost("~/api/BasicCulture/Planet/1/CopyManyOrAll/{CopyType}")]
        public IActionResult CopyManyOrAll([FromBody] Ajax Ajax, string CopyType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                int[] NewEnteredIds = _IPlanet.CopyManyOrAll(Ajax, CopyType);
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
        [HttpPost("~/api/BasicCulture/Planet/1/ExportAsPDF/{ExportationType}")]
        public IActionResult ExportAsPDF([FromBody] Ajax Ajax, string ExportationType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                DateTime Now = _IPlanet.ExportAsPDF(Ajax, ExportationType);

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
        [HttpPost("~/api/BasicCulture/Planet/1/ExportAsExcel/{ExportationType}")]
        public IActionResult ExportAsExcel([FromBody] Ajax Ajax, string ExportationType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                DateTime Now = _IPlanet.ExportAsExcel(Ajax, ExportationType);

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
        [HttpPost("~/api/BasicCulture/Planet/1/ExportAsCSV/{ExportationType}")]
        public IActionResult ExportAsCSV([FromBody] Ajax Ajax, string ExportationType)
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                DateTime Now = _IPlanet.ExportAsCSV(Ajax, ExportationType);

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