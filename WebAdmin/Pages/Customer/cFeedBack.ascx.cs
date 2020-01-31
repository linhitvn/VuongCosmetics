using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Telerik.Web.UI;
using System.Data;

public partial class Pages_Customer_cFeedBack : TUserControlForList
{
    DAFeedBack tData = new DAFeedBack();
    public DataGrid dataGrid = new DataGrid();
    override protected Boolean SetServerControl()
    {
        try
        {
            this.Grid = RadGrid1;
            this.messBox = message_box;

            //this.BtCreate = btCreate;
            //this.BtClone = btClone;
            this.BtDelete = btDelete;

            RadGrid1.PageSize = Convert.ToInt32(MyConfig.GetValueByKey("PageSize"));
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
            
            //RadGrid1.DataSource = tData.USP_FeedBack_GetAll(0, 0);
            RadGrid1.DataSource = tData.USP_FeedBack_GetAll(0, 0);
            RadGrid1.DataBind();
           


            dataGrid.DataBind();
            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    //private DataTable BuildTable(DataSet ds)
    //{
    //    DataTable tbData = new DataTable("a");
    //    tbData.Columns.Add("ID");//id
    //    tbData.Columns.Add("IsRead");//star
    //    tbData.Columns.Add("Name");//name
    //    tbData.Columns.Add("FeedBack");//urgent
    //    tbData.Columns.Add("SysDate"); //date
    //    Table aa = new Table();
        
        
    //    ////////////////////////////////////
    //    DataRow row = tbData.NewRow();
    //    if(ds.Tables.Count == 1)
    //    {
    //        foreach(DataRow dr in ds.Tables[0].Rows)
    //        {
    //            row["ID"] = dr["ID"].ToString();
    //            //row["IsRead"] = dr["IsRead"].ToString();
    //            if (bool.Parse(dr["IsRead"].ToString()) == true)
    //                row["IsRead"] = "<i class=\"fa fa-star\">";
    //            else
    //                row["IsRead"] = "<i class=\"fa fa-star-o\"></i>";

    //            row["Name"] = dr["Name"].ToString();
    //            row["FeedBack"] = dr["FeedBack"].ToString();
    //            row["SysDate"] = dr["SysDate"].ToString();
                
    //            tbData.Rows.Add(row);
    //            row = null;
    //        }
    //    }
    //    return tbData;

    //}
    //void RadGrid1_RowDataBound(object sender, GridItemEventArgs e)
    //{
    //    if (e.Item is GridDataItem)
    //    {
    //        if (bool.Parse(e.Cells[1].ToString()) == true)
    //        e.Row.CssClass = "unread";
    //    }
    //}
    override protected int DeleteByID(int pID)
    {
        try
        {
            return tData.USP_FeedBack_Delete(pID);
        }
        catch { return 0; }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = tData.USP_FeedBack_GetAll(0, 0);
    }
    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        foreach (GridDataItem dataItem in RadGrid1.Items)
        {
            dataItem.CssClass = "unread";
            if (dataItem.Expanded)// && dataItem.OwnerTableView.Name == "TableName")
            {
                //dataItem.BackColor = Color.Yellow;
                dataItem.CssClass = "unread";
            }
        }
    }
}