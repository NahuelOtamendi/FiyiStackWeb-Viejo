using FiyiStackWeb.Areas.CMSCore.Models;
using FiyiStackWeb.Library;
using System;
using System.Collections.Generic;


namespace FiyiStackWeb.Areas.FiyiStack.Interfaces
{
    /// <summary>
    /// Stack:             5<br/>
    /// Name:              C# Interface. <br/>
    /// Function:          This interface allow you to standardize the C# service associated. 
    ///                    In other words, define the functions that has to implement the C# service. <br/>
    /// Note:              Raise exception in case of missing any function declared here but not in the service. <br/>
    /// </summary>
    public partial interface IFiyiStack
    {
        #region Non-Queries
        string ContactMe(string Name, string Surname, string Email, string Message);
        #endregion
    }
}