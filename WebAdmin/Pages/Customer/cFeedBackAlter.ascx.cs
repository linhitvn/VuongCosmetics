using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using System.Web.Configuration;

public partial class Pages_Customer_cFeedBackAlter : TUserControlForAlter
{
    override protected Boolean SetServerControl()
    {
        try
        {
            // Set Message Value
            this.messBox = message_box;

            // Set button Controller
            this.BtSave1 = Save;
            this.BtSaveAndCreate1 = SaveAndCreate;
        }
        catch
        {
            ShowErrorMes("Lỗi hệ thống Control !");
            return false;
        }

        return true;
    }

    override protected Boolean GetDataComboBox()
    {
        try
        {
            //DAWebGroup mWGroup = new DAWebGroup();
            //
            //ddlRGroup.DataSource = mWGroup.USP_WebGroup_GetAllByCombo();
            //ddlRGroup.DataValueField = "GroupID";
            //ddlRGroup.DataTextField = "GroupName";
            //ddlRGroup.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAFeedBack CreateObjectFromPage()
    {
        // check 
        DAFeedBack daFeedBack = new DAFeedBack();
        //
        daFeedBack.fFeedBack = fFeedBack.Value.Trim();
        daFeedBack.fContent = fContent.Value.Trim();
        daFeedBack.fName = fName.Value.Trim();
        daFeedBack.fAddress = fAddress.Value.Trim();
        daFeedBack.fEmail = fEmail.Value.Trim();
        daFeedBack.fPhone = fPhone.Value.Trim();
        daFeedBack.fisRead = true;// fisRead.Checked;

        //

        return daFeedBack;
    }

    override protected Boolean LoadData()
    {
        try
        {
            LoadFeedBackReply();

            // Load Data For Page.
            DAFeedBack daFeedBack = new DAFeedBack();
            daFeedBack.USP_FeedBack_GetFullID(this.KeyID);
            //
            fFeedBack.Value = daFeedBack.fFeedBack.ToString();
            fContent.Value = daFeedBack.fContent.ToString();
            fName.Value = daFeedBack.fName.ToString();
            fAddress.Value = daFeedBack.fAddress.ToString();
            fEmail.Value = daFeedBack.fEmail.ToString();
            fPhone.Value = daFeedBack.fPhone.ToString();
            //fisRead.Checked = daFeedBack.fisRead;
            fSysDate.InnerText += daFeedBack.fSysDate.ToString();

            if (daFeedBack.fisRead == false)
            {
                // Update FeedBack is readed !
                daFeedBack.USP_FeedBack_Update_IsRead(daFeedBack.fID);
            }
            if (this.KeyID == 0)
            {
                div_btReply.Visible = false;
                div_box_reply.Visible = false;
            }
            else
            {
                div_btReply.Visible = true;
                div_box_reply.Visible = true;
            }
        }
        catch (Exception e)
        {
            ShowErrorMes("Lỗi hệ thống: " + e.ToString());
            return false;
        }

        return true;
    }

    override protected int ExecInsert()
    {
        try
        {
            DAFeedBack DAFeedBack = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAFeedBack.fID = DAFeedBack.USP_GetKey();
                this.KeyID = DAFeedBack.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAFeedBack.fID = 0; }

            DAFeedBack.USP_FeedBack_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAFeedBack DAFeedBack = CreateObjectFromPage();
            DAFeedBack.fID = this.KeyID;

            DAFeedBack.USP_FeedBack_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAFeedBack DAFeedBack = new DAFeedBack();
            DAFeedBack.USP_FeedBack_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        if (fFeedBack.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập tài khoản!");
            fFeedBack.Focus();
            return false;
        }
        if (fContent.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập nội dung phản hồi!");
            fContent.Focus();
            return false;
        }
        return true;
    }

    override protected Boolean CheckDuplicate()
    {
        //if (this.KeyID == 0)
        //{
        //    DACategory DACategory = new DACategory();
        //    if (DACategory.USP_Category_CheckDuplicate(fUserName.Value.Trim()) == 1)
        //    {
        //        ShowErrorMes("Tài khoản này đã tồn tại. Bạn nhập lại!");
        //        fUserName.Focus();
        //        return false;
        //    }
        //}
        return true;
    }


    private void LoadFeedBackReply()
    {
        DAFeedBackReply daFeedBackReply = new DAFeedBackReply();
        RadGrid1.DataSource = daFeedBackReply.USP_FeedBackReply_GetByFeedBackID(this.KeyID);
        RadGrid1.DataBind();

        daFeedBackReply.CloseAll();
    }

    protected void btSendEmail_Click(object sender, EventArgs e)
    {
        if (this.KeyID == 0)
        {
            ShowErrorMes("Bạn phải lưu nội dung phản hồi trước khi gởi email trả lời");
            return;
        }
        string EmailContent = fEmailContent.InnerText;
        string EmailTitle = fEmailTitle.Value;
        string EmailTo = fEmailTo.Value;

        // Send Email
        string fromMailAddress = WebConfigurationManager.AppSettings["MailAccount"].ToString();
        string fromMailPassword = WebConfigurationManager.AppSettings["MailPass"].ToString();
        string fromMailName = WebConfigurationManager.AppSettings["MailName"].ToString();

        MailSender mailSender = new MailSender(fromMailAddress, fromMailPassword, fromMailName);
        mailSender.sendMail(EmailTo, EmailTitle, EmailContent);

        DAFeedBackReply daFeedBackReply = new DAFeedBackReply();
        daFeedBackReply.fID = 0;
        daFeedBackReply.fFeedBackID = this.KeyID;
        daFeedBackReply.fOperator = MySession.UserName;
        daFeedBackReply.fSysDate = DateTime.Now;
        daFeedBackReply.fContent = EmailContent;
        daFeedBackReply.USP_FeedBackReply_Insert();

        LoadFeedBackReply();
        ShowSuccessMes("Đã gởi email thành công");
        
    }
}