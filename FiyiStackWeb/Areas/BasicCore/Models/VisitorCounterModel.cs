using Dapper;
using FiyiStackWeb.Areas.BasicCore.DTOs;
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

namespace FiyiStackWeb.Areas.BasicCore.Models
{
    /// <summary>
    /// Stack:             3 <br/>
    /// Name:              C# Model with stored procedure calls saved on database. <br/>
    /// Function:          Allow you to manipulate information from database using stored procedures.
    ///                    Also, let you make other related actions with the model in question or
    ///                    make temporal copies with random data. <br/>
    /// Fields:            8 <br/> 
    /// Sub-models:      0 models <br/>
    /// Last modification: 22/02/2023 13:29:13
    /// </summary>
    [Serializable]
    public partial class VisitorCounterModel
    {
        [NotMapped]
        private string _ConnectionString = ConnectionStrings.ConnectionStrings.Development();

        #region Fields
        [Library.ModelAttributeValidator.Key("VisitorCounterId")]
        public int VisitorCounterId { get; set; }

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

        [Library.ModelAttributeValidator.DateTime("DateTime", true, "1753-01-01T00:00", "9998-12-30T23:59")]
        public DateTime DateTime { get; set; }

        [Library.ModelAttributeValidator.String("Page", false, 1, 100, "")]
        public string Page { get; set; }
        #endregion

        #region Sub-lists
        
        #endregion

