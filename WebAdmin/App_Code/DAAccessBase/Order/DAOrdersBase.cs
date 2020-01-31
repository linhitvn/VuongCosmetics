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

public class DAOrdersBase : TDatabase
{
    public Int32 fID;
    public Int32 fOrderStatusID;
    public Int32 fPaymentID;
    public Int32 fShippingID;
    public String fBillCustomer;
    public String fBillPhone;
    public String fBillAddress;
    public Int32 fBillProvinceID;
    public Int32 fBillDistrictID;
    public String fShipCustomer;
    public String fShipPhone;
    public String fShipAddress;
    public Int32 fShipProvinceID;
    public Int32 fShipDistrictID;
    public String fShipAddressNote;
    public String fNoteSaler;
    public String fNoteCustomer;
    public Int32 fCustomerID;
    public String fIPAddress;
    public Int32 fTotalPrice;
    public Int32 fDiscount;
    public Int32 fShippingPrice;
    public Int32 fTotalNeedPay;
    public DateTime fSysDate;


    // Reference Table
    public string fPaymentName;
    public string fShippingName;
    public string fCustomerName;
    //
    public String fShipProvince;
    public String fShipDistrict;
    public String fBillDistrict;
    public String fBillProvince;

    public DAOrdersBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Orders";
        mKeyName = "ID";
    }
    public int USP_Orders_Insert()
    {
        mCmd.CommandText = "USP_Orders_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Value = fOrderStatusID;
        mCmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = fPaymentID;
        mCmd.Parameters.Add("@ShippingID", SqlDbType.Int).Value = fShippingID;
        mCmd.Parameters.Add("@BillCustomer", SqlDbType.NVarChar).Value = fBillCustomer;
        mCmd.Parameters.Add("@BillPhone", SqlDbType.NVarChar).Value = fBillPhone;
        mCmd.Parameters.Add("@BillAddress", SqlDbType.NVarChar).Value = fBillAddress;
        mCmd.Parameters.Add("@BillProvinceID", SqlDbType.Int).Value = fBillProvinceID;
        mCmd.Parameters.Add("@BillDistrictID", SqlDbType.Int).Value = fBillDistrictID;
        mCmd.Parameters.Add("@ShipCustomer", SqlDbType.NVarChar).Value = fShipCustomer;
        mCmd.Parameters.Add("@ShipPhone", SqlDbType.NVarChar).Value = fShipPhone;
        mCmd.Parameters.Add("@ShipAddress", SqlDbType.NVarChar).Value = fShipAddress;
        mCmd.Parameters.Add("@ShipProvinceID", SqlDbType.Int).Value = fShipProvinceID;
        mCmd.Parameters.Add("@ShipDistrictID", SqlDbType.Int).Value = fShipDistrictID;
        mCmd.Parameters.Add("@ShipAddressNote", SqlDbType.NVarChar).Value = fShipAddressNote;
        mCmd.Parameters.Add("@NoteSaler", SqlDbType.NVarChar).Value = fNoteSaler;
        mCmd.Parameters.Add("@NoteCustomer", SqlDbType.NVarChar).Value = fNoteCustomer;
        mCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fCustomerID;
        mCmd.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = fIPAddress;
        mCmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = fTotalPrice;
        mCmd.Parameters.Add("@Discount", SqlDbType.Int).Value = fDiscount;
        mCmd.Parameters.Add("@ShippingPrice", SqlDbType.Int).Value = fShippingPrice;
        mCmd.Parameters.Add("@TotalNeedPay", SqlDbType.Int).Value = fTotalNeedPay;

        return Execute();
    }

    public int USP_Orders_Update()
    {
        mCmd.CommandText = "USP_Orders_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Value = fOrderStatusID;
        mCmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = fPaymentID;
        mCmd.Parameters.Add("@ShippingID", SqlDbType.Int).Value = fShippingID;
        mCmd.Parameters.Add("@BillCustomer", SqlDbType.NVarChar).Value = fBillCustomer;
        mCmd.Parameters.Add("@BillPhone", SqlDbType.NVarChar).Value = fBillPhone;
        mCmd.Parameters.Add("@BillAddress", SqlDbType.NVarChar).Value = fBillAddress;
        mCmd.Parameters.Add("@BillProvinceID", SqlDbType.Int).Value = fBillProvinceID;
        mCmd.Parameters.Add("@BillDistrictID", SqlDbType.Int).Value = fBillDistrictID;
        mCmd.Parameters.Add("@ShipCustomer", SqlDbType.NVarChar).Value = fShipCustomer;
        mCmd.Parameters.Add("@ShipPhone", SqlDbType.NVarChar).Value = fShipPhone;
        mCmd.Parameters.Add("@ShipAddress", SqlDbType.NVarChar).Value = fShipAddress;
        mCmd.Parameters.Add("@ShipProvinceID", SqlDbType.Int).Value = fShipProvinceID;
        mCmd.Parameters.Add("@ShipDistrictID", SqlDbType.Int).Value = fShipDistrictID;
        mCmd.Parameters.Add("@ShipAddressNote", SqlDbType.NVarChar).Value = fShipAddressNote;
        mCmd.Parameters.Add("@NoteSaler", SqlDbType.NVarChar).Value = fNoteSaler;
        mCmd.Parameters.Add("@NoteCustomer", SqlDbType.NVarChar).Value = fNoteCustomer;
        mCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = fCustomerID;
        mCmd.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = fIPAddress;
        mCmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = fTotalPrice;
        mCmd.Parameters.Add("@Discount", SqlDbType.Int).Value = fDiscount;
        mCmd.Parameters.Add("@ShippingPrice", SqlDbType.Int).Value = fShippingPrice;
        mCmd.Parameters.Add("@TotalNeedPay", SqlDbType.Int).Value = fTotalNeedPay;

        return Execute();
    }

    public int USP_Orders_Delete(int ID)
    {
        mCmd.CommandText = "USP_Orders_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Orders_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Orders_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Orders_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Orders_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Orders_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Orders_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Orders_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Orders_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Orders_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Orders_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Orders_Fetch()
    {
        return 0;
    }
    public bool USP_Orders_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Orders_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fOrderStatusID = Convert.ToInt32(mDataReader["OrderStatusID"]);
            fPaymentID = Convert.ToInt32(mDataReader["PaymentID"]);
            fShippingID = Convert.ToInt32(mDataReader["ShippingID"]);
            fBillCustomer = mDataReader["BillCustomer"].ToString();
            fBillPhone = mDataReader["BillPhone"].ToString();
            fBillAddress = mDataReader["BillAddress"].ToString();
            fBillProvinceID = Convert.ToInt32(mDataReader["BillProvinceID"]);
            fBillDistrictID = Convert.ToInt32(mDataReader["BillDistrictID"]);
            fShipCustomer = mDataReader["ShipCustomer"].ToString();
            fShipPhone = mDataReader["ShipPhone"].ToString();
            fShipAddress = mDataReader["ShipAddress"].ToString();
            fShipProvinceID = Convert.ToInt32(mDataReader["ShipProvinceID"]);
            fShipDistrictID = Convert.ToInt32(mDataReader["ShipDistrictID"]);
            fShipAddressNote = mDataReader["ShipAddressNote"].ToString();
            fNoteSaler = mDataReader["NoteSaler"].ToString();
            fNoteCustomer = mDataReader["NoteCustomer"].ToString();
            fCustomerID = Convert.ToInt32(mDataReader["CustomerID"]);
            fIPAddress = mDataReader["IPAddress"].ToString();
            fTotalPrice = Convert.ToInt32(mDataReader["TotalPrice"]);
            fDiscount = Convert.ToInt32(mDataReader["Discount"]);
            fShippingPrice = Convert.ToInt32(mDataReader["ShippingPrice"]);
            fTotalNeedPay = Convert.ToInt32(mDataReader["TotalNeedPay"]);
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Orders_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Orders_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    
    
    public SqlDataReader USP_Orders_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Orders_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Orders_CheckDuplicate(string OrderStatusID)
    {
        mCmd.CommandText = "USP_Orders_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@OrderStatusID", SqlDbType.VarChar).Value = OrderStatusID;
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
            fOrderStatusID = Convert.ToInt32(mDataReader["OrderStatusID"]);
            fPaymentID = Convert.ToInt32(mDataReader["PaymentID"]);
            fShippingID = Convert.ToInt32(mDataReader["ShippingID"]);
            fBillCustomer = mDataReader["BillCustomer"].ToString();
            fBillPhone = mDataReader["BillPhone"].ToString();
            fBillAddress = mDataReader["BillAddress"].ToString();
            fBillProvinceID = Convert.ToInt32(mDataReader["BillProvinceID"]);
            fBillDistrictID = Convert.ToInt32(mDataReader["BillDistrictID"]);
            fShipCustomer = mDataReader["ShipCustomer"].ToString();
            fShipPhone = mDataReader["ShipPhone"].ToString();
            fShipAddress = mDataReader["ShipAddress"].ToString();
            fShipProvinceID = Convert.ToInt32(mDataReader["ShipProvinceID"]);
            fShipDistrictID = Convert.ToInt32(mDataReader["ShipDistrictID"]);
            fShipAddressNote = mDataReader["ShipAddressNote"].ToString();
            fNoteSaler = mDataReader["NoteSaler"].ToString();
            fNoteCustomer = mDataReader["NoteCustomer"].ToString();
            fCustomerID = Convert.ToInt32(mDataReader["CustomerID"]);
            fIPAddress = mDataReader["IPAddress"].ToString();
            fTotalPrice = Convert.ToInt32(mDataReader["TotalPrice"]);
            fDiscount = Convert.ToInt32(mDataReader["Discount"]);
            fShippingPrice = Convert.ToInt32(mDataReader["ShippingPrice"]);
            fTotalNeedPay = Convert.ToInt32(mDataReader["TotalNeedPay"]);
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
public partial class DAOrders : DAOrdersBase
{
    //public SqlDataReader USP_Orders_GetFullAllByID(int ID)
    //{
    //    mCmd.CommandText = "USP_Orders_GetFullAllByID";
    //    mCmd.Parameters.Clear();
    //    mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
    //    ExecuteReader();
    //    return mDataReader;
    //}

    public SqlDataReader USP_Orders_GetByCustomerID(int CustomerID)
    {
        mCmd.CommandText = "USP_Orders_GetByCustomerID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        ExecuteReader();
        return mDataReader;
    }

    public bool USP_Orders_GetLastest_ByCustomerID(int CustomerID)
    {
        mCmd.CommandText = "USP_Orders_GetLastest_ByCustomerID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fOrderStatusID = Convert.ToInt32(mDataReader["OrderStatusID"]);
            fPaymentID = Convert.ToInt32(mDataReader["PaymentID"]);
            fShippingID = Convert.ToInt32(mDataReader["ShippingID"]);
            fBillCustomer = mDataReader["BillCustomer"].ToString();
            fBillPhone = mDataReader["BillPhone"].ToString();
            fBillAddress = mDataReader["BillAddress"].ToString();
            fBillProvinceID = Convert.ToInt32(mDataReader["BillProvinceID"]);
            fBillDistrictID = Convert.ToInt32(mDataReader["BillDistrictID"]);
            fShipCustomer = mDataReader["ShipCustomer"].ToString();
            fShipPhone = mDataReader["ShipPhone"].ToString();
            fShipAddress = mDataReader["ShipAddress"].ToString();
            fShipProvinceID = Convert.ToInt32(mDataReader["ShipProvinceID"]);
            fShipDistrictID = Convert.ToInt32(mDataReader["ShipDistrictID"]);
            fShipAddressNote = mDataReader["ShipAddressNote"].ToString();
            fNoteSaler = mDataReader["NoteSaler"].ToString();
            fNoteCustomer = mDataReader["NoteCustomer"].ToString();
            fCustomerID = Convert.ToInt32(mDataReader["CustomerID"]);
            fIPAddress = mDataReader["IPAddress"].ToString();
            fTotalPrice = Convert.ToInt32(mDataReader["TotalPrice"]);
            fDiscount = Convert.ToInt32(mDataReader["Discount"]);
            fShippingPrice = Convert.ToInt32(mDataReader["ShippingPrice"]);
            fTotalNeedPay = Convert.ToInt32(mDataReader["TotalNeedPay"]);
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }


    public DataSet USP_Orders_Search(int CustomerID,int @OrderStatusID, DateTime FromDate, DateTime ToDate)
    {
        mCmd.CommandText = "USP_Orders_Search";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        mCmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Value = @OrderStatusID;
        mCmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = FromDate;
        mCmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = ToDate;
        ExecuteDataSet();
        return mDataSet;
    }

    public DataSet USP_Orders_New()
    {
        mCmd.CommandText = "USP_Orders_New";
        mCmd.Parameters.Clear();
        ExecuteDataSet();
        return mDataSet;
    }
    

    public bool USP_Orders_GetFullAllByID(int ID)
    {
        mCmd.CommandText = "USP_Orders_GetFullAllByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fOrderStatusID = Convert.ToInt32(mDataReader["OrderStatusID"]);
            fPaymentID = Convert.ToInt32(mDataReader["PaymentID"]);
            fShippingID = Convert.ToInt32(mDataReader["ShippingID"]);
            fBillCustomer = mDataReader["BillCustomer"].ToString();
            fBillPhone = mDataReader["BillPhone"].ToString();
            fBillAddress = mDataReader["BillAddress"].ToString();
            fBillProvinceID = Convert.ToInt32(mDataReader["BillProvinceID"]);
            fBillDistrictID = Convert.ToInt32(mDataReader["BillDistrictID"]);
            fShipCustomer = mDataReader["ShipCustomer"].ToString();
            fShipPhone = mDataReader["ShipPhone"].ToString();
            fShipAddress = mDataReader["ShipAddress"].ToString();
            fShipProvinceID = Convert.ToInt32(mDataReader["ShipProvinceID"]);
            fShipDistrictID = Convert.ToInt32(mDataReader["ShipDistrictID"]);
            fShipAddressNote = mDataReader["ShipAddressNote"].ToString();
            fNoteSaler = mDataReader["NoteSaler"].ToString();
            fNoteCustomer = mDataReader["NoteCustomer"].ToString();
            fCustomerID = Convert.ToInt32(mDataReader["CustomerID"]);
            fIPAddress = mDataReader["IPAddress"].ToString();
            fTotalPrice = Convert.ToInt32(mDataReader["TotalPrice"]);
            fDiscount = Convert.ToInt32(mDataReader["Discount"]);
            fShippingPrice = Convert.ToInt32(mDataReader["ShippingPrice"]);
            fTotalNeedPay = Convert.ToInt32(mDataReader["TotalNeedPay"]);
            fSysDate = Convert.ToDateTime(mDataReader["SysDate"]);

            fPaymentName = mDataReader["Payment"].ToString();
            fShippingName = mDataReader["Shipping"].ToString();
            fCustomerName = mDataReader["CustomerName"].ToString();

            fBillProvince = mDataReader["BillProvince"].ToString();
            fBillDistrict = mDataReader["BillDistrict"].ToString();
            fShipProvince = mDataReader["ShipProvince"].ToString();
            fShipDistrict = mDataReader["ShipDistrict"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Orders_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Orders_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }
}
