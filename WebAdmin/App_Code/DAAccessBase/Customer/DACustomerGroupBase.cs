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

public class DACustomerGroupBase : TDatabase
{
    public Int32 fID;
    public String fCustomerGroup;
    public String fDescription;

    public DACustomerGroupBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "CustomerGroup";
        mKeyName = "ID";
    }
    public int USP_CustomerGroup_Insert()
    {
        mCmd.CommandText = "USP_CustomerGroup_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@CustomerGroup", SqlDbType.NVarChar).Value = fCustomerGroup;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;

        return Execute();
    }
    public int USP_CustomerGroup_Insert(Int32 ID, String CustomerGroup, String Description)
    {
        mCmd.CommandText = "USP_CustomerGroup_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@CustomerGroup", SqlDbType.NVarChar).Value = CustomerGroup;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;

        return Execute();
    }

    public int USP_CustomerGroup_Update()
    {
        mCmd.CommandText = "USP_CustomerGroup_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@CustomerGroup", SqlDbType.NVarChar).Value = fCustomerGroup;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;

        return Execute();
    }
    public int USP_CustomerGroup_Update(Int32 ID, String CustomerGroup, String Description)
    {
        mCmd.CommandText = "USP_CustomerGroup_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@CustomerGroup", SqlDbType.NVarChar).Value = CustomerGroup;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;

        return Execute();
    }

    public int USP_CustomerGroup_Delete(int ID)
    {
        mCmd.CommandText = "USP_CustomerGroup_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_CustomerGroup_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_CustomerGroup_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_CustomerGroup_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_CustomerGroup_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_CustomerGroup_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_CustomerGroup_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_CustomerGroup_GetByID(int ID)
    {
        mCmd.CommandText = "USP_CustomerGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_CustomerGroup_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_CustomerGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_CustomerGroup_Fetch()
    {
        return 0;
    }
    public bool USP_CustomerGroup_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_CustomerGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fCustomerGroup = mDataReader["CustomerGroup"].ToString();
            fDescription = mDataReader["Description"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_CustomerGroup_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_CustomerGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_CustomerGroup_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_CustomerGroup_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_CustomerGroup_CheckDuplicate(string CustomerGroup)
    {
        mCmd.CommandText = "USP_CustomerGroup_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CustomerGroup", SqlDbType.VarChar).Value = CustomerGroup;
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
            fCustomerGroup = mDataReader["CustomerGroup"].ToString();
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
public partial class DACustomerGroup : DACustomerGroupBase
{
}
