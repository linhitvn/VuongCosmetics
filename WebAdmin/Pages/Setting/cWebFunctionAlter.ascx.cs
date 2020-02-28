using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.Configuration;

public partial class Pages_Setting_cWebFunctionAlter : TUserControlForAlter
{

    override protected Boolean SetServerControl()
    {
        // Set Message Text
        this.messBox = message_box;

        // Set button Controller
        this.BtSave1 = Save;
        this.BtSaveAndCreate1 = SaveAndCreate;

        return true;

    }

    override protected Boolean GetDataComboBox()
    {
        try
        {
            DAWebFunction daWebFunction = new DAWebFunction();
            fParentID.DataSource = daWebFunction.USP_WebFunction_GetDataForComboBox_Parent();
            fParentID.DataBind();

            return true;
        }
        catch (Exception e){
            ShowErrorMes("Lỗi hệ thống: " + e.ToString());
            return false;
        }
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAWebFunction daWebFunction = new DAWebFunction();
            daWebFunction.USP_WebFunction_GetFullID(this.KeyID);
            //
            fFuncID.Value = daWebFunction.fFuncID.ToString();
            fParentID.Value = daWebFunction.fParentID.ToString();
            fVNName.Value = daWebFunction.fVNName.ToString();
            fENName.Value = daWebFunction.fENName.ToString();
            fUKey.Value = daWebFunction.fUKey.ToString();
            fUControl.Value = daWebFunction.fUControl.ToString();
            fURLLink.Value = daWebFunction.fURLLink.ToString();
            fRole.Value = daWebFunction.fRole.ToString();
            fCssClass.Value = daWebFunction.fCssClass.ToString();
            fIcon.Value = daWebFunction.fIcon.ToString();
            fIconHover.Value = daWebFunction.fIconHover.ToString();
            fActive.Checked = daWebFunction.fActive;
            fDisplayOrder.Value = daWebFunction.fDisplayOrder.ToString();
            fisShow.Checked = daWebFunction.fisShow;


            return true;
        }
        catch (Exception e)
        {
            ShowErrorMes("Lổi hệ thống: " + e.ToString());
            return false;
        }
    }


    private DAWebFunction CreateObjectFromPage(SQL_MODE sqlMode)
    {
        // check 
        DAWebFunction daWebFunction = new DAWebFunction();
        //if (sqlMode == SQL_MODE.Insert)
        //    daWebFunction.USP_WebFunction_GetFullID(0);

        //
        daWebFunction.fFuncID = Convert.ToInt32(fFuncID.Value.Trim());
        daWebFunction.fParentID = Convert.ToInt32(fParentID.Value.Trim());
        daWebFunction.fVNName = fVNName.Value.Trim();
        daWebFunction.fENName = fENName.Value.Trim();
        daWebFunction.fUKey = fUKey.Value.Trim();
        daWebFunction.fUControl = fUControl.Value.Trim();
        daWebFunction.fURLLink = fURLLink.Value.Trim();
        daWebFunction.fRole = Convert.ToInt32(fRole.Value.Trim());
        daWebFunction.fCssClass = fCssClass.Value.Trim();
        daWebFunction.fIcon = fIcon.Value.Trim();
        daWebFunction.fIconHover = fIconHover.Value.Trim();
        daWebFunction.fActive = fActive.Checked;
        daWebFunction.fDisplayOrder = Convert.ToInt32(fDisplayOrder.Value.Trim());
        daWebFunction.fisShow = fisShow.Checked;

        //

        return daWebFunction;
    }

    override protected int ExecInsert()
    {
        // Update with ID = this.ID

        try
        {
            DAWebFunction daWebFunction = CreateObjectFromPage(SQL_MODE.Insert);
            //daWebFunction.fFuncID = daWebFunction.USP_GetKey();
            daWebFunction.USP_WebFunction_Insert();
            if (this.mode == ActParam.New)
            {
                this.KeyID = daWebFunction.fFuncID;
            }
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAWebFunction daWebFunction = CreateObjectFromPage(SQL_MODE.Update);
            daWebFunction.fFuncID = this.KeyID;

            daWebFunction.USP_WebFunction_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAWebFunction daWebFunction = new DAWebFunction();
            daWebFunction.USP_WebFunction_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        // Kiểm tra đầu vào 
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
        // Kiểm tra trùng key
        //if (this.mode != ActParam.Edit)
        //{
        //    DAWebFunction daWebFunction = new DAWebFunction();
        //    if (daWebFunction.USP_WebFunction_CheckDuplicate(fUserName.Value.Trim()) == 1)
        //    {
        //        ShowErrorMes("Tài khoản này đã tồn tại. Bạn nhập lại!");
        //        fUserName.Focus();
        //        return false;
        //    }
        //    return true;
        //}
        //else
        //{
        return true;
        //}
    }
}