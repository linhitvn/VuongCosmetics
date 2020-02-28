using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using Telerik.Web.UI;
using System.IO;

public partial class Pages_Product_cProducerAlter : TUserControlForAlter
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

    private DAProducer CreateObjectFromPage()
    {
        // check 
        DAProducer daProducer = new DAProducer();
        //
        daProducer.fProducerName = fProducerName.Value.Trim();
        daProducer.fDescription = fDescription.Value.Trim();

        HttpPostedFile file = inputFile.PostedFile;

        if (file != null && file.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fLogoLink.ImageUrl, Server);
            daProducer.fLogoLink = Utils.UploadImage(file, Server, "~/Media/Producer");
        }
        else
        {
            daProducer.fLogoLink = fLogoLink.ImageUrl.Replace("~", "");
        }
        fLogoLink.ImageUrl = "~" + daProducer.fLogoLink;
        daProducer.fWebsite = fWebsite.Value.Trim();

        //

        return daProducer;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAProducer daProducer = new DAProducer();
            daProducer.USP_Producer_GetFullID(this.KeyID);
            //
            fProducerName.Value = daProducer.fProducerName.ToString();
            fDescription.Value = daProducer.fDescription.ToString();
            fLogoLink.ImageUrl = "~" + daProducer.fLogoLink.ToString();
            fWebsite.Value = daProducer.fWebsite.ToString();

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
            DAProducer DAProducer = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAProducer.fID = DAProducer.USP_GetKey();
                this.KeyID = DAProducer.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAProducer.fID = 0; }

            DAProducer.USP_Producer_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAProducer DAProducer = CreateObjectFromPage();
            DAProducer.fID = this.KeyID;

            DAProducer.USP_Producer_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAProducer DAProducer = new DAProducer();
            DAProducer.USP_Producer_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        if (fProducerName.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập tên nhà sản xuất!");
            fProducerName.Focus();
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


}