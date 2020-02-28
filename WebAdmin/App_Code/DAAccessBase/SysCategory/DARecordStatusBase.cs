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

public class DARecordStatusBase : TDatabase
{
    public Int32 fID;
    public String fRecordStatus;
    public String fTableName;
    public String fDescription;

    public DARecordStatusBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "RecordStatus";
        mKeyName = "ID";
    }
    public int USP_RecordStatus_Insert()
    {
        mCmd.CommandText = "USP_RecordStatus_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@RecordStatus", SqlDbType.NVarChar).Value = fRecordStatus;
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = fTableName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;

        return Execute();
    }
    public int USP_RecordStatus_Insert(Int32 ID, String RecordStatus, String TableName, String Description)
    {
        mCmd.CommandText = "USP_RecordStatus_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@RecordStatus", SqlDbType.NVarChar).Value = RecordStatus;
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;

        return Execute();
    }

    public int USP_RecordStatus_Update()
    {
        mCmd.CommandText = "USP_RecordStatus_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@RecordStatus", SqlDbType.NVarChar).Value = fRecordStatus;
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = fTableName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;

        return Execute();
    }
    public int USP_RecordStatus_Update(Int32 ID, String RecordStatus, String TableName, String Description)
    {
        mCmd.CommandText = "USP_RecordStatus_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@RecordStatus", SqlDbType.NVarChar).Value = RecordStatus;
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;

        return Execute();
    }

    public int USP_RecordStatus_Delete(int ID)
    {
        mCmd.CommandText = "USP_RecordStatus_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_RecordStatus_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_RecordStatus_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_RecordStatus_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_RecordStatus_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_RecordStatus_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_RecordStatus_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_RecordStatus_GetByID(int ID)
    {
        mCmd.CommandText = "USP_RecordStatus_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_RecordStatus_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_RecordStatus_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_RecordStatus_Fetch()
    {
        return 0;
    }
    public bool USP_RecordStatus_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_RecordStatus_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fRecordStatus = mDataReader["RecordStatus"].ToString();
            fTableName = mDataReader["TableName"].ToString();
            fDescription = mDataReader["Description"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_RecordStatus_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_RecordStatus_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_RecordStatus_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_RecordStatus_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_RecordStatus_CheckDuplicate(string RecordStatus)
    {
        mCmd.CommandText = "USP_RecordStatus_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@RecordStatus", SqlDbType.VarChar).Value = RecordStatus;
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
            fRecordStatus = mDataReader["RecordStatus"].ToString();
            fTableName = mDataReader["TableName"].ToString();
            fDescription = mDataReader["Description"].ToString();

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
public partial class DARecordStatus : DARecordStatusBase
{
    public SqlDataReader USP_RecordStatus_GetComboBox_ByTableName(string TableName)
    {
        mCmd.CommandText = "USP_RecordStatus_GetComboBox_ByTableName";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;
        ExecuteReader();
        return mDataReader;
    }
}
