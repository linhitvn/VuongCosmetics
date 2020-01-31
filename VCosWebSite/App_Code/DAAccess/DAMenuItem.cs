using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NDL.Framework.MSSQL;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DAMenuItem
/// </summary>
public class DAMenuItem : TDatabase
{
	public DAMenuItem()
	{
		//
		// TODO: Add constructor logic here
		//
         mTableName = "MenuItem";
	}

    public SqlDataReader Client_USP_MenuItem_GetByMenuID(int MenuID)
    {
        mCmd.CommandText = "Client_USP_MenuItem_GetByMenuID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@MenuID", SqlDbType.Int).Value = MenuID;
        //mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        return ExecuteReader();
    }

}