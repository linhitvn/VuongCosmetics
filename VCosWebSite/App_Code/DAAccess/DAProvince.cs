using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NDL.Framework.MSSQL;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for DAProvince
/// </summary>
public class DAProvince: TDatabase
{
    public DAProvince()
    {
        mTableName = "Province";
    }

    public SqlDataReader USP_Province_Client_GetAll()
    {
        mCmd.CommandText = "USP_Province_Client_GetAll";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = TypeID;
        return ExecuteReader();
    }

    public SqlDataReader USP_District_Client_GetByCity(int CityID)
    {
        mCmd.CommandText = "USP_District_Client_GetByCity";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
        return ExecuteReader();
    }
}