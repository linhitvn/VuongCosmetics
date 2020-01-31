using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class controls_content_cBestseller : System.Web.UI.UserControl
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadHotProducts();
        }
    }


    protected void rptHotProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
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

    private void LoadHotProducts()
    {
        try
        {
            DataTable dt = new DataTable();
            DAProduct oData = new DAProduct();

            dt.Load(oData.USP_Product_Client_GetHot());

            rptHotProduct.DataSource = dt;
            rptHotProduct.DataBind();
        }
        catch
        {
        }
    }

    #region "Old"

    private void LoadProduct()
    {
        try
        {           
            DataTable dtBest = new DataTable();            
            DAProduct oData = new DAProduct();

            // Load hinh
            DataTable dtImg = new DataTable();
            dtImg.Columns.Add("id", typeof(int));
            dtImg.Columns.Add("Img", typeof(string));

            dtBest.Load(oData.USP_Product_Client_GetBestSeller());

            if (dtBest.Rows.Count > 0)
            {
                //lblProductName.Text = dtBest.Rows[0]["ProductName"].ToString();
                //lblBrand.Text = dtBest.Rows[0]["ProducerName"].ToString();
                //hplProductName.Text = dtBest.Rows[0]["ProductName"].ToString();
                //hplProductName.NavigateUrl = dtBest.Rows[0]["RewriteURL"].ToString();
                //lblID.Text = dtBest.Rows[0]["ID"].ToString();

                if (dtBest.Rows[0]["ImgLink1"].ToString() != "")
                    dtImg.Rows.Add(1, dtBest.Rows[0]["ImgLink1"].ToString());

                if (dtBest.Rows[0]["ImgLink2"].ToString() != "")
                    dtImg.Rows.Add(2, dtBest.Rows[0]["ImgLink2"].ToString());

                if (dtBest.Rows[0]["ImgLink3"].ToString() != "")
                    dtImg.Rows.Add(3, dtBest.Rows[0]["ImgLink3"].ToString());

                if (dtBest.Rows[0]["ImgLink4"].ToString() != "")
                    dtImg.Rows.Add(4, dtBest.Rows[0]["ImgLink4"].ToString());

                if (dtBest.Rows[0]["ImgLink5"].ToString() != "")
                    dtImg.Rows.Add(5, dtBest.Rows[0]["ImgLink5"].ToString());

                //if(dtBest.Rows[0]["Price"].ToString()=="0")
                //    lblPrice.Text = "";
                //else
                //    lblPrice.Text = dtBest.Rows[0]["Price"].ToString() + " VNĐ";      

                //rptImgShow.DataSource = dtImg;
                //rptImgShow.DataBind();
                //rptImgThumb.DataSource = dtImg;
                //rptImgThumb.DataBind();

                dtBest.Rows.RemoveAt(0);
            }
            DataView dv1 = new DataView(dtBest, "RowID<5", "RowID", DataViewRowState.CurrentRows);
            DataView dv2 = new DataView(dtBest, "RowID>4 and RowID<8", "RowID", DataViewRowState.CurrentRows);

            // Load       
            //rptRow1.DataSource = dv1;
            //rptRow1.DataBind();
            //// Load       
            //rptRow2.DataSource = dv2;
            //rptRow2.DataBind();
            
            
        }
        catch
        {
        }
    }
    protected void lkbOrder_Click(object sender, EventArgs e)
    {
        try
        {            
            //int iProductID = int.Parse(lblID.Text);
            //mOrder.USP_OrderDetailTemp_Insert(Session["WOrderID"].ToString(), iProductID,1);
        }
        catch { return; };

        Response.Redirect("~/gio-hang/index.html");
    }

    protected void rptRow1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "AddCart")
        {
            try
            {
                Label lblID = new Label();
                lblID = (Label)e.Item.FindControl("lblID");
                int iProductID = int.Parse(lblID.Text);

                //mOrder.USP_OrderDetailTemp_Insert(Session["WOrderID"].ToString(), iProductID,1);
            }
            catch { return; };

            Response.Redirect("~/gio-hang/index.html");
        }
    }

    protected void rptRow2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "AddCart")
        {
            try
            {
                Label lblID = new Label();
                lblID = (Label)e.Item.FindControl("lblID");
                int iProductID = int.Parse(lblID.Text);

                //mOrder.USP_OrderDetailTemp_Insert(Session["WOrderID"].ToString(), iProductID,1);
            }
            catch { return; };

            Response.Redirect("~/gio-hang/index.html");
        }
    }

    #endregion
}