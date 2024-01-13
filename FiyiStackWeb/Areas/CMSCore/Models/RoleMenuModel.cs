using Dapper;
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
 * Copyright © 2022
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
    /// Fields:            8 <br/> 
    /// Dependencies:      0 models <br/>
    /// Last modification: 20/12/2022 20:28:32
    /// </summary>
    [Serializable]
    public partial class RoleMenuModel
    {
        [NotMapped]
        private string _ConnectionString = ConnectionStrings.ConnectionStrings.Development();

        #region Fields
        [Library.ModelAttributeValidator.Key("RoleMenuId")]
        public int RoleMenuId { get; set; }

        [Library.ModelAttributeValidator.Key("RoleId")]
        public int RoleId { get; set; }

        [Library.ModelAttributeValidator.Key("MenuId")]
        public int MenuId { get; set; }

        public bool Active { get; set; }

        [Library.ModelAttributeValidator.Int("UserCreationId", false, 1, 2147483647)]
        public int UserCreationId { get; set; }

        [Library.ModelAttributeValidator.Int("UserLastModificationId", false, 1, 2147483647)]
        public int UserLastModificationId { get; set; }

        [Library.ModelAttributeValidator.DateTime("DateTimeCreation", false, "01/01/1753 0:00:00.001", "30/12/9998 23:59:59.999")]
        public DateTime DateTimeCreation { get; set; }

        [Library.ModelAttributeValidator.DateTime("DateTimeLastModification", false, "01/01/1753 0:00:00.001", "30/12/9998 23:59:59.999")]
        public DateTime DateTimeLastModification { get; set; }

        public string UserCreationIdFantasyName { get; set; }

        public string UserLastModificationIdFantasyName { get; set; }
        #endregion

        #region Models that depend on this model

        #endregion

        #region Constructors
        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create fastly this model with field RoleMenuId = 0 <br/>
        /// Note 1:       Generally used to have fast access to functions of object. <br/>
        /// Note 2:       Need construction with [new] reserved word, as all constructors. <br/>
        /// Fields:       8 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public RoleMenuModel()
        {
            try { RoleMenuId = 0; }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with stored information in database using RoleMenuId <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       8 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public RoleMenuModel(int RoleMenuId)
        {
            try
            {
                List<RoleMenuModel> lstRoleMenuModel = new List<RoleMenuModel>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("RoleMenuId", RoleMenuId, DbType.Int32, ParameterDirection.Input);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    //In case of not finding anything, Dapper return a List<RoleMenuModel>
                    lstRoleMenuModel = (List<RoleMenuModel>)sqlConnection.Query<RoleMenuModel>("[dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstRoleMenuModel.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId] returned more than one register/row");
                }
        
                foreach (RoleMenuModel rolemenu in lstRoleMenuModel)
                {
                    this.RoleMenuId = rolemenu.RoleMenuId;
					this.RoleId = rolemenu.RoleId;
					this.MenuId = rolemenu.MenuId;
					this.Active = rolemenu.Active;
					this.UserCreationId = rolemenu.UserCreationId;
					this.UserLastModificationId = rolemenu.UserLastModificationId;
					this.DateTimeCreation = rolemenu.DateTimeCreation;
					this.DateTimeLastModification = rolemenu.DateTimeLastModification;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with filled parameters <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       8 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public RoleMenuModel(int RoleMenuId, int RoleId, int MenuId, bool Active, int UserCreationId, int UserLastModificationId, DateTime DateTimeCreation, DateTime DateTimeLastModification)
        {
            try
            {
                this.RoleMenuId = RoleMenuId;
				this.RoleId = RoleId;
				this.MenuId = MenuId;
				this.Active = Active;
				this.UserCreationId = UserCreationId;
				this.UserLastModificationId = UserLastModificationId;
				this.DateTimeCreation = DateTimeCreation;
				this.DateTimeLastModification = DateTimeLastModification;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model (copy) using the given model (original), rolemenu, passed by parameter. <br/>
        /// Note:         This constructor is generally used to execute functions using the copied fields <br/>
        /// Fields:       8 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public RoleMenuModel(RoleMenuModel rolemenu)
        {
            try
            {
                RoleMenuId = rolemenu.RoleMenuId;
				RoleId = rolemenu.RoleId;
				MenuId = rolemenu.MenuId;
				Active = rolemenu.Active;
				UserCreationId = rolemenu.UserCreationId;
				UserLastModificationId = rolemenu.UserLastModificationId;
				DateTimeCreation = rolemenu.DateTimeCreation;
				DateTimeLastModification = rolemenu.DateTimeLastModification;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The number of rows inside RoleMenu</returns>
        public int Count()
        {
            try
            {
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.Count]", commandType: CommandType.StoredProcedure, param: dp);
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
        public DataTable Select1ByRoleMenuIdToDataTable(int RoleMenuId)
        {
            try
            {
                DataTable DataTable = new DataTable();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("RoleMenuId", RoleMenuId, DbType.Int32, ParameterDirection.Input);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId]", commandType: CommandType.StoredProcedure, param: dp);

                    DataTable.Load(dataReader);
                }

                if (DataTable.Rows.Count > 1)
                { throw new Exception("The stored procedure [dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId] returned more than one register/row"); }

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
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.SelectAll]", commandType: CommandType.StoredProcedure, param: dp);

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
        public RoleMenuModel Select1ByRoleMenuIdToModel(int RoleMenuId)
        {
            try
            {
                RoleMenuModel RoleMenuModel = new RoleMenuModel();
                List<RoleMenuModel> lstRoleMenuModel = new List<RoleMenuModel>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("RoleMenuId", RoleMenuId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstRoleMenuModel = (List<RoleMenuModel>)sqlConnection.Query<RoleMenuModel>("[dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId]", dp, commandType: CommandType.StoredProcedure);
                }
        
                if (lstRoleMenuModel.Count > 1)
                { throw new Exception("The stored procedure [dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId] returned more than one register/row"); }

                foreach (RoleMenuModel rolemenu in lstRoleMenuModel)
                {
                    RoleMenuModel.RoleMenuId = rolemenu.RoleMenuId;
					RoleMenuModel.RoleId = rolemenu.RoleId;
					RoleMenuModel.MenuId = rolemenu.MenuId;
					RoleMenuModel.Active = rolemenu.Active;
					RoleMenuModel.UserCreationId = rolemenu.UserCreationId;
					RoleMenuModel.UserLastModificationId = rolemenu.UserLastModificationId;
					RoleMenuModel.DateTimeCreation = rolemenu.DateTimeCreation;
					RoleMenuModel.DateTimeLastModification = rolemenu.DateTimeLastModification;
                }

                return RoleMenuModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<RoleMenuModel> SelectAllToList()
        {
            try
            {
                List<RoleMenuModel> lstRoleMenuModel = new List<RoleMenuModel>();
                DynamicParameters dp = new DynamicParameters();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstRoleMenuModel = (List<RoleMenuModel>)sqlConnection.Query<RoleMenuModel>("[dbo].[CMSCore.RoleMenu.SelectAll]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstRoleMenuModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public rolemenuModelQuery SelectAllPagedToModel(rolemenuModelQuery rolemenuModelQuery)
        {
            try
            {
                rolemenuModelQuery.lstRoleMenuModel = new List<RoleMenuModel>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("QueryString", rolemenuModelQuery.QueryString, DbType.String, ParameterDirection.Input);
                dp.Add("ActualPageNumber", rolemenuModelQuery.ActualPageNumber, DbType.Int32, ParameterDirection.Input);
                dp.Add("RowsPerPage", rolemenuModelQuery.RowsPerPage, DbType.Int32, ParameterDirection.Input);
                dp.Add("SorterColumn", rolemenuModelQuery.SorterColumn, DbType.String, ParameterDirection.Input);
                dp.Add("SortToggler", rolemenuModelQuery.SortToggler, DbType.Boolean, ParameterDirection.Input);
                dp.Add("TotalRows", rolemenuModelQuery.TotalRows, DbType.Int32, ParameterDirection.Output);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    rolemenuModelQuery.lstRoleMenuModel = (List<RoleMenuModel>)sqlConnection.Query<RoleMenuModel>("[dbo].[CMSCore.RoleMenu.SelectAllPagedCustom]", dp, commandType: CommandType.StoredProcedure);
                    rolemenuModelQuery.TotalRows = dp.Get<int>("TotalRows");
                }

                rolemenuModelQuery.TotalPages = Library.Math.Divide(rolemenuModelQuery.TotalRows, rolemenuModelQuery.RowsPerPage, Library.Math.RoundType.RoundUp);

                return rolemenuModelQuery;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        public string SelectMenuesByRoleIdToStringForDashboardIndex(int RoleId)
        {
            try
            {
                List<RoleMenuModel> lstRoleMenuModel = new List<RoleMenuModel>();
                string Menues = "";
                DynamicParameters dp = new DynamicParameters();

                dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Menues", Menues, DbType.String, ParameterDirection.Output);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstRoleMenuModel = (List<RoleMenuModel>)sqlConnection.Query<RoleMenuModel>("[dbo].[CMSCore.RoleMenu.SelectMenuesByRoleIdForDashboardIndexCustom]", dp, commandType: CommandType.StoredProcedure);
                    Menues = dp.Get<string>("Menues");
                }

                return Menues;
            }
            catch (Exception ex) { throw ex; }
        }

        public string SelectMenuesByRoleIdToStringForLayoutDashboard(int RoleId)
        {
            try
            {
                List<RoleMenuModel> lstRoleMenuModel = new List<RoleMenuModel>();
                string Menues = "";
                DynamicParameters dp = new DynamicParameters();

                dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Menues", Menues, DbType.String, ParameterDirection.Output);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstRoleMenuModel = (List<RoleMenuModel>)sqlConnection.Query<RoleMenuModel>("[dbo].[CMSCore.RoleMenu.SelectMenuesByRoleIdForLayoutDashboardCustom]", dp, commandType: CommandType.StoredProcedure);
                    Menues = dp.Get<string>("Menues");
                }

                return Menues;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<roleMenuForChechboxes> SelectAllByRoleIdToRoleMenuForChechboxes(int RoleId)
        {
            try
            {
                List<roleMenuForChechboxes> lstRoleMenuForCheckboxes = new List<roleMenuForChechboxes>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstRoleMenuForCheckboxes = (List<roleMenuForChechboxes>)sqlConnection.Query<roleMenuForChechboxes>("[dbo].[CMSCore.RoleMenu.SelectAllByRoleIdCustom]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstRoleMenuForCheckboxes;
            }
            catch (Exception ex) { throw ex; }
        }

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <returns>NewEnteredId: The ID of the last registry inserted in RoleMenu table</returns>
        public int Insert()
        {
            try
            {
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
                
                dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The ID of the last registry inserted in RoleMenu table</returns>
        public int Insert(RoleMenuModel rolemenu)
        {
            try
            {
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("RoleId", rolemenu.RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("MenuId", rolemenu.MenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", rolemenu.Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("UserCreationId", rolemenu.UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", rolemenu.UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("DateTimeCreation", rolemenu.DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", rolemenu.DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The ID of the last registry inserted in RoleMenu table</returns>
        public int Insert(int RoleId, int MenuId, bool Active, int UserCreationId, int UserLastModificationId, DateTime DateTimeCreation, DateTime DateTimeLastModification)
        {
            try
            {
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in RoleMenu table</returns>
        public int UpdateByRoleMenuId()
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("RoleMenuId", RoleMenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.UpdateByRoleMenuId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in RoleMenu table</returns>
        public int UpdateByRoleMenuId(RoleMenuModel rolemenu)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("RoleMenuId", rolemenu.RoleMenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("RoleId", rolemenu.RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("MenuId", rolemenu.MenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", rolemenu.Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("UserCreationId", rolemenu.UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", rolemenu.UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("DateTimeCreation", rolemenu.DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", rolemenu.DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.UpdateByRoleMenuId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in RoleMenu table</returns>
        public int UpdateByRoleMenuId(int RoleMenuId, int RoleId, int MenuId, bool Active, int UserCreationId, int UserLastModificationId, DateTime DateTimeCreation, DateTime DateTimeLastModification)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("RoleMenuId", RoleMenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
				dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.UpdateByRoleMenuId]", commandType: CommandType.StoredProcedure, param: dp);
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
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.DeleteAll]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <returns>The number of rows deleted in RoleMenu table</returns>
        public int DeleteByRoleMenuId()
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add("RoleMenuId", RoleMenuId, DbType.Int32, ParameterDirection.Input);        
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.DeleteByRoleMenuId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows affected in RoleMenu table</returns>
        public int DeleteByRoleMenuId(int RoleMenuId)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add("RoleMenuId", RoleMenuId, DbType.Int32, ParameterDirection.Input);        
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.DeleteByRoleMenuId]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>("RowsAffected");
                }
                                
                if (RowsAffected == 0) { throw new Exception("RowsAffected with no value"); }

                return RowsAffected;
            }
            catch (Exception ex) { throw ex; }
        }

        public void UpdateByRoleIdByMenuId(int RoleId, int MenuId, bool Selected)
        {
            try
            {
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
                dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Selected", Selected, DbType.Boolean, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.RoleMenu.UpdateByRoleIdByMenuIdCustom]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        /// <summary>
        /// Function: Take the model stored in the given byte array to return the model. <br/>
        /// Note 1:   Similar to a decryptor function. <br/>
        /// Note 2:   The model need the [Serializable] decorator in model definition. <br/>
        /// </summary>
        public RoleMenuModel ByteArrayToRoleMenuModel<T>(byte[] arrRoleMenuModel)
        {
            try
            {
                if (arrRoleMenuModel == null)
                { return new RoleMenuModel(); }
                BinaryFormatter BinaryFormatter = new BinaryFormatter();
                using MemoryStream MemoryStream = new MemoryStream(arrRoleMenuModel);
                object Object = BinaryFormatter.Deserialize(MemoryStream);
                return (RoleMenuModel)Object;
            }
            catch (Exception ex)
            { throw ex; }
        }
        
        /// <summary>
        /// Function: Show all information (fields) inside the model during depuration mode.
        /// </summary>
        public override string ToString()
        {
            return $"RoleMenuId: {RoleMenuId}, " +
				$"RoleId: {RoleId}, " +
				$"MenuId: {MenuId}, " +
				$"Active: {Active}, " +
				$"UserCreationId: {UserCreationId}, " +
				$"UserLastModificationId: {UserLastModificationId}, " +
				$"DateTimeCreation: {DateTimeCreation}, " +
				$"DateTimeLastModification: {DateTimeLastModification}";
        }

        public string ToStringOnlyValuesForHTML()
        {
            return $@"<tr>
                <td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{RoleMenuId}</span>
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{MenuId}</span>
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{DateTimeCreation}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{DateTimeLastModification}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td>
                </tr>";
        }
    }

    /// <summary>
    /// Virtual model used for [dbo].[CMSCore.RoleMenu.SelectAllPaged] stored procedure
    /// </summary>
    public partial class rolemenuModelQuery 
    {
        public string QueryString { get; set; }
        public int ActualPageNumber { get; set; }
        public int RowsPerPage { get; set; }
        public string SorterColumn { get; set; }
        public bool SortToggler { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }
        public List<RoleMenuModel> lstRoleMenuModel { get; set; }
    }

    public partial class roleMenuForChechboxes
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
    }
}