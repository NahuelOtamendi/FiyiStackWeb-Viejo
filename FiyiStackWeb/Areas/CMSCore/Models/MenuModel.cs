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
    /// Sub-models:      0 models <br/>
    /// Last modification: 21/02/2023 17:56:41
    /// </summary>
    [Serializable]
    public partial class MenuModel
    {
        [NotMapped]
        private string _ConnectionString = ConnectionStrings.ConnectionStrings.Development();

        #region Fields
        [Library.ModelAttributeValidator.Key("MenuId")]
        public int MenuId { get; set; }

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

        [Library.ModelAttributeValidator.String("Name", false, 1, 200, "")]
        public string Name { get; set; }

        [Library.ModelAttributeValidator.Int("MenuFatherId", false, 0, 2147483647)]
        public int MenuFatherId { get; set; }

        [Library.ModelAttributeValidator.Int("Order", false, 0, 2147483647)]
        public int Order { get; set; }

        [Library.ModelAttributeValidator.String("URLPath", false, 1, 8000, "")]
        public string URLPath { get; set; }

        [Library.ModelAttributeValidator.String("IconURLPath", false, 1, 8000, "")]
        public string IconURLPath { get; set; }

        public string UserCreationIdFantasyName { get; set; }

        public string UserLastModificationIdFantasyName { get; set; }
        #endregion

        #region Sub-lists

        #endregion

        #region Constructors
        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create fastly this model with field MenuId = 0 <br/>
        /// Note 1:       Generally used to have fast access to functions of object. <br/>
        /// Note 2:       Need construction with [new] reserved word, as all constructors. <br/>
        /// Fields:       11 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public MenuModel()
        {
            try 
            {
                MenuId = 0;

                //Initialize sub-lists
                
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with stored information in database using MenuId <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       11 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public MenuModel(int MenuId)
        {
            try
            {
                List<MenuModel> lstMenuModel = new List<MenuModel>();

                //Initialize sub-lists
                
                
                DynamicParameters dp = new DynamicParameters();

                dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    //In case of not finding anything, Dapper return a List<MenuModel>
                    lstMenuModel = (List<MenuModel>)sqlConnection.Query<MenuModel>("[dbo].[CMSCore.Menu.Select1ByMenuId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstMenuModel.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[CMSCore.Menu.Select1ByMenuId] returned more than one register/row");
                }
        
                foreach (MenuModel menu in lstMenuModel)
                {
                    this.MenuId = menu.MenuId;
					this.Active = menu.Active;
					this.DateTimeCreation = menu.DateTimeCreation;
					this.DateTimeLastModification = menu.DateTimeLastModification;
					this.UserCreationId = menu.UserCreationId;
					this.UserLastModificationId = menu.UserLastModificationId;
					this.Name = menu.Name;
					this.MenuFatherId = menu.MenuFatherId;
					this.Order = menu.Order;
					this.URLPath = menu.URLPath;
					this.IconURLPath = menu.IconURLPath;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with filled parameters <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       11 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public MenuModel(int MenuId, bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, string Name, int MenuFatherId, int Order, string URLPath, string IconURLPath)
        {
            try
            {
                //Initialize sub-lists
                

                this.MenuId = MenuId;
				this.Active = Active;
				this.DateTimeCreation = DateTimeCreation;
				this.DateTimeLastModification = DateTimeLastModification;
				this.UserCreationId = UserCreationId;
				this.UserLastModificationId = UserLastModificationId;
				this.Name = Name;
				this.MenuFatherId = MenuFatherId;
				this.Order = Order;
				this.URLPath = URLPath;
				this.IconURLPath = IconURLPath;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model (copy) using the given model (original), menu, passed by parameter. <br/>
        /// Note:         This constructor is generally used to execute functions using the copied fields <br/>
        /// Fields:       11 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public MenuModel(MenuModel menu)
        {
            try
            {
                //Initialize sub-lists
                

                MenuId = menu.MenuId;
				Active = menu.Active;
				DateTimeCreation = menu.DateTimeCreation;
				DateTimeLastModification = menu.DateTimeLastModification;
				UserCreationId = menu.UserCreationId;
				UserLastModificationId = menu.UserLastModificationId;
				Name = menu.Name;
				MenuFatherId = menu.MenuFatherId;
				Order = menu.Order;
				URLPath = menu.URLPath;
				IconURLPath = menu.IconURLPath;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The number of rows inside Menu</returns>
        public int Count()
        {
            try
            {
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.Count]", commandType: CommandType.StoredProcedure, param: dp);
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
        public DataTable Select1ByMenuIdToDataTable(int MenuId)
        {
            try
            {
                DataTable DataTable = new DataTable();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.Select1ByMenuId]", commandType: CommandType.StoredProcedure, param: dp);

                    DataTable.Load(dataReader);
                }

                if (DataTable.Rows.Count > 1)
                { throw new Exception("The stored procedure [dbo].[CMSCore.Menu.Select1ByMenuId] returned more than one register/row"); }

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
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.SelectAll]", commandType: CommandType.StoredProcedure, param: dp);

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
        public MenuModel Select1ByMenuIdToModel(int MenuId)
        {
            try
            {
                MenuModel MenuModel = new MenuModel();
                List<MenuModel> lstMenuModel = new List<MenuModel>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstMenuModel = (List<MenuModel>)sqlConnection.Query<MenuModel>("[dbo].[CMSCore.Menu.Select1ByMenuId]", dp, commandType: CommandType.StoredProcedure);
                }
        
                if (lstMenuModel.Count > 1)
                { throw new Exception("The stored procedure [dbo].[CMSCore.Menu.Select1ByMenuId] returned more than one register/row"); }

                foreach (MenuModel menu in lstMenuModel)
                {
                    MenuModel.MenuId = menu.MenuId;
					MenuModel.Active = menu.Active;
					MenuModel.DateTimeCreation = menu.DateTimeCreation;
					MenuModel.DateTimeLastModification = menu.DateTimeLastModification;
					MenuModel.UserCreationId = menu.UserCreationId;
					MenuModel.UserLastModificationId = menu.UserLastModificationId;
					MenuModel.Name = menu.Name;
					MenuModel.MenuFatherId = menu.MenuFatherId;
					MenuModel.Order = menu.Order;
					MenuModel.URLPath = menu.URLPath;
					MenuModel.IconURLPath = menu.IconURLPath;
                }

                return MenuModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<MenuModel> SelectAllToList()
        {
            try
            {
                List<MenuModel> lstMenuModel = new List<MenuModel>();
                DynamicParameters dp = new DynamicParameters();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstMenuModel = (List<MenuModel>)sqlConnection.Query<MenuModel>("[dbo].[CMSCore.Menu.SelectAll]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstMenuModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public menuSelectAllPaged SelectAllPagedToModel(menuSelectAllPaged menuSelectAllPaged)
        {
            try
            {
                menuSelectAllPaged.lstMenuModel = new List<MenuModel>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("QueryString", menuSelectAllPaged.QueryString, DbType.String, ParameterDirection.Input);
                dp.Add("ActualPageNumber", menuSelectAllPaged.ActualPageNumber, DbType.Int32, ParameterDirection.Input);
                dp.Add("RowsPerPage", menuSelectAllPaged.RowsPerPage, DbType.Int32, ParameterDirection.Input);
                dp.Add("SorterColumn", menuSelectAllPaged.SorterColumn, DbType.String, ParameterDirection.Input);
                dp.Add("SortToggler", menuSelectAllPaged.SortToggler, DbType.Boolean, ParameterDirection.Input);
                dp.Add("TotalRows", menuSelectAllPaged.TotalRows, DbType.Int32, ParameterDirection.Output);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    menuSelectAllPaged.lstMenuModel = (List<MenuModel>)sqlConnection.Query<MenuModel>("[dbo].[CMSCore.Menu.SelectAllPagedCustom]", dp, commandType: CommandType.StoredProcedure);
                    menuSelectAllPaged.TotalRows = dp.Get<int>("TotalRows");
                }

                menuSelectAllPaged.TotalPages = Library.Math.Divide(menuSelectAllPaged.TotalRows, menuSelectAllPaged.RowsPerPage, Library.Math.RoundType.RoundUp);

                

                return menuSelectAllPaged;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <returns>NewEnteredId: The ID of the last registry inserted in Menu table</returns>
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
				dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
				dp.Add("MenuFatherId", MenuFatherId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Order", Order, DbType.Int32, ParameterDirection.Input);
				dp.Add("URLPath", URLPath, DbType.String, ParameterDirection.Input);
				dp.Add("IconURLPath", IconURLPath, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The ID of the last registry inserted in Menu table</returns>
        public int Insert(MenuModel menu)
        {
            try
            {
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("Active", menu.Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", menu.DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", menu.DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", menu.UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", menu.UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Name", menu.Name, DbType.String, ParameterDirection.Input);
				dp.Add("MenuFatherId", menu.MenuFatherId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Order", menu.Order, DbType.Int32, ParameterDirection.Input);
				dp.Add("URLPath", menu.URLPath, DbType.String, ParameterDirection.Input);
				dp.Add("IconURLPath", menu.IconURLPath, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The ID of the last registry inserted in Menu table</returns>
        public int Insert(bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, string Name, int MenuFatherId, int Order, string URLPath, string IconURLPath)
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
				dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
				dp.Add("MenuFatherId", MenuFatherId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Order", Order, DbType.Int32, ParameterDirection.Input);
				dp.Add("URLPath", URLPath, DbType.String, ParameterDirection.Input);
				dp.Add("IconURLPath", IconURLPath, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in Menu table</returns>
        public int UpdateByMenuId()
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
				dp.Add("MenuFatherId", MenuFatherId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Order", Order, DbType.Int32, ParameterDirection.Input);
				dp.Add("URLPath", URLPath, DbType.String, ParameterDirection.Input);
				dp.Add("IconURLPath", IconURLPath, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.UpdateByMenuId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in Menu table</returns>
        public int UpdateByMenuId(MenuModel menu)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("MenuId", menu.MenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", menu.Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", menu.DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", menu.DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", menu.UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", menu.UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Name", menu.Name, DbType.String, ParameterDirection.Input);
				dp.Add("MenuFatherId", menu.MenuFatherId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Order", menu.Order, DbType.Int32, ParameterDirection.Input);
				dp.Add("URLPath", menu.URLPath, DbType.String, ParameterDirection.Input);
				dp.Add("IconURLPath", menu.IconURLPath, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.UpdateByMenuId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in Menu table</returns>
        public int UpdateByMenuId(int MenuId, bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, string Name, int MenuFatherId, int Order, string URLPath, string IconURLPath)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
				dp.Add("MenuFatherId", MenuFatherId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Order", Order, DbType.Int32, ParameterDirection.Input);
				dp.Add("URLPath", URLPath, DbType.String, ParameterDirection.Input);
				dp.Add("IconURLPath", IconURLPath, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.UpdateByMenuId]", commandType: CommandType.StoredProcedure, param: dp);
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
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.DeleteAll]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <returns>The number of rows deleted in Menu table</returns>
        public int DeleteByMenuId()
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);        
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.DeleteByMenuId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows affected in Menu table</returns>
        public int DeleteByMenuId(int MenuId)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add("MenuId", MenuId, DbType.Int32, ParameterDirection.Input);        
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[CMSCore.Menu.DeleteByMenuId]", commandType: CommandType.StoredProcedure, param: dp);
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
        public MenuModel ByteArrayToMenuModel<T>(byte[] arrMenuModel)
        {
            try
            {
                if (arrMenuModel == null)
                { return new MenuModel(); }
                BinaryFormatter BinaryFormatter = new BinaryFormatter();
                using MemoryStream MemoryStream = new MemoryStream(arrMenuModel);
                object Object = BinaryFormatter.Deserialize(MemoryStream);
                return (MenuModel)Object;
            }
            catch (Exception ex)
            { throw ex; }
        }
        
        /// <summary>
        /// Function: Show all information (fields) inside the model during depuration mode.
        /// </summary>
        public override string ToString()
        {
            return $"MenuId: {MenuId}, " +
				$"Active: {Active}, " +
				$"DateTimeCreation: {DateTimeCreation}, " +
				$"DateTimeLastModification: {DateTimeLastModification}, " +
				$"UserCreationId: {UserCreationId}, " +
				$"UserLastModificationId: {UserLastModificationId}, " +
				$"Name: {Name}, " +
				$"MenuFatherId: {MenuFatherId}, " +
				$"Order: {Order}, " +
				$"URLPath: {URLPath}, " +
				$"IconURLPath: {IconURLPath}";
        }

        public string ToStringOnlyValuesForHTML()
        {
            return $@"<tr>
                <td align=""left"" valign=""top"">
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{Name}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{MenuFatherId}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{Order}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{URLPath}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{IconURLPath}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td>
                </tr>";
        }
    }
}