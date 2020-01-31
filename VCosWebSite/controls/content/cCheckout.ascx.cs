using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NDL.Framework.Common;

public partial class controls_content_cCheckout : System.Web.UI.UserControl
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
                lblQuantity.Text = dt.Compute("SUM(Quantity)", string.Empty).ToString();
            
            // Load       
            rptOrder.DataSource = dt;
            rptOrder.DataBind();


        }
        catch
        {
        }
    }

    protected void btnBuy_Click(object sender, EventArgs e)
    {
        txtFullName.Text = txtFullName.Text.Trim();
        txtAddress.Text = txtAddress.Text.Trim();
        txtEmail.Text = txtEmail.Text.Trim();
        txtTel.Text = txtTel.Text.Trim();
       
        lblMessege.Text = "";

        if (txtFullName.Text == "" || txtFullName.Text.Length < 4)
        {
            lblMessege.Text = "Họ tên không được trống và phải lớn hơn 3 ký tự!";
            txtFullName.Focus();
            return;
        }

        if (txtAddress.Text == "" || txtAddress.Text.Length < 6)
        {
            lblMessege.Text = "Địa chỉ không hợp lệ!";
            txtAddress.Focus();
            return;
        }
                
        if (txtEmail.Text == "" || !Utilities.isEmail(txtEmail.Text))
        {
            lblMessege.Text = "Địa chỉ Email không hợp lệ!";
            txtEmail.Focus();
            return;
        }
        if (txtTel.Text == "")
        {
            lblMessege.Text = "Số điện thoại không được trống!";
            txtTel.Focus();
            return;
        }
               
        int iResult;
        //iResult = mOrder.USP_Orders_Client_Insert(Session["WOrderID"].ToString(), txtFullName.Text, txtAddress.Text, txtTel.Text, txtEmail.Text);

        Response.Redirect("/index.html");
    }
}