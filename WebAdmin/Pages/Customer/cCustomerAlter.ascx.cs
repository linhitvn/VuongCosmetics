using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using Telerik.Web.UI;
using System.Web.Configuration;

public partial class Pages_Customer_cCustomerAlter : TUserControlForAlter
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
            DAProvince daProvince = new DAProvince();
            fProvinceID.DataSource = daProvince.USP_Province_GetDataForComboBox();
            fProvinceID.DataBind();

            daProvince.CloseAll();

            DACustomerGroup daCustomerGroup = new DACustomerGroup();
            fCustomerGroupID.DataSource = daCustomerGroup.USP_CustomerGroup_GetDataForComboBox();
            fCustomerGroupID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DACustomer CreateObjectFromPage()
    {
        // check 
        DACustomer daCustomer = new DACustomer();
        //
        daCustomer.fCustomerName = fCustomerName.Value.Trim();
        daCustomer.fCustomerGroupID = Convert.ToInt32(fCustomerGroupID.Value.Trim());
        daCustomer.fCompany = fCompany.Value.Trim();
        daCustomer.fEmail = fEmail.Value.Trim();
        daCustomer.fPhone = fPhone.Value.Trim();
        daCustomer.fAddress = fAddress.Value.Trim();
        daCustomer.fProvinceID = Convert.ToInt32(fProvinceID.Value.Trim());
        daCustomer.fBirthday = fBirthday.Value.Trim();
        daCustomer.fSex = Convert.ToByte(fSex.Value.Trim());
        daCustomer.fSocialNetwork = fSocialNetwork.Value.Trim();
        daCustomer.fUsername = fUsername.Value.Trim();
        daCustomer.fPassword = fPassword.Value.Trim();
        daCustomer.fNote = fNote.Value.Trim();
        daCustomer.fOperator = "";// MySession.UserName;

        //

        return daCustomer;
    }

    private void LoadWishList(int pCustomerID)
    {
        DAWishlist daWishList = new DAWishlist();
        RadGrid_WishList.DataSource = daWishList.USP_Wishlist_GetByCustomerID(pCustomerID);
        RadGrid_WishList.DataBind();
        daWishList.CloseAll();

    }

    private void LoadOrders(int pCustomerID)
    {
        DAOrders daOrders = new DAOrders();
        RadGrid_Orders.DataSource = daOrders.USP_Orders_GetByCustomerID(pCustomerID);
        RadGrid_Orders.DataBind();

        daOrders.CloseAll();
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DACustomer daCustomer = new DACustomer();
            daCustomer.USP_Customer_GetFullID(this.KeyID);
            //
            fCustomerName.Value = daCustomer.fCustomerName.ToString();
            fCustomerGroupID.Value = daCustomer.fCustomerGroupID.ToString();
            fCompany.Value = daCustomer.fCompany.ToString();
            fEmail.Value = daCustomer.fEmail.ToString();
            fPhone.Value = daCustomer.fPhone.ToString();
            fAddress.Value = daCustomer.fAddress.ToString();
            fProvinceID.Value = daCustomer.fProvinceID.ToString();
            fBirthday.Value = daCustomer.fBirthday.ToString();
            fSex.Value = daCustomer.fSex.ToString();
            fSocialNetwork.Value = daCustomer.fSocialNetwork.ToString();
            fUsername.Value = daCustomer.fUsername.ToString();
            fPassword.Value = daCustomer.fPassword.ToString();
            fNote.Value = daCustomer.fNote.ToString();
            fSysDate.SelectedDate = daCustomer.fSysDate;

            // Load WishList
            LoadWishList(this.KeyID);
            LoadOrders(this.KeyID);

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

    override protected int ExecInsert()
    {
        try
        {
            DACustomer DACustomer = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DACustomer.fID = DACustomer.USP_GetKey();
                this.KeyID = DACustomer.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DACustomer.fID = 0; }

            DACustomer.USP_Customer_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DACustomer DACustomer = CreateObjectFromPage();
            DACustomer.fID = this.KeyID;

            DACustomer.USP_Customer_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DACustomer DACustomer = new DACustomer();
            DACustomer.USP_Customer_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        if (fCustomerName.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập tên khách hàng!");
            fCustomerName.Focus();
            return false;
        }
        if (fCustomerGroupID.Value.Trim() == "0")
        {
            ShowErrorMes("Bạn chưa nhập nhóm khách hàng!");
            fCustomerGroupID.Focus();
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

    protected void RadGrid_Orders_ItemCommand(object sender, GridCommandEventArgs e)
    {
        int lKeyID = 0;
        string lEvent = e.CommandName;
        string page = "";
        switch (lEvent)
        {
            case ActRow.Edit:
                lKeyID = int.Parse(e.CommandArgument.ToString());
                page = WebConfigurationManager.AppSettings["PageOrder"];
                TNavigation.EditPage(page, lKeyID, "401", "edit");
                break;
        }
    }
}