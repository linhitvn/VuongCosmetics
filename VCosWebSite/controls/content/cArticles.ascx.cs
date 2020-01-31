using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class controls_content_cArticles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //LoadArticles();
        }
    }

    protected void lvData_PreRender(object sender, EventArgs e)
    {
        LoadListViewData();
    }

    //Load dữ liệu vào ListView
    private void LoadListViewData()
    {
        DAArticle da = new DAArticle();
        DataTable dt = new DataTable();
        try
        {
            dt.Load(da.USP_Article_Client_GetPageArticle(23,0));
            if (dt.Rows.Count > 0)
            {
                lvData.DataSource = dt;
                lvData.DataBind();
                //Reset lai pager
                //dpData.SetPageProperties(0, dpData.PageSize, true);
                //lblPage.Text = "Trong tổng cộng " + ((dpData.TotalRowCount / dpData.PageSize) + 1).ToString() + " trang";

                if (dt.Rows.Count <= 5)
                    dvPaging.Visible = false;
                else
                    dvPaging.Visible = true;
            }
        }
        catch { }
        finally
        {
            da.Close();
        }
    }
}