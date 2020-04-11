using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NDL.Framework.MSSQL;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DAArticle
/// </summary>
public class DAArticle : TDatabase
{
	public DAArticle()
	{
		//
		// TODO: Add constructor logic here
		//
        mTableName = "Article";
    }

    public SqlDataReader USP_Article_Client_GetPageArticle(int CategoryID, int page)
    {
        mCmd.CommandText = "USP_Article_Client_GetPageArticle";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
        mCmd.Parameters.Add("@Page", SqlDbType.Int).Value = page;
        return ExecuteReader();
    }

    public SqlDataReader USP_Article_Client_GetDetail(int ArticleID)
    {
        mCmd.CommandText = "USP_Article_Client_GetDetail";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
        return ExecuteReader();
    }

    public SqlDataReader USP_Article_Client_GetAbout()
    {
        mCmd.CommandText = "USP_Article_Client_GetAbout";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
        return ExecuteReader();
    }

    public SqlDataReader USP_Article_Client_GetTop()
    {
        mCmd.CommandText = "USP_Article_Client_GetTop";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@UrlCate", SqlDbType.VarChar).Value = UrlCate;
        return ExecuteReader();
    }

    public SqlDataReader USP_Article_Client_GetHot()
    {
        mCmd.CommandText = "USP_Article_Client_GetHot";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@UrlCate", SqlDbType.VarChar).Value = UrlCate;
        return ExecuteReader();
    }

    public SqlDataReader USP_Article_Client_GetNotification()
    {
        mCmd.CommandText = "USP_Article_Client_GetNotification";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
        return ExecuteReader();
    }
    public SqlDataReader USP_Article_Client_GetFooter()
    {
        mCmd.CommandText = "USP_Article_Client_GetFooter";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
        return ExecuteReader();
    }
    public SqlDataReader USP_Article_Client_GetContactUs()
    {
        mCmd.CommandText = "USP_Article_Client_GetContactUs";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
        return ExecuteReader();
    }
}