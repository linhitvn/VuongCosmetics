using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class controls_content_cAbout : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadAbout();
        }
    }

    private void LoadAbout()
    {
        try
        {
            DataTable dt = new DataTable();
            DAArticle oData = new DAArticle();
            dt.Load(oData.USP_Article_Client_GetAbout());

            rptAbout.DataSource = dt;
            rptAbout.DataBind();
        }
        catch
        {
        }
    }
}