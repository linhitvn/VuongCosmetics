using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_SysCategory_cDistrictAlter : TUserControlForAlter
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
            DAProvince daProvince = new DAProvince();
            fProvinceID.DataSource = daProvince.USP_Province_GetDataForComboBox();
            fProvinceID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DADistrict CreateObjectFromPage()
    {
        // check 
        DADistrict daDistrict = new DADistrict();
        //
        daDistrict.fDistrict = fDistrict.Value.Trim();
        daDistrict.fProvinceID = Convert.ToInt32(fProvinceID.Value.Trim());

        //

        return daDistrict;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DADistrict daDistrict = new DADistrict();
            daDistrict.USP_District_GetFullID(this.KeyID);
            //
            fDistrict.Value = daDistrict.fDistrict.ToString();
            fProvinceID.Value = daDistrict.fProvinceID.ToString();

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
            DADistrict DADistrict = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DADistrict.fID = DADistrict.USP_GetKey();
                this.KeyID = DADistrict.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DADistrict.fID = 0; }

            DADistrict.USP_District_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DADistrict DADistrict = CreateObjectFromPage();
            DADistrict.fID = this.KeyID;

            DADistrict.USP_District_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DADistrict DADistrict = new DADistrict();
            DADistrict.USP_District_Delete(pID);
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