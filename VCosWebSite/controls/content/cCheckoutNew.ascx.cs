using NDL.Framework.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_content_cCheckoutNew : System.Web.UI.UserControl
{
    DAOrderDetailTemp mOrder = new DAOrderDetailTemp();
    DAProvince mData = new DAProvince();
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {            
            LoadProvice();
            LoadProduct();
        }
        if(Session["OrderBuyID"] != null)
        {
            int iOrderBuyID = Int32.Parse(Session["OrderBuyID"].ToString());
            if (iOrderBuyID > 0)
                lblMessege.Text = "Chúc mừng bạn đã đặt hàng thành công!";
            else
                lblMessege.Text = "Có lỗi xảy ra trong quá trình đặt hàng. Bạn vui lòng qua lại sau.";

            Session["OrderBuyID"] = null;
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
                lblTax.Text = dt.Compute("SUM(VAT)", string.Empty).ToString();
                //lblSumOrder.Text = dt.Compute("SUM(Price)", string.Empty).ToString();
                //lblTotal.Text = dt.Compute("SUM(TotalPrice)", string.Empty).ToString();

                lblSumOrder.Text = Convert.ToInt32(dt.Compute("SUM(SubTotal)", String.Empty)).ToString("#,##");
                lblTotal.Text = Convert.ToInt32(dt.Compute("SUM(TotalPrice)", String.Empty)).ToString("#,##");
                
                btnBuy.Visible = true;
                // Load       
                rptOrder.DataSource = dt;
                rptOrder.DataBind();
            }
        }
        catch
        {
        }
    }
    private void LoadProvice()
    {
        try
        {
            string CityId = WebConfigurationManager.AppSettings["CityID"];
            DataTable dt = new DataTable();
            dt.Load(mData.USP_Province_Client_GetAll());
            if(dt.Rows.Count>0)
            {
                ddlCity.DataSource = dt;
                ddlCity.DataBind();

                ddlCity.SelectedValue = CityId;
                LoadDistrict(Convert.ToInt32(CityId));
            }
            
        }
        catch
        {
        }
    }
    private void LoadDistrict(int cityID)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Load(mData.USP_District_Client_GetByCity(cityID));
            if (dt.Rows.Count > 0)
            {
                ddlDistrict.DataSource = dt;
                ddlDistrict.DataBind();
            }

        }
        catch
        {
        }
    }
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        txtFirstName.Value = txtFirstName.Value.Trim();
        txtLastName.Value = txtLastName.Value.Trim();
        txtAddress.Value = txtAddress.Value.Trim();
        txtEmail.Value = txtEmail.Value.Trim();
        txtTel.Value = txtTel.Value.Trim();

        lblMessege.Text = "";

        if (txtFirstName.Value == "")
        {
            lblMessege.Text = "Bạn chưa nhập Tên!";
            txtFirstName.Focus();
            return;
        }
        if (txtLastName.Value == "")
        {
            lblMessege.Text = "Bạn chưa nhập Họ!";
            txtLastName.Focus();
            return;
        }

        if (txtAddress.Value == "" || txtAddress.Value.Length < 6)
        {
            lblMessege.Text = "Địa chỉ nhận hàng không hợp lệ!";
            txtAddress.Focus();
            return;
        }

        if (txtEmail.Value == "" || !Utilities.isEmail(txtEmail.Value))
        {
            lblMessege.Text = "Địa chỉ Email không hợp lệ!";
            txtEmail.Focus();
            return;
        }
        if (txtTel.Value == "")
        {
            lblMessege.Text = "Số điện thoại không được trống!";
            txtTel.Focus();
            return;
        }

        int iResult;
        iResult = mOrder.USP_Orders_Client_Insert(Session["WOrderID"].ToString(), txtLastName.Value + " " + txtFirstName.Value, txtAddress.Value, txtTel.Value, txtEmail.Value,Convert.ToInt32(rblPayment.SelectedValue), Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlDistrict.SelectedValue));
        Session["OrderBuyID"] = iResult;

        Response.Redirect("/check-out/index.html");
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDistrict(Convert.ToInt32(ddlCity.SelectedValue));
    }
}