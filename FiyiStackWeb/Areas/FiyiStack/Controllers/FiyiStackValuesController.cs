using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FiyiStackWeb.Areas.BasicCore.Models;
using FiyiStackWeb.Areas.CMSCore.Models;
using FiyiStackWeb.Library;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using FiyiStackWeb.Areas.FiyiStack.Interfaces;
using FiyiStackWeb.Areas.FiyiStack.Filters;

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. Add your custom code after the last line of auto generation
 */

//Last modification on: 09/12/2022 19:23:03

namespace FiyiStackWeb.Areas.CMSCore.Controllers
{
    /// <summary>
    /// Stack:             6<br/>
    /// Name:              C# Web API Controller. <br/>
    /// Function:          Allow you to intercept HTPP calls and comunicate with his C# Service using dependency injection.<br/>
    /// Last modification: 09/12/2022 19:23:03
    /// </summary>
    [ApiController]
    [FiyiStackFilter]
    public partial class FiyiStackValuesController : ControllerBase
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IFiyiStack _IFiyiStack;

        public FiyiStackValuesController(IWebHostEnvironment WebHostEnvironment, IFiyiStack IFiyiStack) 
        {
            _WebHostEnvironment = WebHostEnvironment;
            _IFiyiStack = IFiyiStack;
        }

        #region Non-Queries
        [HttpPost("~/api/FiyiStack/1/ContactMe")]
        [Produces("text/plain")]
        public IActionResult ContactMe()
        {
            try
            {
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) { SyncIO.AllowSynchronousIO = true; }

                string Name = HttpContext.Request.Form["name"];
                string Surname = HttpContext.Request.Form["surname"];
                string Email = HttpContext.Request.Form["email"];
                string Message = HttpContext.Request.Form["textarea-message"];

                string ReplyMessage = _IFiyiStack.ContactMe(Name, Surname, Email, Message);

                return StatusCode(200, ReplyMessage);
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
                return StatusCode(500, ex);
            }
        }
        #endregion
    }
}