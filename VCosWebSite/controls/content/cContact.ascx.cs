﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common;
using System.Web.Configuration;
using System.Data;
using System.Net.Mail;

public partial class controls_content_cContact : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadContactUs();
        }
    }

    private void LoadContactUs()
    {
        try
        {
            DataTable dt = new DataTable();
            DAArticle oData = new DAArticle();
            dt.Load(oData.USP_Article_Client_GetContactUs());
            if (dt.Rows.Count > 0)
                divContactUs.InnerHtml = dt.Rows[0]["Content"].ToString();
        }
        catch
        {
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        txtFullName.Value = txtFullName.Value.Trim();
        txtTitle.Value = txtTitle.Value.Trim();
        txtPhone.Value = txtPhone.Value.Trim();
        txtEmail.Value = txtEmail.Value.Trim();
        txtContent.Value = txtContent.Value.Trim();

        lblMessege.Text = "";

        if (txtFullName.Value == "" || txtFullName.Value.Length < 4)
        {
            lblMessege.Text = string.Format(Message.Show("WARNING"), "Họ tên không được trống và phải lớn hơn 3 ký tự!"); 
            txtFullName.Focus();
            return;
        }
        if (txtEmail.Value == "" || !Utilities.isEmail(txtEmail.Value))
        {
            lblMessege.Text = string.Format(Message.Show("WARNING"), "Địa chỉ Email không hợp lệ!");
            txtEmail.Focus();
            return;
        }
        if (txtTitle.Value == "")
        {
            lblMessege.Text = string.Format(Message.Show("WARNING"), "Tiêu đề không được trống!");
            txtTitle.Focus();
            return;
        }

        
        if (txtContent.Value == "")
        {
            lblMessege.Text = string.Format(Message.Show("WARNING"), "Nội dung không được trống!");
            txtContent.Focus();
            return;
        }

        string sFromEmail = WebConfigurationManager.AppSettings["FromMail"];
        string sPassEmail = WebConfigurationManager.AppSettings["FromPass"];
        string sInCommingEmail = WebConfigurationManager.AppSettings["Incomming"];
        string sToEmail = WebConfigurationManager.AppSettings["ToEmail"];

        string content = "<h4><b>Thông tin liên hệ</b></h4> <br />";
        content += "<b>Họ tên: </b>" + txtFullName.Value + "<br />";
        content += "<b>Email: </b>" + txtEmail.Value + "<br />";
        content += "<b>Điện thoại: </b>" + txtPhone.Value + "<br />";
        content += "<b>Chủ đề: </b>" + txtTitle.Value + "<br />";
        content += "<b>Nội dung: </b>" + txtContent.Value + "<br />";

        Utils.SendMail(sFromEmail, sPassEmail, sInCommingEmail, sToEmail,"", txtTitle.Value, content);
       
        txtFullName.Value = String.Empty;
        txtTitle.Value = String.Empty;
        txtContent.Value = String.Empty;
        txtEmail.Value = String.Empty;
        txtPhone.Value = String.Empty;
        lblMessege.Text = string.Format(Message.Show("ANYSUCC"), "Cảm ơn bạn đã liên hệ! Chúng tôi sẽ trả lời bạn trong thời gian sớm nhất.");
        
        
    }
    
}