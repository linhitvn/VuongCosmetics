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

public class DAFeedBackReplyBase : TDatabase
{
    public Int32 fID;
    public String fContent;
    public DateTime fSysDate;
    public String fOperator;
    public Int32 fFeedBackID;

    public DAFeedBackReplyBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "FeedBackReply";
        mKeyName = "ID";
    }
    public int USP_FeedBackReply_Insert()
    {
        mCmd.CommandText = "USP_FeedBackReply_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = fContent;
        mCmd.Parameters.Add("@SysDate", SqlDbType.DateTime).Value = fSysDate;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;
        mCmd.Parameters.Add("@FeedBackID", SqlDbType.Int).Value = fFeedBackID;

        return Execute();
    }
    public int USP_FeedBackReply_Insert(Int32 ID, String Content, DateTime SysDate, String Operator, Int32 FeedBackID)
    {
        mCmd.CommandText = "USP_FeedBackReply_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = Content;
        mCmd.Parameters.Add("@SysDate", SqlDbType.DateTime).Value = SysDate;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = Operator;
        mCmd.Parameters.Add("@FeedBackID", SqlDbType.Int).Value = FeedBackID;

        return Execute();
    }

    public int USP_FeedBackReply_Update()
    {
        mCmd.CommandText = "USP_FeedBackReply_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = fContent;
        mCmd.Parameters.Add("@SysDate", SqlDbType.DateTime).Value = fSysDate;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;
        mCmd.Parameters.Add("@FeedBackID", SqlDbType.Int).Value = fFeedBackID;

        return Execute();
    }
    public int USP_FeedBackReply_Update(Int32 ID, String Content, DateTime SysDate, String Operator, Int32 FeedBackID)
    {
        mCmd.CommandText = "USP_FeedBackReply_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = Content;
        mCmd.Parameters.Add("@SysDate", SqlDbType.DateTime).Value = SysDate;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = Operator;
        mCmd.Parameters.Add("@FeedBackID", SqlDbType.Int).Value = FeedBackID;

        return Execute();
    }

    public int USP_FeedBackReply_Delete(int ID)
    {
        mCmd.CommandText = "USP_FeedBackReply_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_FeedBackReply_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_FeedBackReply_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_FeedBackReply_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_FeedBackReply_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_FeedBackReply_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_FeedBackReply_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_FeedBackReply_GetByID(int ID)
    {
        mCmd.CommandText = "USP_FeedBackReply_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_FeedBackReply_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_FeedBackReply_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_FeedBackReply_Fetch()
    {
        return 0;
    }
    public bool USP_FeedBackReply_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_FeedBackReply_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fContent = mDataReader["Content"].ToString();
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);
            fOperator = mDataReader["Operator"].ToString();
            fFeedBackID = Convert.ToInt32(mDataReader["FeedBackID"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_FeedBackReply_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_FeedBackReply_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_FeedBackReply_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_FeedBackReply_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_FeedBackReply_CheckDuplicate(string Content)
    {
        mCmd.CommandText = "USP_FeedBackReply_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@Content", SqlDbType.VarChar).Value = Content;
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
            fContent = mDataReader["Content"].ToString();
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);
            fOperator = mDataReader["Operator"].ToString();
            fFeedBackID = Convert.ToInt32(mDataReader["FeedBackID"]);

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
public partial class DAFeedBackReply : DAFeedBackReplyBase
{
    public SqlDataReader USP_FeedBackReply_GetByFeedBackID(int FeedBackID)
    {
        mCmd.CommandText = "USP_FeedBackReply_GetByFeedBackID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FeedBackID", SqlDbType.Int).Value = FeedBackID;
        ExecuteReader();
        return mDataReader;
    }
    
}
