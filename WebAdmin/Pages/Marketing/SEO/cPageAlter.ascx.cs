using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Marketing_SEO_cPageAlter : TUserControlForAlter
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
            DAPage daPage = new DAPage();
            daPage.USP_Page_GetFullID(this.KeyID);

            fPage.Value = daPage.fPage.ToString();
            fMetaTitle.Value = daPage.fMetaTitle.ToString();
            fMetaDescription.Value = daPage.fMetaDescription.ToString();
            fMetaKeywords.Value = daPage.fMetaKeywords.ToString();

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
        DAPage daPage = new DAPage();
        daPage.fID = this.KeyID;
        daPage.fMetaDescription = fMetaDescription.Value;
        daPage.fMetaKeywords = fMetaDescription.Value;
        daPage.fMetaTitle = fMetaTitle.Value;

        daPage.USP_Page_UpdateSEO();
        return 1;
        //return base.ExecUpdate();
    }
}