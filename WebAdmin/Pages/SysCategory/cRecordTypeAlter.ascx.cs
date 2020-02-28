using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_SysCategory_cRecordTypeAlter : TUserControlForAlter
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

    private DARecordType CreateObjectFromPage()
    {
        // check 
        DARecordType daRecordType = new DARecordType();
        //
        daRecordType.fRecordType = fRecordType.Value.Trim();
        daRecordType.fTableName = fTableName.Value.Trim();
        daRecordType.fDescription = fDescription.Value.Trim();

        //

        return daRecordType;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DARecordType daRecordType = new DARecordType();
            daRecordType.USP_RecordType_GetFullID(this.KeyID);
            //
            fRecordType.Value = daRecordType.fRecordType.ToString();
            fTableName.Value = daRecordType.fTableName.ToString();
            fDescription.Value = daRecordType.fDescription.ToString();

            //

            // Khi cần enabled cột nào
            //if (this.KeyID > 0)
            //{
            //    if (mode != Act.Clone)
            //        fUserName.Enabled = false;
            //    else
            //        fUserName.Text = "";
            //}
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
            DARecordType DARecordType = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DARecordType.fID = DARecordType.USP_GetKey();
                this.KeyID = DARecordType.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DARecordType.fID = 0; }

            DARecordType.USP_RecordType_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DARecordType DARecordType = CreateObjectFromPage();
            DARecordType.fID = this.KeyID;

            DARecordType.USP_RecordType_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DARecordType DARecordType = new DARecordType();
            DARecordType.USP_RecordType_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        //if (fUserName.Value.Trim() == "")
        //{
        //    ShowErrorMes("Bạn chưa nhập tài khoản!");
        //    fUserName.Focus();
        //    return false;
        //}
        //if (fPassWord.Value.Trim() == "")
        //{
        //    ShowErrorMes("Bạn chưa nhập mật khẩu!");
        //    fPassWord.Focus();
        //    return false;
        //}
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
}