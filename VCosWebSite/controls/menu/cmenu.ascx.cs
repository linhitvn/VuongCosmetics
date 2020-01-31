using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class controls_menu_cmenu : System.Web.UI.UserControl
{
    DataTable dt = new DataTable();
    DAOrderDetailTemp mOrder = new DAOrderDetailTemp();
    protected void Page_Load(object sender, EventArgs e)
    {
        CssActive();
        if (!Page.IsPostBack)
        {
            LoadProduct();
        }
        //LoadDropdown();
    }
    private void CssActive()
    {
        string mnuActive = Session["Dropdown"].ToString();
        switch (mnuActive)
        {
            case "":
                liHome.Attributes["class"] = "nav-item active";
                break;
            case "PRO":
            case "DPRO":
                liProduct.Attributes["class"] = "nav-item active";
                break;
            case "CONT":
                liContact.Attributes["class"] = "nav-item active";
                break;
            case "ABOUT":
                liAbout.Attributes["class"] = "nav-item active";
                break;
            default:
                liHome.Attributes["class"] = "nav-item active";
                break;
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
                lblTotal.Text = Convert.ToInt32(dt.Compute("SUM(TotalPrice)", string.Empty)).ToString("#,##");
            }
            // Load       
            rptCart.DataSource = dt;
            rptCart.DataBind();


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
           
            DAMenuItem oData = new DAMenuItem();            
            dt.Load(oData.Client_USP_MenuItem_GetByMenuID(1));

            // Lay menu cha            
            //DataTable dtParent = dt.Select("ParentID = 0").CopyToDataTable();            
            DataView dv = new DataView(dt, "ParentID = 0", "Pos", DataViewRowState.CurrentRows);
            //rptMenu.DataSource = dv;
            //rptMenu.DataBind();

        }
        catch
        {
        }
    }
        
    protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
}

