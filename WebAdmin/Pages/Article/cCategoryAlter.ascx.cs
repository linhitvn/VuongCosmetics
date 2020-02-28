using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Article_cCategoryAlter : TUserControlForAlter
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
            DACategory daCategory = new DACategory();
            fParentID.DataSource = daCategory.USP_Category_GetDataForComboBox(this.KeyID);
            fParentID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DACategory CreateObjectFromPage()
    {
        // check 
        DACategory daCategory = new DACategory();
        //
        daCategory.fCategory = fCategory.Value.Trim();
        daCategory.fParentID = Convert.ToInt32(fParentID.Value.Trim());
        daCategory.fUrlRewrite = fUrlRewrite.Value.Trim();

        HttpPostedFile file = inputFile.PostedFile;

        if (file != null && file.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImgLink.ImageUrl, Server);
            daCategory.fImgLink = Utils.UploadImage(file, Server, "~/Media/Category");
        }
        else
        {
            daCategory.fImgLink = fImgLink.ImageUrl.Replace("~", "");
        }
        fImgLink.ImageUrl = "~" + daCategory.fImgLink;

        daCategory.fMetaTitle = fMetaTitle.Value.Trim();
        daCategory.fMetaDescription = fMetaDescription.Value.Trim();
        daCategory.fMetaKeywords = fMetaKeywords.Value.Trim();
        daCategory.fTags = fTags.Value.Trim();
        daCategory.fActive = fActive.Checked;
        daCategory.fPos = Convert.ToInt32(fPos.Value.Trim());
        daCategory.fOperator = MySession.UserName;

        //

        return daCategory;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DACategory daCategory = new DACategory();
            daCategory.USP_Category_GetFullID(this.KeyID);
            //
            fCategory.Value = daCategory.fCategory.ToString();
            fParentID.Value = daCategory.fParentID.ToString();
            fUrlRewrite.Value = daCategory.fUrlRewrite.ToString();
            fImgLink.ImageUrl = "~" + daCategory.fImgLink.ToString();
            fMetaTitle.Value = daCategory.fMetaTitle.ToString();
            fMetaDescription.Value = daCategory.fMetaDescription.ToString();
            fMetaKeywords.Value = daCategory.fMetaKeywords.ToString();
            fTags.Value = daCategory.fTags.ToString();
            fActive.Checked = daCategory.fActive;
            fPos.Value = daCategory.fPos.ToString();

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
            DACategory DACategory = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DACategory.fID = DACategory.USP_GetKey();
                this.KeyID = DACategory.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DACategory.fID = 0; }

            DACategory.USP_Category_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DACategory DACategory = CreateObjectFromPage();
            DACategory.fID = this.KeyID;

            DACategory.USP_Category_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DACategory DACategory = new DACategory();
            DACategory.USP_Category_Delete(pID);
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