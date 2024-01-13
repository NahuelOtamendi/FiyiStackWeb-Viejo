using Dapper;
using FiyiStackWeb.Areas.FiyiStack.DTOs;
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

namespace FiyiStackWeb.Areas.FiyiStack.Models
{
    /// <summary>
    /// Stack:             3 <br/>
    /// Name:              C# Model with stored procedure calls saved on database. <br/>
    /// Function:          Allow you to manipulate information from database using stored procedures.
    ///                    Also, let you make other related actions with the model in question or
    ///                    make temporal copies with random data. <br/>
    /// Fields:            9 <br/> 
    /// Sub-models:      0 models <br/>
    /// Last modification: 23/07/2023 22:03:13
    /// </summary>
    [Serializable]
    public partial class SendUsDBDiagramModel
    {
        [NotMapped]
        private string _ConnectionString = ConnectionStrings.ConnectionStrings.Development();

        #region Fields
        [Library.ModelAttributeValidator.Key("SendUsDBDiagramId")]
        public int SendUsDBDiagramId { get; set; }

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

        [Library.ModelAttributeValidator.String("Title", false, 1, 300, "")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Library.ModelAttributeValidator.String("FileUploaded", false, 1, 8000, "")]
        public string FileUploaded { get; set; }
        #endregion

        #region Sub-lists
        
        #endregion

