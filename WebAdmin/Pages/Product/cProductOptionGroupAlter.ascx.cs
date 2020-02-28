using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Product_cProductOptionGroupAlter : TUserControlForAlter
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
            DARecordType daRecordType = new DARecordType();
            fRecordTypeID.DataSource = daRecordType.USP_RecordType_GetComboBox_ByTableName("ProductOptionGroup");
            fRecordTypeID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAProductOptionGroup CreateObjectFromPage()
    {
        // check 
        DAProductOptionGroup daProductOptionGroup = new DAProductOptionGroup();
        //
        daProductOptionGroup.fProductOptionGroup = fProductOptionGroup.Value.Trim();
        daProductOptionGroup.fDescription = fDescription.Value.Trim();
        daProductOptionGroup.fRecordTypeID = Convert.ToInt32(fRecordTypeID.Value.Trim());

        //

        return daProductOptionGroup;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAProductOptionGroup daProductOptionGroup = new DAProductOptionGroup();
            daProductOptionGroup.USP_ProductOptionGroup_GetFullID(this.KeyID);
            //
            fProductOptionGroup.Value = daProductOptionGroup.fProductOptionGroup.ToString();
            fDescription.Value = daProductOptionGroup.fDescription.ToString();
            fRecordTypeID.Value = daProductOptionGroup.fRecordTypeID.ToString();

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
            DAProductOptionGroup DAProductOptionGroup = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAProductOptionGroup.fID = DAProductOptionGroup.USP_GetKey();
                this.KeyID = DAProductOptionGroup.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAProductOptionGroup.fID = 0; }

            DAProductOptionGroup.USP_ProductOptionGroup_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAProductOptionGroup DAProductOptionGroup = CreateObjectFromPage();
            DAProductOptionGroup.fID = this.KeyID;

            DAProductOptionGroup.USP_ProductOptionGroup_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAProductOptionGroup DAProductOptionGroup = new DAProductOptionGroup();
            DAProductOptionGroup.USP_ProductOptionGroup_Delete(pID);
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