using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using Telerik.Web.UI;

public partial class Pages_Order_cOrdersAlter : TUserControlForAlter
{
    override protected Boolean SetServerControl()
    {
        try
        {
            // Set Message Value
            this.messBox = message_box;

            // Set button Controller
            this.BtSave1 = Save;
            //this.BtSaveAndCreate1 = SaveAndCreate;

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
            DAOrderStatus daOrderStatus = new DAOrderStatus();
            fOrderStatusID.DataSource = daOrderStatus.USP_OrderStatus_GetDataForComboBox();
            fOrderStatusID.DataBind();

            DAPayment daPayment = new DAPayment();
            fPaymentID.DataSource = daPayment.USP_Payment_GetDataForComboBox();
            fPaymentID.DataBind();

            DAShipping daShipping = new DAShipping();
            fShippingID.DataSource = daShipping.USP_Shipping_GetDataForComboBox();
            fShippingID.DataBind();

            DAProvince daProvinceBilling = new DAProvince();
            fBillProvinceID.DataSource = daProvinceBilling.USP_Province_GetDataForComboBox();
            fBillProvinceID.DataBind();

            DADistrict daDistrictBilling = new DADistrict();
            fBillDistrictID.DataSource = daDistrictBilling.USP_District_GetDataForComboBox_ByProvinceID(int.Parse(fBillProvinceID.SelectedValue));
            fBillDistrictID.DataBind();


            DAProvince daProvinceShipping = new DAProvince();
            fShipProvinceID.DataSource = daProvinceShipping.USP_Province_GetDataForComboBox();
            fShipProvinceID.DataBind();


            DADistrict daDistrictShipping = new DADistrict();
            fShipDistrictID.DataSource = daDistrictShipping.USP_District_GetDataForComboBox_ByProvinceID(int.Parse(fShipProvinceID.SelectedValue));
            fShipDistrictID.DataBind();

            DACustomer daCustomer = new DACustomer();
            fCustomerID.DataSource = daCustomer.USP_Customer_GetDataForComboBox();
            fCustomerID.DataBind();

            DAProvince daProvince = new DAProvince();
            fProvinceID.DataSource = daProvince.USP_Province_GetDataForComboBox();
            fProvinceID.DataBind();

            DACustomerGroup daCustomerGroup = new DACustomerGroup();
            fCustomerGroupID.DataSource = daCustomerGroup.USP_CustomerGroup_GetDataForComboBox();
            fCustomerGroupID.DataBind();


            //LoadCategory();
            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAOrders CreateObjectFromPage()
    {
        // check 
        DAOrders daOrders = new DAOrders();
        //
        daOrders.fOrderStatusID = Convert.ToInt32(fOrderStatusID.Value.Trim());
        daOrders.fPaymentID = Convert.ToInt32(fPaymentID.Value.Trim());
        daOrders.fShippingID = Convert.ToInt32(fShippingID.Value.Trim());
        daOrders.fBillCustomer = fBillCustomer.Value.Trim();
        daOrders.fBillPhone = fBillPhone.Value.Trim();
        daOrders.fBillAddress = fBillAddress.Value.Trim();
        daOrders.fBillProvinceID = Convert.ToInt32(fBillProvinceID.SelectedValue.Trim());
        daOrders.fBillDistrictID = Convert.ToInt32(fBillDistrictID.Value.Trim());
        daOrders.fShipCustomer = fShipCustomer.Value.Trim();
        daOrders.fShipPhone = fShipPhone.Value.Trim();
        daOrders.fShipAddress = fShipAddress.Value.Trim();
        daOrders.fShipProvinceID = Convert.ToInt32(fShipProvinceID.SelectedValue.Trim());
        daOrders.fShipDistrictID = Convert.ToInt32(fShipDistrictID.Value.Trim());
        daOrders.fShipAddressNote = fShipAddressNote.Value.Trim();
        daOrders.fNoteSaler = fNoteSaler.Value.Trim();
        daOrders.fNoteCustomer = fNoteCustomer.Value.Trim();
        daOrders.fCustomerID = int.Parse(fCustomerID.SelectedValue);
        daOrders.fIPAddress = fIPAddress.InnerText.Trim();
        daOrders.fTotalPrice = Convert.ToInt32(fTotalPrice.Value);
        daOrders.fDiscount = Convert.ToInt32(fDiscount.Value);
        daOrders.fShippingPrice = Convert.ToInt32(fShippingPrice.Value);
        daOrders.fTotalNeedPay = Convert.ToInt32(fTotalNeedPay.Value);

        //

        return daOrders;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAOrders daOrders = new DAOrders();
            daOrders.USP_Orders_GetFullID(this.KeyID);
            //
            fOrderStatusID.Value = daOrders.fOrderStatusID.ToString();
            fPaymentID.Value = daOrders.fPaymentID.ToString();
            fShippingID.Value = daOrders.fShippingID.ToString();
            fBillCustomer.Value = daOrders.fBillCustomer.ToString();
            fBillPhone.Value = daOrders.fBillPhone.ToString();
            fBillAddress.Value = daOrders.fBillAddress.ToString();
            fBillProvinceID.SelectedValue = daOrders.fBillProvinceID.ToString();
            fBillDistrictID.Value = daOrders.fBillDistrictID.ToString();
            fShipCustomer.Value = daOrders.fShipCustomer.ToString();
            fShipPhone.Value = daOrders.fShipPhone.ToString();
            fShipAddress.Value = daOrders.fShipAddress.ToString();
            fShipProvinceID.SelectedValue = daOrders.fShipProvinceID.ToString();
            fShipDistrictID.Value = daOrders.fShipDistrictID.ToString();
            fShipAddressNote.Value = daOrders.fShipAddressNote.ToString();
            fNoteSaler.Value = daOrders.fNoteSaler.ToString();
            fNoteCustomer.Value = daOrders.fNoteCustomer.ToString();
            fCustomerID.SelectedValue = daOrders.fCustomerID.ToString();
            fIPAddress.InnerText = daOrders.fIPAddress.ToString();
            fTotalPrice.Value = daOrders.fTotalPrice;
            fDiscount.Value = daOrders.fDiscount;
            fShippingPrice.Value = daOrders.fShippingPrice;
            fTotalNeedPay.Value = daOrders.fTotalNeedPay;

            //

            // Khi cần enabled cột nào
            if (this.KeyID == 0)
            {
                fIPAddress.InnerText = "LocalHost";

                btPrintBill.Visible = false;
                btPrintPacking.Visible = false;
            }
            else
            {
                titleTotalPrice.InnerText = MyString.CurrencyFomat(daOrders.fTotalNeedPay) + " vnđ";
                // Load OrderDetailt
                LoadDataOrderDetailt();
                LoadCustomerInfo(int.Parse(fCustomerID.SelectedValue));

                btPrintBill.Visible = true;
                btPrintPacking.Visible = false;

                btPrintBill.HRef = "~/Pages/Order/InvoiceTemplate/Bill.aspx?OrderID=" + this.KeyID.ToString();
                btPrintPacking.HRef = "~/Pages/Order/InvoiceTemplate/Packing.aspx?OrderID=" + this.KeyID.ToString();
            }

        }
        catch (Exception e)
        {
            ShowErrorMes("Lỗi hệ thống: " + e.ToString());
            return false;
        }

        return true;
    }

    override protected int ExecInsert()
    {
        try
        {
            if (CreateOrUpdateCustomer())
            {
                DAOrders DAOrders = CreateObjectFromPage();

                if (this.mode == ActParam.New)
                {
                    DAOrders.fID = DAOrders.USP_GetKey();
                    this.KeyID = DAOrders.fID; // --> Update new SessionID for continue edit.

                    btPrintBill.Visible = true;
                    btPrintPacking.Visible = true;

                    btPrintBill.HRef = "~/Pages/Order/InvoiceTemplate/Bill.aspx?OrderID=" + this.KeyID.ToString();
                    btPrintPacking.HRef = "~/Pages/Order/InvoiceTemplate/Packing.aspx?OrderID=" + this.KeyID.ToString();
                }
                else
                {
                    DAOrders.fID = 0;
                }

                // Tạo khách hàng trước ---> Nếu thành công mới tạo đơn hàng

                DAOrders.USP_Orders_Insert();
                return 1;
            }
            else
                return -1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            if (CreateOrUpdateCustomer())
            {
                DAOrders DAOrders = CreateObjectFromPage();
                DAOrders.fID = this.KeyID;

                DAOrders.USP_Orders_Update();
                return 1;
            }
            else
                return 0;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAOrders DAOrders = new DAOrders();
            DAOrders.USP_Orders_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        if (fOrderStatusID.Value == "0")
        {
            ShowErrorMes("Bạn chưa nhập trạng thái đơn hàng!");
            fOrderStatusID.Focus();
            return false;
        }
        if (fShippingID.Value == "0")
        {
            ShowErrorMes("Bạn chưa nhập hình thức chuyển hàng!");
            fShippingID.Focus();
            return false;
        }
        if (fPaymentID.Value == "0")
        {
            ShowErrorMes("Bạn chưa nhập hình thức thanh toán");
            fPaymentID.Focus();
            return false;
        }
        if (fBillProvinceID.SelectedValue == "0")
        {
            ShowErrorMes("Bạn chưa nhập tỉnh thành trong địa chỉ thanh toán");
            fBillProvinceID.Focus();
            return false;
        }
        if (fBillDistrictID.Value == "0")
        {
            ShowErrorMes("Bạn chưa nhập Quận/Huyện trong địa chỉ thanh toán");
            fBillDistrictID.Focus();
            return false;
        }
        if (fShipProvinceID.SelectedValue == "0")
        {
            ShowErrorMes("Bạn chưa nhập tỉnh thành trong địa chỉ giao hàng");
            fShipProvinceID.Focus();
            return false;
        }
        if (fShipDistrictID.Value == "0")
        {
            ShowErrorMes("Bạn chưa nhập Quận/Huyện trong địa chỉ giao hàng");
            fShipDistrictID.Focus();
            return false;
        }
        if (fShipAddress.Value == "")
        {
            ShowErrorMes("Bạn chưa nhập địa chỉ giao hàng");
            fShipAddress.Focus();
            return false;
        }
        if (fShipCustomer.Value == "")
        {
            ShowErrorMes("Bạn chưa nhập tên người nhận hàng");
            fShipCustomer.Focus();
            return false;
        }
        if (fShipPhone.Value == "")
        {
            ShowErrorMes("Bạn chưa nhập số điện thoại người nhận hàng");
            fShipPhone.Focus();
            return false;
        }

        if (fBillAddress.Value == "")
        {
            ShowErrorMes("Bạn chưa nhập địa chỉ thanh toán");
            fBillAddress.Focus();
            return false;
        }
        if (fBillCustomer.Value == "")
        {
            ShowErrorMes("Bạn chưa nhập tên người thanh toán");
            fBillCustomer.Focus();
            return false;
        }
        if (fBillPhone.Value == "")
        {
            ShowErrorMes("Bạn chưa nhập số điện thoại người thanh toán");
            fBillPhone.Focus();
            return false;
        }
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

    private void ControlCustomerInfo(int CustomerID)
    {
        if (CustomerID == 0) // Khách hàng mới
        {
            fCustomer.Disabled = false;
        }
        else
        {
            fCustomer.Disabled = true;
        }
    }

    private Boolean CreateOrUpdateCustomer()
    {
        int CustomerID = int.Parse(fCustomerID.SelectedValue);
        if (CheckInputCustomerInfo())
        {
            try
            {
                DACustomer daCustomer = new DACustomer();
                daCustomer.fID = CustomerID;
                daCustomer.fCustomerName = fCustomer.Value;
                daCustomer.fCustomerGroupID = int.Parse(fCustomerGroupID.Value);
                daCustomer.fEmail = fEmail.Value;
                daCustomer.fProvinceID = int.Parse(fProvinceID.Value);
                daCustomer.fPhone = fPhone.Value;
                daCustomer.fOperator = MySession.UserName;
                daCustomer.fAddress = "";
                daCustomer.fBirthday = "";
                daCustomer.fCompany = "";
                daCustomer.fNote = "";
                daCustomer.fPassword = "";
                daCustomer.fSex = 0;
                daCustomer.fSocialNetwork = "";
                daCustomer.fUsername = fEmail.Value;

                if (CustomerID == 0)
                {
                    daCustomer.fID = daCustomer.USP_GetKey();
                    daCustomer.USP_Customer_Insert();

                    DACustomer daCustomer1 = new DACustomer();
                    fCustomerID.DataSource = daCustomer1.USP_Customer_GetDataForComboBox();
                    fCustomerID.DataBind();

                    fCustomerID.SelectedValue = daCustomer.fID.ToString();
                }
                else
                {
                    daCustomer.USP_Customer_Update();
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowErrorMes("Lỗi hệ thống: " + ex.ToString());
                return false;
            }
        }
        else
            return false;

    }

    private Boolean CheckInputCustomerInfo()
    {
        if (fCustomer.Value == "" ||
            fCustomerGroupID.Value == "0" ||
            fEmail.Value == "" ||
            fProvinceID.Value == "0" ||
            fPhone.Value == "")
        {
            ShowErrorMes("Nhập đầy đủ thông tin về khách hàng");
            return false;
        }
        return true;
    }

    private void LoadCustomerOrderInfo(int CustomerID)
    {
        DAOrders daOrder = new DAOrders();
        daOrder.USP_Orders_GetLastest_ByCustomerID(CustomerID);
        fShippingID.Value = daOrder.fShippingID.ToString();
        fPaymentID.Value = daOrder.fPaymentID.ToString();

        fBillAddress.Value = daOrder.fBillAddress;
        fBillCustomer.Value = daOrder.fBillCustomer;
        fBillDistrictID.Value = daOrder.fBillDistrictID.ToString();
        fBillPhone.Value = daOrder.fBillPhone;
        fBillProvinceID.SelectedValue = daOrder.fBillProvinceID.ToString();

        fShipAddress.Value = daOrder.fShipAddress;
        fShipAddressNote.Value = daOrder.fShipAddressNote;
        fShipCustomer.Value = daOrder.fShipCustomer;
        fShipDistrictID.Value = daOrder.fShipDistrictID.ToString();
        fShipPhone.Value = daOrder.fShipPhone;
        fShipProvinceID.SelectedValue = daOrder.fShipProvinceID.ToString();

    }

    private void LoadCustomerInfo(int CustomerID)
    {


        if (CustomerID == 0)
        {
            fCustomer.Value = "";
            fEmail.Value = "";
            fCustomerGroupID.Value = "0";
            fPhone.Value = "";
            fProvinceID.Value = "0";
        }
        else
        {
            DACustomer daCustomer = new DACustomer();
            daCustomer.USP_Customer_GetFullID(CustomerID);
            fCustomer.Value = daCustomer.fCustomerName;
            fEmail.Value = daCustomer.fEmail;
            fCustomerGroupID.Value = daCustomer.fCustomerGroupID.ToString();
            fPhone.Value = daCustomer.fPhone;
            fProvinceID.Value = daCustomer.fProvinceID.ToString();
        }

        // Control Input
        ControlCustomerInfo(CustomerID);
    }

    protected void fCustomerID_SelectedIndexChanged(object sender, EventArgs e)
    {
        int CustomerID = int.Parse(fCustomerID.SelectedValue);
        LoadCustomerInfo(CustomerID);
        LoadCustomerOrderInfo(CustomerID);
    }

    // Load Category
    //private void LoadCategory()
    //{
    //    DAProductCat daProductCat = new DAProductCat();
    //    RadTreeView_ProductCat.DataSource = daProductCat.USP_ProductCat_GetForTree();
    //    RadTreeView_ProductCat.DataBind();
    //}

    private void LoadDataOrderDetailt()
    {
        DAOrderDetailt daOrderDetailt = new DAOrderDetailt();
        RadGrid_OrderDetailt.DataSource = daOrderDetailt.USP_OrderDetailt_GetByOrderID(this.KeyID);
        RadGrid_OrderDetailt.DataBind();
    }

    public void UpdateQuality_CLick(object sender, EventArgs e)
    {
        int lKeyID = 0;

        foreach (GridDataItem item in RadGrid_OrderDetailt.Items)
        {
            try
            {
                lKeyID = int.Parse(item.GetDataKeyValue(RadGrid_OrderDetailt.MasterTableView.DataKeyNames[0]).ToString());
                RadNumericTextBox fQuanlity = (RadNumericTextBox)item.FindControl("fQuatity");

                DAOrderDetailt daOrderDetailt = new DAOrderDetailt();
                daOrderDetailt.USP_OrderDetailt_UpdateQuatity(lKeyID, int.Parse(fQuanlity.Text));
            }
            catch 
            {
                break;
            }
        }


        LoadData();
        LoadDataOrderDetailt();

    }
    protected void RadGrid_OrderDetailt_ItemCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            int lKeyID = 0;
            string lEvent = e.CommandName;

            lKeyID = int.Parse(e.CommandArgument.ToString());
            DAOrderDetailt daOrderDetailt = new DAOrderDetailt();
            daOrderDetailt.USP_OrderDetailt_Delete(lKeyID);

            LoadData();
            LoadDataOrderDetailt();

            ShowSuccessMes("Đã xóa sản phẩm khỏi giỏ hàng");
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệt thống: " + ex.ToString());
        }
    }
    private void LoadDataProductList(string ProductName = "")
    {
        DAProduct daProduct = new DAProduct();
        sProfuctSearch.DataSource = daProduct.USP_Product_SearchByName(ProductName);
        sProfuctSearch.DataBind();
    }
    protected void RadComboBox2_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        Session["searchValue"] = e.Text.ToString();
        LoadDataProductList(e.Text.ToString());
    }
    protected void RadComboBox2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (this.KeyID == 0)
        {
            mesOrderDetail.InnerText = "(Phải lưu thông tin đơn hàng trước khi thêm sản phẩm !)";
            return;
        }
        mesOrderDetail.InnerText = "";
        DAOrderDetailt daOrderDetailt = new DAOrderDetailt();
        int ProductID = int.Parse(sProfuctSearch.SelectedValue);
        int Quatity = 1;

        daOrderDetailt.USP_OrderDetailt_AddProduct(ProductID, Quatity, this.KeyID);

        LoadDataOrderDetailt();
        LoadData();

        fTotalNeedPay.Value = fTotalPrice.Value + fShippingPrice.Value - fDiscount.Value;

        string searchValue = Session["searchValue"] == null ? "" : Session["searchValue"].ToString();
        LoadDataProductList(searchValue);
    }
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    DAProduct daProduct = new DAProduct();
    //    GridView1.DataSource = daProduct.USP_GetAll(0, 0);
    //    GridView1.DataBind();
    //}
    protected void fDiscount_TextChanged(object sender, EventArgs e)
    {
        fTotalNeedPay.Value = fTotalPrice.Value + fShippingPrice.Value - fDiscount.Value;
        ExecUpdate();
    }
    protected void fShippingPrice_TextChanged(object sender, EventArgs e)
    {
        fTotalNeedPay.Value = fTotalPrice.Value + fShippingPrice.Value - fDiscount.Value;
        ExecUpdate();
    }
    protected void fShipProvinceID_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        DADistrict daDistrictShipping = new DADistrict();
        fShipDistrictID.DataSource = daDistrictShipping.USP_District_GetDataForComboBox_ByProvinceID(int.Parse(fShipProvinceID.SelectedValue));
        fShipDistrictID.DataBind();
    }
    protected void fBillProvinceID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DADistrict daDistrictBilling = new DADistrict();
        fBillDistrictID.DataSource = daDistrictBilling.USP_District_GetDataForComboBox_ByProvinceID(int.Parse(fBillProvinceID.SelectedValue));
        fBillDistrictID.DataBind();
    }
}