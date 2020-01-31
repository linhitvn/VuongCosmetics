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

public class DAMenuItemBase : TDatabase
{
    public Int32 fID;
    public String fMenuItem;
    public Int32 fParentID;
    public String fUrl;
    public String fUrlRewrite;
    public Int32 fMenuID;
    public Int32 fPos;
    public Boolean fActive;
    public String fImg;
    public String fCss;

    public DAMenuItemBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "MenuItem";
        mKeyName = "ID";
    }
    public int USP_MenuItem_Insert()
    {
        mCmd.CommandText = "USP_MenuItem_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@MenuItem", SqlDbType.NVarChar).Value = fMenuItem;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = fUrl;
        mCmd.Parameters.Add("@UrlRewrite", SqlDbType.VarChar).Value = fUrlRewrite;
        mCmd.Parameters.Add("@MenuID", SqlDbType.Int).Value = fMenuID;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Img", SqlDbType.NVarChar).Value = fImg;
        mCmd.Parameters.Add("@Css", SqlDbType.VarChar).Value = fCss;

        return Execute();
    }
    public int USP_MenuItem_Insert(Int32 ID, String MenuItem, Int32 ParentID, String Url, String UrlRewrite, Int32 MenuID, Int32 Pos, Boolean Active, String Img, String Css)
    {
        mCmd.CommandText = "USP_MenuItem_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@MenuItem", SqlDbType.NVarChar).Value = MenuItem;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = Url;
        mCmd.Parameters.Add("@UrlRewrite", SqlDbType.VarChar).Value = UrlRewrite;
        mCmd.Parameters.Add("@MenuID", SqlDbType.Int).Value = MenuID;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Img", SqlDbType.NVarChar).Value = Img;
        mCmd.Parameters.Add("@Css", SqlDbType.VarChar).Value = Css;

        return Execute();
    }

    public int USP_MenuItem_Update()
    {
        mCmd.CommandText = "USP_MenuItem_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@MenuItem", SqlDbType.NVarChar).Value = fMenuItem;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = fUrl;
        mCmd.Parameters.Add("@UrlRewrite", SqlDbType.VarChar).Value = fUrlRewrite;
        mCmd.Parameters.Add("@MenuID", SqlDbType.Int).Value = fMenuID;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Img", SqlDbType.NVarChar).Value = fImg;
        mCmd.Parameters.Add("@Css", SqlDbType.VarChar).Value = fCss;

        return Execute();
    }
    public int USP_MenuItem_Update(Int32 ID, String MenuItem, Int32 ParentID, String Url, String UrlRewrite, Int32 MenuID, Int32 Pos, Boolean Active, String Img, String Css)
    {
        mCmd.CommandText = "USP_MenuItem_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@MenuItem", SqlDbType.NVarChar).Value = MenuItem;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = Url;
        mCmd.Parameters.Add("@UrlRewrite", SqlDbType.VarChar).Value = UrlRewrite;
        mCmd.Parameters.Add("@MenuID", SqlDbType.Int).Value = MenuID;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Img", SqlDbType.NVarChar).Value = Img;
        mCmd.Parameters.Add("@Css", SqlDbType.VarChar).Value = Css;

        return Execute();
    }

    public int USP_MenuItem_Delete(int ID)
    {
        mCmd.CommandText = "USP_MenuItem_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_MenuItem_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_MenuItem_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_MenuItem_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_MenuItem_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_MenuItem_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_MenuItem_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_MenuItem_GetByID(int ID)
    {
        mCmd.CommandText = "USP_MenuItem_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_MenuItem_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_MenuItem_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_MenuItem_Fetch()
    {
        return 0;
    }
    public bool USP_MenuItem_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_MenuItem_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fMenuItem = mDataReader["MenuItem"].ToString();
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fUrl = mDataReader["Url"].ToString();
            fUrlRewrite = mDataReader["UrlRewrite"].ToString();
            fMenuID = Convert.ToInt32(mDataReader["MenuID"]);
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fImg = mDataReader["Img"].ToString();
            fCss = mDataReader["Css"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_MenuItem_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_MenuItem_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_MenuItem_GetDataForComboBox(int ID = 0)
    {
        mCmd.CommandText = "USP_MenuItem_GetDataForComboBox";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }


    public int USP_MenuItem_CheckDuplicate(string MenuItem)
    {
        mCmd.CommandText = "USP_MenuItem_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@MenuItem", SqlDbType.VarChar).Value = MenuItem;
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
            fMenuItem = mDataReader["MenuItem"].ToString();
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fUrl = mDataReader["Url"].ToString();
            fUrlRewrite = mDataReader["UrlRewrite"].ToString();
            fMenuID = Convert.ToInt32(mDataReader["MenuID"]);
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fImg = mDataReader["Img"].ToString();
            fCss = mDataReader["Css"].ToString();

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
public partial class DAMenuItem : DAMenuItemBase
{
    public DataSet USP_MenuItem_GetForTree()
    {
        mCmd.CommandText = "USP_MenuItem_GetForTree";
        mCmd.Parameters.Clear();
        ExecuteDataSet();
        return mDataSet;
    }
}
