using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using Telerik.Web.UI;

public partial class Pages_Marketing_Discount_cDiscountAlter : TUserControlForAlter
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
            DARecordType daDiscountType = new DARecordType();
            fDiscountTypeID.DataSource = daDiscountType.USP_RecordType_GetComboBox_ByTableName("Discount");
            fDiscountTypeID.DataBind();

            //DARecordType daCouponType = new DARecordType();
            //fCouponTypeID.DataSource = daDiscountType.USP_RecordType_GetComboBox_ByTableName("Coupon");
            //fCouponTypeID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DADiscount CreateObjectFromPage()
    {
        // check 
        DADiscount daDiscount = new DADiscount();
        //
        daDiscount.fDiscountName = fDiscountName.Value.Trim();
        daDiscount.fDiscountTypeID = Convert.ToInt32(fDiscountTypeID.Value.Trim());
        daDiscount.fValue = Convert.ToInt32(fValue.Value.Trim());
        daDiscount.fCoupon = fCoupon.Value.Trim();
        if (unLimitedCoupon.Checked)
        {
            daDiscount.fCouponTypeID = 6;
            daDiscount.fCouponValue = 0;
        }
        else if (limitedPerUser.Checked)
        {
            daDiscount.fCouponTypeID = 7;
            daDiscount.fCouponValue = Convert.ToInt32(limitedPerUserValue.Value.Trim()); 
        }
        else
        {
            daDiscount.fCouponTypeID = 8;
            daDiscount.fCouponValue = Convert.ToInt32(limitedPerUsedValue.Value.Trim()); 
        }
        daDiscount.fIsNotAllowWithOther = fIsNotAllowWithOther.Checked;
        daDiscount.fFromDate = Convert.ToDateTime(fFromDate.SelectedDate);
        daDiscount.fToDate = Convert.ToDateTime(fToDate.SelectedDate);
        daDiscount.fMinProductNumber = Convert.ToInt32(fMinProductNumber.Value.Trim());
        daDiscount.fMinOrderPrice = Convert.ToInt32(fMinOrderPrice.Value.Trim());

        //

        return daDiscount;
    }

    private void LoadCategory()
    {
        DAProductCat daProductCat = new DAProductCat();
        RadTreeView1.DataSource = daProductCat.USP_ProductCat_GetBelongDiscountID(this.KeyID);
        RadTreeView1.DataBind();
    }

    override protected Boolean LoadData()
    {
        try
        {
            LoadCategory();

            // Load Data For Page.
            DADiscount daDiscount = new DADiscount();
            daDiscount.USP_Discount_GetFullID(this.KeyID);
            //
            fDiscountName.Value = daDiscount.fDiscountName.ToString();
            fDiscountTypeID.Value = daDiscount.fDiscountTypeID.ToString();
            fValue.Value = daDiscount.fValue.ToString();
            fCoupon.Value = daDiscount.fCoupon.ToString();
            if (daDiscount.fCouponTypeID == 6)
            {
                unLimitedCoupon.Checked = true;
            }
            else if (daDiscount.fCouponTypeID == 7)
            {
                limitedPerUser.Checked = true;
                limitedPerUserValue.Value = daDiscount.fCouponValue.ToString();
            }
            else
            {
                limitedPerUsed.Checked = true;
                limitedPerUsedValue.Value = daDiscount.fCouponValue.ToString();
            }
            //fCouponTypeID.Value = daDiscount.fCouponTypeID.ToString();
            //fCouponValue.Value = daDiscount.fCouponValue.ToString();
            fIsNotAllowWithOther.Checked = daDiscount.fIsNotAllowWithOther;
            fFromDate.SelectedDate = daDiscount.fFromDate;
            fToDate.SelectedDate = daDiscount.fToDate;
            fMinProductNumber.Value = daDiscount.fMinProductNumber.ToString();
            fMinOrderPrice.Value = daDiscount.fMinOrderPrice.ToString();

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

    override protected int ExecInsert()
    {
        try
        {
            DADiscount DADiscount = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DADiscount.fID = DADiscount.USP_GetKey();
                this.KeyID = DADiscount.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DADiscount.fID = 0; }

            DADiscount.USP_Discount_Insert();
            return UpdateCategory() == true ? 1 : -1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DADiscount DADiscount = CreateObjectFromPage();
            DADiscount.fID = this.KeyID;

            DADiscount.USP_Discount_Update();
            return UpdateCategory() == true ? 1 : -1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DADiscount DADiscount = new DADiscount();
            DADiscount.USP_Discount_Delete(pID);
            return 1;
        }
        catch { return 0; }
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

    private Boolean UpdateCategory()
    {
        try
        {
            String IDListProductCatID = ",";
            DADiscountProductCat daDiscountProductCat = new DADiscountProductCat();
            IList<RadTreeNode> nodeCollection = RadTreeView1.CheckedNodes;
            foreach (RadTreeNode node in nodeCollection)
            {
                IDListProductCatID += node.Value + ",";
            }
            daDiscountProductCat.USP_DiscountProductCat_UpdateCustom(this.KeyID, IDListProductCatID);
            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.ToString());
            return false;
        }
    }
}