using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NDL.Framework.MSSQL;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DAOrderDetailTemp
/// </summary>
public class DAOrderDetailTemp : TDatabase
{
	public DAOrderDetailTemp()
	{
        mTableName = "OrderDetailTemp";
	}

    public SqlDataReader USP_OrderDetailTemp_GetByOrderID(String OrderID)
    {
        mCmd.CommandText = "USP_OrderDetailTemp_GetByOrderID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@OrderID", SqlDbType.VarChar).Value = OrderID;
        return ExecuteReader();
    }

    public SqlDataReader USP_OrderDetailTemp_GetAllOrderID(String OrderID)
    {
        mCmd.CommandText = "USP_OrderDetailTemp_GetAllOrderID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@OrderID", SqlDbType.VarChar).Value = OrderID;
        return ExecuteReader();
    }

    public int USP_OrderDetailTemp_Insert(String OrderID, int ProductID, int Quantity)
    {
        mCmd.CommandText = "USP_OrderDetailTemp_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@OrderID", SqlDbType.VarChar).Value = OrderID;
        mCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
        mCmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
        return Execute();
    }

    public int USP_OrderDetailTemp_Delete(int ID)
    {
        mCmd.CommandText = "USP_OrderDetailTemp_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Orders_Client_Insert(String WOrderID, String FullName, String Address, String Phone, String Email, int PaymentID, int ProvinceID, int DistrictID)
    {
        mCmd.CommandText = "USP_Orders_Client_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@WOrderID", SqlDbType.VarChar).Value = WOrderID;
        mCmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = FullName;
        mCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
        mCmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = Phone;
        mCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
        mCmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = PaymentID;
        mCmd.Parameters.Add("@ProvinceID", SqlDbType.Int).Value = ProvinceID;
        mCmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = DistrictID;
        return Execute();
    }
}