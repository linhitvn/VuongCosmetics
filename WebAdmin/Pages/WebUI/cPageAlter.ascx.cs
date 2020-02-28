using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_SysCategory_cPageAlter : TUserControlForAlter
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

    private DAPage CreateObjectFromPage()
    {
        // check 
        DAPage daPage = new DAPage();
        //
        daPage.fPage = fPage.Value.Trim();
        daPage.fPageURL = fPageURL.Value.Trim();
        daPage.fUControl = fUControl.Value.Trim();
        daPage.fDescription = fDescription.Value;

        HttpPostedFile file = inputFile.PostedFile;

        if (file != null && file.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImgLink.ImageUrl, Server);
            daPage.fImgLink = Utils.UploadImage(file, Server, "~/Media/Page");
        }
        else
        {
            daPage.fImgLink = fImgLink.ImageUrl.Replace("~", "");
        }
        fImgLink.ImageUrl = "~" + daPage.fImgLink;

        daPage.fParam = fParam.Value.Trim();
        daPage.fActive = fActive.Checked;
        daPage.fOperator = MySession.UserName;
        daPage.fMetaTitle = fMetaTitle.Value.Trim();
        daPage.fMetaDescription = fMetaDescription.Value.Trim();
        daPage.fMetaKeywords = fMetaKeywords.Value.Trim();
        daPage.fTags = fTags.Value.Trim();
        //

        return daPage;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAPage daPage = new DAPage();
            daPage.USP_Page_GetFullID(this.KeyID);
            //
            fPage.Value = daPage.fPage.ToString();
            fPageURL.Value = daPage.fPageURL.ToString();
            fUControl.Value = daPage.fUControl.ToString();
            fDescription.Value = daPage.fDescription.ToString();
            fImgLink.ImageUrl = "~" + daPage.fImgLink.ToString();
            fParam.Value = daPage.fParam.ToString();
            fActive.Checked = daPage.fActive;
            fMetaTitle.Value = daPage.fMetaTitle.ToString();
            fMetaDescription.Value = daPage.fMetaDescription.ToString();
            fMetaKeywords.Value = daPage.fMetaKeywords.ToString();
            fTags.Value = daPage.fTags.ToString();
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
            DAPage DAPage = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAPage.fID = DAPage.USP_GetKey();
                this.KeyID = DAPage.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAPage.fID = 0; }

            DAPage.USP_Page_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAPage DAPage = CreateObjectFromPage();
            DAPage.fID = this.KeyID;

            DAPage.USP_Page_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAPage DAPage = new DAPage();
            DAPage.USP_Page_Delete(pID);
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