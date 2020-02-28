using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using System.IO;
using Telerik.Web.UI;

public partial class Pages_Widgets_ShortCutAlter : TUserControlForAlter
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
            DAShortCutType daShortCutType = new DAShortCutType();
            fShortCutTypeID.DataSource = daShortCutType.USP_ShortCutType_GetDataForComboBox();
            fShortCutTypeID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAShortCut CreateObjectFromPage()
    {
        // check 
        DAShortCut daShortCut = new DAShortCut();
        //
        daShortCut.fShortCutName = fShortCutName.Value.Trim();
        daShortCut.fShortCutTypeID = Convert.ToInt32(fShortCutTypeID.Value.Trim());
        daShortCut.fContent1 = fContent1.Value.Trim();
        daShortCut.fContent2 = fContent2.Value.Trim();

        HttpPostedFile file = inputFile.PostedFile;

        if (file != null && file.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fImgLink.ImageUrl, Server);
            daShortCut.fImgLink = Utils.UploadImage(file, Server, "~/Media/ShortCut");
        }
        else
        {
            daShortCut.fImgLink = fImgLink.ImageUrl.Replace("~", "");
        }
        fImgLink.ImageUrl = "~" + daShortCut.fImgLink;

        daShortCut.fCss = fCss.Value;
        daShortCut.fUrlLink = fUrlLink.Value.Trim();
        daShortCut.fPos = Convert.ToInt32(fPos.Value.Trim());
        daShortCut.fActive = fActive.Checked;

        //

        return daShortCut;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAShortCut daShortCut = new DAShortCut();
            daShortCut.USP_ShortCut_GetFullID(this.KeyID);
            //
            fShortCutName.Value = daShortCut.fShortCutName.ToString();
            fShortCutTypeID.Value = daShortCut.fShortCutTypeID.ToString();
            fContent1.Value = daShortCut.fContent1.ToString();
            fContent2.Value = daShortCut.fContent2.ToString();
            fImgLink.ImageUrl = "~" + daShortCut.fImgLink.ToString();
            fCss.Value = daShortCut.fCss;
            fUrlLink.Value = daShortCut.fUrlLink.ToString();
            fPos.Value = daShortCut.fPos.ToString();
            fActive.Checked = daShortCut.fActive;

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
            DAShortCut DAShortCut = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAShortCut.fID = DAShortCut.USP_GetKey();
                this.KeyID = DAShortCut.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAShortCut.fID = 0; }

            DAShortCut.USP_ShortCut_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAShortCut DAShortCut = CreateObjectFromPage();
            DAShortCut.fID = this.KeyID;

            DAShortCut.USP_ShortCut_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAShortCut DAShortCut = new DAShortCut();
            DAShortCut.USP_ShortCut_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        if (fShortCutName.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập tiêu đề ShortCut!");
            fShortCutName.Focus();
            return false;
        }
        if (fShortCutTypeID.Value.Trim() == "0")
        {
            ShowErrorMes("Bạn chưa nhập loại ShortCut!");
            fShortCutTypeID.Focus();
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