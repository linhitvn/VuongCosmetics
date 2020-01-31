using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NDL.Framework.Common;

public partial class controls_content_cProductDetail : System.Web.UI.UserControl
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
                Response.Redirect("~/index.html");
            }
            //LoadProduct();          
        }
    }

    // Hiển thị menu
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
                lblProductName.Text = dt.Rows[0]["ProductName"].ToString();
                lblBrand.Text = dt.Rows[0]["ProducerName"].ToString();
                lblSKU.Text = dt.Rows[0]["ProductCode"].ToString();
                txtProductID.Text = dt.Rows[0]["ID"].ToString();

                //if (dt.Rows[0]["Price"].ToString() == "0")
                //    lblPrice.Text = "Liên hệ";
                //else
                //    lblPrice.Text = dt.Rows[0]["Price"].ToString() + " VNĐ";
                // Load hinh
                DataTable dtImg = new DataTable();
                dtImg.Columns.Add("id", typeof(int));
                dtImg.Columns.Add("Img", typeof(string));
               
                if (dt.Rows[0]["ImgLink1"].ToString() != "")
                    dtImg.Rows.Add(1, dt.Rows[0]["ImgLink1"].ToString());

                if (dt.Rows[0]["ImgLink2"].ToString() != "")
                    dtImg.Rows.Add(2, dt.Rows[0]["ImgLink2"].ToString());
                    
                if (dt.Rows[0]["ImgLink3"].ToString() != "")
                    dtImg.Rows.Add(3, dt.Rows[0]["ImgLink3"].ToString());
                   
                if (dt.Rows[0]["ImgLink4"].ToString() != "")
                    dtImg.Rows.Add(4, dt.Rows[0]["ImgLink4"].ToString());
                   
                if (dt.Rows[0]["ImgLink5"].ToString() != "")
                    dtImg.Rows.Add(5, dt.Rows[0]["ImgLink5"].ToString());
                   
                lblDescription.Text = dt.Rows[0]["Description"].ToString();
                //sImgSlider = sSlider;
                //sImgThumb = sThumb;
                rptImgShow.DataSource = dtImg;
                rptImgShow.DataBind();
                rptImgThumb.DataSource = dtImg;
                rptImgThumb.DataBind();
                
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

    protected void lkbOrder_Click(object sender, EventArgs e)
    {
        try
        {
            DAOrderDetailTemp mOrder = new DAOrderDetailTemp();
            int iProductID = int.Parse(txtProductID.Text);
            int iQuantity =1;
            if(Utilities.IsNumeric(txtQuantity.Text))
                iQuantity = int.Parse(txtQuantity.Text);

            mOrder.USP_OrderDetailTemp_Insert(Session["WOrderID"].ToString(), iProductID, iQuantity);
        }
        catch { return; };
        Response.Redirect("~/gio-hang/index.html");
    }
}