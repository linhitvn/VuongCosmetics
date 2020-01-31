using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Telerik.Web.UI;

public partial class Pages_WebUI_cControl : TUserControlForList_TreeList
{
    DAControl tData = new DAControl();
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
            RadTreeList1.DataSource = tData.USP_Control_GetByPageID_GetTree(int.Parse(sPageID.Value));
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
            return tData.USP_Control_Delete(pID);
        }
        catch { return 0; }
    }


    protected void RadGrid1_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
    {
        RadTreeList1.DataSource = tData.USP_Control_GetByPageID_GetTree(int.Parse(sPageID.Value));
    }
    override protected Boolean GetDataComboBox()
    {
        DAPage daPage = new DAPage();
        sPageID.DataSource = daPage.USP_Page_GetDataForComboBox();
        sPageID.DataBind();

        return true;
    }

    protected void Search_Click(Object sender, EventArgs e)
    {
        LoadData();
    }
}