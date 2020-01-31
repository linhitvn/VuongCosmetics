using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Telerik.Web.UI;

public partial class Pages_Article_cCagegory : TUserControlForList_TreeList
{
    DACategory tData = new DACategory();
    override protected Boolean SetServerControl()
    {
        try
        {
            this.Grid = RadTreeList1;
            this.messBox = message_box;

            this.BtCreate = btCreate;
            this.BtClone = btClone;
            this.BtDelete = btDelete;

            RadTreeList1.PageSize = Convert.ToInt32(MyConfig.GetValueByKey("PageSize"));
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
            RadTreeList1.DataSource = tData.USP_Category_GetForTree();
            RadTreeList1.DataBind();

            RadTreeList1.ExpandAllItems();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            return tData.USP_Category_Delete(pID);
        }
        catch { return 0; }
    }

    protected void RadGrid1_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
    {
        RadTreeList1.DataSource = tData.USP_Category_GetForTree();        
    }
}