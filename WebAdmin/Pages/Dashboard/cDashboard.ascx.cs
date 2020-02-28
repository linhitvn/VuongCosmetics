using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.Configuration;

public partial class Pages_Dashboard_cDashboard : TUserControlForList
{
    DAOrders tData = new DAOrders();

    protected override bool SetServerControl()
    {
        this.messBox = message_box;
        return true;
    }

    private void LoadDateShortStatistic()
    {
        DAReport daReport = new DAReport();
        daReport.USP_Report_DashBoard();

        if (daReport.mDataReader.Read())
        {
            fCustomerNumber.InnerText = daReport.mDataReader["CustomerNumber"].ToString();
            fOrderNumber.InnerText = daReport.mDataReader["OrderNumber"].ToString();
            fProductNumber.InnerText = daReport.mDataReader["ProductNumber"].ToString();
            fNewsNumber.InnerText = daReport.mDataReader["NewsNumber"].ToString();

            daReport.mDataReader.Close();
        }
        else
            daReport.mDataReader.Close();

    }

    // Xử lý dữ liệu đơn hàng
    override protected Boolean LoadData()
    {
        try
        {
            LoadDateShortStatistic();

            RadGrid_Orders.DataSource = tData.USP_Orders_New();
            RadGrid_Orders.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }
    protected void RadGrid_Orders_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid_Orders.DataSource = tData.USP_Orders_New();
    }

    protected void RadGrid_Orders_ItemCommand(object sender, GridCommandEventArgs e)
    {
        int lKeyID = 0;
        string lEvent = e.CommandName;
        string page = "";
        switch (lEvent)
        {
            case ActRow.Edit:
                lKeyID = int.Parse(e.CommandArgument.ToString());
                page = WebConfigurationManager.AppSettings["PageOrder"];
                TNavigation.EditPage(page, lKeyID);
                break;
        }
    }
}