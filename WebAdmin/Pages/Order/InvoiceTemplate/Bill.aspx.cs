using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InvoiceTemplate_Bill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int OrderID = int.Parse(Request.QueryString["OrderID"].ToString());

            LoadData(OrderID);
            LoadOrderDetail(OrderID);
        }
        catch { }
    }

    private void LoadOrderDetail(int OrderID)
    {
        DAOrderDetailt daOrderDetailt = new DAOrderDetailt();
        rptOrderDetail.DataSource = daOrderDetailt.USP_OrderDetailt_GetByOrderID(OrderID);
        rptOrderDetail.DataBind();
    }

    protected Boolean LoadData(int OrderID)
    {
        try
        {
            // Load Data For Page.
            DAOrders daOrders = new DAOrders();
            daOrders.USP_Orders_GetFullAllByID(OrderID);
            //
            fBillCustomer.InnerText = daOrders.fBillCustomer.ToString();
            fBillPhone.InnerText = daOrders.fBillPhone.ToString();
            fBillAddress.InnerText = daOrders.fBillAddress.ToString();
            fShipCustomer.InnerText = daOrders.fShipCustomer.ToString();
            fShipPhone.InnerText = daOrders.fShipPhone.ToString();
            fShipAddress.InnerText = daOrders.fShipAddress.ToString();

            lblBillCity.InnerText = daOrders.fBillDistrict.ToString() + ", " + daOrders.fBillProvince.ToString(); 
            lblShipCity.InnerText = daOrders.fShipDistrict.ToString() + ", " + daOrders.fShipProvince.ToString();

            fShippingName.InnerText = daOrders.fShippingName;
            fPaymentName.InnerText = daOrders.fPaymentName;
            fCustomer.InnerText = daOrders.fCustomerName;
            fOrdersID.InnerText = daOrders.fID.ToString();
            fSysDate.InnerText = daOrders.fSysDate.ToShortDateString();

            fTotalPrice.InnerText = MyString.CurrencyFomat(daOrders.fTotalPrice);
            fDiscount.InnerText = MyString.CurrencyFomat(daOrders.fDiscount);
            fShippingPrice.InnerText = MyString.CurrencyFomat(daOrders.fShippingPrice);
            fTotalNeedPay.InnerText = MyString.CurrencyFomat(daOrders.fTotalNeedPay);

        }
        catch 
        {
            return false;
        }

        return true;
    }
}