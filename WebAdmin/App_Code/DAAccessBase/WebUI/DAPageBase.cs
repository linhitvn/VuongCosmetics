using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
using NDL.Framework.MSSQL;

public class DAPageBase : TDatabase
{
    public Int32 fID;
    public String fPage;
    public String fPageURL;
    public String fImgLink;
    public String fDescription;
    public String fUControl;
    public String fParam;
    public Boolean fActive;
    public String fOperator;
    public String fMetaTitle;
    public String fMetaDescription;
    public String fMetaKeywords;
    public String fTags;

    public DAPageBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Page";
        mKeyName = "ID";
    }
    public int USP_Page_Insert()
    {
        mCmd.CommandText = "USP_Page_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Page", SqlDbType.NVarChar).Value = fPage;
        mCmd.Parameters.Add("@PageURL", SqlDbType.NVarChar).Value = fPageURL;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@UControl", SqlDbType.VarChar).Value = fUControl;
        mCmd.Parameters.Add("@Param", SqlDbType.NVarChar).Value = fParam;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = fTags;

        return Execute();
    }
    public int USP_Page_Insert(Int32 ID, String Page, String PageURL, String ImgLink, String Description, String UControl, String Param, Boolean Active, String Operator, String MetaTitle, String MetaDescription, String MetaKeywords, String Tags)
    {
        mCmd.CommandText = "USP_Page_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Page", SqlDbType.NVarChar).Value = Page;
        mCmd.Parameters.Add("@PageURL", SqlDbType.NVarChar).Value = PageURL;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = ImgLink;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@UControl", SqlDbType.VarChar).Value = UControl;
        mCmd.Parameters.Add("@Param", SqlDbType.NVarChar).Value = Param;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = Operator;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = MetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = MetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = MetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = Tags;

        return Execute();
    }

    public int USP_Page_Update()
    {
        mCmd.CommandText = "USP_Page_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Page", SqlDbType.NVarChar).Value = fPage;
        mCmd.Parameters.Add("@PageURL", SqlDbType.NVarChar).Value = fPageURL;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@UControl", SqlDbType.VarChar).Value = fUControl;
        mCmd.Parameters.Add("@Param", SqlDbType.NVarChar).Value = fParam;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = fTags;

        return Execute();
    }
    public int USP_Page_Update(Int32 ID, String Page, String PageURL, String ImgLink, String Description, String UControl, String Param, Boolean Active, String Operator, String MetaTitle, String MetaDescription, String MetaKeywords, String Tags)
    {
        mCmd.CommandText = "USP_Page_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Page", SqlDbType.NVarChar).Value = Page;
        mCmd.Parameters.Add("@PageURL", SqlDbType.NVarChar).Value = PageURL;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = ImgLink;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@UControl", SqlDbType.VarChar).Value = UControl;
        mCmd.Parameters.Add("@Param", SqlDbType.NVarChar).Value = Param;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = Operator;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = MetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = MetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = MetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = Tags;

        return Execute();
    }

    public int USP_Page_Delete(int ID)
    {
        mCmd.CommandText = "USP_Page_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Page_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Page_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Page_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Page_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Page_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Page_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Page_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Page_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Page_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Page_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Page_Fetch()
    {
        return 0;
    }
    public bool USP_Page_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Page_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fPage = mDataReader["Page"].ToString();
            fPageURL = mDataReader["PageURL"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fUControl = mDataReader["UControl"].ToString();
            fParam = mDataReader["Param"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fOperator = mDataReader["Operator"].ToString();
            fMetaTitle = mDataReader["MetaTitle"].ToString();
            fMetaDescription = mDataReader["MetaDescription"].ToString();
            fMetaKeywords = mDataReader["MetaKeywords"].ToString();
            fTags = mDataReader["Tags"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Page_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Page_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Page_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Page_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Page_CheckDuplicate(string Page)
    {
        mCmd.CommandText = "USP_Page_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@Page", SqlDbType.VarChar).Value = Page;
        //ExecuteReader();
        return Execute();
    }

    public int USP_NewKey()
    {
        fID = USP_GetKey();
        return fID;
    }

    public bool Fetch_Reader(bool bClose)
    {
        if (mDataReader.IsClosed)
            return false;
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fPage = mDataReader["Page"].ToString();
            fPageURL = mDataReader["PageURL"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fUControl = mDataReader["UControl"].ToString();
            fParam = mDataReader["Param"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fOperator = mDataReader["Operator"].ToString();
            fMetaTitle = mDataReader["MetaTitle"].ToString();
            fMetaDescription = mDataReader["MetaDescription"].ToString();
            fMetaKeywords = mDataReader["MetaKeywords"].ToString();
            fTags = mDataReader["Tags"].ToString();

            return true;
        }
        else
            if (bClose)
            {
                mDataReader.Close();
            }
        return false;
    }

    public bool U_Fetch_Reader(bool bClose)
    {
        return Fetch_Reader(bClose);
    }

    public bool U_Fetch_Reader()
    {
        return Fetch_Reader(true);
    }

}
public partial class DAPage : DAPageBase
{
    public DataSet USP_Page_GetAllPage()
    {
        mCmd.CommandText = "USP_Page_GetAllPage";
        mCmd.Parameters.Clear();
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }
    public int USP_Page_UpdateSEO()
    {
        mCmd.CommandText = "USP_Page_UpdateSeo";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        return Execute();
    }
}
