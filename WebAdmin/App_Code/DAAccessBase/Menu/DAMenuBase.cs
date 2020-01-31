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

public class DAMenuBase : TDatabase
{
    public Int32 fID;
    public String fMenuName;
    public String fDescription;
    public Boolean fActive;

    public DAMenuBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Menu";
        mKeyName = "ID";
    }
    public int USP_Menu_Insert()
    {
        mCmd.CommandText = "USP_Menu_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = fMenuName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;

        return Execute();
    }
    public int USP_Menu_Insert(Int32 ID, String MenuName, String Description, Boolean Active)
    {
        mCmd.CommandText = "USP_Menu_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = MenuName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;

        return Execute();
    }

    public int USP_Menu_Update()
    {
        mCmd.CommandText = "USP_Menu_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = fMenuName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;

        return Execute();
    }
    public int USP_Menu_Update(Int32 ID, String MenuName, String Description, Boolean Active)
    {
        mCmd.CommandText = "USP_Menu_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = MenuName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;

        return Execute();
    }

    public int USP_Menu_Delete(int ID)
    {
        mCmd.CommandText = "USP_Menu_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Menu_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Menu_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Menu_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Menu_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Menu_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Menu_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Menu_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Menu_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Menu_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Menu_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Menu_Fetch()
    {
        return 0;
    }
    public bool USP_Menu_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Menu_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fMenuName = mDataReader["MenuName"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Menu_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Menu_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Menu_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Menu_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Menu_CheckDuplicate(string MenuName)
    {
        mCmd.CommandText = "USP_Menu_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@MenuName", SqlDbType.VarChar).Value = MenuName;
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
            fMenuName = mDataReader["MenuName"].ToString();
            fDescription = mDataReader["Description"].ToString();
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
public partial class DAMenu : DAMenuBase
{
}
