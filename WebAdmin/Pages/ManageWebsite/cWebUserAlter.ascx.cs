using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_ManageWebsite_cWebUserAlter : TUserControlForAlter
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
        catch {
            ShowErrorMes("Lỗi hệ thống Control !");
            return false;
        }

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
            //fPassWord.Value = MD5Encrypt.DecryptDataMD5(DAWebUser.fPassWord, "CMSVTS");
            ddlRGroup.Value = DAWebUser.fRole.ToString();
            fAddress.Value = DAWebUser.fAddress.ToString();
            fTel.Value = DAWebUser.fTel.ToString();
            fEmail.Value = DAWebUser.fEmail.ToString();
            fSocial.Value = DAWebUser.fSocial.ToString();

            fDescription.Value = DAWebUser.fDescription.ToString();
            fActive.Checked = (Boolean)DAWebUser.fActive;
            //if(cHiddenUPassword.Value!="")
            //MD5Encrypt.EncryptDataMD5(DAWebUser.fPassWord, "CMSVTS");

            if (mode == Act.Edit)
                fUserName.Disabled = true;


        }
        catch (Exception e)
        {
            ShowErrorMes("Lỗi hệ thống: " + e.ToString());
            return false;
        }

        return true;
    }

    override protected Boolean GetDataComboBox()
    {
        try
        {
            DAWebGroup mWGroup = new DAWebGroup();

            ddlRGroup.DataSource = mWGroup.USP_WebGroup_GetAllByComboByUserID(int.Parse(MySession.UserID));
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
        DAWebUser.fPassWord = MD5Encrypt.EncryptDataMD5(fPassWord.Value.Trim(), "CMSVTS");
        DAWebUser.fRole = Convert.ToInt32(ddlRGroup.Value);
        DAWebUser.fAddress = fAddress.Value;
        DAWebUser.fTel = fTel.Value;
        DAWebUser.fEmail = fEmail.Value;
        DAWebUser.fSocial = fSocial.Value;

        DAWebUser.fDescription = fDescription.Value;
        DAWebUser.fActive = fActive.Checked;

        return DAWebUser;
    }

    override protected int ExecInsert()
    {
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

            DAWebUser.USP_WebUser_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAWebUser DAWebUser = new DAWebUser();
            return DAWebUser.USP_WebUser_Delete(pID);
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
        if (fPassWord.Value.Trim() == "" && this.mode != Act.Edit)
        {
            ShowErrorMes("Bạn chưa nhập mật khẩu!");
            fPassWord.Focus();
            return false;
        }
        if (ddlRGroup.Value.Trim() == "0")
        {
            ShowErrorMes("Bạn chưa chọn quyền của người dùng !");
            ddlRGroup.Focus();
            return false;
        }
        return true;
    }

    override protected Boolean CheckDuplicate()
    {
        if (this.KeyID == 0)
        {
            DAWebUser DAWebUser = new DAWebUser();
            if (DAWebUser.USP_WebUser_CheckDuplicate(fUserName.Value.Trim()) == 1)
            {
                ShowErrorMes("Tài khoản này đã tồn tại. Bạn nhập lại!");
                fUserName.Focus();
                return false;
            }
        }
        return true;
    }
}