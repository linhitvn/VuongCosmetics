using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Telerik.Web.UI;

public partial class Pages_Order_cOrders : TUserControlForList
{
    DAOrders tData = new DAOrders();
    override protected Boolean SetServerControl()
    {
        try
        {
            this.Grid = RadGrid1;
            this.messBox = message_box;

            this.BtCreate = btCreate;
            //this.BtClone = btClone;
            this.BtDelete = btDelete;

            RadGrid1.PageSize = Convert.ToInt32(MyConfig.GetValueByKey("PageSize"));

            int OrderDay;
            try
            {
                OrderDay = int.Parse(MyConfig.GetValueByKey("OrderDay").ToString());
            }
            catch
            {
                OrderDay = 30;
            }
            sFromDate.SelectedDate = DateTime.Now.AddDays(-OrderDay);
            sToDate.SelectedDate = DateTime.Now;
        }
        catch
        {
            return false;
        }

        return true;
    }
    override protected Boolean GetDataComboBox() {

        DACustomer daCustomer = new DACustomer();
        sCustomerID.DataSource = daCustomer.USP_Customer_GetDataForComboBox();
        sCustomerID.DataBind();

        DAOrderStatus daOrderStatus = new DAOrderStatus();
        sOrderStatus.DataSource = daOrderStatus.USP_OrderStatus_GetDataForComboBox();
        sOrderStatus.DataBind();

        return true;
    }
    override protected Boolean LoadData()
    {
        try
        {
            RadGrid1.DataSource = tData.USP_Orders_Search(int.Parse(sCustomerID.Value), int.Parse(sOrderStatus.Value), Convert.ToDateTime(sFromDate.SelectedDate), Convert.ToDateTime(sToDate.SelectedDate));
            RadGrid1.DataBind();

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
            return tData.USP_Orders_Delete(pID);
        }
        catch { return 0; }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = tData.USP_Orders_GetAll(0, 0);
    }

    // Event Clone's button Click
    //public void Clone_Click(object sender, EventArgs e)
    //{
    //    if (this.Grid == null)
    //        return;

    //    int lKeyID = 0;
    //    int count = 0;
    //    foreach (GridDataItem item in this.Grid.SelectedItems)
    //    {
    //        if (item.Selected)
    //        {
    //            lKeyID = int.Parse(item.GetDataKeyValue(this.Grid.MasterTableView.DataKeyNames[0]).ToString());
    //            count++;
    //        }
    //    }
    //    switch (count)
    //    {
    //        case 0:
    //            ShowErrorMes("Vui lòng chọn 1 hàng để sao chép");
    //            break;
    //        case 1:
    //            string page = Page.Request.QueryString["module"];
    //            TNavigation.ClonePage(page, lKeyID);
    //            break;
    //        default: // Have more than 1 Row be selected !
    //            ShowErrorMes("Chỉ được phép chọn tối đa 1 dòng để sao chép");
    //            break;
    //    }
    //}

}