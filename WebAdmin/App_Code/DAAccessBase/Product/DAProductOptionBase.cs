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

public class DAProductOptionBase : TDatabase
{
    public Int32 fID;
    public String fProductOption;
    public String fValue;
    public Int32 fProductOptionGroupID;

    public DAProductOptionBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "ProductOption";
        mKeyName = "ID";
    }
    public int USP_ProductOption_Insert()
    {
        mCmd.CommandText = "USP_ProductOption_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProductOption", SqlDbType.NVarChar).Value = fProductOption;
        mCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = fValue;
        mCmd.Parameters.Add("@ProductOptionGroupID", SqlDbType.Int).Value = fProductOptionGroupID;

        return Execute();
    }
    public int USP_ProductOption_Insert(Int32 ID, String ProductOption, String Value, Int32 ProductOptionGroupID)
    {
        mCmd.CommandText = "USP_ProductOption_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ProductOption", SqlDbType.NVarChar).Value = ProductOption;
        mCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = Value;
        mCmd.Parameters.Add("@ProductOptionGroupID", SqlDbType.Int).Value = ProductOptionGroupID;

        return Execute();
    }

    public int USP_ProductOption_Update()
    {
        mCmd.CommandText = "USP_ProductOption_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProductOption", SqlDbType.NVarChar).Value = fProductOption;
        mCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = fValue;
        mCmd.Parameters.Add("@ProductOptionGroupID", SqlDbType.Int).Value = fProductOptionGroupID;

        return Execute();
    }
    public int USP_ProductOption_Update(Int32 ID, String ProductOption, String Value, Int32 ProductOptionGroupID)
    {
        mCmd.CommandText = "USP_ProductOption_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ProductOption", SqlDbType.NVarChar).Value = ProductOption;
        mCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = Value;
        mCmd.Parameters.Add("@ProductOptionGroupID", SqlDbType.Int).Value = ProductOptionGroupID;

        return Execute();
    }

    public int USP_ProductOption_Delete(int ID)
    {
        mCmd.CommandText = "USP_ProductOption_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_ProductOption_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_ProductOption_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_ProductOption_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ProductOption_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ProductOption_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ProductOption_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_ProductOption_GetByID(int ID)
    {
        mCmd.CommandText = "USP_ProductOption_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_ProductOption_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ProductOption_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_ProductOption_Fetch()
    {
        return 0;
    }
    public bool USP_ProductOption_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_ProductOption_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fProductOption = mDataReader["ProductOption"].ToString();
            fValue = mDataReader["Value"].ToString();
            fProductOptionGroupID = Convert.ToInt32(mDataReader["ProductOptionGroupID"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_ProductOption_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ProductOption_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ProductOption_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_ProductOption_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_ProductOption_CheckDuplicate(string ProductOption)
    {
        mCmd.CommandText = "USP_ProductOption_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProductOption", SqlDbType.VarChar).Value = ProductOption;
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
            fProductOption = mDataReader["ProductOption"].ToString();
            fValue = mDataReader["Value"].ToString();
            fProductOptionGroupID = Convert.ToInt32(mDataReader["ProductOptionGroupID"]);

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
public partial class DAProductOption : DAProductOptionBase
{
}
