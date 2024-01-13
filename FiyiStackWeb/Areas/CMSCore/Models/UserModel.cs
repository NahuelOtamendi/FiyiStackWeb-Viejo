using Dapper;
using FiyiStackWeb.Areas.CMSCore.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

namespace FiyiStackWeb.Areas.CMSCore.Models
{
    /// <summary>
    /// Stack:             3 <br/>
    /// Name:              C# Model with stored procedure calls saved on database. <br/>
    /// Function:          Allow you to manipulate information from database using stored procedures.
    ///                    Also, let you make other related actions with the model in question or
    ///                    make temporal copies with random data. <br/>
    /// Fields:            11 <br/> 
    /// Sub-models:      1 models <br/>
    /// Last modification: 21/02/2023 18:02:07
    /// </summary>
    [Serializable]
    public partial class UserModel
    {
        [NotMapped]
        private string _ConnectionString = ConnectionStrings.ConnectionStrings.Development();

        #region Fields
        [Library.ModelAttributeValidator.Key("UserId")]
        public int UserId { get; set; }

        ///<summary>
        /// For auditing purposes
        ///</summary>
        public bool Active { get; set; }

        ///<summary>
        /// For auditing purposes
        ///</summary>
        [Library.ModelAttributeValidator.DateTime("DateTimeCreation", false, "1753-01-01T00:00", "9998-12-30T23:59")]
        public DateTime DateTimeCreation { get; set; }

        ///<summary>
        /// For auditing purposes
        ///</summary>
        [Library.ModelAttributeValidator.DateTime("DateTimeLastModification", false, "1753-01-01T00:00", "9998-12-30T23:59")]
        public DateTime DateTimeLastModification { get; set; }

        ///<summary>
        /// For auditing purposes
        ///</summary>
        [Library.ModelAttributeValidator.Key("UserCreationId")]
        public int UserCreationId { get; set; }

        ///<summary>
        /// For auditing purposes
        ///</summary>
        [Library.ModelAttributeValidator.Key("UserLastModificationId")]
        public int UserLastModificationId { get; set; }

        [Library.ModelAttributeValidator.String("FantasyName", false, 1, 200, "")]
        public string FantasyName { get; set; }

        [Library.ModelAttributeValidator.String("Email", false, 1, 320, "")]
        public string Email { get; set; }

        [Library.ModelAttributeValidator.String("Password", false, 1, 8000, "")]
        public string Password { get; set; }

        [Library.ModelAttributeValidator.Key("RoleId")]
        public int RoleId { get; set; }

        [Library.ModelAttributeValidator.String("RegistrationToken", true, 1, 8000, "")]
        public string RegistrationToken { get; set; }

        public string UserCreationIdFantasyName { get; set; }

        public string UserLastModificationIdFantasyName { get; set; }

        public string RoleIdName { get; set; }
        #endregion

        #region Sub-lists

        #endregion

