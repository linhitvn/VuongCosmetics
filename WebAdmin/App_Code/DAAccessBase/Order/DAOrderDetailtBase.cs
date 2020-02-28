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

public class DAOrderDetailtBase : TDatabase
{
    public Int32 fID;
    public Int32 fOrdersID;
    public String fProductCode;
    public String fProductName;
    public Int32 fProductID;
    public String fUnitName;
    public Int32 fPrice;
    public Int32 fQuatity;
    public Int32 fVAT;
    public Int32 fTotalPrice;

    public DAOrderDetailtBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "OrderDetailt";
        mKeyName = "ID";
    }
    public int USP_OrderDetailt_Insert()
    {
        mCmd.CommandText = "USP_OrderDetailt_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@OrdersID", SqlDbType.Int).Value = fOrdersID;
        mCmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = fProductCode;
        mCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = fProductName;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = fProductID;
        mCmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = fUnitName;
        mCmd.Parameters.Add("@Price", SqlDbType.Int).Value = fPrice;
        mCmd.Parameters.Add("@Quatity", SqlDbType.Int).Value = fQuatity;
        mCmd.Parameters.Add("@VAT", SqlDbType.Int).Value = fVAT;
        mCmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = fTotalPrice;

        return Execute();
    }
    public int USP_OrderDetailt_Insert(Int32 ID, Int32 OrdersID, String ProductCode, String ProductName, Int32 ProductID, String UnitName, Int32 Price, Int32 Quatity, Int32 VAT, Int32 TotalPrice)
    {
        mCmd.CommandText = "USP_OrderDetailt_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@OrdersID", SqlDbType.Int).Value = OrdersID;
        mCmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = ProductCode;
        mCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = ProductName;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        mCmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = UnitName;
        mCmd.Parameters.Add("@Price", SqlDbType.Int).Value = Price;
        mCmd.Parameters.Add("@Quatity", SqlDbType.Int).Value = Quatity;
        mCmd.Parameters.Add("@VAT", SqlDbType.Int).Value = VAT;
        mCmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = TotalPrice;

        return Execute();
    }

    public int USP_OrderDetailt_Update()
    {
        mCmd.CommandText = "USP_OrderDetailt_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@OrdersID", SqlDbType.Int).Value = fOrdersID;
        mCmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = fProductCode;
        mCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = fProductName;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = fProductID;
        mCmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = fUnitName;
        mCmd.Parameters.Add("@Price", SqlDbType.Int).Value = fPrice;
        mCmd.Parameters.Add("@Quatity", SqlDbType.Int).Value = fQuatity;
        mCmd.Parameters.Add("@VAT", SqlDbType.Int).Value = fVAT;
        mCmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = fTotalPrice;

        return Execute();
    }
    public int USP_OrderDetailt_Update(Int32 ID, Int32 OrdersID, String ProductCode, String ProductName, Int32 ProductID, String UnitName, Int32 Price, Int32 Quatity, Int32 VAT, Int32 TotalPrice)
    {
        mCmd.CommandText = "USP_OrderDetailt_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@OrdersID", SqlDbType.Int).Value = OrdersID;
        mCmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = ProductCode;
        mCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = ProductName;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        mCmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = UnitName;
        mCmd.Parameters.Add("@Price", SqlDbType.Int).Value = Price;
        mCmd.Parameters.Add("@Quatity", SqlDbType.Int).Value = Quatity;
        mCmd.Parameters.Add("@VAT", SqlDbType.Int).Value = VAT;
        mCmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = TotalPrice;

        return Execute();
    }

    public int USP_OrderDetailt_Delete(int ID)
    {
        mCmd.CommandText = "USP_OrderDetailt_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_OrderDetailt_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_OrderDetailt_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_OrderDetailt_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_OrderDetailt_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_OrderDetailt_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_OrderDetailt_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_OrderDetailt_GetByID(int ID)
    {
        mCmd.CommandText = "USP_OrderDetailt_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_OrderDetailt_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_OrderDetailt_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_OrderDetailt_Fetch()
    {
        return 0;
    }
    public bool USP_OrderDetailt_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_OrderDetailt_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fOrdersID = Convert.ToInt32(mDataReader["OrdersID"]);
            fProductCode = mDataReader["ProductCode"].ToString();
            fProductName = mDataReader["ProductName"].ToString();
            fProductID = Convert.ToInt32(mDataReader["ProductID"]);
            fUnitName = mDataReader["UnitName"].ToString();
            fPrice = Convert.ToInt32(mDataReader["Price"]);
            fQuatity = Convert.ToInt32(mDataReader["Quatity"]);
            fVAT = Convert.ToInt32(mDataReader["VAT"]);
            fTotalPrice = Convert.ToInt32(mDataReader["TotalPrice"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_OrderDetailt_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_OrderDetailt_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_OrderDetailt_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_OrderDetailt_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_OrderDetailt_CheckDuplicate(string OrdersID)
    {
        mCmd.CommandText = "USP_OrderDetailt_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@OrdersID", SqlDbType.VarChar).Value = OrdersID;
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
            fOrdersID = Convert.ToInt32(mDataReader["OrdersID"]);
            fProductCode = mDataReader["ProductCode"].ToString();
            fProductName = mDataReader["ProductName"].ToString();
            fProductID = Convert.ToInt32(mDataReader["ProductID"]);
            fUnitName = mDataReader["UnitName"].ToString();
            fPrice = Convert.ToInt32(mDataReader["Price"]);
            fQuatity = Convert.ToInt32(mDataReader["Quatity"]);
            fVAT = Convert.ToInt32(mDataReader["VAT"]);
            fTotalPrice = Convert.ToInt32(mDataReader["TotalPrice"]);

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
public partial class DAOrderDetailt : DAOrderDetailtBase
{

    public DataSet USP_OrderDetailt_GetByOrderID(int OrderID)
    {
        mCmd.CommandText = "USP_OrderDetailt_GetByOrderID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }


    public int USP_OrderDetailt_UpdateQuatity(int ID, int Quatity)
    {
        mCmd.CommandText = "USP_OrderDetailt_UpdateQuatity";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@Quatity", SqlDbType.Int).Value = Quatity;

        return Execute();
    }
    public int USP_OrderDetailt_AddProduct(int ProductID, int Quatity, int OrdersID)
    {
        mCmd.CommandText = "USP_OrderDetailt_AddProduct";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        mCmd.Parameters.Add("@Quatity", SqlDbType.Int).Value = Quatity;
        mCmd.Parameters.Add("@OrdersID", SqlDbType.Int).Value = OrdersID;

        return Execute();
    }
    
}
