using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using System.Data.SqlClient;

public partial class Pages_Backup_cOrderDetailt : TUserControlForAlter
{
    override protected Boolean SetServerControl()
    {
        try
        {
            // Set Message Value
            this.messBox = message_box;

            // Set button Controller
            this.BtSave1 = Save;
            this.BtSaveAndCreate1 = SaveAndCreate;
        }
        catch
        {
            ShowErrorMes("Lỗi hệ thống Control !");
            return false;
        }

        return true;
    }

    override protected Boolean GetDataComboBox()
    {
        try
        {


            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }


    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAOrders daOrders = new DAOrders();
            //daOrders.USP_Orders_GetFullAllByID(this.KeyID);
            SqlDataReader mDataReader = daOrders.USP_Orders_GetByID_Reader(this.KeyID);

            if (mDataReader.Read())
            {
                // Thong tin co ban
                fID.InnerText = "#" + mDataReader["ID"].ToString();
                fSysDate.InnerText = mDataReader["SysDate"].ToString();
                fOrderStatus.InnerText = mDataReader["OrderStatus"].ToString();

                // Thong tin khách hàng
                fCustomer.InnerText = mDataReader["CustomerName"].ToString();
                fEmail.InnerText = mDataReader["Email"].ToString();
                fCustomerGroup.InnerText = mDataReader["CustomerGroup"].ToString();
                fIPAddress.InnerText = mDataReader["IPAddress"].ToString();


                fPayment.InnerText = mDataReader["Payment"].ToString();
                fShipping.InnerText = mDataReader["Shipping"].ToString();

                fBillCustomer.InnerText = mDataReader["BillCustomer"].ToString();
                fBillPhone.InnerText = mDataReader["BillPhone"].ToString();
                fBillAddress.InnerText = mDataReader["BillAddress"].ToString();
                fBillProvince.InnerText = mDataReader["BillProvince"].ToString();
                fBillDistrict.InnerText = mDataReader["BillDistrict"].ToString();
                fShipCustomer.InnerText = mDataReader["ShipCustomer"].ToString();
                fShipPhone.InnerText = mDataReader["ShipPhone"].ToString();
                fShipAddress.InnerText = mDataReader["ShipAddress"].ToString();
                fShipProvince.InnerText = mDataReader["ShipProvince"].ToString();
                fShipDistrict.InnerText = mDataReader["ShipDistrict"].ToString();
                fShipAddressNote.InnerText = mDataReader["ShipAddressNote"].ToString();
                fNoteSaler.InnerText = mDataReader["NoteSaler"].ToString();
                fNoteCustomer.InnerText = mDataReader["NoteCustomer"].ToString();


                //fTotalPrice.InnerText = mDataReader["TotalPrice"].ToString();
                //fDiscount.InnerText = mDataReader["Discount"].ToString();
                //fShippingPrice.InnerText = mDataReader["ShippingPrice"].ToString();
                //fTotalNeedPay.InnerText = mDataReader["TotalNeedPay"].ToString();


                mDataReader.Close();
                return true;
            }
            else
                mDataReader.Close();


            //return false;
            //
            //fOrderStatusID.Value = daOrders.fOrderStatusID.ToString();
            //fPaymentID.Value = daOrders.fPaymentID.ToString();
            //fShippingID.Value = daOrders.fShippingID.ToString();


            //fBillCustomer.InnerText = daOrders.fBillCustomer.ToString();
            //fBillPhone.InnerText = daOrders.fBillPhone.ToString();
            //fBillAddress.InnerText = daOrders.fBillAddress.ToString();
            //fBillProvinceID.InnerText = daOrders.fBillProvinceID.ToString();
            //fBillDistrictID.InnerText = daOrders.fBillDistrictID.ToString();
            //fShipCustomer.InnerText = daOrders.fShipCustomer.ToString();
            //fShipPhone.InnerText = daOrders.fShipPhone.ToString();
            //fShipAddress.InnerText = daOrders.fShipAddress.ToString();
            //fShipProvinceID.InnerText = daOrders.fShipProvinceID.ToString();
            //fShipDistrictID.InnerText = daOrders.fShipDistrictID.ToString();
            //fShipAddressNote.InnerText = daOrders.fShipAddressNote.ToString();
            //fNoteSaler.InnerText = daOrders.fNoteSaler.ToString();
            //fNoteCustomer.InnerText = daOrders.fNoteCustomer.ToString();
            //fCustomer.InnerText = daOrders.fCustomerID.ToString();
            //fIPAddress.InnerText = daOrders.fIPAddress.ToString();
            //fTotalPrice.Value = daOrders.fTotalPrice.ToString();
            //fDiscount.Value = daOrders.fDiscount.ToString();
            //fShippingPrice.Value = daOrders.fShippingPrice.ToString();
            //fTotalNeedPay.Value = daOrders.fTotalNeedPay.ToString();
            //fSysDate.SelectedDate = daOrders.fSysDate;

            //

            // Khi cần enabled cột nào
            //if (this.KeyID > 0)
            //{
            //    if (mode != Act.Clone)
            //        fUserName.Enabled = false;
            //    else
            //        fUserName.Text = "";
            //}
        }
        catch (Exception e)
        {
            ShowErrorMes("Lỗi hệ thống: " + e.ToString());
            return false;
        }

        return true;
    }


    override protected Boolean CheckInput()
    {
        //if (fUserName.Value.Trim() == "")
        //{
        //    ShowErrorMes("Bạn chưa nhập tài khoản!");
        //    fUserName.Focus();
        //    return false;
        //}
        //if (fPassWord.Value.Trim() == "")
        //{
        //    ShowErrorMes("Bạn chưa nhập mật khẩu!");
        //    fPassWord.Focus();
        //    return false;
        //}
        return true;
    }

    override protected Boolean CheckDuplicate()
    {
        //if (this.KeyID == 0)
        //{
        //    DACategory DACategory = new DACategory();
        //    if (DACategory.USP_Category_CheckDuplicate(fUserName.Value.Trim()) == 1)
        //    {
        //        ShowErrorMes("Tài khoản này đã tồn tại. Bạn nhập lại!");
        //        fUserName.Focus();
        //        return false;
        //    }
        //}
        return true;
    }
}