        #region Constructors
        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create fastly this model with field SendUsDBDiagramId = 0 <br/>
        /// Note 1:       Generally used to have fast access to functions of object. <br/>
        /// Note 2:       Need construction with [new] reserved word, as all constructors. <br/>
        /// Fields:       9 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public SendUsDBDiagramModel()
        {
            try 
            {
                SendUsDBDiagramId = 0;

                //Initialize sub-lists
                
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with stored information in database using SendUsDBDiagramId <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       9 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public SendUsDBDiagramModel(int SendUsDBDiagramId)
        {
            try
            {
                List<SendUsDBDiagramModel> lstSendUsDBDiagramModel = new List<SendUsDBDiagramModel>();

                //Initialize sub-lists
                
                
                DynamicParameters dp = new DynamicParameters();

                dp.Add("SendUsDBDiagramId", SendUsDBDiagramId, DbType.Int32, ParameterDirection.Input);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    //In case of not finding anything, Dapper return a List<SendUsDBDiagramModel>
                    lstSendUsDBDiagramModel = (List<SendUsDBDiagramModel>)sqlConnection.Query<SendUsDBDiagramModel>("[dbo].[FiyiStack.SendUsDBDiagram.Select1BySendUsDBDiagramId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstSendUsDBDiagramModel.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[FiyiStack.SendUsDBDiagram.Select1BySendUsDBDiagramId] returned more than one register/row");
                }
        
                foreach (SendUsDBDiagramModel sendusdbdiagram in lstSendUsDBDiagramModel)
                {
                    this.SendUsDBDiagramId = sendusdbdiagram.SendUsDBDiagramId;
					this.Active = sendusdbdiagram.Active;
					this.DateTimeCreation = sendusdbdiagram.DateTimeCreation;
					this.DateTimeLastModification = sendusdbdiagram.DateTimeLastModification;
					this.UserCreationId = sendusdbdiagram.UserCreationId;
					this.UserLastModificationId = sendusdbdiagram.UserLastModificationId;
					this.Title = sendusdbdiagram.Title;
					this.Description = sendusdbdiagram.Description;
					this.FileUploaded = sendusdbdiagram.FileUploaded;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with filled parameters <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       9 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public SendUsDBDiagramModel(int SendUsDBDiagramId, bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, string Title, string Description, string FileUploaded)
        {
            try
            {
                //Initialize sub-lists
                

                this.SendUsDBDiagramId = SendUsDBDiagramId;
				this.Active = Active;
				this.DateTimeCreation = DateTimeCreation;
				this.DateTimeLastModification = DateTimeLastModification;
				this.UserCreationId = UserCreationId;
				this.UserLastModificationId = UserLastModificationId;
				this.Title = Title;
				this.Description = Description;
				this.FileUploaded = FileUploaded;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model (copy) using the given model (original), sendusdbdiagram, passed by parameter. <br/>
        /// Note:         This constructor is generally used to execute functions using the copied fields <br/>
        /// Fields:       9 <br/> 
        /// Dependencies: 0 models depend on this model <br/>
        /// </summary>
        public SendUsDBDiagramModel(SendUsDBDiagramModel sendusdbdiagram)
        {
            try
            {
                //Initialize sub-lists
                

                SendUsDBDiagramId = sendusdbdiagram.SendUsDBDiagramId;
				Active = sendusdbdiagram.Active;
				DateTimeCreation = sendusdbdiagram.DateTimeCreation;
				DateTimeLastModification = sendusdbdiagram.DateTimeLastModification;
				UserCreationId = sendusdbdiagram.UserCreationId;
				UserLastModificationId = sendusdbdiagram.UserLastModificationId;
				Title = sendusdbdiagram.Title;
				Description = sendusdbdiagram.Description;
				FileUploaded = sendusdbdiagram.FileUploaded;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The number of rows inside SendUsDBDiagram</returns>
        public int Count()
        {
            try
            {
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.Count]", commandType: CommandType.StoredProcedure, param: dp);
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
        public DataTable Select1BySendUsDBDiagramIdToDataTable(int SendUsDBDiagramId)
        {
            try
            {
                DataTable DataTable = new DataTable();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("SendUsDBDiagramId", SendUsDBDiagramId, DbType.Int32, ParameterDirection.Input);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.Select1BySendUsDBDiagramId]", commandType: CommandType.StoredProcedure, param: dp);

                    DataTable.Load(dataReader);
                }

                if (DataTable.Rows.Count > 1)
                { throw new Exception("The stored procedure [dbo].[FiyiStack.SendUsDBDiagram.Select1BySendUsDBDiagramId] returned more than one register/row"); }

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
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.SelectAll]", commandType: CommandType.StoredProcedure, param: dp);

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
        public SendUsDBDiagramModel Select1BySendUsDBDiagramIdToModel(int SendUsDBDiagramId)
        {
            try
            {
                SendUsDBDiagramModel SendUsDBDiagramModel = new SendUsDBDiagramModel();
                List<SendUsDBDiagramModel> lstSendUsDBDiagramModel = new List<SendUsDBDiagramModel>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("SendUsDBDiagramId", SendUsDBDiagramId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstSendUsDBDiagramModel = (List<SendUsDBDiagramModel>)sqlConnection.Query<SendUsDBDiagramModel>("[dbo].[FiyiStack.SendUsDBDiagram.Select1BySendUsDBDiagramId]", dp, commandType: CommandType.StoredProcedure);
                }
        
                if (lstSendUsDBDiagramModel.Count > 1)
                { throw new Exception("The stored procedure [dbo].[FiyiStack.SendUsDBDiagram.Select1BySendUsDBDiagramId] returned more than one register/row"); }

                foreach (SendUsDBDiagramModel sendusdbdiagram in lstSendUsDBDiagramModel)
                {
                    SendUsDBDiagramModel.SendUsDBDiagramId = sendusdbdiagram.SendUsDBDiagramId;
					SendUsDBDiagramModel.Active = sendusdbdiagram.Active;
					SendUsDBDiagramModel.DateTimeCreation = sendusdbdiagram.DateTimeCreation;
					SendUsDBDiagramModel.DateTimeLastModification = sendusdbdiagram.DateTimeLastModification;
					SendUsDBDiagramModel.UserCreationId = sendusdbdiagram.UserCreationId;
					SendUsDBDiagramModel.UserLastModificationId = sendusdbdiagram.UserLastModificationId;
					SendUsDBDiagramModel.Title = sendusdbdiagram.Title;
					SendUsDBDiagramModel.Description = sendusdbdiagram.Description;
					SendUsDBDiagramModel.FileUploaded = sendusdbdiagram.FileUploaded;
                }

                return SendUsDBDiagramModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<SendUsDBDiagramModel> SelectAllToList()
        {
            try
            {
                List<SendUsDBDiagramModel> lstSendUsDBDiagramModel = new List<SendUsDBDiagramModel>();
                DynamicParameters dp = new DynamicParameters();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    lstSendUsDBDiagramModel = (List<SendUsDBDiagramModel>)sqlConnection.Query<SendUsDBDiagramModel>("[dbo].[FiyiStack.SendUsDBDiagram.SelectAll]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstSendUsDBDiagramModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public sendusdbdiagramSelectAllPaged SelectAllPagedToModel(sendusdbdiagramSelectAllPaged sendusdbdiagramSelectAllPaged)
        {
            try
            {
                sendusdbdiagramSelectAllPaged.lstSendUsDBDiagramModel = new List<SendUsDBDiagramModel>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("QueryString", sendusdbdiagramSelectAllPaged.QueryString, DbType.String, ParameterDirection.Input);
                dp.Add("ActualPageNumber", sendusdbdiagramSelectAllPaged.ActualPageNumber, DbType.Int32, ParameterDirection.Input);
                dp.Add("RowsPerPage", sendusdbdiagramSelectAllPaged.RowsPerPage, DbType.Int32, ParameterDirection.Input);
                dp.Add("SorterColumn", sendusdbdiagramSelectAllPaged.SorterColumn, DbType.String, ParameterDirection.Input);
                dp.Add("SortToggler", sendusdbdiagramSelectAllPaged.SortToggler, DbType.Boolean, ParameterDirection.Input);
                dp.Add("TotalRows", sendusdbdiagramSelectAllPaged.TotalRows, DbType.Int32, ParameterDirection.Output);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    sendusdbdiagramSelectAllPaged.lstSendUsDBDiagramModel = (List<SendUsDBDiagramModel>)sqlConnection.Query<SendUsDBDiagramModel>("[dbo].[FiyiStack.SendUsDBDiagram.SelectAllPaged]", dp, commandType: CommandType.StoredProcedure);
                    sendusdbdiagramSelectAllPaged.TotalRows = dp.Get<int>("TotalRows");
                }

                sendusdbdiagramSelectAllPaged.TotalPages = Library.Math.Divide(sendusdbdiagramSelectAllPaged.TotalRows, sendusdbdiagramSelectAllPaged.RowsPerPage, Library.Math.RoundType.RoundUp);

                

                return sendusdbdiagramSelectAllPaged;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <returns>NewEnteredId: The ID of the last registry inserted in SendUsDBDiagram table</returns>
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
				dp.Add("Title", Title, DbType.String, ParameterDirection.Input);
				dp.Add("Description", Description, DbType.String, ParameterDirection.Input);
				dp.Add("FileUploaded", FileUploaded, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The ID of the last registry inserted in SendUsDBDiagram table</returns>
        public int Insert(SendUsDBDiagramModel sendusdbdiagram)
        {
            try
            {
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("Active", sendusdbdiagram.Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", sendusdbdiagram.DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", sendusdbdiagram.DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", sendusdbdiagram.UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", sendusdbdiagram.UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Title", sendusdbdiagram.Title, DbType.String, ParameterDirection.Input);
				dp.Add("Description", sendusdbdiagram.Description, DbType.String, ParameterDirection.Input);
				dp.Add("FileUploaded", sendusdbdiagram.FileUploaded, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The ID of the last registry inserted in SendUsDBDiagram table</returns>
        public int Insert(bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, string Title, string Description, string FileUploaded)
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
				dp.Add("Title", Title, DbType.String, ParameterDirection.Input);
				dp.Add("Description", Description, DbType.String, ParameterDirection.Input);
				dp.Add("FileUploaded", FileUploaded, DbType.String, ParameterDirection.Input);
                dp.Add("NewEnteredId", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.Insert]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in SendUsDBDiagram table</returns>
        public int UpdateBySendUsDBDiagramId()
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("SendUsDBDiagramId", SendUsDBDiagramId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Title", Title, DbType.String, ParameterDirection.Input);
				dp.Add("Description", Description, DbType.String, ParameterDirection.Input);
				dp.Add("FileUploaded", FileUploaded, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.UpdateBySendUsDBDiagramId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in SendUsDBDiagram table</returns>
        public int UpdateBySendUsDBDiagramId(SendUsDBDiagramModel sendusdbdiagram)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("SendUsDBDiagramId", sendusdbdiagram.SendUsDBDiagramId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", sendusdbdiagram.Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", sendusdbdiagram.DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", sendusdbdiagram.DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", sendusdbdiagram.UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", sendusdbdiagram.UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Title", sendusdbdiagram.Title, DbType.String, ParameterDirection.Input);
				dp.Add("Description", sendusdbdiagram.Description, DbType.String, ParameterDirection.Input);
				dp.Add("FileUploaded", sendusdbdiagram.FileUploaded, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.UpdateBySendUsDBDiagramId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows updated in SendUsDBDiagram table</returns>
        public int UpdateBySendUsDBDiagramId(int SendUsDBDiagramId, bool Active, DateTime DateTimeCreation, DateTime DateTimeLastModification, int UserCreationId, int UserLastModificationId, string Title, string Description, string FileUploaded)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                dp.Add("SendUsDBDiagramId", SendUsDBDiagramId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
				dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
				dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
				dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
				dp.Add("Title", Title, DbType.String, ParameterDirection.Input);
				dp.Add("Description", Description, DbType.String, ParameterDirection.Input);
				dp.Add("FileUploaded", FileUploaded, DbType.String, ParameterDirection.Input);
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.UpdateBySendUsDBDiagramId]", commandType: CommandType.StoredProcedure, param: dp);
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
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.DeleteAll]", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <returns>The number of rows deleted in SendUsDBDiagram table</returns>
        public int DeleteBySendUsDBDiagramId()
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add("SendUsDBDiagramId", SendUsDBDiagramId, DbType.Int32, ParameterDirection.Input);        
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.DeleteBySendUsDBDiagramId]", commandType: CommandType.StoredProcedure, param: dp);
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
        /// <returns>The number of rows affected in SendUsDBDiagram table</returns>
        public int DeleteBySendUsDBDiagramId(int SendUsDBDiagramId)
        {
            try
            {
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add("SendUsDBDiagramId", SendUsDBDiagramId, DbType.Int32, ParameterDirection.Input);        
                dp.Add("RowsAffected", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader("[dbo].[FiyiStack.SendUsDBDiagram.DeleteBySendUsDBDiagramId]", commandType: CommandType.StoredProcedure, param: dp);
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
        public SendUsDBDiagramModel ByteArrayToSendUsDBDiagramModel<T>(byte[] arrSendUsDBDiagramModel)
        {
            try
            {
                if (arrSendUsDBDiagramModel == null)
                { return new SendUsDBDiagramModel(); }
                BinaryFormatter BinaryFormatter = new BinaryFormatter();
                using MemoryStream MemoryStream = new MemoryStream(arrSendUsDBDiagramModel);
                object Object = BinaryFormatter.Deserialize(MemoryStream);
                return (SendUsDBDiagramModel)Object;
            }
            catch (Exception ex)
            { throw ex; }
        }
        
        /// <summary>
        /// Function: Show all information (fields) inside the model during depuration mode.
        /// </summary>
        public override string ToString()
        {
            return $"SendUsDBDiagramId: {SendUsDBDiagramId}, " +
				$"Active: {Active}, " +
				$"DateTimeCreation: {DateTimeCreation}, " +
				$"DateTimeLastModification: {DateTimeLastModification}, " +
				$"UserCreationId: {UserCreationId}, " +
				$"UserLastModificationId: {UserLastModificationId}, " +
				$"Title: {Title}, " +
				$"Description: {Description}, " +
				$"FileUploaded: {FileUploaded}";
        }

        public string ToStringOnlyValuesForHTML()
        {
            return $@"<tr>
                <td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{SendUsDBDiagramId}</span>
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{Title}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{Description}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td><td align=""left"" valign=""top"">
        <div style=""height: 12px; line-height: 12px; font-size: 10px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"">{FileUploaded}</span>
        </font>
        <div style=""height: 40px; line-height: 40px; font-size: 38px;"">&nbsp;</div>
    </td>
                </tr>";
        }
    }
}