        #region Constructors
        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create fastly this model with field UserId = 0 <br/>
        /// Note 1:       Generally used to have fast access to functions of object. <br/>
        /// Note 2:       Need construction with [new] reserved word, as all constructors. <br/>
        /// Fields:       11 <br/> 
        /// Dependencies: 1 models depend on this model <br/>
        /// </summary>
        public UserModel()
        {
            try 
            {
                UserId = 0;

                //Initialize sub-lists
                
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with stored information in database using UserId <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       11 <br/> 
        /// Dependencies: 1 models depend on this model <br/>
        /// </summary>
        public UserModel(int UserId)
        {
            try
            {
                List<UserModel> lstUserModel = new List<UserModel>();

                //Initialize sub-lists
                
                DynamicParameters dp = new DynamicParameters();

                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    //In case of not finding anything, Dapper return a List<UserModel>
                    lstUserModel = (List<UserModel>)sqlConnection.Query<UserModel>("[dbo].[CMSCore.User.Select1ByUserId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstUserModel.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[CMSCore.User.Select1ByUserId] returned more than one register/row");
                }
        
                foreach (UserModel user in lstUserModel)
                {
                    this.UserId = user.UserId;
					this.Active = user.Active;
					this.DateTimeCreation = user.DateTimeCreation;
					this.DateTimeLastModification = user.DateTimeLastModification;
					this.UserCreationId = user.UserCreationId;
					this.UserLastModificationId = user.UserLastModificationId;
					this.FantasyName = user.FantasyName;
					this.Email = user.Email;
					this.Password = user.Password;
					this.RoleId = user.RoleId;
					this.RegistrationToken = user.RegistrationToken;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with filled parameters <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       11 <br/> 
        /// Dependencies: 1 models depend on this model <br/>
        /// </summary>
        public UserModel(int UserId, bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, string FantasyName, string Email, string Password, int RoleId, string RegistrationToken)
        {
            try
            {
                //Initialize sub-lists

                this.UserId = UserId;
				this.Active = Active;
				this.DateTimeCreation = DateTimeCreation;
				this.DateTimeLastModification = DateTimeLastModification;
				this.UserCreationId = UserCreationId;
				this.UserLastModificationId = UserLastModificationId;
				this.FantasyName = FantasyName;
				this.Email = Email;
				this.Password = Password;
				this.RoleId = RoleId;
				this.RegistrationToken = RegistrationToken;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model (copy) using the given model (original), user, passed by parameter. <br/>
        /// Note:         This constructor is generally used to execute functions using the copied fields <br/>
        /// Fields:       11 <br/> 
        /// Dependencies: 1 models depend on this model <br/>
        /// </summary>
        public UserModel(UserModel user)
        {
            try
            {
                //Initialize sub-lists

                UserId = user.UserId;
				Active = user.Active;
				DateTimeCreation = user.DateTimeCreation;
				DateTimeLastModification = user.DateTimeLastModification;
				UserCreationId = user.UserCreationId;
				UserLastModificationId = user.UserLastModificationId;
				FantasyName = user.FantasyName;
				Email = user.Email;
				Password = user.Password;
				RoleId = user.RoleId;
				RegistrationToken = user.RegistrationToken;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The number of rows inside User</returns>
        public int Count()
        {
            try
            {
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.Count]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                }

                int RowsCounter = Convert.ToInt32(DataTable.Rows[0][0].ToString());

                return RowsCounter;
            }
            catch (Exception ex) { throw ex; }
        }

        #region Queries to DataTable
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        public DataTable Select1ByUserIdToDataTable(int UserId)
        {
            try
            {
                DataTable DataTable = new DataTable();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.Select1ByUserId]", commandType: CommandType.StoredProcedure, param: dp);

                    DataTable.Load(dataReader);
                }

                if (DataTable.Rows.Count > 1)
                { throw new Exception("The stored procedure [dbo].[CMSCore.User.Select1ByUserId] returned more than one register/row"); }

                return DataTable;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SelectAllToDataTable()
        {
            try
            {
                DataTable DataTable = new DataTable();
                DynamicParameters dp = new DynamicParameters();
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.SelectAll]", commandType: CommandType.StoredProcedure, param: dp);

                    DataTable.Load(dataReader);
                }

                return DataTable;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Queries to Models
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        public UserModel Select1ByUserIdToModel(int UserId)
        {
            try
            {
                UserModel UserModel = new UserModel();
                List<UserModel> lstUserModel = new List<UserModel>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstUserModel = (List<UserModel>)sqlConnection.Query<UserModel>("[dbo].[CMSCore.User.Select1ByUserId]", dp, commandType: CommandType.StoredProcedure);
                }
        
                if (lstUserModel.Count > 1)
                { throw new Exception("The stored procedure [dbo].[CMSCore.User.Select1ByUserId] returned more than one register/row"); }

                foreach (UserModel user in lstUserModel)
                {
                    UserModel.UserId = user.UserId;
					UserModel.Active = user.Active;
					UserModel.DateTimeCreation = user.DateTimeCreation;
					UserModel.DateTimeLastModification = user.DateTimeLastModification;
					UserModel.UserCreationId = user.UserCreationId;
					UserModel.UserLastModificationId = user.UserLastModificationId;
					UserModel.FantasyName = user.FantasyName;
					UserModel.Email = user.Email;
					UserModel.Password = user.Password;
					UserModel.RoleId = user.RoleId;
					UserModel.RegistrationToken = user.RegistrationToken;
                }

                return UserModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<UserModel> SelectAllToList()
        {
            try
            {
                List<UserModel> lstUserModel = new List<UserModel>();
                DynamicParameters dp = new DynamicParameters();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstUserModel = (List<UserModel>)sqlConnection.Query<UserModel>("[dbo].[CMSCore.User.SelectAll]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstUserModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<UserModel> SelectAllByEmployeeRoleToList(int EmployeeRoleId)
        {
            try
            {
                List<UserModel> lstUserModel = new List<UserModel>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("EmployeeRoleId", EmployeeRoleId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstUserModel = (List<UserModel>)sqlConnection.Query<UserModel>("[dbo].[CMSCore.User.SelectAllByEmployeeRoleIdCustom]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstUserModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public userSelectAllPaged SelectAllPagedToModel(userSelectAllPaged userSelectAllPaged)
        {
            try
            {
                userSelectAllPaged.lstUserModel = new List<UserModel>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("QueryString", userSelectAllPaged.QueryString, DbType.String, ParameterDirection.Input);
                dp.Add("ActualPageNumber", userSelectAllPaged.ActualPageNumber, DbType.Int32, ParameterDirection.Input);
                dp.Add("RowsPerPage", userSelectAllPaged.RowsPerPage, DbType.Int32, ParameterDirection.Input);
                dp.Add("SorterColumn", userSelectAllPaged.SorterColumn, DbType.String, ParameterDirection.Input);
                dp.Add("SortToggler", userSelectAllPaged.SortToggler, DbType.Boolean, ParameterDirection.Input);
                dp.Add("TotalRows", userSelectAllPaged.TotalRows, DbType.Int32, ParameterDirection.Output);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    userSelectAllPaged.lstUserModel = (List<UserModel>)sqlConnection.Query<UserModel>("[dbo].[CMSCore.User.SelectAllPagedCustom]", dp, commandType: CommandType.StoredProcedure);
                    userSelectAllPaged.TotalRows = dp.Get<int>("TotalRows");
                }

                userSelectAllPaged.TotalPages = Library.Math.Divide(userSelectAllPaged.TotalRows, userSelectAllPaged.RowsPerPage, Library.Math.RoundType.RoundUp);

                return userSelectAllPaged;
            }
            catch (Exception ex) { throw ex; }
        }

        public UserModel Login(string FantasyNameOrEmail, string Password)
        {
            try
            {
                UserModel UserModel = new UserModel();
                List<UserModel> lstUserModel = new List<UserModel>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("FantasyNameOrEmail", FantasyNameOrEmail, DbType.String, ParameterDirection.Input);
                dp.Add("Password", Password, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstUserModel = (List<UserModel>)sqlConnection.Query<UserModel>("[dbo].[CMSCore.User.LoginCustom]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstUserModel.Count > 1)
                { throw new Exception("The stored procedure [dbo].[CMSCore.User.LoginCustom] returned more than one register/row"); }

                foreach (UserModel user in lstUserModel)
                {
                    UserModel.UserId = user.UserId;
                    UserModel.FantasyName = user.FantasyName;
                    UserModel.Email = user.Email;
                    UserModel.Password = user.Password;
                    UserModel.RoleId = user.RoleId;
                    UserModel.Active = user.Active;
                    UserModel.UserCreationId = user.UserCreationId;
                    UserModel.UserLastModificationId = user.UserLastModificationId;
                    UserModel.DateTimeCreation = user.DateTimeCreation;
                    UserModel.DateTimeLastModification = user.DateTimeLastModification;
                    UserModel.RegistrationToken = user.RegistrationToken;
                }

                return UserModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public UserModel Select1ByEmail(string Email)
        {
            try
            {
                UserModel UserModel = new UserModel();
                List<UserModel> lstUserModel = new List<UserModel>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("Email", Email, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstUserModel = (List<UserModel>)sqlConnection.Query<UserModel>("[dbo].[CMSCore.User.Select1ByEmailCustom]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstUserModel.Count > 1)
                { throw new Exception("The stored procedure [dbo].[CMSCore.User.Select1ByEmailCustom] returned more than one register/row"); }

                foreach (UserModel user in lstUserModel)
                {
                    UserModel.UserId = user.UserId;
                    UserModel.FantasyName = user.FantasyName;
                    UserModel.Email = user.Email;
                    UserModel.Password = user.Password;
                    UserModel.RoleId = user.RoleId;
                    UserModel.Active = user.Active;
                    UserModel.UserCreationId = user.UserCreationId;
                    UserModel.UserLastModificationId = user.UserLastModificationId;
                    UserModel.DateTimeCreation = user.DateTimeCreation;
                    UserModel.DateTimeLastModification = user.DateTimeLastModification;
                    UserModel.RegistrationToken = user.RegistrationToken;
                }

                return UserModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public UserModel Select1ByRegistrationTokenToModel(string RegistrationToken)
        {
            try
            {
                UserModel UserModel = new UserModel();
                List<UserModel> lstUserModel = new List<UserModel>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("RegistrationToken", RegistrationToken, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstUserModel = (List<UserModel>)sqlConnection.Query<UserModel>("[dbo].[CMSCore.User.Select1ByRegistrationTokenCustom]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstUserModel.Count > 1)
                { throw new Exception("The stored procedure [dbo].[CMSCore.User.Select1ByRegistrationTokenCustom] returned more than one register/row"); }

                foreach (UserModel user in lstUserModel)
                {
                    UserModel.UserId = user.UserId;
                    UserModel.FantasyName = user.FantasyName;
                    UserModel.Email = user.Email;
                    UserModel.Password = user.Password;
                    UserModel.RoleId = user.RoleId;
                    UserModel.Active = user.Active;
                    UserModel.UserCreationId = user.UserCreationId;
                    UserModel.UserLastModificationId = user.UserLastModificationId;
                    UserModel.DateTimeCreation = user.DateTimeCreation;
                    UserModel.DateTimeLastModification = user.DateTimeLastModification;
                    UserModel.RegistrationToken = user.RegistrationToken;
                }

                return UserModel;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <returns>NewEnteredId: The ID of the last registry inserted in User table</returns>
        public int Insert()
        {
            try
            {
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
                
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("FantasyName", FantasyName, DbType.String, ParameterDirection.Input);
				dp.Add("Email", Email, DbType.String, ParameterDirection.Input);
				dp.Add("Password", Password, DbType.String, ParameterDirection.Input);
				dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("RegistrationToken", RegistrationToken, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.Insert]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    NewEnteredId = dp.Get<int>("NewEnteredId");
                }
                                
                if (NewEnteredId == 0) { throw new Exception("NewEnteredId with no value"); }

                return NewEnteredId;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <returns>The ID of the last registry inserted in User table</returns>
        public int Insert(UserModel user)
        {
            try
            {
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("Active", user.Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", user.DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", user.DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", user.UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", user.UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("FantasyName", user.FantasyName, DbType.String, ParameterDirection.Input);
				dp.Add("Email", user.Email, DbType.String, ParameterDirection.Input);
				dp.Add("Password", user.Password, DbType.String, ParameterDirection.Input);
				dp.Add("RoleId", user.RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("RegistrationToken", user.RegistrationToken, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.Insert]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    NewEnteredId = dp.Get<int>("NewEnteredId");
                }
                                
                if (NewEnteredId == 0) { throw new Exception("NewEnteredId with no value"); }

                return NewEnteredId;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <returns>The ID of the last registry inserted in User table</returns>
        public int Insert(bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, string FantasyName, string Email, string Password, int RoleId, string RegistrationToken)
        {
            try
            {
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("FantasyName", FantasyName, DbType.String, ParameterDirection.Input);
				dp.Add("Email", Email, DbType.String, ParameterDirection.Input);
				dp.Add("Password", Password, DbType.String, ParameterDirection.Input);
				dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("RegistrationToken", RegistrationToken, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.Insert]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    NewEnteredId = dp.Get<int>("NewEnteredId");
                }
                                
                if (NewEnteredId == 0) { throw new Exception("NewEnteredId with no value"); }

                return NewEnteredId;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <returns>The number of rows updated in User table</returns>
        public int UpdateByUserId()
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("FantasyName", FantasyName, DbType.String, ParameterDirection.Input);
				dp.Add("Email", Email, DbType.String, ParameterDirection.Input);
				dp.Add("Password", Password, DbType.String, ParameterDirection.Input);
				dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("RegistrationToken", RegistrationToken, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.UpdateByUserId]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>("RowsAffected");
                }
                                
                if (RowsAffected == 0) { throw new Exception("RowsAffected with no value"); }

                return RowsAffected;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <returns>The number of rows updated in User table</returns>
        public int UpdateByUserId(UserModel user)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("UserId", user.UserId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", user.Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", user.DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", user.DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", user.UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", user.UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("FantasyName", user.FantasyName, DbType.String, ParameterDirection.Input);
				dp.Add("Email", user.Email, DbType.String, ParameterDirection.Input);
				dp.Add("Password", user.Password, DbType.String, ParameterDirection.Input);
				dp.Add("RoleId", user.RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("RegistrationToken", user.RegistrationToken, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.UpdateByUserId]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>("RowsAffected");
                }
                                
                if (RowsAffected == 0) { throw new Exception("RowsAffected with no value"); }

                return RowsAffected;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <returns>The number of rows updated in User table</returns>
        public int UpdateByUserId(int UserId, bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, string FantasyName, string Email, string Password, int RoleId, string RegistrationToken)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("FantasyName", FantasyName, DbType.String, ParameterDirection.Input);
				dp.Add("Email", Email, DbType.String, ParameterDirection.Input);
				dp.Add("Password", Password, DbType.String, ParameterDirection.Input);
				dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("RegistrationToken", RegistrationToken, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.UpdateByUserId]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>("RowsAffected");
                }
                                
                if (RowsAffected == 0) { throw new Exception("RowsAffected with no value"); }

                return RowsAffected;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        ///
        public void DeleteAll()
        {
            try
            {
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.DeleteAll]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <returns>The number of rows deleted in User table</returns>
        public int DeleteByUserId()
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);        
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.DeleteByUserId]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>("RowsAffected");
                }
                                
                if (RowsAffected == 0) { throw new Exception("RowsAffected with no value"); }

                return RowsAffected;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <returns>The number of rows affected in User table</returns>
        public int DeleteByUserId(int UserId)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);        
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.DeleteByUserId]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>("RowsAffected");
                }
                                
                if (RowsAffected == 0) { throw new Exception("RowsAffected with no value"); }

                return RowsAffected;
            }
            catch (Exception ex) { throw ex; }
        }

        public int ChangePassword(int UserId, string NewPassword)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
                dp.Add("NewPassword", NewPassword, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.User.ChangePasswordCustom]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>("RowsAffected");
                }

                if (RowsAffected == 0) { throw new Exception("RowsAffected with no value"); }

                return RowsAffected;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        /// <summary>
        /// Function: Take the model stored in the given byte array to return the model. <br/>
        /// Note 1:   Similar to a decryptor function. <br/>
        /// Note 2:   The model need the [Serializable] decorator in model definition. <br/>
        /// </summary>
        public UserModel ByteArrayToUserModel<T>(byte[] arrUserModel)
        {
            try
            {
                if (arrUserModel == null)
                { return new UserModel(); }
                BinaryFormatter BinaryFormatter = new BinaryFormatter();
                using MemoryStream MemoryStream = new MemoryStream(arrUserModel);
                object Object = BinaryFormatter.Deserialize(MemoryStream);
                return (UserModel)Object;
            }
            catch (Exception ex)
            { throw ex; }
        }
        
        /// <summary>
        /// Function: Show all information (fields) inside the model during depuration mode.
        /// </summary>
        public override string ToString()
        {
            return $"UserId: {UserId}, " +
				$"Active: {Active}, " +
				$"DateTimeCreation: {DateTimeCreation}, " +
				$"DateTimeLastModification: {DateTimeLastModification}, " +
				$"UserCreationId: {UserCreationId}, " +
				$"UserLastModificationId: {UserLastModificationId}, " +
				$"FantasyName: {FantasyName}, " +
				$"Email: {Email}, " +
				$"Password: {Password}, " +
				$"RoleId: {RoleId}, " +
				$"RegistrationToken: {RegistrationToken}";
        }

        public string ToStringOnlyValuesForHTML()
        {
            return $@"<tr>
                <td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{UserId}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{Active}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{DateTimeCreation}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{DateTimeLastModification}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{UserCreationId}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{UserLastModificationId}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{FantasyName}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{Email}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{Password}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{RoleId}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{RegistrationToken}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td>
                </tr>";
        }
    }
}