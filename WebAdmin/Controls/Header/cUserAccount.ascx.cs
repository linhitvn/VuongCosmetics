using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class Controls_Header_cUserAccount : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fUsername.InnerHtml = MyConfig.GetValueByKey("FullName").ToString();
        fUserInfo.InnerHtml = "Xin chào: " + MyConfig.GetValueByKey("FullName").ToString() + "<small>Member since Nov. 2012</small>";
    }

    protected void btLogout_Click(object sender, EventArgs e){
        Session.Abandon();
        Response.Redirect(WebConfigurationManager.AppSettings["WebHome"]);
    }
}