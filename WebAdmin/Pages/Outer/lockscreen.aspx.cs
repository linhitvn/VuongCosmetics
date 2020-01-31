using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Outer_lockscreen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        userName.InnerText = MySession.UserName;
        MySession.ClockScren = "True";
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        String sPassEnscrypted = MD5Encrypt.EncryptDataMD5(Password.Value, "CMSVTS");
        if (sPassEnscrypted == MySession.PassWord)
        {
            MySession.ClockScren = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "VoteJsFunc", "window.parent.$('#div_iframe').remove();", true);
        }
    }
}