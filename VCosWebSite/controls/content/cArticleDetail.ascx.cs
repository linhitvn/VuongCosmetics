    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NDL.Framework.Common;
using System.Web.UI.HtmlControls;

public partial class controls_content_cArticleDetail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string iAD;
        iAD = (Request.QueryString["AID"] == null ? "" : Request.QueryString["AID"]);
        
        if (!Page.IsPostBack)
        {
            if (Utilities.IsNumeric(iAD))
            {
                LoadDataDetail(Convert.ToInt32(iAD));
            }
            else
            {
                Response.Redirect("~/index.html");
            }
            LoadHotArticle();
        }
    }

    // Hiển thị chi tiết
    private void LoadDataDetail(Int32 AID)
    {
        try
        {
            DataTable mTable = new DataTable();
            DAArticle oData = new DAArticle();

            mTable.Load(oData.USP_Article_Client_GetDetail(AID));

            String sDes, sKey;

            if (mTable.Rows.Count > 0)
            {
                lblTitle.Text = mTable.Rows[0]["Title"].ToString();
                lblOperator.Text = mTable.Rows[0]["Operator"].ToString();
                lblDate.Text = Convert.ToDateTime(mTable.Rows[0]["PublishDate"]).ToString("MMMM dd, yyyy");
                lblView.Text = mTable.Rows[0]["ViewNumber"].ToString();

                lblContent.Text = mTable.Rows[0]["Content"].ToString();

                sDes = mTable.Rows[0]["MetaDescription"].ToString();
                sKey = mTable.Rows[0]["MetaKeywords"].ToString();

                // Add Tieu de
                Page.Header.Title = mTable.Rows[0]["MetaTitle"].ToString(); 

                // Create two instances of an HtmlMeta control.
                HtmlMeta hm1 = new HtmlMeta();
                HtmlMeta hm2 = new HtmlMeta();

                // Define an HTML <meta> element - description - that is useful for search engines.
                hm1.Name = "description";
                hm1.Content = sDes;

                // Define an HTML <meta> element - keywords - that is useful for search engines.
                hm2.Name = "keywords";
                hm2.Content = sKey; // clsCommon.ConvertToUnSign(sDes);

                // Get a reference to the page header element.
                HtmlHead head = (HtmlHead)Page.Header;

                head.Controls.Add(hm1);
                head.Controls.Add(hm2);


                // Load tin khác

                mTable.Rows.RemoveAt(0);

                //if (dr.HasRows)
                //    dvOther.Visible = true;
                //else
                //    dvOther.Visible = false;

                rptOther.DataSource = mTable;
                rptOther.DataBind();

            }
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

            //if (mTable.Rows.Count > 0)
            //{
            //    imgLink.ImageUrl = mTable.Rows[0]["ImgLink"].ToString();
            //    imgLink.AlternateText = mTable.Rows[0]["Title"].ToString();
            //    lblTitle.Text = mTable.Rows[0]["Title"].ToString();
            //    lblDescription.Text = mTable.Rows[0]["Description"].ToString();

            //    mTable.Rows.RemoveAt(0);
            //}

            // Load tin khác           
            rptHotNews.DataSource = mTable;
            rptHotNews.DataBind();
        }
        catch
        {
        }
    }
}