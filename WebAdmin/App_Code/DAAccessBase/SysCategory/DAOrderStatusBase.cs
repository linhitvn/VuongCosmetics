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

public class DAOrderStatusBase : TDatabase
{
    public Int32 fID;
    public String fOrderStatus;
    public String fDescription;
    public Int32 fPos;

    public DAOrderStatusBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "OrderStatus";
        mKeyName = "ID";
    }
    public int USP_OrderStatus_Insert()
    {
        mCmd.CommandText = "USP_OrderStatus_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar).Value = fOrderStatus;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;

        return Execute();
    }
    public int USP_OrderStatus_Insert(Int32 ID, String OrderStatus, String Description, Int32 Pos)
    {
        mCmd.CommandText = "USP_OrderStatus_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar).Value = OrderStatus;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;

        return Execute();
    }

    public int USP_OrderStatus_Update()
    {
        mCmd.CommandText = "USP_OrderStatus_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar).Value = fOrderStatus;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;

        return Execute();
    }
    public int USP_OrderStatus_Update(Int32 ID, String OrderStatus, String Description, Int32 Pos)
    {
        mCmd.CommandText = "USP_OrderStatus_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar).Value = OrderStatus;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;

        return Execute();
    }

    public int USP_OrderStatus_Delete(int ID)
    {
        mCmd.CommandText = "USP_OrderStatus_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_OrderStatus_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_OrderStatus_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_OrderStatus_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_OrderStatus_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_OrderStatus_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_OrderStatus_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_OrderStatus_GetByID(int ID)
    {
        mCmd.CommandText = "USP_OrderStatus_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_OrderStatus_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_OrderStatus_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_OrderStatus_Fetch()
    {
        return 0;
    }
    public bool USP_OrderStatus_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_OrderStatus_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fOrderStatus = mDataReader["OrderStatus"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_OrderStatus_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_OrderStatus_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_OrderStatus_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_OrderStatus_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_OrderStatus_CheckDuplicate(string OrderStatus)
    {
        mCmd.CommandText = "USP_OrderStatus_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@OrderStatus", SqlDbType.VarChar).Value = OrderStatus;
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
            fOrderStatus = mDataReader["OrderStatus"].ToString();
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
public partial class DAOrderStatus : DAOrderStatusBase
{
}
