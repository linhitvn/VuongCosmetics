using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NDL.Framework.MSSQL;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DAProduct
/// </summary>
public class DAProduct : TDatabase
{
	public DAProduct()
	{
		//
		// TODO: Add constructor logic here
		//
        mTableName = "Product";
	}

    public SqlDataReader USP_Product_Client_GetHot()
    {
        mCmd.CommandText = "USP_Product_Client_GetHot";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
        return ExecuteReader();
    }

    public SqlDataReader USP_Product_Client_GetNew()
    {
        mCmd.CommandText = "USP_Product_Client_GetNew";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
        return ExecuteReader();
    }

    public SqlDataReader USP_Product_Client_GetBestSeller()
    {
        mCmd.CommandText = "USP_Product_Client_GetBestSeller";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
        return ExecuteReader();
    }

    public SqlDataReader USP_Product_Client_GetAllList(int ProCatID)
    {
        mCmd.CommandText = "USP_Product_Client_GetAllList";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProCatID", SqlDbType.Int).Value = ProCatID;
        return ExecuteReader();
    }

    public SqlDataReader USP_Product_Client_Search(String Productname)
    {
        mCmd.CommandText = "USP_Product_Client_Search";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@Productname", SqlDbType.NVarChar).Value = Productname;
        return ExecuteReader();
    }
    public SqlDataReader USP_Product_Client_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Product_Client_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return ExecuteReader();
    }

    public SqlDataReader USP_Product_Client_GetRelatebyID(int ID)
    {
        mCmd.CommandText = "USP_Product_Client_GetRelatebyID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return ExecuteReader();
    }

    // ProductCat
    public SqlDataReader USP_ProductCat_Client_GetAll()
    {
        mCmd.CommandText = "USP_ProductCat_Client_GetAll";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
        return ExecuteReader();
    }
}