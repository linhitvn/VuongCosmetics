using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Marketing_SupportOnline_cSupportOnlineAlter : TUserControlForAlter
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

    private DASupportOnline CreateObjectFromPage()
    {
        // check 
        DASupportOnline daSupportOnline = new DASupportOnline();
        //
        daSupportOnline.fSupportName = fSupportName.Value.Trim();
        HttpPostedFile file = inputFile.PostedFile;

        if (file != null && file.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImgLink.ImageUrl, Server);
            daSupportOnline.fImgLink = Utils.UploadImage(file, Server, "~/Media/SupportOnline");
        }
        else
        {
            daSupportOnline.fImgLink = fImgLink.ImageUrl.Replace("~", "");
        }
        fImgLink.ImageUrl = "~" + daSupportOnline.fImgLink;


        daSupportOnline.fPhone = fPhone.Value.Trim();
        daSupportOnline.fEmail = fEmail.Value.Trim();
        daSupportOnline.fSkype = fSkype.Value.Trim();
        daSupportOnline.fYahoo = fYahoo.Value.Trim();
        daSupportOnline.fGooglePlus = fGooglePlus.Value.Trim();
        daSupportOnline.fFaceBook = fFaceBook.Value.Trim();
        daSupportOnline.fActive = fActive.Checked;
        daSupportOnline.fPos = Convert.ToInt32(fPos.Value.Trim());

        //

        return daSupportOnline;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DASupportOnline daSupportOnline = new DASupportOnline();
            daSupportOnline.USP_SupportOnline_GetFullID(this.KeyID);
            //
            fSupportName.Value = daSupportOnline.fSupportName.ToString();
            fImgLink.ImageUrl = "~" + daSupportOnline.fImgLink.ToString();
            fPhone.Value = daSupportOnline.fPhone.ToString();
            fEmail.Value = daSupportOnline.fEmail.ToString();
            fSkype.Value = daSupportOnline.fSkype.ToString();
            fYahoo.Value = daSupportOnline.fYahoo.ToString();
            fGooglePlus.Value = daSupportOnline.fGooglePlus.ToString();
            fFaceBook.Value = daSupportOnline.fFaceBook.ToString();
            fActive.Checked = daSupportOnline.fActive;
            fPos.Value = daSupportOnline.fPos.ToString();

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
            DASupportOnline DASupportOnline = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DASupportOnline.fID = DASupportOnline.USP_GetKey();
                this.KeyID = DASupportOnline.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DASupportOnline.fID = 0; }

            DASupportOnline.USP_SupportOnline_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DASupportOnline DASupportOnline = CreateObjectFromPage();
            DASupportOnline.fID = this.KeyID;

            DASupportOnline.USP_SupportOnline_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DASupportOnline DASupportOnline = new DASupportOnline();
            DASupportOnline.USP_SupportOnline_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        if (fSupportName.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập tên hiển thị!");
            fSupportName.Focus();
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

}