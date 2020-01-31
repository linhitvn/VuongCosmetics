using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;

public partial class Controls_Header_cHeader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        LoadFeedBack();
        cUserAccount.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["ControlPath"] + "Header/cUserAccount.ascx"));
    }

    private void LoadFeedBack()
    {


        DAFeedBack daFeedBack = new DAFeedBack();
        DataTable  dataTable = new DataTable();
        dataTable.Load(daFeedBack.USP_FeedBack_GetAll_NotRead());
        rptFeedBack.DataSource = dataTable;
        rptFeedBack.DataBind();

        int Count = dataTable.Rows.Count;

        if (Count > 0)
        {
            fFeedBackNumber.InnerText = Count.ToString();
        }
        daFeedBack.CloseAll();
    }
}