using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class controls_content_cSlider : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadSlider();
        }
    }

    
    private void LoadSlider()
    {
        try
        {
            DataTable mTable = new DataTable();
            DAShortCut oData = new DAShortCut();

            mTable.Load(oData.Client_USP_ShortCut_GetByTypeID(1));

            rptSlider.DataSource = mTable;
            rptSlider.DataBind();

        }
        catch
        {
        }
    }
}