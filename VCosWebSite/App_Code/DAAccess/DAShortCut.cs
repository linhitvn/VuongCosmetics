using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NDL.Framework.MSSQL;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DAShortCut
/// </summary>
public class DAShortCut : TDatabase
{
	public DAShortCut()
	{
        mTableName = "ShortCut";
	}

    public SqlDataReader Client_USP_ShortCut_GetByTypeID(int TypeID)
    {
        mCmd.CommandText = "Client_USP_ShortCut_GetByTypeID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = TypeID;
        return ExecuteReader();
    }

}