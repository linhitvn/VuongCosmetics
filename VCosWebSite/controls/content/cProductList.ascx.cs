using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_content_cProductList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadProductCategory();
            LoadProducts(0);
        }

    }

    private void LoadProductCategory()
    {
        try
        {
            DataTable dt = new DataTable();
            DAProduct oData = new DAProduct();

            dt.Load(oData.USP_ProductCat_Client_GetAll());

            rptProductCate.DataSource = dt;
            rptProductCate.DataBind();
        }
        catch
        {
        }
    }
    //Load dữ liệu 
    private void LoadProducts(Int32 iProCate)
    {
        try
        {
            DataTable dt = new DataTable();
            DAProduct oData = new DAProduct();

            dt.Load(oData.USP_Product_Client_GetAllList(iProCate));

            rptProList.DataSource = dt;
            rptProList.DataBind();
        }
        catch
        {
        }
    }

    protected void rptProList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DAOrderDetailTemp mOrder = new DAOrderDetailTemp();
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
}