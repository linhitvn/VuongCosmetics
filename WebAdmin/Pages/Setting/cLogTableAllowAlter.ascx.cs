using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Setting_cLogTableAllowAlter : TUserControlForAlter
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
            DALogTable daLogTable = new DALogTable();
            fTableName.DataSource = daLogTable.FUNC_GET_ALL_TABLE();
            fTableName.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DALogTableAllow CreateObjectFromPage()
    {
        // check 
        DALogTableAllow daLogTableAllow = new DALogTableAllow();
        //
        daLogTableAllow.fTableName = fTableName.Value.Trim();

        //

        return daLogTableAllow;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DALogTableAllow daLogTableAllow = new DALogTableAllow();
            daLogTableAllow.USP_LogTableAllow_GetFullID(this.KeyID);
            //
            fTableName.Value = daLogTableAllow.fTableName.ToString();

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
            DALogTableAllow DALogTableAllow = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DALogTableAllow.fID = DALogTableAllow.USP_GetKey();
                this.KeyID = DALogTableAllow.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DALogTableAllow.fID = 0; }

            DALogTableAllow.USP_LogTableAllow_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DALogTableAllow DALogTableAllow = CreateObjectFromPage();
            DALogTableAllow.fID = this.KeyID;

            DALogTableAllow.USP_LogTableAllow_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DALogTableAllow DALogTableAllow = new DALogTableAllow();
            DALogTableAllow.USP_LogTableAllow_Delete(pID);
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
        if (this.KeyID == 0)
        {
            DALogTableAllow daLogTableAllow = new DALogTableAllow();
            if(daLogTableAllow.USP_LogTableAllow_CheckDuplicate(fTableName.Value) == 1){
                ShowErrorMes("Bảng này đã tồn tại");
                return false;
            }
        }
        return true;
    }
}