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

public class DACategoryBase : TDatabase
{
    public Int32 fID;
    public String fCategory;
    public Int32 fParentID;
    public String fUrlRewrite;
    public String fImgLink;
    public String fMetaTitle;
    public String fMetaDescription;
    public String fMetaKeywords;
    public String fTags;
    public Boolean fActive;
    public Int32 fPos;
    public String fOperator;

    public DACategoryBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Category";
        mKeyName = "ID";
    }
    public int USP_Category_Insert()
    {
        mCmd.CommandText = "USP_Category_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = fCategory;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@UrlRewrite", SqlDbType.VarChar).Value = fUrlRewrite;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = fTags;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;

        return Execute();
    }
    public int USP_Category_Insert(Int32 ID, String Category, Int32 ParentID, String UrlRewrite, String ImgLink, String MetaTitle, String MetaDescription, String MetaKeywords, String Tags, Boolean Active, Int32 Pos, String Operator)
    {
        mCmd.CommandText = "USP_Category_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = Category;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@UrlRewrite", SqlDbType.VarChar).Value = UrlRewrite;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = ImgLink;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = MetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = MetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = MetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = Tags;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = Operator;

        return Execute();
    }

    public int USP_Category_Update()
    {
        mCmd.CommandText = "USP_Category_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = fCategory;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@UrlRewrite", SqlDbType.VarChar).Value = fUrlRewrite;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = fTags;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;

        return Execute();
    }
    public int USP_Category_Update(Int32 ID, String Category, Int32 ParentID, String UrlRewrite, String ImgLink, String MetaTitle, String MetaDescription, String MetaKeywords, String Tags, Boolean Active, Int32 Pos, String Operator)
    {
        mCmd.CommandText = "USP_Category_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = Category;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@UrlRewrite", SqlDbType.VarChar).Value = UrlRewrite;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = ImgLink;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = MetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = MetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = MetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = Tags;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = Operator;

        return Execute();
    }

    public int USP_Category_Delete(int ID)
    {
        mCmd.CommandText = "USP_Category_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Category_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Category_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Category_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Category_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Category_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Category_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Category_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Category_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Category_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Category_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Category_Fetch()
    {
        return 0;
    }
    public bool USP_Category_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Category_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fCategory = mDataReader["Category"].ToString();
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fUrlRewrite = mDataReader["UrlRewrite"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fMetaTitle = mDataReader["MetaTitle"].ToString();
            fMetaDescription = mDataReader["MetaDescription"].ToString();
            fMetaKeywords = mDataReader["MetaKeywords"].ToString();
            fTags = mDataReader["Tags"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fOperator = mDataReader["Operator"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Category_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Category_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Category_GetDataForComboBox(int ID = 0)
    {
        mCmd.CommandText = "USP_Category_GetDataForComboBox";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Category_CheckDuplicate(string Category)
    {
        mCmd.CommandText = "USP_Category_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = Category;
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
            fCategory = mDataReader["Category"].ToString();
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fUrlRewrite = mDataReader["UrlRewrite"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fMetaTitle = mDataReader["MetaTitle"].ToString();
            fMetaDescription = mDataReader["MetaDescription"].ToString();
            fMetaKeywords = mDataReader["MetaKeywords"].ToString();
            fTags = mDataReader["Tags"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fOperator = mDataReader["Operator"].ToString();

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

public partial class DACategory : DACategoryBase
{
    public DataSet USP_Category_GetForTree()
    {
        mCmd.CommandText = "USP_Category_GetForTree";
        mCmd.Parameters.Clear();
        ExecuteDataSet();
        return mDataSet;
    }
    public int USP_Category_UpdateSEO()
    {
        mCmd.CommandText = "USP_Category_UpdateSEO";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;

        return Execute();
    }
}
