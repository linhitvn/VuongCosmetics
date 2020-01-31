using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;

public partial class Controls_Menu_cLeftMenu : System.Web.UI.UserControl
{
    DAWebFuncGroup mData = new DAWebFuncGroup();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        // Check permission
        if (Session["UPermission"] == null || Session["UPermission"].ToString() == "") //Chưa login
            Response.Redirect(WebConfigurationManager.AppSettings["WebHome"] + "admin/");

        if (!Page.IsPostBack)
        {
            LoadMenuParant();
        }

        //fUsername.InnerHtml = "Xin chào: " + Permission.GetValueSysConfig("FullName").ToString();
    }

    private void LoadMenuParant()
    {
        String role = MyConfig.GetValueByKey("Role");
        dt = mData.USP_WebFuncGroup_GetRolebyGroupID(Convert.ToInt32(role)).Tables[0];

        DataView mnuParent = new DataView(dt);
        mnuParent.RowFilter = "ParentID is NULL";

        rptParent.DataSource = mnuParent;
        rptParent.DataBind();
    }

    protected void rptParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hdnParentID = e.Item.FindControl("hdnParentID") as HiddenField;
        Repeater rp1 = (Repeater)e.Item.FindControl("rptChild");
        //ds2.SelectParameters["ParentID"].DefaultValue = hdnParentID.Value.ToString();
        DataView mnuChild = new DataView(dt);
        mnuChild.RowFilter = "ParentID=" + hdnParentID.Value;

        rp1.DataSource = mnuChild;
        rp1.DataBind();

    }
    protected string GetActiveClass(string funcID)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["module"]) && Request.QueryString["module"].Length > 2
            && !string.IsNullOrEmpty(funcID) && funcID.Length > 2 && Request.QueryString["module"].Substring(0, 2) == funcID.Substring(0, 2))
            return "active";

        return "";
    }
}