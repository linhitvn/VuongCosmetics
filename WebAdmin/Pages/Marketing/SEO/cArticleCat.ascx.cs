using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pages_Marketing_SEO_cArticleCat : TUserControlForList_TreeList
{
    DACategory tData = new DACategory();
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
            this.Grid.DataSource = tData.USP_Category_GetForTree();
            this.Grid.DataBind();

            this.Grid.ExpandAllItems();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }
    protected void RadGrid1_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
    {
        this.Grid.DataSource = tData.USP_Category_GetForTree();
    }
}