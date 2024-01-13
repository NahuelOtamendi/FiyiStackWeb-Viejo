using ClosedXML.Excel;
using CsvHelper;
using IronPdf;
using Microsoft.AspNetCore.Http;
using FiyiStackWeb.Areas.CMSCore.Models;
using FiyiStackWeb.Areas.CMSCore.DTOs;
using FiyiStackWeb.Areas.CMSCore.Interfaces;
using FiyiStackWeb.Areas.FiyiStack.Models;
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

//Last modification on: 21/02/2023 18:02:07

namespace FiyiStackWeb.Areas.CMSCore.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 21/02/2023 18:02:07
    /// </summary>
    public partial class UserService : IUser
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public UserService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public UserModel Select1ByUserIdToModel(int UserId)
        {
            return new UserModel().Select1ByUserIdToModel(UserId);
        }

        public List<UserModel> SelectAllToList()
        {
            return new UserModel().SelectAllToList();
        }

        public userSelectAllPaged SelectAllPagedToModel(userSelectAllPaged userSelectAllPaged)
        {
            return new UserModel().SelectAllPagedToModel(userSelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(UserModel UserModel)
        {
            return new UserModel().Insert(UserModel);
        }

        public int UpdateByUserId(UserModel UserModel)
        {
            return new UserModel().UpdateByUserId(UserModel);
        }

        public int DeleteByUserId(int UserId)
        {
            return new UserModel().DeleteByUserId(UserId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                UserModel UserModel = new UserModel();
                UserModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    UserModel UserModel = new UserModel().Select1ByUserIdToModel(Convert.ToInt32(RowsChecked[i]));
                    UserModel.DeleteByUserId(UserModel.UserId);
                }
            }
        }

        public int CopyByUserId(int UserId)
        {
            UserModel UserModel = new UserModel().Select1ByUserIdToModel(UserId);
            int NewEnteredId = new UserModel().Insert(UserModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<UserModel> lstUserModel = new List<UserModel> { };
                lstUserModel = new UserModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstUserModel.Count];

                for (int i = 0; i < lstUserModel.Count; i++)
                {
                    NewEnteredIds[i] = lstUserModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    UserModel UserModel = new UserModel().Select1ByUserIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = UserModel.Insert();
                }

                return NewEnteredIds;
            }
        }

        public UserModel Login(string UserNameOrEmail, string Password)
        {
            Password = Security.EncodeString(Password);
            UserModel UserModel = new UserModel().Login(UserNameOrEmail, Password);

            return UserModel;
        }

        public string ChangePassword(int UserId, string ActualPassword, string NewPassword)
        {
            NewPassword = Security.EncodeString(NewPassword);
            ActualPassword = Security.EncodeString(ActualPassword);

            UserModel UserModel = new UserModel(UserId);

            if (UserModel.Password == ActualPassword)
            {
                UserModel.ChangePassword(UserId, NewPassword);
                return "Password changed";
            }
            else
            {
                return "The actual password is wrong";
            }
        }

        public string Register(string FantasyName, string Email, string Password)
        {
            Password = Security.EncodeString(Password);

            UserModel UserModel = new UserModel();

            //Verify that email is not in database
            UserModel = UserModel.Select1ByEmail(Email);
            if (UserModel.UserId == 0)
            {
                string RegistrationToken = Guid.NewGuid().ToString();

                //Save user
                UserModel.FantasyName = FantasyName;
                UserModel.Email = Email;
                UserModel.Password = Password;
                UserModel.RoleId = 2; //Client role
                UserModel.RegistrationToken = RegistrationToken;
                UserModel.Active = false;
                UserModel.DateTimeCreation = DateTime.Now;
                UserModel.DateTimeLastModification = DateTime.Now;
                UserModel.Insert();

                //Save in database fiyistac_FiyiStackApp
                //UserFromFiyiStackApp UserFromFiyiStackApp = new UserFromFiyiStackApp();
                //RoleId = 2 Client, AccountTypeId = 1 FREE TRIAL, 20 generations left
                //UserFromFiyiStackApp.Insert(FantasyName,FantasyName,Email,Password,2,1,20);

                #region Send registration email
                string EmailContent = $@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd"">
<html>
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
<title>Mailto</title>
<link href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700"" rel=""stylesheet"">
<style type=""text/css"">
html {{ -webkit-text-size-adjust: none; -ms-text-size-adjust: none;}}

	@media only screen and (min-device-width: 750px) {{
		.table750 {{width: 750px !important;}}
	}}
	@media only screen and (max-device-width: 750px), only screen and (max-width: 750px){{
      table[class=""table750""] {{width: 100% !important;}}
      .mob_b {{width: 93% !important; max-width: 93% !important; min-width: 93% !important;}}
      .mob_b1 {{width: 100% !important; max-width: 100% !important; min-width: 100% !important;}}
      .mob_left {{text-align: left !important;}}
      .mob_center {{text-align: center !important;}}
      .mob_soc {{width: 50% !important; max-width: 50% !important; min-width: 50% !important;}}
      .mob_menu {{width: 50% !important; max-width: 50% !important; min-width: 50% !important; box-shadow: inset -1px -1px 0 0 rgba(255, 255, 255, 0.2); }}
      .mob_btn {{width: 100% !important; max-width: 100% !important; min-width: 100% !important;}}
      .mob_pad {{width: 15px !important; max-width: 15px !important; min-width: 15px !important;}}
      .top_pad {{height: 15px !important; max-height: 15px !important; min-height: 15px !important;}}
      .top_pad2 {{height: 50px !important; max-height: 50px !important; min-height: 50px !important;}}
      .mob_title1 {{font-size: 36px !important; line-height: 40px !important;}}
      .mob_title2 {{font-size: 26px !important; line-height: 33px !important;}}
      .mob_txt {{font-size: 20px !important; line-height: 25px !important;}}
 	}}
   @media only screen and (max-device-width: 550px), only screen and (max-width: 550px){{
      .mod_div {{display: block !important;}}
   }}
	.table750 {{width: 750px;}}
</style>
</head>
<body style=""margin: 0; padding: 0;"">

<table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""background: #f5f8fa; min-width: 340px; font-size: 1px; line-height: normal;"">
 	<tr>
   	<td align=""center"" valign=""top"">   			
   		<!--[if (gte mso 9)|(IE)]>
         <table border=""0"" cellspacing=""0"" cellpadding=""0"">
         <tr><td align=""center"" valign=""top"" width=""750""><![endif]-->
   		<table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""750"" class=""table750"" style=""width: 100%; max-width: 750px; min-width: 340px; background: #f5f8fa;"">
   			<tr>
               <td class=""mob_pad"" width=""25"" style=""width: 25px; max-width: 25px; min-width: 25px;"">&nbsp;</td>
   				<td align=""center"" valign=""top"" style=""background: #ffffff;"">

                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""width: 100% !important; min-width: 100%; max-width: 100%; background: #f5f8fa;"">
                     <tr>
                        <td align=""right"" valign=""top"">
                           <div class=""top_pad"" style=""height: 25px; line-height: 25px; font-size: 23px;"">&nbsp;</div>
                        </td>
                     </tr>
                  </table>

                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%;"">
                     <tr>
                        <td class=""mob_left"" align=""center"" valign=""top"">
                           <font class=""mob_title1"" face=""'Source Sans Pro', sans-serif"" color=""#1a1a1a"" style=""font-size: 44px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"">
                              <span class=""mob_title1"" style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 44px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"">Please, finish registration</span>
                           </font>
                           <div style=""height: 25px; line-height: 25px; font-size: 23px;"">&nbsp;</div>
                           <font class=""mob_title2"" face=""'Source Sans Pro', sans-serif"" color=""#5e5e5e"" style=""font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">
                              <span class=""mob_title2"" style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #5e5e5e; font-size: 28px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">One more step away from entering FiyiStackWeb, what are you waiting for?</span>
                           </font>
                           <div style=""height: 38px; line-height: 38px; font-size: 36px;"">&nbsp;</div>
                           <table class=""mob_btn"" cellpadding=""0"" cellspacing=""0"" border=""0"" style=""background: #27cbcc; border-radius: 4px;"">
                              <tr>
                                 <td align=""center"" valign=""top""> 
                                    <a href=""https://fiyistack.com/CMSCore/RecordActivation?RegistrationToken={RegistrationToken}"" target=""_blank"" style=""display: block; border: 1px solid #27cbcc; border-radius: 4px; padding: 19px 26px; font-family: 'Source Sans Pro', Arial, Verdana, Tahoma, Geneva, sans-serif; color: #ffffff; font-size: 20px; line-height: 30px; text-decoration: none; white-space: nowrap; font-weight: 600;"">
                                       <font face=""'Source Sans Pro', sans-serif"" color=""#ffffff"" style=""font-size: 26px; line-height: 30px; text-decoration: none; white-space: nowrap; font-weight: 600;"">
                                          <span style=""font-family: 'Source Sans Pro', Arial, Verdana, Tahoma, Geneva, sans-serif; color: #ffffff; font-size: 26px; line-height: 30px; text-decoration: none; white-space: nowrap; font-weight: 600;"">Yes,&nbsp;register</span>
                                       </font>
                                    </a>
                                 </td>
                              </tr>
                           </table>
                           <div class=""top_pad2"" style=""height: 78px; line-height: 78px; font-size: 76px;"">&nbsp;</div>
                        </td>
                     </tr>
                  </table>

                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%; border-width: 1px; border-style: solid; border-color: #e8e8e8; border-bottom: none; border-left: none; border-right: none;"">
                     <tr>
                        <td class=""mob_left"" align=""center"" valign=""top"">
                           <div style=""height: 27px; line-height: 27px; font-size: 25px;"">&nbsp;</div>
                           <font face=""'Source Sans Pro', sans-serif"" color=""#8c8c8c"" style=""font-size: 17px; line-height: 23px;"">
                              <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #8c8c8c; font-size: 17px; line-height: 23px;"">If you received this email by mistake, simply delete it. You won't be registered if you don't click the confirmation link above.</span>
                           </font>
                           <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
                        </td>
                     </tr>
                  </table>
                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""width: 100% !important; min-width: 100%; max-width: 100%; background: #f5f8fa;"">
                     <tr>
                        <td align=""center"" valign=""top"">
                           <div style=""height: 34px; line-height: 34px; font-size: 32px;"">&nbsp;</div>
                           <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%;"">
                              <tr>
                                 <td align=""center"" valign=""top"">
                                    <div style=""height: 34px; line-height: 34px; font-size: 32px;"">&nbsp;</div>
                                    <font face=""'Source Sans Pro', sans-serif"" color=""#868686"" style=""font-size: 17px; line-height: 20px;"">
                                       <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #868686; font-size: 17px; line-height: 20px;"">Copyright &copy; {DateTime.Now.Year} FiyiStackWeb. All&nbsp;Rights&nbsp;Reserved. Thanks!</span>
                                    </font>
                                    <div style=""height: 3px; line-height: 3px; font-size: 1px;"">&nbsp;</div>
                                    <font face=""'Source Sans Pro', sans-serif"" color=""#1a1a1a"" style=""font-size: 17px; line-height: 20px;"">
                                        <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 17px; line-height: 20px;"">
                                            <a href=""mailto:help@fiyistack.com"" target=""_blank"" style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 17px; line-height: 20px; text-decoration: none;"">
                                                help@fiyistack.com
                                            </a>
                                            &nbsp;&nbsp;|&nbsp;&nbsp; 
                                            <a href=""tel:+543512329541"" target=""_blank"" style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 17px; line-height: 20px; text-decoration: none;"">
                                                (+54) 351-2329541
                                            </a>
                                    </font>
                                    <div style=""height: 35px; line-height: 35px; font-size: 33px;"">&nbsp;</div>
                                 </td>
                              </tr>
                           </table>
                        </td>
                     </tr>
                  </table>  

               </td>
               <td class=""mob_pad"" width=""25"" style=""width: 25px; max-width: 25px; min-width: 25px;"">&nbsp;</td>
            </tr>
         </table>
         <!--[if (gte mso 9)|(IE)]>
         </td></tr>
         </table><![endif]-->
      </td>
   </tr>
</table>
</body>
</html>";

                BasicCore.Models.ParameterModel ParameterModel = new BasicCore.Models.ParameterModel();
                string Address = ParameterModel.Select1ByName("Address");
                string fPassword = ParameterModel.Select1ByName("Password"); //Start with f because Password is a parameter of this function
                string Host = ParameterModel.Select1ByName("Host");


                MailMessage MailMessage = new MailMessage();
                SmtpClient SmtpClient = new SmtpClient();

                MailMessage.Subject = "Finish your registration";
                MailMessage.To.Add(Email);//Addresses to send mail to
                MailMessage.Body = EmailContent;
                MailMessage.BodyEncoding = Encoding.UTF8;
                MailMessage.IsBodyHtml = true;
                MailMessage.SubjectEncoding = Encoding.UTF8;
                MailMessage.From = new MailAddress(Address, "FiyiStackWeb");

                SmtpClient.Credentials = new NetworkCredential(Address, fPassword);
                SmtpClient.Host = Host;//Server from which the mail is sent
                SmtpClient.Send(MailMessage);//Send mail
                #endregion

                return "Successfully registered user";
            }
            else
            {
                return "The email is already registered";
            }
        }

        public string RecoverPassword(string Email)
        {
            UserModel UserModel = new UserModel();

            //Verify that email is not in database
            UserModel = UserModel.Select1ByEmail(Email);
            if (UserModel.UserId != 0)
            {
                string NewPassword = Guid.NewGuid().ToString();
                string FantasyName = UserModel.FantasyName;

                //Save user
                UserModel.Password = Security.EncodeString(NewPassword);
                UserModel.DateTimeLastModification = DateTime.Now;
                UserModel.UpdateByUserId();

                #region Send registration email
                string EmailContent = $@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd"">
<html>
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
<title>Recover password - FiyiStack</title>
<link href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700"" rel=""stylesheet"">
<style type=""text/css"">
html {{ -webkit-text-size-adjust: none; -ms-text-size-adjust: none;}}

	@media only screen and (min-device-width: 750px) {{
		.table750 {{width: 750px !important;}}
	}}
	@media only screen and (max-device-width: 750px), only screen and (max-width: 750px){{
      table[class=""table750""] {{width: 100% !important;}}
      .mob_b {{width: 93% !important; max-width: 93% !important; min-width: 93% !important;}}
      .mob_b1 {{width: 100% !important; max-width: 100% !important; min-width: 100% !important;}}
      .mob_left {{text-align: left !important;}}
      .mob_soc {{width: 50% !important; max-width: 50% !important; min-width: 50% !important;}}
      .mob_menu {{width: 50% !important; max-width: 50% !important; min-width: 50% !important; box-shadow: inset -1px -1px 0 0 rgba(255, 255, 255, 0.2); }}
      .mob_center {{text-align: center !important;}}
      .top_pad {{height: 15px !important; max-height: 15px !important; min-height: 15px !important;}}
      .mob_pad {{width: 15px !important; max-width: 15px !important; min-width: 15px !important;}}
      .mob_div {{display: block !important;}}
 	}}
   @media only screen and (max-device-width: 550px), only screen and (max-width: 550px){{
      .mod_div {{display: block !important;}}
   }}
	.table750 {{width: 750px;}}
</style>
</head>
<body style=""margin: 0; padding: 0;"">

<table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""background: #f3f3f3; min-width: 350px; font-size: 1px; line-height: normal;"">
 	<tr>
   	<td align=""center"" valign=""top"">   			
   		<!--[if (gte mso 9)|(IE)]>
         <table border=""0"" cellspacing=""0"" cellpadding=""0"">
         <tr><td align=""center"" valign=""top"" width=""750""><![endif]-->
   		<table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""750"" class=""table750"" style=""width: 100%; max-width: 750px; min-width: 350px; background: #f3f3f3;"">
   			<tr>
               <td class=""mob_pad"" width=""25"" style=""width: 25px; max-width: 25px; min-width: 25px;"">&nbsp;</td>
   				<td align=""center"" valign=""top"" style=""background: #ffffff;"">

                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""width: 100% !important; min-width: 100%; max-width: 100%; background: #f3f3f3;"">
                     <tr>
                        <td align=""right"" valign=""top"">
                           <div class=""top_pad"" style=""height: 25px; line-height: 25px; font-size: 23px;"">&nbsp;</div>
                        </td>
                     </tr>
                  </table>

                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%;"">
                     <tr>
                        <td align=""left"" valign=""top"">
                           <font face=""'Source Sans Pro', sans-serif"" color=""#1a1a1a"" style=""font-size: 52px; line-height: 60px; font-weight: 300; letter-spacing: -1.5px;"">
                              <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 52px; line-height: 60px; font-weight: 300; letter-spacing: -1.5px;"">Hey {FantasyName},</span>
                           </font>
                           <div style=""height: 33px; line-height: 33px; font-size: 31px;"">&nbsp;</div>
                           <font face=""'Source Sans Pro', sans-serif"" color=""#585858"" style=""font-size: 24px; line-height: 32px;"">
                              <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #585858; font-size: 24px; line-height: 32px;"">
                                It seems that you have forgotten the password, use this to recover your account: {NewPassword}. Then you can change it in the dashboard.
                              </span>
                           </font>
                           <div style=""height: 33px; line-height: 33px; font-size: 31px;"">&nbsp;</div>
                           <div style=""height: 75px; line-height: 75px; font-size: 73px;"">&nbsp;</div>
                        </td>
                     </tr>
                  </table>

                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""90%"" style=""width: 90% !important; min-width: 90%; max-width: 90%; border-width: 1px; border-style: solid; border-color: #e8e8e8; border-bottom: none; border-left: none; border-right: none;"">
                     <tr>
                        <td align=""left"" valign=""top"">
                           <div style=""height: 15px; line-height: 15px; font-size: 13px;"">&nbsp;</div>
                        </td>
                     </tr>
                  </table>

                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%;"">
                     <tr>
                        <td align=""center"" valign=""top"">
                           <!--[if (gte mso 9)|(IE)]>
                           <table border=""0"" cellspacing=""0"" cellpadding=""0"">
                           <tr><td align=""center"" valign=""top"" width=""50""><![endif]-->
                           <div style=""display: inline-block; vertical-align: top; width: 50px;"">
                           </div><!--[if (gte mso 9)|(IE)]></td><td align=""left"" valign=""top"" width=""390""><![endif]--><div class=""mob_div"" style=""display: inline-block; vertical-align: top; width: 62%; min-width: 260px;"">
                           </div><!--[if (gte mso 9)|(IE)]></td><td align=""left"" valign=""top"" width=""177""><![endif]--><div style=""display: inline-block; vertical-align: top; width: 177px;"">
                              <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""width: 100% !important; min-width: 100%; max-width: 100%;"">
                                 <tr>
                                    <td align=""center"" valign=""top"">
                                       <div style=""height: 13px; line-height: 13px; font-size: 11px;"">&nbsp;</div>
                                       <div style=""display: block; max-width: 177px;"">
                                          <img src=""img/txt.png"" alt=""img"" width=""177"" border=""0"" style=""display: block; width: 177px; max-width: 100%;"" />
                                       </div>
                                    </td>
                                 </tr>
                              </table>
                           </div>
                           <!--[if (gte mso 9)|(IE)]>
                           </td></tr>
                           </table><![endif]-->
                           <div style=""height: 30px; line-height: 30px; font-size: 28px;"">&nbsp;</div>
                        </td>
                     </tr>
                  </table>

                  <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""width: 100% !important; min-width: 100%; max-width: 100%; background: #f3f3f3;"">
                     <tr>
                        <td align=""center"" valign=""top"">
                           <div style=""height: 34px; line-height: 34px; font-size: 32px;"">&nbsp;</div>
                           <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%;"">
                              <tr>
                                 <td align=""center"" valign=""top"">
                                    <div style=""height: 34px; line-height: 34px; font-size: 32px;"">&nbsp;</div>
                                    <font face=""'Source Sans Pro', sans-serif"" color=""#868686"" style=""font-size: 17px; line-height: 20px;"">
                                       <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #868686; font-size: 17px; line-height: 20px;"">Copyright &copy; 2017 Mailto. All&nbsp;Rights&nbsp;Reserved. Thanks!</span>
                                    </font>
                                    <div style=""height: 3px; line-height: 3px; font-size: 1px;"">&nbsp;</div>
                                    <font face=""'Source Sans Pro', sans-serif"" color=""#1a1a1a"" style=""font-size: 17px; line-height: 20px;"">
                                       <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 17px; line-height: 20px;""><a href=""#"" target=""_blank"" style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 17px; line-height: 20px; text-decoration: none;"">help@mailto.com</a> &nbsp;&nbsp;|&nbsp;&nbsp; <a href=""#"" target=""_blank"" style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 17px; line-height: 20px; text-decoration: none;"">1(800)232-90-26</a></span>
                                    </font>
                                    <div style=""height: 35px; line-height: 35px; font-size: 33px;"">&nbsp;</div>
                                    <div style=""height: 35px; line-height: 35px; font-size: 33px;"">&nbsp;</div>
                                 </td>
                              </tr>
                           </table>
                        </td>
                     </tr>
                  </table>  

               </td>
               <td class=""mob_pad"" width=""25"" style=""width: 25px; max-width: 25px; min-width: 25px;"">&nbsp;</td>
            </tr>
         </table>
         <!--[if (gte mso 9)|(IE)]>
         </td></tr>
         </table><![endif]-->
      </td>
   </tr>
</table>
</body>
</html>";

                BasicCore.Models.ParameterModel ParameterModel = new BasicCore.Models.ParameterModel();
                string Address = ParameterModel.Select1ByName("Address");
                string Password = ParameterModel.Select1ByName("Password");
                string Host = ParameterModel.Select1ByName("Host");


                MailMessage MailMessage = new MailMessage();
                SmtpClient SmtpClient = new SmtpClient();

                MailMessage.Subject = "Recover password";
                MailMessage.To.Add(Email);//Addresses to send mail to
                MailMessage.Body = EmailContent;
                MailMessage.BodyEncoding = Encoding.UTF8;
                MailMessage.IsBodyHtml = true;
                MailMessage.SubjectEncoding = Encoding.UTF8;
                MailMessage.From = new MailAddress(Address, "FiyiStackWeb");

                SmtpClient.Credentials = new NetworkCredential(Address, Password);
                SmtpClient.Host = Host;//Server from which the mail is sent
                SmtpClient.Send(MailMessage);//Send mail
                #endregion

                return "Recovery email sent";
            }
            else
            {
                return "The email doesn't exist";
            }
        }
        #endregion

        #region Other services
        public DateTime ExportAsPDF(Ajax Ajax, string ExportationType)
        {
            var Renderer = new HtmlToPdf();
            DateTime Now = DateTime.Now;
            string RowsAsHTML = "";
            List<UserModel> lstUserModel = new List<UserModel> { };

            if (ExportationType == "All")
            {
                lstUserModel = new UserModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    UserModel UserModel = new UserModel().Select1ByUserIdToModel(Convert.ToInt32(RowChecked));
                    lstUserModel.Add(UserModel);
                }
            }

            foreach (UserModel row in lstUserModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of User</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">UserId&nbsp;&nbsp;&nbsp;</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">FantasyName&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Email&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Password&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">RoleId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">RegistrationToken&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/CMSCore/User/User_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtUser = new DataTable();
                dtUser.TableName = "User";

                //We define another DataTable dtUserCopy to avoid issue related to DateTime conversion
                DataTable dtUserCopy = new DataTable();
                dtUserCopy.TableName = "User";

                #region Define columns for dtUserCopy
                DataColumn dtColumnUserIdFordtUserCopy = new DataColumn();
                    dtColumnUserIdFordtUserCopy.DataType = typeof(string);
                    dtColumnUserIdFordtUserCopy.ColumnName = "UserId";
                    dtUserCopy.Columns.Add(dtColumnUserIdFordtUserCopy);

                    DataColumn dtColumnActiveFordtUserCopy = new DataColumn();
                    dtColumnActiveFordtUserCopy.DataType = typeof(string);
                    dtColumnActiveFordtUserCopy.ColumnName = "Active";
                    dtUserCopy.Columns.Add(dtColumnActiveFordtUserCopy);

                    DataColumn dtColumnDateTimeCreationFordtUserCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtUserCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtUserCopy.ColumnName = "DateTimeCreation";
                    dtUserCopy.Columns.Add(dtColumnDateTimeCreationFordtUserCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtUserCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtUserCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtUserCopy.ColumnName = "DateTimeLastModification";
                    dtUserCopy.Columns.Add(dtColumnDateTimeLastModificationFordtUserCopy);

                    DataColumn dtColumnUserCreationIdFordtUserCopy = new DataColumn();
                    dtColumnUserCreationIdFordtUserCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtUserCopy.ColumnName = "UserCreationId";
                    dtUserCopy.Columns.Add(dtColumnUserCreationIdFordtUserCopy);

                    DataColumn dtColumnUserLastModificationIdFordtUserCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtUserCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtUserCopy.ColumnName = "UserLastModificationId";
                    dtUserCopy.Columns.Add(dtColumnUserLastModificationIdFordtUserCopy);

                    DataColumn dtColumnFantasyNameFordtUserCopy = new DataColumn();
                    dtColumnFantasyNameFordtUserCopy.DataType = typeof(string);
                    dtColumnFantasyNameFordtUserCopy.ColumnName = "FantasyName";
                    dtUserCopy.Columns.Add(dtColumnFantasyNameFordtUserCopy);

                    DataColumn dtColumnEmailFordtUserCopy = new DataColumn();
                    dtColumnEmailFordtUserCopy.DataType = typeof(string);
                    dtColumnEmailFordtUserCopy.ColumnName = "Email";
                    dtUserCopy.Columns.Add(dtColumnEmailFordtUserCopy);

                    DataColumn dtColumnPasswordFordtUserCopy = new DataColumn();
                    dtColumnPasswordFordtUserCopy.DataType = typeof(string);
                    dtColumnPasswordFordtUserCopy.ColumnName = "Password";
                    dtUserCopy.Columns.Add(dtColumnPasswordFordtUserCopy);

                    DataColumn dtColumnRoleIdFordtUserCopy = new DataColumn();
                    dtColumnRoleIdFordtUserCopy.DataType = typeof(string);
                    dtColumnRoleIdFordtUserCopy.ColumnName = "RoleId";
                    dtUserCopy.Columns.Add(dtColumnRoleIdFordtUserCopy);

                    DataColumn dtColumnRegistrationTokenFordtUserCopy = new DataColumn();
                    dtColumnRegistrationTokenFordtUserCopy.DataType = typeof(string);
                    dtColumnRegistrationTokenFordtUserCopy.ColumnName = "RegistrationToken";
                    dtUserCopy.Columns.Add(dtColumnRegistrationTokenFordtUserCopy);

                    
                #endregion

                dtUser = new UserModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtUser.Rows)
                {
                    dtUserCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtUserCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/Usering/User/User_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsUser = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtUserCopy to avoid issue related to DateTime conversion
                    DataTable dtUserCopy = new DataTable();
                    dtUserCopy.TableName = "User";

                    #region Define columns for dtUserCopy
                    DataColumn dtColumnUserIdFordtUserCopy = new DataColumn();
                    dtColumnUserIdFordtUserCopy.DataType = typeof(string);
                    dtColumnUserIdFordtUserCopy.ColumnName = "UserId";
                    dtUserCopy.Columns.Add(dtColumnUserIdFordtUserCopy);

                    DataColumn dtColumnActiveFordtUserCopy = new DataColumn();
                    dtColumnActiveFordtUserCopy.DataType = typeof(string);
                    dtColumnActiveFordtUserCopy.ColumnName = "Active";
                    dtUserCopy.Columns.Add(dtColumnActiveFordtUserCopy);

                    DataColumn dtColumnDateTimeCreationFordtUserCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtUserCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtUserCopy.ColumnName = "DateTimeCreation";
                    dtUserCopy.Columns.Add(dtColumnDateTimeCreationFordtUserCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtUserCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtUserCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtUserCopy.ColumnName = "DateTimeLastModification";
                    dtUserCopy.Columns.Add(dtColumnDateTimeLastModificationFordtUserCopy);

                    DataColumn dtColumnUserCreationIdFordtUserCopy = new DataColumn();
                    dtColumnUserCreationIdFordtUserCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtUserCopy.ColumnName = "UserCreationId";
                    dtUserCopy.Columns.Add(dtColumnUserCreationIdFordtUserCopy);

                    DataColumn dtColumnUserLastModificationIdFordtUserCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtUserCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtUserCopy.ColumnName = "UserLastModificationId";
                    dtUserCopy.Columns.Add(dtColumnUserLastModificationIdFordtUserCopy);

                    DataColumn dtColumnFantasyNameFordtUserCopy = new DataColumn();
                    dtColumnFantasyNameFordtUserCopy.DataType = typeof(string);
                    dtColumnFantasyNameFordtUserCopy.ColumnName = "FantasyName";
                    dtUserCopy.Columns.Add(dtColumnFantasyNameFordtUserCopy);

                    DataColumn dtColumnEmailFordtUserCopy = new DataColumn();
                    dtColumnEmailFordtUserCopy.DataType = typeof(string);
                    dtColumnEmailFordtUserCopy.ColumnName = "Email";
                    dtUserCopy.Columns.Add(dtColumnEmailFordtUserCopy);

                    DataColumn dtColumnPasswordFordtUserCopy = new DataColumn();
                    dtColumnPasswordFordtUserCopy.DataType = typeof(string);
                    dtColumnPasswordFordtUserCopy.ColumnName = "Password";
                    dtUserCopy.Columns.Add(dtColumnPasswordFordtUserCopy);

                    DataColumn dtColumnRoleIdFordtUserCopy = new DataColumn();
                    dtColumnRoleIdFordtUserCopy.DataType = typeof(string);
                    dtColumnRoleIdFordtUserCopy.ColumnName = "RoleId";
                    dtUserCopy.Columns.Add(dtColumnRoleIdFordtUserCopy);

                    DataColumn dtColumnRegistrationTokenFordtUserCopy = new DataColumn();
                    dtColumnRegistrationTokenFordtUserCopy.DataType = typeof(string);
                    dtColumnRegistrationTokenFordtUserCopy.ColumnName = "RegistrationToken";
                    dtUserCopy.Columns.Add(dtColumnRegistrationTokenFordtUserCopy);

                    
                    #endregion

                    dsUser.Tables.Add(dtUserCopy);

                    for (int i = 0; i < dsUser.Tables.Count; i++)
                    {
                        dtUserCopy = new UserModel().Select1ByUserIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtUserCopy.Rows)
                        {
                            dsUser.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsUser.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsUser.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/Usering/User/User_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<UserModel> lstUserModel = new List<UserModel> { };

            if (ExportationType == "All")
            {
                lstUserModel = new UserModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    UserModel UserModel = new UserModel().Select1ByUserIdToModel(Convert.ToInt32(RowChecked));
                    lstUserModel.Add(UserModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/Usering/User/User_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstUserModel);
            }

            return Now;
        }
        #endregion
    }
}