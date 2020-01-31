using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;

public partial class controls_header_cheader : System.Web.UI.UserControl
{
    DAOrderDetailTemp mOrder = new DAOrderDetailTemp();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["WOrderID"] != null)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt.Load(mOrder.USP_OrderDetailTemp_GetByOrderID(Session["WOrderID"].ToString()));
        //        if (dt.Rows.Count > 0)
        //        {
        //            lblQuantity.Text = dt.Rows[0]["Quantity"].ToString();
        //            lblTotalPrice.Text = dt.Rows[0]["TotalPrice"].ToString();
        //        }              
        //    }
        //    catch { return; };

        //}        
        if (!Page.IsPostBack)
        {
            LoadNotification();
        }
    }
    
    protected void lkbSearch_Click(object sender, EventArgs e)
    {
        //txtSearch.Text = txtSearch.Text.Trim();
        //if (txtSearch.Text.Length > 0)
        //{
        //    Session["SearchKey"] = txtSearch.Text;
        //    Response.Redirect("~/tim-kiem/index.html");
        //}
    }

    private void LoadNotification()
    {
        try
        {
            DataTable dt = new DataTable();
            DAArticle oData = new DAArticle();
            dt.Load(oData.USP_Article_Client_GetNotification());

            rptNotification.DataSource = dt;
            rptNotification.DataBind();
        }
        catch
        {
        }
    }
}