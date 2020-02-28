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

public class DAUserMenuBase : TDatabase
{
    public Int32 fID;
    public String fUserMenuName;
    public String fUrl;
    public Int32 fParentID;
    public String fNote;
    public Int32 fPos;
    public Boolean fActive;
    public String fSeoDescription;
    public String fSeoTitle;
    public String fSeoKeyword;

    public DAUserMenuBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "UserMenu";
        mKeyName = "ID";
    }
    public int USP_UserMenu_Insert()
    {
        mCmd.CommandText = "USP_UserMenu_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@UserMenuName", SqlDbType.NVarChar).Value = fUserMenuName;
        mCmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = fUrl;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = fNote;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@SeoDescription", SqlDbType.NVarChar).Value = fSeoDescription;
        mCmd.Parameters.Add("@SeoTitle", SqlDbType.NVarChar).Value = fSeoTitle;
        mCmd.Parameters.Add("@SeoKeyword", SqlDbType.NVarChar).Value = fSeoKeyword;

        return Execute();
    }
    public int USP_UserMenu_Insert(Int32 ID, String UserMenuName, String Url, Int32 ParentID, String Note, Int32 Pos, Boolean Active, String SeoDescription, String SeoTitle, String SeoKeyword)
    {
        mCmd.CommandText = "USP_UserMenu_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@UserMenuName", SqlDbType.NVarChar).Value = UserMenuName;
        mCmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = Url;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = Note;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@SeoDescription", SqlDbType.NVarChar).Value = SeoDescription;
        mCmd.Parameters.Add("@SeoTitle", SqlDbType.NVarChar).Value = SeoTitle;
        mCmd.Parameters.Add("@SeoKeyword", SqlDbType.NVarChar).Value = SeoKeyword;

        return Execute();
    }

    public int USP_UserMenu_Update()
    {
        mCmd.CommandText = "USP_UserMenu_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@UserMenuName", SqlDbType.NVarChar).Value = fUserMenuName;
        mCmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = fUrl;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = fNote;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@SeoDescription", SqlDbType.NVarChar).Value = fSeoDescription;
        mCmd.Parameters.Add("@SeoTitle", SqlDbType.NVarChar).Value = fSeoTitle;
        mCmd.Parameters.Add("@SeoKeyword", SqlDbType.NVarChar).Value = fSeoKeyword;

        return Execute();
    }
    public int USP_UserMenu_Update(Int32 ID, String UserMenuName, String Url, Int32 ParentID, String Note, Int32 Pos, Boolean Active, String SeoDescription, String SeoTitle, String SeoKeyword)
    {
        mCmd.CommandText = "USP_UserMenu_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@UserMenuName", SqlDbType.NVarChar).Value = UserMenuName;
        mCmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = Url;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = Note;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@SeoDescription", SqlDbType.NVarChar).Value = SeoDescription;
        mCmd.Parameters.Add("@SeoTitle", SqlDbType.NVarChar).Value = SeoTitle;
        mCmd.Parameters.Add("@SeoKeyword", SqlDbType.NVarChar).Value = SeoKeyword;

        return Execute();
    }

    public int USP_UserMenu_Delete(int ID)
    {
        mCmd.CommandText = "USP_UserMenu_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_UserMenu_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_UserMenu_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_UserMenu_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_UserMenu_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_UserMenu_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_UserMenu_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_UserMenu_GetByID(int ID)
    {
        mCmd.CommandText = "USP_UserMenu_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_UserMenu_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_UserMenu_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_UserMenu_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_UserMenu_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_UserMenu_Fetch()
    {
        return 0;
    }
    public bool USP_UserMenu_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_UserMenu_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fUserMenuName = mDataReader["UserMenuName"].ToString();
            fUrl = mDataReader["Url"].ToString();
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fNote = mDataReader["Note"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fSeoDescription = mDataReader["SeoDescription"].ToString();
            fSeoTitle = mDataReader["SeoTitle"].ToString();
            fSeoKeyword = mDataReader["SeoKeyword"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_UserMenu_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_UserMenu_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
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
            fUserMenuName = mDataReader["UserMenuName"].ToString();
            fUrl = mDataReader["Url"].ToString();
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fNote = mDataReader["Note"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fSeoDescription = mDataReader["SeoDescription"].ToString();
            fSeoTitle = mDataReader["SeoTitle"].ToString();
            fSeoKeyword = mDataReader["SeoKeyword"].ToString();

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
public partial class DAUserMenu : DAUserMenuBase
{
}
