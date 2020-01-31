using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using System.IO;

public partial class Pages_WebUI_cControlAlter : TUserControlForAlter
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
            DAPage daPage = new DAPage();
            fPageID.DataSource = daPage.USP_Page_GetDataForComboBox();
            fPageID.DataBind();

            DAControlList daControlList = new DAControlList();
            fUControl.DataSource = daControlList.USP_ControlList_GetDataForComboBox_Custom();
            fUControl.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAControl CreateObjectFromPage()
    {
        // check 
        DAControl daControl = new DAControl();
        //
        daControl.fControlName = fControlName.Value.Trim();
        daControl.fPageID = Convert.ToInt32(fPageID.SelectedValue.Trim());
        daControl.fParentID = Convert.ToInt32(fParentID.Value);
        daControl.fUControl = fUControl.SelectedValue.Trim();
        daControl.fParam = fparam.Value.Trim();
        daControl.fIsAdsControl = fIsAdsControl.Checked;
        daControl.fPos = Convert.ToInt32(fPos.Value.Trim());
        daControl.fActive = fActive.Checked;
        daControl.fOperator = MySession.UserName;

        //

        return daControl;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAControl daControl = new DAControl();
            daControl.USP_Control_GetFullID(this.KeyID);
            //
            fControlName.Value = daControl.fControlName.ToString();
            fPageID.SelectedValue = daControl.fPageID.ToString();

            LoadListControl();
            fParentID.Value = daControl.fParentID.ToString();
            
            fUControl.SelectedValue = daControl.fUControl.ToString();
            fparam.Value = daControl.fParam.ToString();
            fIsAdsControl.Checked = daControl.fIsAdsControl;
            fPos.Value = daControl.fPos.ToString();
            fActive.Checked = daControl.fActive;

            //
            LoadDataControlTemplate();

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
            DAControl DAControl = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAControl.fID = DAControl.USP_GetKey();
                this.KeyID = DAControl.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAControl.fID = 0; }

            DAControl.USP_Control_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAControl DAControl = CreateObjectFromPage();
            DAControl.fID = this.KeyID;

            DAControl.USP_Control_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAControl DAControl = new DAControl();
            DAControl.USP_Control_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        // Check Thong số Control
        string reg = fparam.Attributes["placeholder"];
        if (fControlName.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập tên Control");
            fControlName.Focus();
            return false;
        }
        if (fPageID.SelectedValue.Trim() == "0")
        {
            ShowErrorMes("Bạn chưa nhập Control này thuộc trang nào");
            fPageID.Focus();
            return false;
        }
        if (fUControl.SelectedValue.Trim() == "")
        {
            ShowErrorMes("Bạn chưa chọn Control template");
            fUControl.Focus();
            return false;
        }
        if (!Utils.CheckReg(reg, fparam.Value))
        {
            ShowErrorMes("Thông số param không hợp lệ. Vui lòng đọc hướng dẫn phía dưới");
            fparam.Focus();
            return false;
        }
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

    private void LoadDataControlTemplate()
    {
        DAControlList daControlList = new DAControlList();
        daControlList.USP_ControlList_GetByControlPath(fUControl.SelectedValue);
        fparam.Value = "";
        fparam.Attributes["placeholder"] = daControlList.fParamExample;
        fIsAdsControl.Checked = daControlList.fIsAdsControl;
        fParamHelp.InnerText = daControlList.fDescription;
        fImgLink.ImageUrl = "~" + daControlList.fImgLink;
    }

    private void LoadListControl()
    {
        DAControl daControl = new DAControl();
        fParentID.DataSource = daControl.USP_Control_GetDataForComboBox_ByPageID(int.Parse(fPageID.SelectedValue));
        fParentID.DataBind();
    }

    protected void fUControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDataControlTemplate();
    }
    protected void fPageID_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadListControl();
    }
}