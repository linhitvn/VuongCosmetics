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

public class DARecordTypeBase : TDatabase
{
    public Int32 fID;
    public String fRecordType;
    public String fTableName;
    public String fDescription;

    public DARecordTypeBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "RecordType";
        mKeyName = "ID";
    }
    public int USP_RecordType_Insert()
    {
        mCmd.CommandText = "USP_RecordType_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@RecordType", SqlDbType.NVarChar).Value = fRecordType;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = fTableName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;

        return Execute();
    }
    public int USP_RecordType_Insert(Int32 ID, String RecordType, String TableName, String Description)
    {
        mCmd.CommandText = "USP_RecordType_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@RecordType", SqlDbType.NVarChar).Value = RecordType;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = TableName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;

        return Execute();
    }

    public int USP_RecordType_Update()
    {
        mCmd.CommandText = "USP_RecordType_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@RecordType", SqlDbType.NVarChar).Value = fRecordType;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = fTableName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;

        return Execute();
    }
    public int USP_RecordType_Update(Int32 ID, String RecordType, String TableName, String Description)
    {
        mCmd.CommandText = "USP_RecordType_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@RecordType", SqlDbType.NVarChar).Value = RecordType;
        mCmd.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = TableName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;

        return Execute();
    }

    public int USP_RecordType_Delete(int ID)
    {
        mCmd.CommandText = "USP_RecordType_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_RecordType_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_RecordType_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_RecordType_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_RecordType_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_RecordType_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_RecordType_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_RecordType_GetByID(int ID)
    {
        mCmd.CommandText = "USP_RecordType_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_RecordType_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_RecordType_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_RecordType_Fetch()
    {
        return 0;
    }
    public bool USP_RecordType_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_RecordType_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fRecordType = mDataReader["RecordType"].ToString();
            fTableName = mDataReader["TableName"].ToString();
            fDescription = mDataReader["Description"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_RecordType_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_RecordType_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_RecordType_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_RecordType_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_RecordType_CheckDuplicate(string RecordType)
    {
        mCmd.CommandText = "USP_RecordType_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@RecordType", SqlDbType.VarChar).Value = RecordType;
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
            fRecordType = mDataReader["RecordType"].ToString();
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
public partial class DARecordType : DARecordTypeBase
{
    public SqlDataReader USP_RecordType_GetComboBox_ByTableName(string TableName)
    {
        mCmd.CommandText = "USP_RecordType_GetComboBox_ByTableName";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = TableName;
        ExecuteReader();
        return mDataReader;
    }
    
}
