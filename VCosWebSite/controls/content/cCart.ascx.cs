using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class controls_content_cCart : System.Web.UI.UserControl
{
    DAOrderDetailTemp mOrder = new DAOrderDetailTemp();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadProduct();
        }
    }

    private void LoadProduct()
    {
        try
        {
            DataTable dt = new DataTable();
            
            dt.Load(mOrder.USP_OrderDetailTemp_GetAllOrderID(Session["WOrderID"].ToString()));

            if (dt.Rows.Count > 0)
            {
                lblQuantity.Text = dt.Compute("SUM(Quantity)", string.Empty).ToString();
                lkbBuy.Visible = true;
            }
            // Load       
            rptOrder.DataSource = dt;
            rptOrder.DataBind();

            
        }
        catch
        {
        }
    }

    protected void rptOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            try
            {
                Label lblID = new Label();
                lblID = (Label)e.Item.FindControl("lblID");
                int iID = int.Parse(lblID.Text);

                mOrder.USP_OrderDetailTemp_Delete(iID);
            }
            catch { return; };

            Response.Redirect("~/gio-hang/index.html");
        }
    }


    protected void lkbBuy_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/check-out/index.html");
    }
}