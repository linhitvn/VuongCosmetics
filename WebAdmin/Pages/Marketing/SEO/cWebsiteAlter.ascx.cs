using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Marketing_SEO_cWebsite : TUserControlForAlter
{
    DAWebInfo daWebInfo = new DAWebInfo();
    override protected Boolean SetServerControl()
    {
        try
        {
            // Set Message Value
            this.messBox = message_box;

            // Set button Controller
            this.BtSave1 = Save;
           // this.BtSaveAndCreate1 = SaveAndCreate;
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
            daWebInfo.USP_WebInfo_GetByID(1);

            fWebsiteName.Value = daWebInfo.fWebsiteName.ToString();
            fMetaTitle.Value = daWebInfo.fSeoTitle.ToString();
            fMetaDescription.Value = daWebInfo.fSeoDescription.ToString();
            fMetaKeywords.Value = daWebInfo.fSeoKeyword.ToString();
        }
        catch (Exception e)
        {
            ShowErrorMes("Lỗi hệ thống: " + e.ToString());
            return false;
        }

        return true;
    }

    //protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    //{
    //    //RadGrid1.DataSource = tData.USP_Payment_GetAll(0, 0);
    //}
    protected override int ExecUpdate()
    {
        daWebInfo.fID = this.KeyID;
        daWebInfo.fSeoDescription = fMetaDescription.Value;
        daWebInfo.fSeoKeyword = fMetaDescription.Value;
        daWebInfo.fSeoTitle = fMetaTitle.Value;

        daWebInfo.USP_WebInfo_UpdateSEO();
        return 1;
    }
}