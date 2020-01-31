using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class controls_content_cHProducts : System.Web.UI.UserControl
{
    DAOrderDetailTemp mOrder = new DAOrderDetailTemp();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadProduct();
        }
    }

    // Hiển thị
    private void LoadProduct()
    {
        try
        {
            DataTable dtHot = new DataTable();
            //DataTable dtNew = new DataTable();
            DAProduct oData = new DAProduct();

            dtHot.Load(oData.USP_Product_Client_GetHot());
            //dtNew.Load(oData.USP_Product_Client_GetNew());

            // Load       
            rptHot.DataSource = dtHot;
            rptHot.DataBind();

            //rptNew.DataSource = dtNew;
            //rptNew.DataBind();
        }
        catch
        {
        }
    }
    protected void rptHot_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "AddCart")
        {           
            try
            {              
                Label lblID = new Label();
                lblID = (Label)e.Item.FindControl("lblID"); 
                int iProductID = int.Parse(lblID.Text);

                mOrder.USP_OrderDetailTemp_Insert(Session["WOrderID"].ToString(), iProductID,1);
            }
            catch { return; };

            Response.Redirect("/gio-hang/index.html");
        }
    }

    protected void rptNew_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "AddCart")
        {
            try
            {
                Label lblID = new Label();
                lblID = (Label)e.Item.FindControl("lblID");
                int iProductID = int.Parse(lblID.Text);

                mOrder.USP_OrderDetailTemp_Insert(Session["WOrderID"].ToString(), iProductID,1);
            }
            catch { return; };

            Response.Redirect("~/gio-hang/index.html");
        }
    }
}