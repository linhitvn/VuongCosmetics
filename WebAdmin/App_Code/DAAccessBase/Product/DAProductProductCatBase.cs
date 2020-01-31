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

public class DAProductProductCatBase : TDatabase
{
    public Int32 fID;
    public Int32 fProductID;
    public Int32 fProductCatID;

    public DAProductProductCatBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "ProductProductCat";
        mKeyName = "ID";
    }
    public int USP_ProductProductCat_Insert()
    {
        mCmd.CommandText = "USP_ProductProductCat_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = fProductID;
        mCmd.Parameters.Add("@ProductCatID", SqlDbType.Int).Value = fProductCatID;

        return Execute();
    }
    public int USP_ProductProductCat_Insert(Int32 ID, Int32 ProductID, Int32 ProductCatID)
    {
        mCmd.CommandText = "USP_ProductProductCat_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        mCmd.Parameters.Add("@ProductCatID", SqlDbType.Int).Value = ProductCatID;

        return Execute();
    }

    public int USP_ProductProductCat_Update()
    {
        mCmd.CommandText = "USP_ProductProductCat_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = fProductID;
        mCmd.Parameters.Add("@ProductCatID", SqlDbType.Int).Value = fProductCatID;

        return Execute();
    }
    public int USP_ProductProductCat_Update(Int32 ID, Int32 ProductID, Int32 ProductCatID)
    {
        mCmd.CommandText = "USP_ProductProductCat_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        mCmd.Parameters.Add("@ProductCatID", SqlDbType.Int).Value = ProductCatID;

        return Execute();
    }

    public int USP_ProductProductCat_Delete(int ID)
    {
        mCmd.CommandText = "USP_ProductProductCat_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_ProductProductCat_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_ProductProductCat_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_ProductProductCat_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ProductProductCat_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ProductProductCat_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_ProductProductCat_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_ProductProductCat_GetByID(int ID)
    {
        mCmd.CommandText = "USP_ProductProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_ProductProductCat_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ProductProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_ProductProductCat_Fetch()
    {
        return 0;
    }
    public bool USP_ProductProductCat_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_ProductProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fProductID = Convert.ToInt32(mDataReader["ProductID"]);
            fProductCatID = Convert.ToInt32(mDataReader["ProductCatID"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_ProductProductCat_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_ProductProductCat_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_ProductProductCat_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_ProductProductCat_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_ProductProductCat_CheckDuplicate(string ProductID)
    {
        mCmd.CommandText = "USP_ProductProductCat_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID;
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
            fProductID = Convert.ToInt32(mDataReader["ProductID"]);
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
public partial class DAProductProductCat : DAProductProductCatBase
{
    public int USP_ProductProductCat_UpdateCustom(Int32 ProductID, string ProductCatIDs)
    {
        mCmd.CommandText = "USP_ProductProductCat_UpdateCustom";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        mCmd.Parameters.Add("@ProductCatIDs", SqlDbType.VarChar).Value = ProductCatIDs;

        return Execute();
    }
}
