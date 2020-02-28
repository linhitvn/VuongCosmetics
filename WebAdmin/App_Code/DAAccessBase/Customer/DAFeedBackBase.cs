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

public class DAFeedBackBase : TDatabase
{
    public Int32 fID;
    public String fFeedBack;
    public String fContent;
    public String fName;
    public String fAddress;
    public String fEmail;
    public String fPhone;
    public Boolean fisRead;
    public DateTime fSysDate;

    public DAFeedBackBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "FeedBack";
        mKeyName = "ID";
    }
    public int USP_FeedBack_Insert()
    {
        mCmd.CommandText = "USP_FeedBack_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@FeedBack", SqlDbType.NVarChar).Value = fFeedBack;
        mCmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = fContent;
        mCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = fName;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = fAddress;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = fPhone;
        mCmd.Parameters.Add("@isRead", SqlDbType.Bit).Value = fisRead;

        return Execute();
    }

    public int USP_FeedBack_Update()
    {
        mCmd.CommandText = "USP_FeedBack_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@FeedBack", SqlDbType.NVarChar).Value = fFeedBack;
        mCmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = fContent;
        mCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = fName;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = fAddress;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = fPhone;
        mCmd.Parameters.Add("@isRead", SqlDbType.Bit).Value = fisRead;

        return Execute();
    }

    public int USP_FeedBack_Delete(int ID)
    {
        mCmd.CommandText = "USP_FeedBack_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_FeedBack_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_FeedBack_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_FeedBack_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_FeedBack_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_FeedBack_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_FeedBack_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_FeedBack_GetByID(int ID)
    {
        mCmd.CommandText = "USP_FeedBack_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_FeedBack_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_FeedBack_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_FeedBack_Fetch()
    {
        return 0;
    }
    public bool USP_FeedBack_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_FeedBack_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fFeedBack = mDataReader["FeedBack"].ToString();
            fContent = mDataReader["Content"].ToString();
            fName = mDataReader["Name"].ToString();
            fAddress = mDataReader["Address"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fPhone = mDataReader["Phone"].ToString();
            fisRead = Convert.ToBoolean(mDataReader["isRead"]);
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_FeedBack_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_FeedBack_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_FeedBack_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_FeedBack_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_FeedBack_CheckDuplicate(string FeedBack)
    {
        mCmd.CommandText = "USP_FeedBack_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FeedBack", SqlDbType.VarChar).Value = FeedBack;
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
            fFeedBack = mDataReader["FeedBack"].ToString();
            fContent = mDataReader["Content"].ToString();
            fName = mDataReader["Name"].ToString();
            fAddress = mDataReader["Address"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fPhone = mDataReader["Phone"].ToString();
            fisRead = Convert.ToBoolean(mDataReader["isRead"]);
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);

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
public partial class DAFeedBack : DAFeedBackBase
{
    public int USP_FeedBack_Update_IsRead(int ID)
    {
        mCmd.CommandText = "USP_FeedBack_Update_IsRead";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

        return Execute();
    }
    public SqlDataReader USP_FeedBack_GetAll_NotRead()
    {
        mCmd.CommandText = "USP_FeedBack_GetAll_NotRead";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }
}
