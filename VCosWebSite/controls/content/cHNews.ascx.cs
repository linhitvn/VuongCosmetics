using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;

public partial class controls_content_cHNews : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadArticle();
        }
    }

    // Hiển thị chi tiết
    private void LoadArticle()
    {
        try
        {
            DataTable mTable = new DataTable();
            DAArticle oData = new DAArticle();

            mTable.Load(oData.USP_Article_Client_GetTop());

            if (mTable.Rows.Count > 0)
            {
                imgLink.ImageUrl = mTable.Rows[0]["ImgLink"].ToString();
                imgLink.AlternateText = mTable.Rows[0]["Title"].ToString();
                //lblTitle.Text = mTable.Rows[0]["Title"].ToString();
                lblDate.Text = Convert.ToDateTime(mTable.Rows[0]["PublishDate"]).ToString("dd");
                lblMonth.Text =Convert.ToDateTime(mTable.Rows[0]["PublishDate"]).ToString("MM");
                lblDescription.Text = mTable.Rows[0]["Description"].ToString();
                hplTitle.Text = mTable.Rows[0]["Title"].ToString();
                hplTitle.NavigateUrl =  mTable.Rows[0]["UrlRewrite"].ToString();
                hplLink.NavigateUrl =  mTable.Rows[0]["UrlRewrite"].ToString();
                hplDetail.NavigateUrl =  mTable.Rows[0]["UrlRewrite"].ToString();

                mTable.Rows.RemoveAt(0);
            }

            // Load tin khác           
            rptArticle.DataSource = mTable;
            rptArticle.DataBind();
        }
        catch
        {
        }
    }
}