using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_content_cSalesPolicy : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadSalesPolicy();
        }
    }
    private void LoadSalesPolicy()
    {
        try
        {
            DataTable dt = new DataTable();
            DAArticle oData = new DAArticle();
            dt.Load(oData.USP_Article_Client_GetSalesPolicy());
            if (dt.Rows.Count > 0)
                divPolicy.InnerHtml = dt.Rows[0]["Content"].ToString();
        }
        catch
        {
        }
    }
}