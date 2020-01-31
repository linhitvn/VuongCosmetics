using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pages_Marketing_SEO_cPage : TUserControlForList
{
    DAPage tData = new DAPage();

    override protected Boolean SetServerControl()
    {
        try
        {
            this.Grid = RadGrid1;
            this.messBox = message_box;

            this.Grid.PageSize = Convert.ToInt32(MyConfig.GetValueByKey("PageSize"));
        }
        catch
        {
            return false;
        }

        return true;
    }
    override protected Boolean LoadData()
    {
        try
        {
            RadGrid1.DataSource = tData.USP_Page_GetAllPage();
            RadGrid1.DataBind();

            //this.Grid.ExpandAllItems();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }
    //protected void RadGrid1_NeedDataSource(object sender, ListNeedDataSourceEventArgs e)
    //{
    //    this.Grid.DataSource = tData.USP_Page_GetAllPage();
    //}
}