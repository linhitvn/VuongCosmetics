using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;

public partial class Pages_Setting_cWebConfigAlter : TUserControlForAlter
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

    private DAWebConfig CreateObjectFromPage()
    {
        // check 
        DAWebConfig daWebConfig = new DAWebConfig();
        //
        daWebConfig.fConfigKey = fConfigKey.Value.Trim();
        daWebConfig.fConfigValue = fConfigValue.Value.Trim();
        daWebConfig.fDescription = fDescription.Value.Trim();

        //

        return daWebConfig;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAWebConfig daWebConfig = new DAWebConfig();
            daWebConfig.USP_WebConfig_GetFullID(this.KeyID);
            //
            fConfigKey.Value = daWebConfig.fConfigKey.ToString();
            fConfigValue.Value = daWebConfig.fConfigValue.ToString();
            fDescription.Value = daWebConfig.fDescription.ToString();

            //

            // Khi cần enabled cột nào
            if (this.KeyID > 0)
            {
                fConfigKey.Disabled = true;
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
            DAWebConfig DAWebConfig = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAWebConfig.fConfigID = DAWebConfig.USP_GetKey();
                this.KeyID = DAWebConfig.fConfigID; // --> Update new SessionID for continue edit.
            }
            else
            { DAWebConfig.fConfigID = 0; }

            DAWebConfig.USP_WebConfig_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAWebConfig DAWebConfig = CreateObjectFromPage();
            DAWebConfig.fConfigID = this.KeyID;

            DAWebConfig.USP_WebConfig_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAWebConfig DAWebConfig = new DAWebConfig();
            DAWebConfig.USP_WebConfig_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        if (fConfigKey.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa nhập từ khóa");
            fConfigKey.Focus();
            return false;
        }
        if (fConfigValue.Value.Trim() == "")
        {
            ShowErrorMes("Bạn chưa giá trị cấu hình.");
            fConfigValue.Focus();
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
}