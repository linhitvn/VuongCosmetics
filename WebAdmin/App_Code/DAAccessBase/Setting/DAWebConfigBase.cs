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

public class DAWebConfigBase : TDatabase
{
    public Int32 fConfigID;
    public String fConfigKey;
    public String fConfigValue;
    public String fDescription;

    public DAWebConfigBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "WebConfig";
        mKeyName = "ConfigID";
    }
    public int USP_WebConfig_Insert()
    {
        mCmd.CommandText = "USP_WebConfig_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = fConfigID;
        mCmd.Parameters.Add("@ConfigKey", SqlDbType.NVarChar).Value = fConfigKey;
        mCmd.Parameters.Add("@ConfigValue", SqlDbType.VarChar).Value = fConfigValue;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;

        return Execute();
    }
    public int USP_WebConfig_Insert(Int32 ConfigID, String ConfigKey, String ConfigValue, String Description)
    {
        mCmd.CommandText = "USP_WebConfig_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = ConfigID;
        mCmd.Parameters.Add("@ConfigKey", SqlDbType.NVarChar).Value = ConfigKey;
        mCmd.Parameters.Add("@ConfigValue", SqlDbType.VarChar).Value = ConfigValue;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;

        return Execute();
    }

    public int USP_WebConfig_Update()
    {
        mCmd.CommandText = "USP_WebConfig_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = fConfigID;
        mCmd.Parameters.Add("@ConfigKey", SqlDbType.NVarChar).Value = fConfigKey;
        mCmd.Parameters.Add("@ConfigValue", SqlDbType.VarChar).Value = fConfigValue;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;

        return Execute();
    }
    public int USP_WebConfig_Update(Int32 ConfigID, String ConfigKey, String ConfigValue, String Description)
    {
        mCmd.CommandText = "USP_WebConfig_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = ConfigID;
        mCmd.Parameters.Add("@ConfigKey", SqlDbType.NVarChar).Value = ConfigKey;
        mCmd.Parameters.Add("@ConfigValue", SqlDbType.VarChar).Value = ConfigValue;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;

        return Execute();
    }

    public int USP_WebConfig_Delete(int ConfigID)
    {
        mCmd.CommandText = "USP_WebConfig_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = ConfigID;
        return Execute();
    }

    public int USP_WebConfig_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = fConfigID;
        return Execute();
    }

    public DataSet USP_WebConfig_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_WebConfig_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_WebConfig_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_WebConfig_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_WebConfig_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_WebConfig_GetByID(int ConfigID)
    {
        mCmd.CommandText = "USP_WebConfig_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = ConfigID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_WebConfig_GetByID_Reader(int ConfigID)
    {
        mCmd.CommandText = "USP_WebConfig_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = ConfigID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_WebConfig_Fetch()
    {
        return 0;
    }
    public bool USP_WebConfig_GetFullID(int ConfigID)
    {
        mCmd.CommandText = "USP_WebConfig_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = ConfigID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fConfigID = Convert.ToInt32(mDataReader["ConfigID"]);
            fConfigKey = mDataReader["ConfigKey"].ToString();
            fConfigValue = mDataReader["ConfigValue"].ToString();
            fDescription = mDataReader["Description"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_WebConfig_GetFullID_Reader(int ConfigID)
    {
        mCmd.CommandText = "USP_WebConfig_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = ConfigID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_WebConfig_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_WebConfig_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_WebConfig_CheckDuplicate(string ConfigKey)
    {
        mCmd.CommandText = "USP_WebConfig_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigKey", SqlDbType.VarChar).Value = ConfigKey;
        //ExecuteReader();
        return Execute();
    }

    public int USP_NewKey()
    {
        fConfigID = USP_GetKey();
        return fConfigID;
    }

    public bool Fetch_Reader(bool bClose)
    {
        if (mDataReader.IsClosed)
            return false;
        if (mDataReader.Read())
        {
            fConfigID = Convert.ToInt32(mDataReader["ConfigID"]);
            fConfigKey = mDataReader["ConfigKey"].ToString();
            fConfigValue = mDataReader["ConfigValue"].ToString();
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
public partial class DAWebConfig : DAWebConfigBase
{
    public int USP_WebConfig_UpdateListConfigValue(int ConfigID, string ConfigValue)
    {
        mCmd.CommandText = "USP_WebConfig_UpdateListConfigValue";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ConfigID", SqlDbType.Int).Value = ConfigID;
        mCmd.Parameters.Add("@ConfigValue", SqlDbType.VarChar).Value = ConfigValue;

        return Execute();
    }
}
