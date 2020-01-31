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

public class DAShortCutBase : TDatabase
{
    public Int32 fID;
    public String fShortCutName;
    public Int32 fShortCutTypeID;
    public String fContent1;
    public String fContent2;
    public String fImgLink;
    public String fCss;
    public String fUrlLink;
    public Int32 fPos;
    public Boolean fActive;

    public DAShortCutBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "ShortCut";
        mKeyName = "ID";
    }
    public int USP_ShortCut_Insert()
    {
        mCmd.CommandText = "USP_ShortCut_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ShortCutName", SqlDbType.NVarChar).Value = fShortCutName;
        mCmd.Parameters.Add("@ShortCutTypeID", SqlDbType.Int).Value = fShortCutTypeID;
        mCmd.Parameters.Add("@Content1", SqlDbType.NVarChar).Value = fContent1;
        mCmd.Parameters.Add("@Content2", SqlDbType.NVarChar).Value = fContent2;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@Css", SqlDbType.VarChar).Value = fCss;
        mCmd.Parameters.Add("@UrlLink", SqlDbType.NVarChar).Value = fUrlLink;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;

        return Execute();
    }
    public int USP_ShortCut_Insert(Int32 ID, String ShortCutName, Int32 ShortCutTypeID, String Content1, String Content2, String ImgLink, String Css, String UrlLink, Int32 Pos, Boolean Active)
    {
        mCmd.CommandText = "USP_ShortCut_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ShortCutName", SqlDbType.NVarChar).Value = ShortCutName;
        mCmd.Parameters.Add("@ShortCutTypeID", SqlDbType.Int).Value = ShortCutTypeID;
        mCmd.Parameters.Add("@Content1", SqlDbType.NVarChar).Value = Content1;
        mCmd.Parameters.Add("@Content2", SqlDbType.NVarChar).Value = Content2;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = ImgLink;
        mCmd.Parameters.Add("@Css", SqlDbType.VarChar).Value = Css;
        mCmd.Parameters.Add("@UrlLink", SqlDbType.NVarChar).Value = UrlLink;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;

        return Execute();
    }

    public int USP_ShortCut_Update()
    {
        mCmd.CommandText = "USP_ShortCut_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ShortCutName", SqlDbType.NVarChar).Value = fShortCutName;
        mCmd.Parameters.Add("@ShortCutTypeID", SqlDbType.Int).Value = fShortCutTypeID;
        mCmd.Parameters.Add("@Content1", SqlDbType.NVarChar).Value = fContent1;
        mCmd.Parameters.Add("@Content2", SqlDbType.NVarChar).Value = fContent2;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@Css", SqlDbType.VarChar).Value = fCss;
        mCmd.Parameters.Add("@UrlLink", SqlDbType.NVarChar).Value = fUrlLink;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;

        return Execute();
    }
    public int USP_ShortCut_Update(Int32 ID, String ShortCutName, Int32 ShortCutTypeID, String Content1, String Content2, String ImgLink, String Css, String UrlLink, Int32 Pos, Boolean Active)
    {
        mCmd.CommandText = "USP_ShortCut_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ShortCutName", SqlDbType.NVarChar).Value = ShortCutName;
        mCmd.Parameters.Add("@ShortCutTypeID", SqlDbType.Int).Value = ShortCutTypeID;
        mCmd.Parameters.Add("@Content1", SqlDbType.NVarChar).Value = Content1;
        mCmd.Parameters.Add("@Content2", SqlDbType.NVarChar).Value = Content2;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = ImgLink;
        mCmd.Parameters.Add("@Css", SqlDbType.VarChar).Value = Css;
        mCmd.Parameters.Add("@UrlLink", SqlDbType.NVarChar).Value = UrlLink;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;

        return Execute();
    }

    public int USP_ShortCut_Delete(int ID)
    {
        mCmd.CommandText = "USP_ShortCut_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_ShortCut_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_ShortCut_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_ShortCut_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ShortCut_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ShortCut_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ShortCut_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_ShortCut_GetByID(int ID)
    {
        mCmd.CommandText = "USP_ShortCut_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_ShortCut_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ShortCut_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_ShortCut_Fetch()
    {
        return 0;
    }
    public bool USP_ShortCut_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_ShortCut_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fShortCutName = mDataReader["ShortCutName"].ToString();
            fShortCutTypeID = Convert.ToInt32(mDataReader["ShortCutTypeID"]);
            fContent1 = mDataReader["Content1"].ToString();
            fContent2 = mDataReader["Content2"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fCss = mDataReader["Css"].ToString();
            fUrlLink = mDataReader["UrlLink"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_ShortCut_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ShortCut_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ShortCut_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_ShortCut_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_ShortCut_CheckDuplicate(string ShortCutName)
    {
        mCmd.CommandText = "USP_ShortCut_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ShortCutName", SqlDbType.VarChar).Value = ShortCutName;
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
            fShortCutName = mDataReader["ShortCutName"].ToString();
            fShortCutTypeID = Convert.ToInt32(mDataReader["ShortCutTypeID"]);
            fContent1 = mDataReader["Content1"].ToString();
            fContent2 = mDataReader["Content2"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fCss = mDataReader["Css"].ToString();
            fUrlLink = mDataReader["UrlLink"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);

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
public partial class DAShortCut : DAShortCutBase
{
    public DataSet USP_ShortCut_GetByShortTypeID(int ShortCutTypeID)
    {
        mCmd.CommandText = "USP_ShortCut_GetByShortTypeID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ShortCutTypeID", SqlDbType.Int).Value = ShortCutTypeID;
        ExecuteDataSet();
        return mDataSet;
    }
    
}
