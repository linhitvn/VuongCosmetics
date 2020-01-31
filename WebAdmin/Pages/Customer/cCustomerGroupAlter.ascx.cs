using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Customer_cCustomerGroupAlter : TUserControlForAlter
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

    private DACustomerGroup CreateObjectFromPage()
    {
        // check 
        DACustomerGroup daCustomerGroup = new DACustomerGroup();
        //
        daCustomerGroup.fCustomerGroup = fCustomerGroup.Value.Trim();
        daCustomerGroup.fDescription = fDescription.Value.Trim();

        //

        return daCustomerGroup;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DACustomerGroup daCustomerGroup = new DACustomerGroup();
            daCustomerGroup.USP_CustomerGroup_GetFullID(this.KeyID);
            //
            fCustomerGroup.Value = daCustomerGroup.fCustomerGroup.ToString();
            fDescription.Value = daCustomerGroup.fDescription.ToString();

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
            DACustomerGroup DACustomerGroup = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DACustomerGroup.fID = DACustomerGroup.USP_GetKey();
                this.KeyID = DACustomerGroup.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DACustomerGroup.fID = 0; }

            DACustomerGroup.USP_CustomerGroup_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DACustomerGroup DACustomerGroup = CreateObjectFromPage();
            DACustomerGroup.fID = this.KeyID;

            DACustomerGroup.USP_CustomerGroup_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DACustomerGroup DACustomerGroup = new DACustomerGroup();
            DACustomerGroup.USP_CustomerGroup_Delete(pID);
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