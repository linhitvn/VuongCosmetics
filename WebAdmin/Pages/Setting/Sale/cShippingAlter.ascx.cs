using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Setting_Sale_cShippingAlter : TUserControlForAlter
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
            //DAWebGroup mWGroup = new DAWebGroup();
            //
            //ddlRGroup.DataSource = mWGroup.USP_WebGroup_GetAllByCombo();
            //ddlRGroup.DataValueField = "GroupID";
            //ddlRGroup.DataTextField = "GroupName";
            //ddlRGroup.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAShipping CreateObjectFromPage()
    {
        // check 
        DAShipping daShipping = new DAShipping();
        //
        daShipping.fShipping = fShipping.Value.Trim();
        daShipping.fDescription = fDescription.Value.Trim();
        daShipping.fPos = Convert.ToInt32(fPos.Value.Trim());

        //

        return daShipping;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAShipping daShipping = new DAShipping();
            daShipping.USP_Shipping_GetFullID(this.KeyID);
            //
            fShipping.Value = daShipping.fShipping.ToString();
            fDescription.Value = daShipping.fDescription.ToString();
            fPos.Value = daShipping.fPos.ToString();

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
            DAShipping DAShipping = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAShipping.fID = DAShipping.USP_GetKey();
                this.KeyID = DAShipping.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAShipping.fID = 0; }

            DAShipping.USP_Shipping_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAShipping DAShipping = CreateObjectFromPage();
            DAShipping.fID = this.KeyID;

            DAShipping.USP_Shipping_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAShipping DAShipping = new DAShipping();
            DAShipping.USP_Shipping_Delete(pID);
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
}