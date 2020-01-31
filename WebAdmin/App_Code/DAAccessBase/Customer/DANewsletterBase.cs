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

public class DANewsletterBase : TDatabase
{
    public Int32 fID;
    public String fCustomerName;
    public String fEmail;
    public DateTime fSysDate;

    public DANewsletterBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Newsletter";
        mKeyName = "ID";
    }
    public int USP_Newsletter_Insert()
    {
        mCmd.CommandText = "USP_Newsletter_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = fCustomerName;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;

        return Execute();
    }
    public int USP_Newsletter_Update()
    {
        mCmd.CommandText = "USP_Newsletter_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = fCustomerName;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;

        return Execute();
    }

    public int USP_Newsletter_Delete(int ID)
    {
        mCmd.CommandText = "USP_Newsletter_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Newsletter_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Newsletter_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Newsletter_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Newsletter_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Newsletter_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Newsletter_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Newsletter_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Newsletter_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Newsletter_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Newsletter_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Newsletter_Fetch()
    {
        return 0;
    }
    public bool USP_Newsletter_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Newsletter_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fCustomerName = mDataReader["CustomerName"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Newsletter_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Newsletter_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Newsletter_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Newsletter_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Newsletter_CheckDuplicate(string CustomerName)
    {
        mCmd.CommandText = "USP_Newsletter_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = CustomerName;
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
            fCustomerName = mDataReader["CustomerName"].ToString();
            fEmail = mDataReader["Email"].ToString();
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
public partial class DANewsletter : DANewsletterBase
{
}
