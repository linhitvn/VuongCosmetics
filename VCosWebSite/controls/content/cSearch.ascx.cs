using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NDL.Framework.Common;

public partial class controls_content_cSearch : System.Web.UI.UserControl
{
    DataTable dt = new DataTable();    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadHotArticle();
            LoadMenu();
        }
        lblSearch.Text = Session["SearchKey"].ToString();
    }
    // Hiển thị
    protected void lvData_PreRender(object sender, EventArgs e)
    {
        LoadProducts();
    }

    //Load dữ liệu vào ListView   
    private void LoadProducts()
    {
        try
        {
            DataTable dt = new DataTable();
            DAProduct oData = new DAProduct();

            dt.Load(oData.USP_Product_Client_Search(Session["SearchKey"].ToString()));

            lvData.DataSource = dt;
            lvData.DataBind();

            if (dt.Rows.Count < 10)
                dvPaging.Visible = false;
        }
        catch
        {
        }
    }

    private void LoadHotArticle()
    {
        try
        {
            DataTable mTable = new DataTable();
            DAArticle oData = new DAArticle();

            mTable.Load(oData.USP_Article_Client_GetHot());
            // Load tin khác           
            rptHotNews.DataSource = mTable;
            rptHotNews.DataBind();
        }
        catch
        {
        }
    }

    // Hiển thị menu
    private void LoadMenu()
    {
        try
        {

            DAProduct oData = new DAProduct();
            dt.Load(oData.USP_ProductCat_Client_GetAll());

            // Lay menu cha            
            //DataTable dtParent = dt.Select("ParentID = 0").CopyToDataTable();            
            DataView dv = new DataView(dt, "ParentID = 0", "Pos", DataViewRowState.CurrentRows);
            rptProCat.DataSource = dv;
            rptProCat.DataBind();

        }
        catch
        {
        }
    }

    protected void rptProCat_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater subRepeter = (Repeater)e.Item.FindControl("rptChild");
            int ID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID"));

            //DataTable dtChild = dt.Select("ParentID = " + ID.ToString()).CopyToDataTable();       
            DataView dvChild = new DataView(dt, "ParentID = " + ID.ToString(), "Pos", DataViewRowState.CurrentRows);
            if (dvChild.Count > 0)
            {
                subRepeter.DataSource = dvChild;
                subRepeter.DataBind();
            }
        }
    }

    protected void lvData_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "AddCart")
        {
            try
            {
                DAOrderDetailTemp mOrder = new DAOrderDetailTemp();
                Label lblID = new Label();
                lblID = (Label)e.Item.FindControl("lblID");
                int iProductID = int.Parse(lblID.Text);

                mOrder.USP_OrderDetailTemp_Insert(Session["WOrderID"].ToString(), iProductID, 1);
            }
            catch { return; };

            Response.Redirect("~/gio-hang/index.html");
        }
    }
}