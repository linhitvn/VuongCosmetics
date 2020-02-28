using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using NDL.Framework.Common.Encryption;
using NDL.Framework.Common;
using ServiceReference1;

public partial class Pages_Outer_Login : System.Web.UI.Page
{
    //int MaxLogin = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Reset Click Screen !
        MySession.ClockScren = null;

        if (MyConfig.DevMode)
        {
            //if (txtWebsite.Value == "")
            //    txtWebsite.Value = "Dev";
            //GetConnection();
            if (txtUserName.Value == "")
            {
                txtUserName.Value = "sa";
                txtPassword.Value = "123";
            }

            ProcessLogin();
        }
    }

    private void GetConnection()
    {
        //lblError.InnerText = "";
        //string website = txtWebsite.Value;

        //ServiceSoapClient a = new ServiceSoapClient();
        //string Con = a.GetConnectionStringByDomain(website);
        //if (Con == "" || Con == null)
        //{
        //    lblError.InnerText = "WebSite không tồn tại, vui lòng gọi cho chúng tôi để hỗ trợ !";
        //    return;
        //}

        //Session["ConnectionString"] = Con;
    }

    protected void cAccept_Click(object sender, EventArgs e)
    {
        //GetConnection();

        ProcessLogin();
    }

    private void ProcessLogin()
    {
        string website = txtWebsite.Value;


        DAWebUser mData = new DAWebUser();
        DAWebFuncGroup mPermission = new DAWebFuncGroup();

        txtUserName.Value = txtUserName.Value.Trim();
        txtPassword.Value = txtPassword.Value.Trim();
        lblError.InnerText = "";

        if (txtUserName.Value == "")
        {
            lblError.InnerText = "Bạn chưa nhập tên đăng nhập!";
            return;
        }
        //if (!Utilities.isEmail(txtUserName.Text))
        //{
        //    lblError.InnerText = string.Format(Message.Show("WARNING"), "Địa chỉ email không hợp lệ!");
        //    return;
        //}
        if (txtPassword.Value == "")
        {
            lblError.InnerText = "Bạn chưa nhập mật khẩu!";
            return;
        }
        //Login sai quá số lần cho phép ==> bật hộp thoại yêu cầu nhập mã kiểm tra.
        //if ((pnlRandom.Visible == true) && (!CaptchaGenerator.IsValidText(txtRandom.Text)))
        //{
        //    lblError.InnerText = "Chuỗi kiểm tra không đúng!";
        //    txtRandom.Text = "";
        //    SetCaptcha();
        //    return;
        //}

        String sPass = MD5Encrypt.EncryptDataMD5(txtPassword.Value, "CMSVTS");
        DataTable dt = new DataTable();
        Dictionary<string, string> config = new Dictionary<string, string>();
        Dictionary<Int32, Boolean> permission = new Dictionary<Int32, Boolean>();
        Dictionary<Int32, String> navigation = new Dictionary<Int32, String>();
        try
        {
            dt.Load(mData.USP_WebUser_Login(txtUserName.Value, sPass));
            if (dt.Rows.Count > 0)
            {
                String RoleID = dt.Rows[0]["Role"].ToString();
                if (Utilities.IsNullOrEmpty(RoleID) || RoleID == "0")
                {
                    lblError.InnerText = string.Format(Message.Show(MessageText.WARNING), "Bạn chưa được cấp quyền truy cập hệ thống!");
                    return;
                }
                else
                {
                    config.Add("WebSite", website);
                    config.Add("UserID", dt.Rows[0]["UserID"].ToString());
                    config.Add("UserName", dt.Rows[0]["UserName"].ToString());
                    config.Add("FullName", dt.Rows[0]["FullName"].ToString());
                    config.Add("PassWord", dt.Rows[0]["PassWord"].ToString());
                    config.Add("Email", dt.Rows[0]["Email"].ToString());
                    config.Add("Role", dt.Rows[0]["Role"].ToString());

                    // load Config
                    DataTable dtconfig = new DataTable();
                    dtconfig = mPermission.USP_webConfig_GetAll(0,0).Tables[0];
                    if (dtconfig.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtconfig.Rows.Count; j++)
                        {
                            config.Add(dtconfig.Rows[j]["ConfigKey"].ToString(), dtconfig.Rows[j]["ConfigValue"].ToString());
                        }
                    }

                    Session["USysConfig"] = config;

                    // Load permission menu
                    DataTable dtmenu = new DataTable();
                    dtmenu = mPermission.USP_WebFuncGroup_GetFuncbyGroupID(Convert.ToInt32(RoleID)).Tables[0];
                    for (int j = 0; j < dtmenu.Rows.Count; j++)
                    {
                        permission.Add(Convert.ToInt32(dtmenu.Rows[j]["FuncID"]), Convert.ToBoolean(dtmenu.Rows[j]["pView"]));
                        navigation.Add(Convert.ToInt32(dtmenu.Rows[j]["FuncID"]), dtmenu.Rows[j]["UControl"].ToString());
                    }
                    Session["UPermission"] = permission;
                    Session["UCNavigation"] = navigation;

                    // + Utils.FuncParam()

                    Response.Redirect(WebConfigurationManager.AppSettings["WebHome"] + "/?module=100");
                }
            }
            else
            {
                //if (Session["LoginFail"] != null)
                //    Session["LoginFail"] = (int)Session["LoginFail"] + 1;
                //else
                //    Session["LoginFail"] = 0;
                //if ((int)Session["LoginFail"] > MaxLogin)
                //{
                //    if (!pnlRandom.Visible)
                //        pnlRandom.Visible = true;
                //    else
                //    {
                //        txtRandom.Text = "";
                //        SetCaptcha();
                //    }
                //}
                lblError.InnerText = "Tài khoản hoặc Mật khẩu không đúng!";
                return;
            }

        }
        catch (Exception ex)
        {
            lblError.InnerText = ex.Message;
            return;
        };
    }
}