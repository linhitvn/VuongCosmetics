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

public class DAArticleBase : TDatabase
{
    public Int32 fID;
    public Int32 fCategoryID;
    public String fTitle;
    public String fDescription;
    public String fContent;
    public String fUrlRewrite;
    public String fImgLink;
    public Boolean fIsComment;
    public Byte fNew;
    public Byte fHot;
    public Int32 fViewNumber;
    public Int32 fRecordStatusID;
    public DateTime fPublishDate;
    public String fMetaTitle;
    public String fMetaDescription;
    public String fMetaKeywords;
    public String fTags;
    public String fOperator;
    public String fTitleNosign;

    public DAArticleBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Article";
        mKeyName = "ID";
    }
    public int USP_Article_Insert()
    {
        mCmd.CommandText = "USP_Article_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = fCategoryID;
        mCmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = fTitle;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = fContent;
        mCmd.Parameters.Add("@UrlRewrite", SqlDbType.VarChar).Value = fUrlRewrite;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@IsComment", SqlDbType.Bit).Value = fIsComment;
        mCmd.Parameters.Add("@New", SqlDbType.TinyInt).Value = fNew;
        mCmd.Parameters.Add("@Hot", SqlDbType.TinyInt).Value = fHot;
        mCmd.Parameters.Add("@ViewNumber", SqlDbType.Int).Value = fViewNumber;
        mCmd.Parameters.Add("@RecordStatusID", SqlDbType.Int).Value = fRecordStatusID;
        mCmd.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = fPublishDate;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = fTags;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;
        mCmd.Parameters.Add("@TitleNosign", SqlDbType.VarChar).Value = fTitleNosign;

        return Execute();
    }
    

    public int USP_Article_Update()
    {
        mCmd.CommandText = "USP_Article_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = fCategoryID;
        mCmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = fTitle;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = fContent;
        mCmd.Parameters.Add("@UrlRewrite", SqlDbType.VarChar).Value = fUrlRewrite;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@IsComment", SqlDbType.Bit).Value = fIsComment;
        mCmd.Parameters.Add("@New", SqlDbType.TinyInt).Value = fNew;
        mCmd.Parameters.Add("@Hot", SqlDbType.TinyInt).Value = fHot;
        mCmd.Parameters.Add("@ViewNumber", SqlDbType.Int).Value = fViewNumber;
        mCmd.Parameters.Add("@RecordStatusID", SqlDbType.Int).Value = fRecordStatusID;
        mCmd.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = fPublishDate;
        mCmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = fMetaTitle;
        mCmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = fMetaDescription;
        mCmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = fMetaKeywords;
        mCmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = fTags;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;
        mCmd.Parameters.Add("@TitleNosign", SqlDbType.VarChar).Value = fTitleNosign;

        return Execute();
    }

    public int USP_Article_Delete(int ID)
    {
        mCmd.CommandText = "USP_Article_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Article_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Article_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Article_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Article_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Article_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Article_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Article_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Article_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Article_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Article_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Article_Fetch()
    {
        return 0;
    }
    public bool USP_Article_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Article_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fCategoryID = Convert.ToInt32(mDataReader["CategoryID"]);
            fTitle = mDataReader["Title"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fContent = mDataReader["Content"].ToString();
            fUrlRewrite = mDataReader["UrlRewrite"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fIsComment = Convert.ToBoolean(mDataReader["IsComment"]);
            fNew = Convert.ToByte(mDataReader["New"]);
            fHot = Convert.ToByte(mDataReader["Hot"]);
            fViewNumber = Convert.ToInt32(mDataReader["ViewNumber"]);
            fRecordStatusID = Convert.ToInt32(mDataReader["RecordStatusID"]);
            fPublishDate = Convert.ToDateTime(mDataReader["PublishDate"]);
            fMetaTitle = mDataReader["MetaTitle"].ToString();
            fMetaDescription = mDataReader["MetaDescription"].ToString();
            fMetaKeywords = mDataReader["MetaKeywords"].ToString();
            fTags = mDataReader["Tags"].ToString();
            fOperator = mDataReader["Operator"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Article_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Article_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Article_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Article_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Article_CheckDuplicate(string CategoryID)
    {
        mCmd.CommandText = "USP_Article_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CategoryID", SqlDbType.VarChar).Value = CategoryID;
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
            fCategoryID = Convert.ToInt32(mDataReader["CategoryID"]);
            fTitle = mDataReader["Title"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fContent = mDataReader["Content"].ToString();
            fUrlRewrite = mDataReader["UrlRewrite"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fIsComment = Convert.ToBoolean(mDataReader["IsComment"]);
            fNew = Convert.ToByte(mDataReader["New"]);
            fHot = Convert.ToByte(mDataReader["Hot"]);
            fViewNumber = Convert.ToInt32(mDataReader["ViewNumber"]);
            fRecordStatusID = Convert.ToInt32(mDataReader["RecordStatusID"]);
            fPublishDate = Convert.ToDateTime(mDataReader["PublishDate"]);
            fMetaTitle = mDataReader["MetaTitle"].ToString();
            fMetaDescription = mDataReader["MetaDescription"].ToString();
            fMetaKeywords = mDataReader["MetaKeywords"].ToString();
            fTags = mDataReader["Tags"].ToString();
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
public partial class DAArticle : DAArticleBase
{
    public SqlDataReader USP_Article_Search(int CategoryID, string TitleNosign)
    {
        mCmd.CommandText = "USP_Article_Search";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
        mCmd.Parameters.Add("@TitleNosign", SqlDbType.NVarChar).Value = TitleNosign;
        ExecuteReader();
        return mDataReader;
    }
}
