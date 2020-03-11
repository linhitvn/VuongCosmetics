using NDL.Framework.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_content_cProductDetailNew : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string iPRO;
        iPRO = (Request.QueryString["PID"] == null ? "" : Request.QueryString["PID"]);

        if (!Page.IsPostBack)
        {
            if (Utilities.IsNumeric(iPRO))
            {
                LoadProductDetail(Convert.ToInt32(iPRO));
            }
            else
            {
                Response.Redirect("/index.html");
            }
           
        }
    }
    private void LoadProductDetail(Int32 ID)
    {
        try
        {
            DataTable dt = new DataTable();
            DAProduct oData = new DAProduct();

            // get data
            dt.Load(oData.USP_Product_Client_GetByID(ID));

            // Lay 
            if (dt.Rows.Count > 0)
            {
               imgLink.ImageUrl = "/assets/images/products/pro_M_001.png";
               lblProductName.Text = dt.Rows[0]["ProductName"].ToString();
                if (dt.Rows[0]["ImgLink1"].ToString() != "")
                    imgLink.ImageUrl = dt.Rows[0]["ImgLink1"].ToString();


                lblPrice.Text = Convert.ToInt32(dt.Rows[0]["Price"]).ToString("#,##");

                //if(dt.Rows[0]["SalePrice"].ToString() != "0")
                //{
                //    lblSalePrice.Text = Convert.ToInt32(dt.Rows[0]["SalePrice"]).ToString("#,##") + " VNĐ";
                //}
                if (Convert.ToBoolean(dt.Rows[0]["IsHiddenWhenOutoff"]))
                {
                    lblOutofStock.Text = "Hết hàng";
                    pnlOutofStock.Visible = false;
                }
                else
                {
                    lblOutofStock.Text = "Còn hàng";
                }
                    
                lblDescription.Text = dt.Rows[0]["Description"].ToString();

                lblPID.Text = ID.ToString();

                // Load product relate
                DataTable dtDetail = new DataTable();
                dtDetail.Load(oData.USP_Product_Client_GetRelatebyID(ID));

                rptRelateProduct.DataSource = dtDetail;
                rptRelateProduct.DataBind();
            }

        }
        catch
        {
        }
    }

    protected void rptRelateProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
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

    protected void lkbAddCart_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
                return;

            DAOrderDetailTemp mOrder = new DAOrderDetailTemp();
            int iProductID = int.Parse(lblPID.Text);
            int iQuantity = int.Parse(txtQuantity.Text);
            if (iProductID>0)
            {
                mOrder.USP_OrderDetailTemp_Insert(Session["WOrderID"].ToString(), iProductID, iQuantity);               
            }
            
        }
        catch { return; };
        Response.Redirect("/gio-hang/index.html");
    }
}