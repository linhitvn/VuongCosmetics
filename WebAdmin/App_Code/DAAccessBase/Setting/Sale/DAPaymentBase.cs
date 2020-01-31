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

public class DAPaymentBase : TDatabase
{
    public Int32 fID;
    public String fPayment;
    public String fDescription;
    public Int32 fPos;

    public DAPaymentBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Payment";
        mKeyName = "ID";
    }
    public int USP_Payment_Insert()
    {
        mCmd.CommandText = "USP_Payment_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Payment", SqlDbType.NVarChar).Value = fPayment;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;

        return Execute();
    }
    public int USP_Payment_Insert(Int32 ID, String Payment, String Description, Int32 Pos)
    {
        mCmd.CommandText = "USP_Payment_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Payment", SqlDbType.NVarChar).Value = Payment;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;

        return Execute();
    }

    public int USP_Payment_Update()
    {
        mCmd.CommandText = "USP_Payment_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Payment", SqlDbType.NVarChar).Value = fPayment;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;

        return Execute();
    }
    public int USP_Payment_Update(Int32 ID, String Payment, String Description, Int32 Pos)
    {
        mCmd.CommandText = "USP_Payment_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Payment", SqlDbType.NVarChar).Value = Payment;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;

        return Execute();
    }

    public int USP_Payment_Delete(int ID)
    {
        mCmd.CommandText = "USP_Payment_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Payment_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Payment_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Payment_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Payment_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Payment_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Payment_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Payment_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Payment_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Payment_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Payment_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Payment_Fetch()
    {
        return 0;
    }
    public bool USP_Payment_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Payment_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fPayment = mDataReader["Payment"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Payment_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Payment_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Payment_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Payment_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Payment_CheckDuplicate(string Payment)
    {
        mCmd.CommandText = "USP_Payment_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@Payment", SqlDbType.VarChar).Value = Payment;
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
            fPayment = mDataReader["Payment"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);

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
public partial class DAPayment : DAPaymentBase
{
}
