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

public class DADiscountProductCatBase : TDatabase
{
    public Int32 fID;
    public Int32 fDiscountID;
    public Int32 fProductCatID;

    public DADiscountProductCatBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "DiscountProductCat";
        mKeyName = "ID";
    }
    public int USP_DiscountProductCat_Insert()
    {
        mCmd.CommandText = "USP_DiscountProductCat_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@DiscountID", SqlDbType.Int).Value = fDiscountID;
        mCmd.Parameters.Add("@ProductCatID", SqlDbType.Int).Value = fProductCatID;

        return Execute();
    }
    public int USP_DiscountProductCat_Insert(Int32 ID, Int32 DiscountID, Int32 ProductCatID)
    {
        mCmd.CommandText = "USP_DiscountProductCat_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@DiscountID", SqlDbType.Int).Value = DiscountID;
        mCmd.Parameters.Add("@ProductCatID", SqlDbType.Int).Value = ProductCatID;

        return Execute();
    }

    public int USP_DiscountProductCat_Update()
    {
        mCmd.CommandText = "USP_DiscountProductCat_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@DiscountID", SqlDbType.Int).Value = fDiscountID;
        mCmd.Parameters.Add("@ProductCatID", SqlDbType.Int).Value = fProductCatID;

        return Execute();
    }
    public int USP_DiscountProductCat_Update(Int32 ID, Int32 DiscountID, Int32 ProductCatID)
    {
        mCmd.CommandText = "USP_DiscountProductCat_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@DiscountID", SqlDbType.Int).Value = DiscountID;
        mCmd.Parameters.Add("@ProductCatID", SqlDbType.Int).Value = ProductCatID;

        return Execute();
    }

    public int USP_DiscountProductCat_Delete(int ID)
    {
        mCmd.CommandText = "USP_DiscountProductCat_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_DiscountProductCat_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_DiscountProductCat_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_DiscountProductCat_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_DiscountProductCat_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_DiscountProductCat_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_DiscountProductCat_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_DiscountProductCat_GetByID(int ID)
    {
        mCmd.CommandText = "USP_DiscountProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_DiscountProductCat_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_DiscountProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_DiscountProductCat_Fetch()
    {
        return 0;
    }
    public bool USP_DiscountProductCat_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_DiscountProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fDiscountID = Convert.ToInt32(mDataReader["DiscountID"]);
            fProductCatID = Convert.ToInt32(mDataReader["ProductCatID"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_DiscountProductCat_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_DiscountProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_DiscountProductCat_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_DiscountProductCat_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_DiscountProductCat_CheckDuplicate(string DiscountID)
    {
        mCmd.CommandText = "USP_DiscountProductCat_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@DiscountID", SqlDbType.VarChar).Value = DiscountID;
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
            fDiscountID = Convert.ToInt32(mDataReader["DiscountID"]);
            fProductCatID = Convert.ToInt32(mDataReader["ProductCatID"]);

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
public partial class DADiscountProductCat : DADiscountProductCatBase
{
    public int USP_DiscountProductCat_UpdateCustom(Int32 DiscountID, string ProductCatIDs)
    {
        mCmd.CommandText = "USP_DiscountProductCat_UpdateCustom";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@DiscountID", SqlDbType.Int).Value = DiscountID;
        mCmd.Parameters.Add("@ProductCatIDs", SqlDbType.VarChar).Value = ProductCatIDs;

        return Execute();
    }
}
