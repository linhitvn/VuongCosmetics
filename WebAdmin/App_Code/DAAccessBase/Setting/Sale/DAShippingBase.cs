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

public class DAShippingBase : TDatabase
{
    public Int32 fID;
    public String fShipping;
    public String fDescription;
    public Int32 fPos;

    public DAShippingBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Shipping";
        mKeyName = "ID";
    }
    public int USP_Shipping_Insert()
    {
        mCmd.CommandText = "USP_Shipping_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Shipping", SqlDbType.NVarChar).Value = fShipping;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;

        return Execute();
    }
    public int USP_Shipping_Insert(Int32 ID, String Shipping, String Description, Int32 Pos)
    {
        mCmd.CommandText = "USP_Shipping_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Shipping", SqlDbType.NVarChar).Value = Shipping;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;

        return Execute();
    }

    public int USP_Shipping_Update()
    {
        mCmd.CommandText = "USP_Shipping_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@Shipping", SqlDbType.NVarChar).Value = fShipping;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;

        return Execute();
    }
    public int USP_Shipping_Update(Int32 ID, String Shipping, String Description, Int32 Pos)
    {
        mCmd.CommandText = "USP_Shipping_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Shipping", SqlDbType.NVarChar).Value = Shipping;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;

        return Execute();
    }

    public int USP_Shipping_Delete(int ID)
    {
        mCmd.CommandText = "USP_Shipping_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Shipping_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Shipping_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Shipping_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Shipping_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Shipping_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Shipping_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Shipping_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Shipping_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Shipping_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Shipping_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Shipping_Fetch()
    {
        return 0;
    }
    public bool USP_Shipping_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Shipping_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fShipping = mDataReader["Shipping"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Shipping_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Shipping_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Shipping_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Shipping_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Shipping_CheckDuplicate(string Shipping)
    {
        mCmd.CommandText = "USP_Shipping_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@Shipping", SqlDbType.VarChar).Value = Shipping;
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
            fShipping = mDataReader["Shipping"].ToString();
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
public partial class DAShipping : DAShippingBase
{
}
