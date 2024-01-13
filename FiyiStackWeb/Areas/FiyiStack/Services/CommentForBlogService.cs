using ClosedXML.Excel;
using CsvHelper;
using IronPdf;
using Microsoft.AspNetCore.Http;
using FiyiStackWeb.Areas.FiyiStack.Models;
using FiyiStackWeb.Areas.FiyiStack.DTOs;
using FiyiStackWeb.Areas.FiyiStack.Interfaces;
using FiyiStackWeb.Areas.CMSCore.Models;
using FiyiStackWeb.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;

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

//Last modification on: 22/02/2023 7:10:30

namespace FiyiStackWeb.Areas.FiyiStack.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 22/02/2023 7:10:30
    /// </summary>
    public partial class CommentForBlogService : ICommentForBlog
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public CommentForBlogService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public CommentForBlogModel Select1ByCommentForBlogIdToModel(int CommentForBlogId)
        {
            return new CommentForBlogModel().Select1ByCommentForBlogIdToModel(CommentForBlogId);
        }

        public List<CommentForBlogModel> SelectAllToList()
        {
            return new CommentForBlogModel().SelectAllToList();
        }

        public commentforblogSelectAllPaged SelectAllPagedToModel(commentforblogSelectAllPaged commentforblogSelectAllPaged)
        {
            return new CommentForBlogModel().SelectAllPagedToModel(commentforblogSelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(CommentForBlogModel CommentForBlogModel)
        {
            return new CommentForBlogModel().Insert(CommentForBlogModel);
        }

        public int UpdateByCommentForBlogId(CommentForBlogModel CommentForBlogModel)
        {
            return new CommentForBlogModel().UpdateByCommentForBlogId(CommentForBlogModel);
        }

        public int DeleteByCommentForBlogId(int CommentForBlogId)
        {
            return new CommentForBlogModel().DeleteByCommentForBlogId(CommentForBlogId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                CommentForBlogModel CommentForBlogModel = new CommentForBlogModel();
                CommentForBlogModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    CommentForBlogModel CommentForBlogModel = new CommentForBlogModel().Select1ByCommentForBlogIdToModel(Convert.ToInt32(RowsChecked[i]));
                    CommentForBlogModel.DeleteByCommentForBlogId(CommentForBlogModel.CommentForBlogId);
                }
            }
        }

        public int CopyByCommentForBlogId(int CommentForBlogId)
        {
            CommentForBlogModel CommentForBlogModel = new CommentForBlogModel().Select1ByCommentForBlogIdToModel(CommentForBlogId);
            int NewEnteredId = new CommentForBlogModel().Insert(CommentForBlogModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<CommentForBlogModel> lstCommentForBlogModel = new List<CommentForBlogModel> { };
                lstCommentForBlogModel = new CommentForBlogModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstCommentForBlogModel.Count];

                for (int i = 0; i < lstCommentForBlogModel.Count; i++)
                {
                    NewEnteredIds[i] = lstCommentForBlogModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    CommentForBlogModel CommentForBlogModel = new CommentForBlogModel().Select1ByCommentForBlogIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = CommentForBlogModel.Insert();
                }

                return NewEnteredIds;
            }
        }

        public string PostComment(int UserId, int BlogId, string Comment)
        {
            CommentForBlogModel CommentForBlogModel = new CommentForBlogModel()
            {
                UserCreationId = UserId,
                UserLastModificationId = UserId,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                Active = true,
                BlogId = BlogId,
                Comment = Comment
            };

            string NewEnteredId = CommentForBlogModel.Insert().ToString();

            UserModel UserModel = new UserModel(UserId);
            BlogModel BlogModel = new BlogModel(BlogId);

            #region Send email to me
            try
            {
//                string EmailContent = $@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd"">
//<html>
//<head>
//<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
//<title>Mailto</title>
//<link href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700"" rel=""stylesheet"">
//<style type=""text/css"">
//html {{ -webkit-text-size-adjust: none; -ms-text-size-adjust: none;}}

//	@media only screen and (min-device-width: 750px) {{
//		.table750 {{width: 750px !important;}}
//	}}
//	@media only screen and (max-device-width: 750px), only screen and (max-width: 750px){{
//      table[class=""table750""] {{width: 100% !important;}}
//      .mob_b {{width: 93% !important; max-width: 93% !important; min-width: 93% !important;}}
//      .mob_b1 {{width: 100% !important; max-width: 100% !important; min-width: 100% !important;}}
//      .mob_left {{text-align: left !important;}}
//      .mob_center {{text-align: center !important;}}
//      .mob_soc {{width: 50% !important; max-width: 50% !important; min-width: 50% !important;}}
//      .mob_menu {{width: 50% !important; max-width: 50% !important; min-width: 50% !important; box-shadow: inset -1px -1px 0 0 rgba(255, 255, 255, 0.2); }}
//      .mob_btn {{width: 100% !important; max-width: 100% !important; min-width: 100% !important;}}
//      .mob_pad {{width: 15px !important; max-width: 15px !important; min-width: 15px !important;}}
//      .top_pad {{height: 15px !important; max-height: 15px !important; min-height: 15px !important;}}
//      .top_pad2 {{height: 50px !important; max-height: 50px !important; min-height: 50px !important;}}
//      .mob_title1 {{font-size: 36px !important; line-height: 40px !important;}}
//      .mob_title2 {{font-size: 26px !important; line-height: 33px !important;}}
//      .mob_txt {{font-size: 20px !important; line-height: 25px !important;}}
// 	}}
//   @media only screen and (max-device-width: 550px), only screen and (max-width: 550px){{
//      .mod_div {{display: block !important;}}
//   }}
//	.table750 {{width: 750px;}}
//</style>
//</head>
//<body style=""margin: 0; padding: 0;"">

//<table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""background: #f5f8fa; min-width: 340px; font-size: 1px; line-height: normal;"">
// 	<tr>
//   	<td align=""center"" valign=""top"">   			
//   		<!--[if (gte mso 9)|(IE)]>
//         <table border=""0"" cellspacing=""0"" cellpadding=""0"">
//         <tr><td align=""center"" valign=""top"" width=""750""><![endif]-->
//   		<table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""750"" class=""table750"" style=""width: 100%; max-width: 750px; min-width: 340px; background: #f5f8fa;"">
//   			<tr>
//               <td class=""mob_pad"" width=""25"" style=""width: 25px; max-width: 25px; min-width: 25px;"">&nbsp;</td>
//   				<td align=""center"" valign=""top"" style=""background: #ffffff;"">

//                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""width: 100% !important; min-width: 100%; max-width: 100%; background: #f5f8fa;"">
//                     <tr>
//                        <td align=""right"" valign=""top"">
//                           <div class=""top_pad"" style=""height: 25px; line-height: 25px; font-size: 23px;"">&nbsp;</div>
//                        </td>
//                     </tr>
//                  </table>

//                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%;"">
//                     <tr>
//                        <td align=""left"" valign=""top"">
//                           <font class=""mob_title1"" face=""'Source Sans Pro', sans-serif"" color=""#1a1a1a"" style=""font-size: 52px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"">
//                              <span class=""mob_title1"" style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 52px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"">Tenes un nuevo comentario en el post {BlogModel.Title}</span>
//                           </font>
//                           <div style=""height: 22px; line-height: 22px; font-size: 20px;"">&nbsp;</div>
//                        </td>
//                     </tr>
//                  </table>

//                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%; background: #f7f7f7; border-top-left-radius: 8px; border-top-right-radius: 8px;"">
//                     <tr>
//                        <td width=""10"" style=""width: 10px; max-width: 10px; min-width: 10px;"">&nbsp;</td>
//                        <td align=""center"" valign=""top"">
//                           <div style=""height: 8px; line-height: 8px; font-size: 6px;"">&nbsp;</div>
//                           <!--[if (gte mso 9)|(IE)]>
//                           <table border=""0"" cellspacing=""0"" cellpadding=""0"">
//                           <tr><td align=""center"" valign=""top"" width=""65""><![endif]-->
//                           <!--[if (gte mso 9)|(IE)]></td><td align=""left"" valign=""top"" width=""515""><![endif]--><div style=""display: inline-block; vertical-align: top; width: 88%; min-width: 260px;"">
//                              <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""width: 100% !important; min-width: 100%; max-width: 100%;"">
//                                 <tr>
//                                    <td width=""6"" style=""width: 6px; max-width: 6px; min-width: 6px;"">&nbsp;</td>
//                                    <td class=""mob_center"" align=""left"" valign=""top"">
//                                       <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
//                                       <a href=""#"" target=""_blank"" style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 19px; line-height: 25px; font-weight: 600; text-decoration: none;"">
//                                          <font face=""'Source Sans Pro', sans-serif"" color=""#1a1a1a"" style=""font-size: 19px; line-height: 25px; font-weight: 600; text-decoration: none;"">
//                                             <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 19px; line-height: 25px; font-weight: 600; text-decoration: none;"">{UserModel.FantasyName} (Mail: {UserModel.Email})</span>
//                                          </font>
//                                       </a>
//                                       <div style=""height: 2px; line-height: 2px; font-size: 1px;"">&nbsp;</div>
//                                       <a href=""#"" target=""_blank"" style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #888888; font-size: 19px; line-height: 22px; text-decoration: none;"">   
//                                          <font face=""'Source Sans Pro', sans-serif"" color=""#888888"" style=""font-size: 19px; line-height: 22px; text-decoration: none;"">
//                                             <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #888888; font-size: 19px; line-height: 22px; text-decoration: none;"">{DateTime.Now.ToString("f")}</span>
//                                          </font>
//                                       </a>
//                                    </td>
//                                    <td width=""6"" style=""width: 6px; max-width: 6px; min-width: 6px;"">&nbsp;</td>
//                                 </tr>
//                              </table>
//                           </div>
//                           <!--[if (gte mso 9)|(IE)]>
//                           </td></tr>
//                           </table><![endif]-->
//                           <div style=""height: 18px; line-height: 18px; font-size: 16px;"">&nbsp;</div>
//                        </td>
//                        <td width=""10"" style=""width: 10px; max-width: 10px; min-width: 10px;"">&nbsp;</td>
//                     </tr>
//                  </table>

//                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%; border-width: 1px; border-style: solid; border-color: #e5e5e5; border-top: none;"">
//                     <tr>
//                        <td width=""5%"" style=""width: 5%; max-width: 5%; min-width: 5%;"">&nbsp;</td>
//                        <td align=""left"" valign=""top"">
//                           <div style=""height: 25px; line-height: 25px; font-size: 23px;"">&nbsp;</div>
//                           <font class=""mob_txt"" face=""'Source Sans Pro', sans-serif"" color=""#1a1a1a"" style=""font-size: 22px; line-height: 27px;"">
//                              <span class=""mob_txt"" style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 22px; line-height: 27px;"">{Comment}</span>
//                           </font>
//                           <div style=""height: 26px; line-height: 26px; font-size: 24px;"">&nbsp;</div>
//                        </td>
//                        <td width=""5%"" style=""width: 5%; max-width: 5%; min-width: 5%;"">&nbsp;</td>
//                     </tr>
//                  </table>
//               </td>
//               <td class=""mob_pad"" width=""25"" style=""width: 25px; max-width: 25px; min-width: 25px;"">&nbsp;</td>
//            </tr>
//         </table>
//         <!--[if (gte mso 9)|(IE)]>
//         </td></tr>
//         </table><![endif]-->
//      </td>
//   </tr>
//</table>
//</body>
//</html>";

//                BasicCore.Models.ParameterModel ParameterModel = new BasicCore.Models.ParameterModel();
//                string Address = ParameterModel.Select1ByName("Address");
//                string fPassword = ParameterModel.Select1ByName("Password"); //Start with f because Password is a parameter of this function
//                string Host = ParameterModel.Select1ByName("Host");


//                MailMessage MailMessage = new MailMessage();
//                SmtpClient SmtpClient = new SmtpClient();

//                MailMessage.Subject = $@"New comment from {UserModel.FantasyName}";
//                MailMessage.To.Add(new MailAddress("novillo.matias1@gmail.com"));//Addresses to send mail to
//                MailMessage.Body = EmailContent;
//                MailMessage.BodyEncoding = Encoding.UTF8;
//                MailMessage.IsBodyHtml = true;
//                MailMessage.SubjectEncoding = Encoding.UTF8;
//                MailMessage.From = new MailAddress(Address, "FiyiStack");

//                SmtpClient.Credentials = new NetworkCredential(Address, fPassword);
//                SmtpClient.Host = Host;//Server from which the mail is sent
//                SmtpClient.Send(MailMessage);//Send mail

                return "Message sent successfully";
            }
            catch (Exception ex) { throw ex; }
            #endregion
        }

        public void PostLike(int BlogId)
        {

            BlogModel BlogModel = new BlogModel(BlogId);

            BlogModel.NumberOfLikes += 1;

            BlogModel.UpdateByBlogId();
        }
        #endregion

        #region Other services
        public DateTime ExportAsPDF(Ajax Ajax, string ExportationType)
        {
            var Renderer = new HtmlToPdf();
            DateTime Now = DateTime.Now;
            string RowsAsHTML = "";
            List<CommentForBlogModel> lstCommentForBlogModel = new List<CommentForBlogModel> { };

            if (ExportationType == "All")
            {
                lstCommentForBlogModel = new CommentForBlogModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    CommentForBlogModel CommentForBlogModel = new CommentForBlogModel().Select1ByCommentForBlogIdToModel(Convert.ToInt32(RowChecked));
                    lstCommentForBlogModel.Add(CommentForBlogModel);
                }
            }

            foreach (CommentForBlogModel row in lstCommentForBlogModel)
            {
                RowsAsHTML += $@"{row.ToStringOnlyValuesForHTML()}";
            }

            Renderer.RenderHtmlAsPdf($@"<table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%;"">
    <tr>
    <td align=""left"" valign=""top"">
        <font face=""'Source Sans Pro', sans-serif"" color=""#1a1a1a"" style=""font-size: 52px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 52px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"">Mikromatica</span>
        </font>
        <div style=""height: 25px; line-height: 25px; font-size: 23px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#4c4c4c"" style=""font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of CommentForBlog</span>
        </font>
        <div style=""height: 35px; line-height: 35px; font-size: 33px;"">&nbsp;</div>
    </td>
    </tr>
</table>
<br>
<table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""width: 100% !important; min-width: 100%; max-width: 100%;"">
    <tr>
        <th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">CommentForBlogId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Active&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">DateTimeCreation&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">DateTimeLastModification&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">UserCreationId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">UserLastModificationId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Comment&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">BlogId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th>
    </tr>
    {RowsAsHTML}
</table>
<br>
<font face=""'Source Sans Pro', sans-serif"" color=""#868686"" style=""font-size: 17px; line-height: 20px;"">
    <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #868686; font-size: 17px; line-height: 20px;"">Printed on: {Now}</span>
</font>
").SaveAs($@"wwwroot/PDFFiles/FiyiStack/CommentForBlog/CommentForBlog_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtCommentForBlog = new DataTable();
                dtCommentForBlog.TableName = "CommentForBlog";

                //We define another DataTable dtCommentForBlogCopy to avoid issue related to DateTime conversion
                DataTable dtCommentForBlogCopy = new DataTable();
                dtCommentForBlogCopy.TableName = "CommentForBlog";

                #region Define columns for dtCommentForBlogCopy
                DataColumn dtColumnCommentForBlogIdFordtCommentForBlogCopy = new DataColumn();
                    dtColumnCommentForBlogIdFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnCommentForBlogIdFordtCommentForBlogCopy.ColumnName = "CommentForBlogId";
                    dtCommentForBlogCopy.Columns.Add(dtColumnCommentForBlogIdFordtCommentForBlogCopy);

                    DataColumn dtColumnActiveFordtCommentForBlogCopy = new DataColumn();
                    dtColumnActiveFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnActiveFordtCommentForBlogCopy.ColumnName = "Active";
                    dtCommentForBlogCopy.Columns.Add(dtColumnActiveFordtCommentForBlogCopy);

                    DataColumn dtColumnDateTimeCreationFordtCommentForBlogCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtCommentForBlogCopy.ColumnName = "DateTimeCreation";
                    dtCommentForBlogCopy.Columns.Add(dtColumnDateTimeCreationFordtCommentForBlogCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtCommentForBlogCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtCommentForBlogCopy.ColumnName = "DateTimeLastModification";
                    dtCommentForBlogCopy.Columns.Add(dtColumnDateTimeLastModificationFordtCommentForBlogCopy);

                    DataColumn dtColumnUserCreationIdFordtCommentForBlogCopy = new DataColumn();
                    dtColumnUserCreationIdFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtCommentForBlogCopy.ColumnName = "UserCreationId";
                    dtCommentForBlogCopy.Columns.Add(dtColumnUserCreationIdFordtCommentForBlogCopy);

                    DataColumn dtColumnUserLastModificationIdFordtCommentForBlogCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtCommentForBlogCopy.ColumnName = "UserLastModificationId";
                    dtCommentForBlogCopy.Columns.Add(dtColumnUserLastModificationIdFordtCommentForBlogCopy);

                    DataColumn dtColumnCommentFordtCommentForBlogCopy = new DataColumn();
                    dtColumnCommentFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnCommentFordtCommentForBlogCopy.ColumnName = "Comment";
                    dtCommentForBlogCopy.Columns.Add(dtColumnCommentFordtCommentForBlogCopy);

                    DataColumn dtColumnBlogIdFordtCommentForBlogCopy = new DataColumn();
                    dtColumnBlogIdFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnBlogIdFordtCommentForBlogCopy.ColumnName = "BlogId";
                    dtCommentForBlogCopy.Columns.Add(dtColumnBlogIdFordtCommentForBlogCopy);

                    
                #endregion

                dtCommentForBlog = new CommentForBlogModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtCommentForBlog.Rows)
                {
                    dtCommentForBlogCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtCommentForBlogCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/CommentForBloging/CommentForBlog/CommentForBlog_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsCommentForBlog = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtCommentForBlogCopy to avoid issue related to DateTime conversion
                    DataTable dtCommentForBlogCopy = new DataTable();
                    dtCommentForBlogCopy.TableName = "CommentForBlog";

                    #region Define columns for dtCommentForBlogCopy
                    DataColumn dtColumnCommentForBlogIdFordtCommentForBlogCopy = new DataColumn();
                    dtColumnCommentForBlogIdFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnCommentForBlogIdFordtCommentForBlogCopy.ColumnName = "CommentForBlogId";
                    dtCommentForBlogCopy.Columns.Add(dtColumnCommentForBlogIdFordtCommentForBlogCopy);

                    DataColumn dtColumnActiveFordtCommentForBlogCopy = new DataColumn();
                    dtColumnActiveFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnActiveFordtCommentForBlogCopy.ColumnName = "Active";
                    dtCommentForBlogCopy.Columns.Add(dtColumnActiveFordtCommentForBlogCopy);

                    DataColumn dtColumnDateTimeCreationFordtCommentForBlogCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtCommentForBlogCopy.ColumnName = "DateTimeCreation";
                    dtCommentForBlogCopy.Columns.Add(dtColumnDateTimeCreationFordtCommentForBlogCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtCommentForBlogCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtCommentForBlogCopy.ColumnName = "DateTimeLastModification";
                    dtCommentForBlogCopy.Columns.Add(dtColumnDateTimeLastModificationFordtCommentForBlogCopy);

                    DataColumn dtColumnUserCreationIdFordtCommentForBlogCopy = new DataColumn();
                    dtColumnUserCreationIdFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtCommentForBlogCopy.ColumnName = "UserCreationId";
                    dtCommentForBlogCopy.Columns.Add(dtColumnUserCreationIdFordtCommentForBlogCopy);

                    DataColumn dtColumnUserLastModificationIdFordtCommentForBlogCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtCommentForBlogCopy.ColumnName = "UserLastModificationId";
                    dtCommentForBlogCopy.Columns.Add(dtColumnUserLastModificationIdFordtCommentForBlogCopy);

                    DataColumn dtColumnCommentFordtCommentForBlogCopy = new DataColumn();
                    dtColumnCommentFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnCommentFordtCommentForBlogCopy.ColumnName = "Comment";
                    dtCommentForBlogCopy.Columns.Add(dtColumnCommentFordtCommentForBlogCopy);

                    DataColumn dtColumnBlogIdFordtCommentForBlogCopy = new DataColumn();
                    dtColumnBlogIdFordtCommentForBlogCopy.DataType = typeof(string);
                    dtColumnBlogIdFordtCommentForBlogCopy.ColumnName = "BlogId";
                    dtCommentForBlogCopy.Columns.Add(dtColumnBlogIdFordtCommentForBlogCopy);

                    
                    #endregion

                    dsCommentForBlog.Tables.Add(dtCommentForBlogCopy);

                    for (int i = 0; i < dsCommentForBlog.Tables.Count; i++)
                    {
                        dtCommentForBlogCopy = new CommentForBlogModel().Select1ByCommentForBlogIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtCommentForBlogCopy.Rows)
                        {
                            dsCommentForBlog.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsCommentForBlog.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsCommentForBlog.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/CommentForBloging/CommentForBlog/CommentForBlog_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<CommentForBlogModel> lstCommentForBlogModel = new List<CommentForBlogModel> { };

            if (ExportationType == "All")
            {
                lstCommentForBlogModel = new CommentForBlogModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    CommentForBlogModel CommentForBlogModel = new CommentForBlogModel().Select1ByCommentForBlogIdToModel(Convert.ToInt32(RowChecked));
                    lstCommentForBlogModel.Add(CommentForBlogModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/CommentForBloging/CommentForBlog/CommentForBlog_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstCommentForBlogModel);
            }

            return Now;
        }
        #endregion
    }
}