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

public class DADiscountBase : TDatabase
{
    public Int32 fID;
    public String fDiscountName;
    public Int32 fDiscountTypeID;
    public Int32 fValue;
    public String fCoupon;
    public Int32 fCouponTypeID;
    public Int32 fCouponValue;
    public Boolean fIsNotAllowWithOther;
    public DateTime fFromDate;
    public DateTime fToDate;
    public Int32 fMinProductNumber;
    public Int32 fMinOrderPrice;

    public DADiscountBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Discount";
        mKeyName = "ID";
    }
    public int USP_Discount_Insert()
    {
        mCmd.CommandText = "USP_Discount_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@DiscountName", SqlDbType.NVarChar).Value = fDiscountName;
        mCmd.Parameters.Add("@DiscountTypeID", SqlDbType.Int).Value = fDiscountTypeID;
        mCmd.Parameters.Add("@Value", SqlDbType.Int).Value = fValue;
        mCmd.Parameters.Add("@Coupon", SqlDbType.VarChar).Value = fCoupon;
        mCmd.Parameters.Add("@CouponTypeID", SqlDbType.Int).Value = fCouponTypeID;
        mCmd.Parameters.Add("@CouponValue", SqlDbType.Int).Value = fCouponValue;
        mCmd.Parameters.Add("@IsNotAllowWithOther", SqlDbType.Bit).Value = fIsNotAllowWithOther;
        mCmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fFromDate;
        mCmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = fToDate;
        mCmd.Parameters.Add("@MinProductNumber", SqlDbType.Int).Value = fMinProductNumber;
        mCmd.Parameters.Add("@MinOrderPrice", SqlDbType.Int).Value = fMinOrderPrice;

        return Execute();
    }
    public int USP_Discount_Insert(Int32 ID, String DiscountName, Int32 DiscountTypeID, Int32 Value, String Coupon, Int32 CouponTypeID, Int32 CouponValue, Boolean IsNotAllowWithOther, DateTime FromDate, DateTime ToDate, Int32 MinProductNumber, Int32 MinOrderPrice)
    {
        mCmd.CommandText = "USP_Discount_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@DiscountName", SqlDbType.NVarChar).Value = DiscountName;
        mCmd.Parameters.Add("@DiscountTypeID", SqlDbType.Int).Value = DiscountTypeID;
        mCmd.Parameters.Add("@Value", SqlDbType.Int).Value = Value;
        mCmd.Parameters.Add("@Coupon", SqlDbType.VarChar).Value = Coupon;
        mCmd.Parameters.Add("@CouponTypeID", SqlDbType.Int).Value = CouponTypeID;
        mCmd.Parameters.Add("@CouponValue", SqlDbType.Int).Value = CouponValue;
        mCmd.Parameters.Add("@IsNotAllowWithOther", SqlDbType.Bit).Value = IsNotAllowWithOther;
        mCmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
        mCmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
        mCmd.Parameters.Add("@MinProductNumber", SqlDbType.Int).Value = MinProductNumber;
        mCmd.Parameters.Add("@MinOrderPrice", SqlDbType.Int).Value = MinOrderPrice;

        return Execute();
    }

    public int USP_Discount_Update()
    {
        mCmd.CommandText = "USP_Discount_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@DiscountName", SqlDbType.NVarChar).Value = fDiscountName;
        mCmd.Parameters.Add("@DiscountTypeID", SqlDbType.Int).Value = fDiscountTypeID;
        mCmd.Parameters.Add("@Value", SqlDbType.Int).Value = fValue;
        mCmd.Parameters.Add("@Coupon", SqlDbType.VarChar).Value = fCoupon;
        mCmd.Parameters.Add("@CouponTypeID", SqlDbType.Int).Value = fCouponTypeID;
        mCmd.Parameters.Add("@CouponValue", SqlDbType.Int).Value = fCouponValue;
        mCmd.Parameters.Add("@IsNotAllowWithOther", SqlDbType.Bit).Value = fIsNotAllowWithOther;
        mCmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fFromDate;
        mCmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = fToDate;
        mCmd.Parameters.Add("@MinProductNumber", SqlDbType.Int).Value = fMinProductNumber;
        mCmd.Parameters.Add("@MinOrderPrice", SqlDbType.Int).Value = fMinOrderPrice;

        return Execute();
    }
    public int USP_Discount_Update(Int32 ID, String DiscountName, Int32 DiscountTypeID, Int32 Value, String Coupon, Int32 CouponTypeID, Int32 CouponValue, Boolean IsNotAllowWithOther, DateTime FromDate, DateTime ToDate, Int32 MinProductNumber, Int32 MinOrderPrice)
    {
        mCmd.CommandText = "USP_Discount_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@DiscountName", SqlDbType.NVarChar).Value = DiscountName;
        mCmd.Parameters.Add("@DiscountTypeID", SqlDbType.Int).Value = DiscountTypeID;
        mCmd.Parameters.Add("@Value", SqlDbType.Int).Value = Value;
        mCmd.Parameters.Add("@Coupon", SqlDbType.VarChar).Value = Coupon;
        mCmd.Parameters.Add("@CouponTypeID", SqlDbType.Int).Value = CouponTypeID;
        mCmd.Parameters.Add("@CouponValue", SqlDbType.Int).Value = CouponValue;
        mCmd.Parameters.Add("@IsNotAllowWithOther", SqlDbType.Bit).Value = IsNotAllowWithOther;
        mCmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
        mCmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
        mCmd.Parameters.Add("@MinProductNumber", SqlDbType.Int).Value = MinProductNumber;
        mCmd.Parameters.Add("@MinOrderPrice", SqlDbType.Int).Value = MinOrderPrice;

        return Execute();
    }

    public int USP_Discount_Delete(int ID)
    {
        mCmd.CommandText = "USP_Discount_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Discount_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Discount_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Discount_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Discount_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Discount_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Discount_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Discount_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Discount_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Discount_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Discount_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Discount_Fetch()
    {
        return 0;
    }
    public bool USP_Discount_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Discount_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fDiscountName = mDataReader["DiscountName"].ToString();
            fDiscountTypeID = Convert.ToInt32(mDataReader["DiscountTypeID"]);
            fValue = Convert.ToInt32(mDataReader["Value"]);
            fCoupon = mDataReader["Coupon"].ToString();
            fCouponTypeID = Convert.ToInt32(mDataReader["CouponTypeID"]);
            fCouponValue = Convert.ToInt32(mDataReader["CouponValue"]);
            fIsNotAllowWithOther = Convert.ToBoolean(mDataReader["IsNotAllowWithOther"]);
            fFromDate = Convert.ToDateTime(mDataReader["FromDate"]);
            fToDate = Convert.ToDateTime(mDataReader["ToDate"]);
            fMinProductNumber = Convert.ToInt32(mDataReader["MinProductNumber"]);
            fMinOrderPrice = Convert.ToInt32(mDataReader["MinOrderPrice"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Discount_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Discount_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Discount_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Discount_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Discount_CheckDuplicate(string DiscountName)
    {
        mCmd.CommandText = "USP_Discount_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@DiscountName", SqlDbType.VarChar).Value = DiscountName;
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
            fDiscountName = mDataReader["DiscountName"].ToString();
            fDiscountTypeID = Convert.ToInt32(mDataReader["DiscountTypeID"]);
            fValue = Convert.ToInt32(mDataReader["Value"]);
            fCoupon = mDataReader["Coupon"].ToString();
            fCouponTypeID = Convert.ToInt32(mDataReader["CouponTypeID"]);
            fCouponValue = Convert.ToInt32(mDataReader["CouponValue"]);
            fIsNotAllowWithOther = Convert.ToBoolean(mDataReader["IsNotAllowWithOther"]);
            fFromDate = Convert.ToDateTime(mDataReader["FromDate"]);
            fToDate = Convert.ToDateTime(mDataReader["ToDate"]);
            fMinProductNumber = Convert.ToInt32(mDataReader["MinProductNumber"]);
            fMinOrderPrice = Convert.ToInt32(mDataReader["MinOrderPrice"]);

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
public partial class DADiscount : DADiscountBase
{
}
