using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Account_cAccountInfo : TUserControlForAlter
{
    override protected Boolean SetServerControl()
    {
        // Set Message Text
        this.messBox = message_box;

        // Set button Controller
        //this.BtDelete1 = BtDelete1;
        this.BtSave1 = Save1;
        //this.BtSaveAndCreate1 = SaveAndCreate1;

        return true;
    }
    
    override protected Boolean Page_Load_Pre()
    {
        // Set KeyID
        this.KeyID = Convert.ToInt32(MyConfig.GetValueByKey("UserID"));
        return true;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAWebUser DAWebUser = new DAWebUser();
            DAWebUser.USP_WebUser_GetFullID(this.KeyID);

            fUserName.Value = DAWebUser.fUserName.ToString();
            fFullName.Value = DAWebUser.fFullName.ToString();
            //fPassWord.Value = DAWebUser.fPassWord.ToString();
            //fPassWord.Attributes.Add("value", MD5Encrypt.DecryptDataMD5(DAWebUser.fPassWord, "CMSVTS"));
            //cHiddenUPassword.Text = DAWebUser.fPassWord.ToString();
            ddlRGroup.Value = DAWebUser.fRole.ToString();
            fAddress.Value = DAWebUser.fAddress.ToString();
            fTel.Value = DAWebUser.fTel.ToString();
            fEmail.Value = DAWebUser.fEmail.ToString();
            fSocial.Value = DAWebUser.fSocial.ToString();

            fDescription.Value = DAWebUser.fDescription.ToString();
            fActive.Checked = (Boolean)DAWebUser.fActive;
            //if (cHiddenUPassword.Text != "")
            //    MD5Encrypt.EncryptDataMD5(DAWebUser.fPassWord, "CMSVTS");

            fUserName.Disabled = true;

        }
        catch
        {
            return false;
        }

        return true;
    }

    override protected Boolean Page_Load_Pos()
    {
        this.BtSave1 = Save1;
        this.BtSave1.Visible = true;

        return true;
    }

    override protected Boolean GetDataComboBox()
    {
        try
        {
            DAWebGroup mWGroup = new DAWebGroup();

            ddlRGroup.DataSource = mWGroup.USP_WebGroup_GetAllByCombo();
            ddlRGroup.DataValueField = "GroupID";
            ddlRGroup.DataTextField = "GroupName";
            ddlRGroup.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAWebUser CreateObjectFromPage()
    {
        // check 

        DAWebUser DAWebUser = new DAWebUser();

        DAWebUser.fUserName = fUserName.Value.Trim();
        DAWebUser.fFullName = fFullName.Value;
        //DAWebUser.fPassWord = MD5Encrypt.EncryptDataMD5(fPassWord.Text.Trim(), "CMSVTS");
        //DAWebUser.fRole = Convert.ToInt32(ddlRGroup.SelectedValue);
        DAWebUser.fAddress = fAddress.Value;
        DAWebUser.fTel = fTel.Value;
        DAWebUser.fEmail = fEmail.Value;
        DAWebUser.fSocial = fSocial.Value;

        //DAWebUser.fDescription = fDescription.Value;
        //DAWebUser.fActive = fActive.Checked;
        //if (fPassWordNew.Value.Trim() != "")
        //    DAWebUser.fPassWord = MD5Encrypt.EncryptDataMD5(fPassWordNew.Value.Trim(), "CMSVTS");
        //else
        //    DAWebUser.fPassWord = MyConfig.GetValueByKey("PassWord");

        return DAWebUser;
    }

    override protected int ExecInsert()
    {
        // Update with ID = this.ID

        try
        {
            DAWebUser DAWebUser = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAWebUser.fUserID = DAWebUser.USP_GetKey();
                this.KeyID = DAWebUser.fUserID; // --> Update new SessionID for continue edit.
            }
            else
            { DAWebUser.fUserID = 0; }

            DAWebUser.USP_WebUser_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAWebUser DAWebUser = CreateObjectFromPage();
            DAWebUser.fUserID = this.KeyID;

            DAWebUser.USP_WebUser_UpdateInfo();
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        if (fUserName.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập tài khoản!");
            fUserName.Focus();
            return false;
        }
        if (fPassWord.Value.Trim() != "")
        {
            if (MD5Encrypt.EncryptDataMD5(fPassWord.Value.Trim(), "CMSVTS") != MyConfig.GetValueByKey("PassWord"))
            {
                ShowErrorMes("Mật khẩu cũ không đúng! Bạn nhập lại ...");
                fPassWord.Focus();
                return false;
            }
        }

        if (fPassWordNew.Value.Trim() != "")
        {
            if (MD5Encrypt.EncryptDataMD5(fPassWord.Value.Trim(), "CMSVTS") != MyConfig.GetValueByKey("PassWord"))
            {
                ShowErrorMes("Mật khẩu cũ không đúng! Bạn nhập lại ...");
                fPassWord.Focus();
                return false;
            }
        }

        return true;
    }

    protected void ChangePass_Click(object sender, EventArgs e)
    {
        try
        {
            if (fPassWord.Value == "" || fPassWordNew.Value == "" || fPassWordNewConfirm.Value == "")
            {
                ShowErrorMes("Vui lòng nhập đầy đủ thông tin mật khẩu");
                return;
            }

            else if (MD5Encrypt.EncryptDataMD5(fPassWord.Value.Trim(), "CMSVTS") != MyConfig.GetValueByKey("PassWord"))
            {
                ShowErrorMes("Mật khẩu cũ không đúng! Bạn nhập lại ...");
                fPassWord.Focus();
                return;
            }
            else if (fPassWordNew.Value != fPassWordNewConfirm.Value)
            {
                ShowErrorMes("Nhập mật khẩu lại không chính xác");
                fPassWordNewConfirm.Focus();
                return;
            }
            DAWebUser daWebUser = new DAWebUser();
            string PassEcryp = MD5Encrypt.EncryptDataMD5(fPassWordNew.Value.Trim(), "CMSVTS");
            daWebUser.USP_WebUser_ChangePass(this.KeyID, PassEcryp);
            ShowSuccessMes("Đỗi mật khẩu thành công");
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.ToString());
        }
    }


}