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

public class DALogTableBase : TDatabase
{
    public Int32 fID;
    public String fTableName;

    public DALogTableBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "LogTable";
        mKeyName = "ID";
    }
    public int USP_LogTable_Insert()
    {
        mCmd.CommandText = "USP_LogTable_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = fTableName;

        return Execute();
    }
    public int USP_LogTable_Insert(Int32 ID, String TableName)
    {
        mCmd.CommandText = "USP_LogTable_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = TableName;

        return Execute();
    }

    public int USP_LogTable_Update()
    {
        mCmd.CommandText = "USP_LogTable_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = fTableName;

        return Execute();
    }
    public int USP_LogTable_Update(Int32 ID, String TableName)
    {
        mCmd.CommandText = "USP_LogTable_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = TableName;

        return Execute();
    }

    public int USP_LogTable_Delete(int ID)
    {
        mCmd.CommandText = "USP_LogTable_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_LogTable_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_LogTable_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_LogTable_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_LogTable_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_LogTable_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_LogTable_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_LogTable_GetByID(int ID)
    {
        mCmd.CommandText = "USP_LogTable_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_LogTable_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_LogTable_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_LogTable_Fetch()
    {
        return 0;
    }
    public bool USP_LogTable_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_LogTable_GetByID";
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

    public SqlDataReader USP_LogTable_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_LogTable_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_LogTable_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_LogTable_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_LogTable_CheckDuplicate(string TableName)
    {
        mCmd.CommandText = "USP_LogTable_CheckDuplicate";
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

public partial class DALogTable : DALogTableBase
{
    public IDataReader USP_LogTable_OperationSearch(DateTime FromDate, DateTime ToDate, int Operation, String TableName)
    {
        mCmd.CommandText = "USP_LogTable_OperationSearch";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
        mCmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
        mCmd.Parameters.Add("@Operation", SqlDbType.TinyInt).Value = Operation;
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;

        return ExecuteReader();
    }


    public int FUNC_DELETE_LOG_FOR_TABLE(String TableName)
    {
        mCmd.CommandText = "FUNC_DELETE_LOG_FOR_TABLE";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;

        return Execute();
    }

    public int FUNC_CREATE_LOG_FOR_TABLE(String TableName)
    {
        mCmd.CommandText = "FUNC_CREATE_LOG_FOR_TABLE";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;

        return Execute();
    }


    public SqlDataReader USP_LogTable_GetDifferent(String TableName, int IDLog)
    {
        mCmd.CommandText = "USP_LogTable_GetDifferent";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;
        mCmd.Parameters.Add("@IDLog", SqlDbType.Int).Value = IDLog;

        return ExecuteReader();
    }
    //public SqlDataReader FUNC_GET_STATUS_TABLE_TRIGGER(String TableName)
    //{
    //    mCmd.CommandText = "FUNC_GET_STATUS_TABLE_TRIGGER";
    //    mCmd.Parameters.Clear();
    //    mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;

    //    return ExecuteReader();
    //}
    public DataSet FUNC_GET_STATUS_TABLE_TRIGGER(String TableName)
    {
        mCmd.CommandText = "FUNC_GET_STATUS_TABLE_TRIGGER";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;

        return ExecuteDataSet();
    }
    public int FUNC_CHANGE_STATUS_TABLE_TRIGGER(String TableName, Boolean Status)
    {
        mCmd.CommandText = "FUNC_CHANGE_STATUS_TABLE_TRIGGER";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;
        mCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;

        return Execute();
    }

    public SqlDataReader FUNC_GET_ALL_TABLE()
    {
        mCmd.CommandText = "FUNC_GET_ALL_TABLE";
        mCmd.Parameters.Clear();

        return ExecuteReader();
    }

    public int FUNC_CHECK_EXIST_IN_TABLE_LOG(String TableName)
    {
        mCmd.CommandText = "FUNC_CHECK_EXIST_IN_TABLE_LOG";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = TableName;

        return Execute();
    }

    public int USP_LogTable_CheckExist(String TableName)
    {
        mCmd.CommandText = "USP_LogTable_CheckExist";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = TableName;

        return Execute();
    }

    public SqlDataReader FUNC_GET_STATUS_TABLE_TRIGGER_ALL()
    {
        mCmd.CommandText = "FUNC_GET_STATUS_TABLE_TRIGGER_ALL";
        mCmd.Parameters.Clear();

        return ExecuteReader();
    }
    
    
}
