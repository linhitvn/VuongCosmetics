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

public class DAWishlistBase : TDatabase
{
    public Int32 fID;
    public Int32 fCustomerID;
    public Int32 fProductID;
    public DateTime fSysDate;

    public DAWishlistBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Wishlist";
        mKeyName = "ID";
    }
    public int USP_Wishlist_Insert()
    {
        mCmd.CommandText = "USP_Wishlist_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fCustomerID;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = fProductID;
        mCmd.Parameters.Add("@SysDate", SqlDbType.DateTime).Value = fSysDate;

        return Execute();
    }
    public int USP_Wishlist_Insert(Int32 ID, Int32 CustomerID, Int32 ProductID, DateTime SysDate)
    {
        mCmd.CommandText = "USP_Wishlist_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        mCmd.Parameters.Add("@SysDate", SqlDbType.DateTime).Value = SysDate;

        return Execute();
    }

    public int USP_Wishlist_Update()
    {
        mCmd.CommandText = "USP_Wishlist_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fCustomerID;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = fProductID;
        mCmd.Parameters.Add("@SysDate", SqlDbType.DateTime).Value = fSysDate;

        return Execute();
    }
    public int USP_Wishlist_Update(Int32 ID, Int32 CustomerID, Int32 ProductID, DateTime SysDate)
    {
        mCmd.CommandText = "USP_Wishlist_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        mCmd.Parameters.Add("@SysDate", SqlDbType.DateTime).Value = SysDate;

        return Execute();
    }

    public int USP_Wishlist_Delete(int ID)
    {
        mCmd.CommandText = "USP_Wishlist_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Wishlist_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Wishlist_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Wishlist_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Wishlist_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Wishlist_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Wishlist_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Wishlist_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Wishlist_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Wishlist_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Wishlist_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Wishlist_Fetch()
    {
        return 0;
    }
    public bool USP_Wishlist_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Wishlist_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fCustomerID = Convert.ToInt32(mDataReader["CustomerID"]);
            fProductID = Convert.ToInt32(mDataReader["ProductID"]);
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Wishlist_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Wishlist_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Wishlist_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Wishlist_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Wishlist_CheckDuplicate(string CustomerID)
    {
        mCmd.CommandText = "USP_Wishlist_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID;
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
            fCustomerID = Convert.ToInt32(mDataReader["CustomerID"]);
            fProductID = Convert.ToInt32(mDataReader["ProductID"]);
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
public partial class DAWishlist : DAWishlistBase
{
    public DataSet USP_Wishlist_GetByCustomerID(int CustomerID)
    {
        mCmd.CommandText = "USP_Wishlist_GetByCustomerID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        ExecuteDataSet();
        return mDataSet;
    }
    
}
