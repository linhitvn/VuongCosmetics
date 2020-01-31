using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_content_cOrder : System.Web.UI.UserControl
{
    DAOrderDetailTemp mOrder = new DAOrderDetailTemp();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadProduct();
            LoadRelateProduct(0);
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
                lblTax.Text = dt.Compute("SUM(VAT)", String.Empty).ToString();
                lblSumOrder.Text = Convert.ToInt32(dt.Compute("SUM(SubTotal)", String.Empty)).ToString("#,##");
                lblTotal.Text = Convert.ToInt32(dt.Compute("SUM(TotalPrice)", String.Empty)).ToString("#,##");
                lkbBuy.Visible = true;
                // Load       
                rptOrder.DataSource = dt;
                rptOrder.DataBind();
            }
        }
        catch(Exception ex){}
    }
    private void LoadRelateProduct(Int32 ID)
    {
        try
        {
            DataTable dt = new DataTable();
            DAProduct oData = new DAProduct();

            // get data
            
                // Load product relate
                DataTable dtDetail = new DataTable();
                dtDetail.Load(oData.USP_Product_Client_GetRelatebyID(ID));

                rptRelateProduct.DataSource = dtDetail;
                rptRelateProduct.DataBind();
            

        }
        catch
        {
        }
    }

    protected void rptOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "RemoveCart")
        {
            try
            {
                Label lblID = new Label();
                lblID = (Label)e.Item.FindControl("lblID");
                int iID = int.Parse(lblID.Text);

                mOrder.USP_OrderDetailTemp_Delete(iID);
            }
            catch { return; };

            Response.Redirect("/gio-hang/index.html");
        }
    }

    protected void rptRelateProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {      
        if (e.CommandName == "AddCart")
        {
            try
            {
                Label lblID = new Label();
                lblID = (Label)e.Item.FindControl("lblID");
                int iProductID = int.Parse(lblID.Text);

                mOrder.USP_OrderDetailTemp_Insert(Session["WOrderID"].ToString(), iProductID, 1);
            }
            catch { return; };

            Response.Redirect("/gio-hang/index.html");
        }
    }

    protected void lkbBuy_Click(object sender, EventArgs e)
    {
        Response.Redirect("/check-out/index.html");
    }
}