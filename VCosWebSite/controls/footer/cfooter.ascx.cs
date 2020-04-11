using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class controls_footer_cfooter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadFooter();
        }
    }

    private void LoadFooter()
    {
        try
        {
            DataTable dt = new DataTable();
            DAArticle oData = new DAArticle();
            dt.Load(oData.USP_Article_Client_GetFooter());
            if(dt.Rows.Count>0)
                divFooter.InnerHtml = dt.Rows[0]["Content"].ToString();
        }
        catch
        {
        }
    }

}