using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Marketing_SEO_cProductCatAlter : TUserControlForAlter
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

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAProductCat daProductCat = new DAProductCat();
            daProductCat.USP_ProductCat_GetFullID(this.KeyID);

            fProductCat.Value = daProductCat.fProductCat.ToString();
            fMetaTitle.Value = daProductCat.fMetaTitle.ToString();
            fMetaDescription.Value = daProductCat.fMetaDescription.ToString();
            fMetaKeywords.Value = daProductCat.fMetaKeywords.ToString();

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

    protected override int ExecUpdate()
    {
        DAProductCat daProductCat = new DAProductCat();
        daProductCat.fID = this.KeyID;
        daProductCat.fMetaDescription = fMetaDescription.Value;
        daProductCat.fMetaKeywords = fMetaDescription.Value;
        daProductCat.fMetaTitle = fMetaTitle.Value;

        daProductCat.USP_ProductCat_UpdateSEO();
        return 1;
    }
}