        #region Constructors
        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create fastly this model with field VisitorCounterId = 0 <br/>
        /// Note 1:       Generally used to have fast access to functions of object. <br/>
        /// Note 2:       Need construction with [new] reserved word, as all constructors. <br/>
        /// Fields:       8 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public VisitorCounterModel()
        {
            try 
            {
                VisitorCounterId = 0;

                //Initialize sub-lists
                
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with stored information in database using VisitorCounterId <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       8 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public VisitorCounterModel(int VisitorCounterId)
        {
            try
            {
                List<VisitorCounterModel> lstVisitorCounterModel = new List<VisitorCounterModel>();

                //Initialize sub-lists
                
                
                DynamicParameters dp = new DynamicParameters();

                dp.Add("VisitorCounterId", VisitorCounterId, DbType.Int32, ParameterDirection.Input);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    //In case of not finding anything, Dapper return a List<VisitorCounterModel>
                    lstVisitorCounterModel = (List<VisitorCounterModel>)sqlConnection.Query<VisitorCounterModel>("[dbo].[BasicCore.VisitorCounter.Select1ByVisitorCounterId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstVisitorCounterModel.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[BasicCore.VisitorCounter.Select1ByVisitorCounterId] returned more than one register/row");
                }
        
                foreach (VisitorCounterModel visitorcounter in lstVisitorCounterModel)
                {
                    this.VisitorCounterId = visitorcounter.VisitorCounterId;
					this.Active = visitorcounter.Active;
					this.DateTimeCreation = visitorcounter.DateTimeCreation;
					this.DateTimeLastModification = visitorcounter.DateTimeLastModification;
					this.UserCreationId = visitorcounter.UserCreationId;
					this.UserLastModificationId = visitorcounter.UserLastModificationId;
					this.DateTime = visitorcounter.DateTime;
					this.Page = visitorcounter.Page;
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
        public VisitorCounterModel(int VisitorCounterId, bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, DateTime DateTime, string Page)
        {
            try
            {
                //Initialize sub-lists
                

                this.VisitorCounterId = VisitorCounterId;
				this.Active = Active;
				this.DateTimeCreation = DateTimeCreation;
				this.DateTimeLastModification = DateTimeLastModification;
				this.UserCreationId = UserCreationId;
				this.UserLastModificationId = UserLastModificationId;
				this.DateTime = DateTime;
				this.Page = Page;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model (copy) using the given model (original), visitorcounter, passed by parameter. <br/>
        /// Note:         This constructor is generally used to execute functions using the copied fields <br/>
        /// Fields:       8 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public VisitorCounterModel(VisitorCounterModel visitorcounter)
        {
            try
            {
                //Initialize sub-lists
                

                VisitorCounterId = visitorcounter.VisitorCounterId;
				Active = visitorcounter.Active;
				DateTimeCreation = visitorcounter.DateTimeCreation;
				DateTimeLastModification = visitorcounter.DateTimeLastModification;
				UserCreationId = visitorcounter.UserCreationId;
				UserLastModificationId = visitorcounter.UserLastModificationId;
				DateTime = visitorcounter.DateTime;
				Page = visitorcounter.Page;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The number of rows inside VisitorCounter</returns>
        public int Count()
        {
            try
            {
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.Count]", commandType: CommandType.StoredProcedure, param: dp);
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
        public DataTable Select1ByVisitorCounterIdToDataTable(int VisitorCounterId)
        {
            try
            {
                DataTable DataTable = new DataTable();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("VisitorCounterId", VisitorCounterId, DbType.Int32, ParameterDirection.Input);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.Select1ByVisitorCounterId]", commandType: CommandType.StoredProcedure, param: dp);

                    DataTable.Load(dataReader);
                }

                if (DataTable.Rows.Count > 1)
                { throw new Exception("The stored procedure [dbo].[BasicCore.VisitorCounter.Select1ByVisitorCounterId] returned more than one register/row"); }

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
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.SelectAll]", commandType: CommandType.StoredProcedure, param: dp);

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
        public VisitorCounterModel Select1ByVisitorCounterIdToModel(int VisitorCounterId)
        {
            try
            {
                VisitorCounterModel VisitorCounterModel = new VisitorCounterModel();
                List<VisitorCounterModel> lstVisitorCounterModel = new List<VisitorCounterModel>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("VisitorCounterId", VisitorCounterId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstVisitorCounterModel = (List<VisitorCounterModel>)sqlConnection.Query<VisitorCounterModel>("[dbo].[BasicCore.VisitorCounter.Select1ByVisitorCounterId]", dp, commandType: CommandType.StoredProcedure);
                }
        
                if (lstVisitorCounterModel.Count > 1)
                { throw new Exception("The stored procedure [dbo].[BasicCore.VisitorCounter.Select1ByVisitorCounterId] returned more than one register/row"); }

                foreach (VisitorCounterModel visitorcounter in lstVisitorCounterModel)
                {
                    VisitorCounterModel.VisitorCounterId = visitorcounter.VisitorCounterId;
					VisitorCounterModel.Active = visitorcounter.Active;
					VisitorCounterModel.DateTimeCreation = visitorcounter.DateTimeCreation;
					VisitorCounterModel.DateTimeLastModification = visitorcounter.DateTimeLastModification;
					VisitorCounterModel.UserCreationId = visitorcounter.UserCreationId;
					VisitorCounterModel.UserLastModificationId = visitorcounter.UserLastModificationId;
					VisitorCounterModel.DateTime = visitorcounter.DateTime;
					VisitorCounterModel.Page = visitorcounter.Page;
                }

                return VisitorCounterModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<VisitorCounterModel> SelectAllToList()
        {
            try
            {
                List<VisitorCounterModel> lstVisitorCounterModel = new List<VisitorCounterModel>();
                DynamicParameters dp = new DynamicParameters();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstVisitorCounterModel = (List<VisitorCounterModel>)sqlConnection.Query<VisitorCounterModel>("[dbo].[BasicCore.VisitorCounter.SelectAll]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstVisitorCounterModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public visitorcounterSelectAllPaged SelectAllPagedToModel(visitorcounterSelectAllPaged visitorcounterSelectAllPaged)
        {
            try
            {
                visitorcounterSelectAllPaged.lstVisitorCounterModel = new List<VisitorCounterModel>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("QueryString", visitorcounterSelectAllPaged.QueryString, DbType.String, ParameterDirection.Input);
                dp.Add("ActualPageNumber", visitorcounterSelectAllPaged.ActualPageNumber, DbType.Int32, ParameterDirection.Input);
                dp.Add("RowsPerPage", visitorcounterSelectAllPaged.RowsPerPage, DbType.Int32, ParameterDirection.Input);
                dp.Add("SorterColumn", visitorcounterSelectAllPaged.SorterColumn, DbType.String, ParameterDirection.Input);
                dp.Add("SortToggler", visitorcounterSelectAllPaged.SortToggler, DbType.Boolean, ParameterDirection.Input);
                dp.Add("TotalRows", visitorcounterSelectAllPaged.TotalRows, DbType.Int32, ParameterDirection.Output);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    visitorcounterSelectAllPaged.lstVisitorCounterModel = (List<VisitorCounterModel>)sqlConnection.Query<VisitorCounterModel>("[dbo].[BasicCore.VisitorCounter.SelectAllPaged]", dp, commandType: CommandType.StoredProcedure);
                    visitorcounterSelectAllPaged.TotalRows = dp.Get<int>("TotalRows");
                }

                visitorcounterSelectAllPaged.TotalPages = Library.Math.Divide(visitorcounterSelectAllPaged.TotalRows, visitorcounterSelectAllPaged.RowsPerPage, Library.Math.RoundType.RoundUp);

                

                return visitorcounterSelectAllPaged;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<visitorCounterPerMonth> SelectAllToVisitorsPerMonthChart()
        {
            try
            {
                List<visitorCounterPerMonth> lstVisitorCounterModel = new List<visitorCounterPerMonth>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("ActualYear", DateTime.Now.Year, DbType.Int32, ParameterDirection.Input);
                dp.Add("LastYear", DateTime.Now.AddYears(-1).Year, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstVisitorCounterModel = (List<visitorCounterPerMonth>)sqlConnection.Query<visitorCounterPerMonth>("[dbo].[BasicCore.VisitorCounter.CountPerMonth]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstVisitorCounterModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<visitorCountPageVisits> SelectAllToVisitorsCounterPageChart()
        {
            try
            {
                List<visitorCountPageVisits> lstVisitorCounterModel = new List<visitorCountPageVisits>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("ActualYear", DateTime.Now.Year, DbType.Int32, ParameterDirection.Input);
                dp.Add("LastYear", DateTime.Now.AddYears(-1).Year, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstVisitorCounterModel = (List<visitorCountPageVisits>)sqlConnection.Query<visitorCountPageVisits>("[dbo].[BasicCore.VisitorCounter.CountPageVisits]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstVisitorCounterModel;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <returns>NewEnteredId: The ID of the last registry inserted in VisitorCounter table</returns>
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
				dp.Add("DateTime", DateTime, DbType.DateTime, ParameterDirection.Input);
				dp.Add("Page", Page, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The ID of the last registry inserted in VisitorCounter table</returns>
        public int Insert(VisitorCounterModel visitorcounter)
        {
            try
            {
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("Active", visitorcounter.Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", visitorcounter.DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", visitorcounter.DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", visitorcounter.UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", visitorcounter.UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("DateTime", visitorcounter.DateTime, DbType.DateTime, ParameterDirection.Input);
				dp.Add("Page", visitorcounter.Page, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The ID of the last registry inserted in VisitorCounter table</returns>
        public int Insert(bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, DateTime DateTime, string Page)
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
				dp.Add("DateTime", DateTime, DbType.DateTime, ParameterDirection.Input);
				dp.Add("Page", Page, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in VisitorCounter table</returns>
        public int UpdateByVisitorCounterId()
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("VisitorCounterId", VisitorCounterId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("DateTime", DateTime, DbType.DateTime, ParameterDirection.Input);
				dp.Add("Page", Page, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.UpdateByVisitorCounterId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in VisitorCounter table</returns>
        public int UpdateByVisitorCounterId(VisitorCounterModel visitorcounter)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("VisitorCounterId", visitorcounter.VisitorCounterId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", visitorcounter.Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", visitorcounter.DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", visitorcounter.DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", visitorcounter.UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", visitorcounter.UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("DateTime", visitorcounter.DateTime, DbType.DateTime, ParameterDirection.Input);
				dp.Add("Page", visitorcounter.Page, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.UpdateByVisitorCounterId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in VisitorCounter table</returns>
        public int UpdateByVisitorCounterId(int VisitorCounterId, bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, DateTime DateTime, string Page)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("VisitorCounterId", VisitorCounterId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("DateTime", DateTime, DbType.DateTime, ParameterDirection.Input);
				dp.Add("Page", Page, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.UpdateByVisitorCounterId]", commandType: CommandType.StoredProcedure, param: dp);
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
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.DeleteAll]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <returns>The number of rows deleted in VisitorCounter table</returns>
        public int DeleteByVisitorCounterId()
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add("VisitorCounterId", VisitorCounterId, DbType.Int32, ParameterDirection.Input);        
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.DeleteByVisitorCounterId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows affected in VisitorCounter table</returns>
        public int DeleteByVisitorCounterId(int VisitorCounterId)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add("VisitorCounterId", VisitorCounterId, DbType.Int32, ParameterDirection.Input);        
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[BasicCore.VisitorCounter.DeleteByVisitorCounterId]", commandType: CommandType.StoredProcedure, param: dp);
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
        public VisitorCounterModel ByteArrayToVisitorCounterModel<T>(byte[] arrVisitorCounterModel)
        {
            try
            {
                if (arrVisitorCounterModel == null)
                { return new VisitorCounterModel(); }
                BinaryFormatter BinaryFormatter = new BinaryFormatter();
                using MemoryStream MemoryStream = new MemoryStream(arrVisitorCounterModel);
                object Object = BinaryFormatter.Deserialize(MemoryStream);
                return (VisitorCounterModel)Object;
            }
            catch (Exception ex)
            { throw ex; }
        }
        
        /// <summary>
        /// Function: Show all information (fields) inside the model during depuration mode.
        /// </summary>
        public override string ToString()
        {
            return $"VisitorCounterId: {VisitorCounterId}, " +
				$"Active: {Active}, " +
				$"DateTimeCreation: {DateTimeCreation}, " +
				$"DateTimeLastModification: {DateTimeLastModification}, " +
				$"UserCreationId: {UserCreationId}, " +
				$"UserLastModificationId: {UserLastModificationId}, " +
				$"DateTime: {DateTime}, " +
				$"Page: {Page}";
        }

        public string ToStringOnlyValuesForHTML()
        {
            return $@"<tr>
                <td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{VisitorCounterId}</span>
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{DateTime}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{Page}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td>
                </tr>";
        }
    }
}