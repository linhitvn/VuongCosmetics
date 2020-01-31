using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Setting_cShortCutAlter : TUserControlForAlter
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

    private DAShortCutType CreateObjectFromPage()
    {
        // check 
        DAShortCutType daShortCutType = new DAShortCutType();
        //
        daShortCutType.fShortCutType = fShortCutType.Value.Trim();
        daShortCutType.fDescription = fDescription.Value.Trim();
        daShortCutType.fHTMLDefault = fHTMLDefault.Value.Trim();
        daShortCutType.fActive = fActive.Checked;

        //

        return daShortCutType;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAShortCutType daShortCutType = new DAShortCutType();
            daShortCutType.USP_ShortCutType_GetFullID(this.KeyID);
            //
            fShortCutType.Value = daShortCutType.fShortCutType.ToString();
            fDescription.Value = daShortCutType.fDescription.ToString();
            fHTMLDefault.Value = daShortCutType.fHTMLDefault.ToString();
            fActive.Checked = daShortCutType.fActive;

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
            DAShortCutType DAShortCutType = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAShortCutType.fID = DAShortCutType.USP_GetKey();
                this.KeyID = DAShortCutType.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAShortCutType.fID = 0; }

            DAShortCutType.USP_ShortCutType_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAShortCutType DAShortCutType = CreateObjectFromPage();
            DAShortCutType.fID = this.KeyID;

            DAShortCutType.USP_ShortCutType_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAShortCutType DAShortCutType = new DAShortCutType();
            DAShortCutType.USP_ShortCutType_Delete(pID);
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