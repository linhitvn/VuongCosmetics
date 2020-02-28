using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using Telerik.Web.UI;
using System.IO;


public partial class Pages_Product_cProductCatAlter : TUserControlForAlter
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
            DAProductCat daProductCat = new DAProductCat();
            fParentID.DataSource = daProductCat.USP_ProductCat_GetDataForComboBox();
            fParentID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAProductCat CreateObjectFromPage()
    {
        // check 
        DAProductCat daProductCat = new DAProductCat();
        //
        daProductCat.fProductCat = fProductCat.Value.Trim();
        daProductCat.fParentID = Convert.ToInt32(fParentID.Value.Trim());
        daProductCat.fDescription = fDescription.Value.Trim();
        HttpPostedFile file = inputFile.PostedFile;
        
        if (file != null && file.ContentLength > 0)
        {
            //Delete old file
            Utils.DeleteFile(fIconLink.ImageUrl, Server);
            daProductCat.fIconLink = Utils.UploadImage(file, Server, "~/Media/ProductCat");
        }
        else
        {
            daProductCat.fIconLink = fIconLink.ImageUrl.Replace("~", "");
        }
        fIconLink.ImageUrl = "~" + daProductCat.fIconLink;
        daProductCat.fPos = Convert.ToInt32(fPos.Value.Trim());
        daProductCat.fMetaTitle = fMetaTitle.Value.Trim();
        daProductCat.fMetaDescription = fMetaDescription.Value.Trim();
        daProductCat.fMetaKeywords = fMetaKeywords.Value.Trim();
        daProductCat.fTags = fTags.Value.Trim();

        //

        return daProductCat;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAProductCat daProductCat = new DAProductCat();
            daProductCat.USP_ProductCat_GetFullID(this.KeyID);
            //
            fProductCat.Value = daProductCat.fProductCat.ToString();
            fParentID.Value = daProductCat.fParentID.ToString();
            fDescription.Value = daProductCat.fDescription.ToString();
            fIconLink.ImageUrl = "~" + daProductCat.fIconLink.ToString();
            fPos.Value = daProductCat.fPos.ToString();
            fMetaTitle.Value = daProductCat.fMetaTitle.ToString();
            fMetaDescription.Value = daProductCat.fMetaDescription.ToString();
            fMetaKeywords.Value = daProductCat.fMetaKeywords.ToString();
            fTags.Value = daProductCat.fTags.ToString();

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
            DAProductCat DAProductCat = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAProductCat.fID = DAProductCat.USP_GetKey();
                this.KeyID = DAProductCat.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAProductCat.fID = 0; }

            DAProductCat.USP_ProductCat_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAProductCat DAProductCat = CreateObjectFromPage();
            DAProductCat.fID = this.KeyID;

            DAProductCat.USP_ProductCat_Update();

            // Update ProductCat

            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAProductCat DAProductCat = new DAProductCat();
            DAProductCat.USP_ProductCat_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        if (fProductCat.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập tên danh mục!");
            fProductCat.Focus();
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