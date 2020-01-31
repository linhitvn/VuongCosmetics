using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using System.Web.Configuration;

public partial class Pages_Product_cProductOptionAlter : TUserControlForAlter
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
            DAProductOptionGroup daProductOptionGroup = new DAProductOptionGroup();
            fProductOptionGroupID.DataSource = daProductOptionGroup.USP_ProductOptionGroup_GetDataForComboBox();
            fProductOptionGroupID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAProductOption CreateObjectFromPage()
    {
        // check 
        DAProductOption daProductOption = new DAProductOption();
        //
        daProductOption.fProductOption = fProductOption.Value.Trim();
        daProductOption.fValue = fValue.Value.Trim();
        daProductOption.fProductOptionGroupID = Convert.ToInt32(fProductOptionGroupID.SelectedValue.Trim());

        //

        return daProductOption;
    }

    protected override bool Page_Load_Pos()
    {
        ShowHideColorBox();
        return true;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAProductOption daProductOption = new DAProductOption();
            daProductOption.USP_ProductOption_GetFullID(this.KeyID);
            //
            fProductOption.Value = daProductOption.fProductOption.ToString();
            fValue.Value = daProductOption.fValue.ToString();
            fProductOptionGroupID.SelectedValue = daProductOption.fProductOptionGroupID.ToString();

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
            DAProductOption DAProductOption = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAProductOption.fID = DAProductOption.USP_GetKey();
                this.KeyID = DAProductOption.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAProductOption.fID = 0; }

            DAProductOption.USP_ProductOption_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAProductOption DAProductOption = CreateObjectFromPage();
            DAProductOption.fID = this.KeyID;

            DAProductOption.USP_ProductOption_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAProductOption DAProductOption = new DAProductOption();
            DAProductOption.USP_ProductOption_Delete(pID);
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

    private void ShowHideColorBox()
    {

        if (fProductOptionGroupID.SelectedValue == WebConfigurationManager.AppSettings["OptionTypeColorID"])
        {
            div_Color.Style.Add("display", "inline");
            //div_Color.Visible = true;
        }
        else
        {
            div_Color.Style.Add("display", "none");
            //div_Color.Visible = false;
        }
    }

    protected void ProductOptionGroup_Change(object sender, EventArgs e)
    {
        ShowHideColorBox();
        //Page_Load(sender,  e);
    }
}