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

public class DALogTableAllowBase : TDatabase
{
    public Int32 fID;
    public String fTableName;

    public DALogTableAllowBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "LogTableAllow";
        mKeyName = "ID";
    }
    public int USP_LogTableAllow_Insert()
    {
        mCmd.CommandText = "USP_LogTableAllow_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = fTableName;

        return Execute();
    }
    public int USP_LogTableAllow_Insert(Int32 ID, String TableName)
    {
        mCmd.CommandText = "USP_LogTableAllow_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = TableName;

        return Execute();
    }

    public int USP_LogTableAllow_Update()
    {
        mCmd.CommandText = "USP_LogTableAllow_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = fTableName;

        return Execute();
    }
    public int USP_LogTableAllow_Update(Int32 ID, String TableName)
    {
        mCmd.CommandText = "USP_LogTableAllow_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = TableName;

        return Execute();
    }

    public int USP_LogTableAllow_Delete(int ID)
    {
        mCmd.CommandText = "USP_LogTableAllow_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_LogTableAllow_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_LogTableAllow_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_LogTableAllow_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_LogTableAllow_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_LogTableAllow_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_LogTableAllow_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_LogTableAllow_GetByID(int ID)
    {
        mCmd.CommandText = "USP_LogTableAllow_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_LogTableAllow_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_LogTableAllow_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_LogTableAllow_Fetch()
    {
        return 0;
    }
    public bool USP_LogTableAllow_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_LogTableAllow_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fTableName = mDataReader["TableName"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_LogTableAllow_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_LogTableAllow_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_LogTableAllow_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_LogTableAllow_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_LogTableAllow_CheckDuplicate(string TableName)
    {
        mCmd.CommandText = "USP_LogTableAllow_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;
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
            fTableName = mDataReader["TableName"].ToString();

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

public partial class DALogTableAllow : DALogTableAllowBase
{

    public int USP_LogTableAllow_CheckExistBelongToLogTable(int LogTableAllowID)
    {
        mCmd.CommandText = "USP_LogTableAllow_CheckExistBelongToLogTable";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@LogTableAllowID", SqlDbType.Int).Value = LogTableAllowID;
        return Execute();
    }

    public SqlDataReader USP_LogTableAllow_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_LogTableAllow_GetDataForComboBox";
        mCmd.Parameters.Clear();
        //mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        //mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }
}
