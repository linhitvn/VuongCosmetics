using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using System.ComponentModel;

public partial class Pages_Setting_cWebGroupAlter : TUserControlForAlter
{
    DAWebGroup daWebGroup = new DAWebGroup();
    override protected Boolean SetServerControl()
    {
        // Set Message Text
        this.messBox = message_box;
        
        this.BtSaveAndCreate1 = SaveAndCreate;
        this.BtSave1 = Save;

        return true;
    }

    override protected Boolean GetDataComboBox()
    {
        int minLevel;
        int MaxLevel;

        try
        {
            minLevel = daWebGroup.USP_WebGroup_GetLevelByUserID(int.Parse(MyConfig.GetValueByKey("UserID"))) + 1;
            MaxLevel = int.Parse(MyConfig.GetValueByKey("MaxLevel"));
        }
        catch (Exception e)
        {
            ShowErrorMes("Lỗi hệ thống : " + e.ToString());
            return false;
        }


        // Create List Level
        BindingList<UserLevel> userLevels = new BindingList<UserLevel>();

        for (int i = minLevel; i <= MaxLevel; i++)
        {
            UserLevel userLevel = new UserLevel();
            userLevel.LevelID = i;
            userLevel.LevelName = "Cấp " + i;
            userLevels.Add(userLevel);
        }

        fLevel.DataSource = userLevels;
        fLevel.DataBind();

        return true;
    }

    override protected Boolean LoadData()
    {

        try
        {
            daWebGroup.USP_WebGroup_GetFullID(this.KeyID);

            fGroupName.Value = daWebGroup.fGroupName.ToString();
            fDescription.Value = daWebGroup.fDescription.ToString();
            fActive.Checked = (Boolean)daWebGroup.fActive;

            fLevel.Value = daWebGroup.fLevel.ToString();
        }
        catch (Exception e)
        {
            ShowErrorMes("Lổi hệ thống: " + e.ToString());
            return false;
        }
        return true;
    }
    private DAWebGroup CreateObjectFromPage()
    {
        DAWebGroup daWebGroup = new DAWebGroup();
        daWebGroup.fGroupName = fGroupName.Value;
        daWebGroup.fDescription = fDescription.Value;
        daWebGroup.fActive = fActive.Checked;
        daWebGroup.fLevel = int.Parse(fLevel.Value);

        return daWebGroup;
    }

    override protected int ExecInsert()
    {
        // Update with ID = this.ID
        // Check input
        try
        {
            DAWebGroup DAWebGroup = CreateObjectFromPage();
            if (this.mode == ActParam.New)
            {
                DAWebGroup.fGroupID = DAWebGroup.USP_GetKey();
                this.KeyID = DAWebGroup.fGroupID; // --> Update new SessionID for continue edit.
            }
            else { DAWebGroup.fGroupID = 0; }
            DAWebGroup.USP_WebGroup_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID
        try
        {
            DAWebGroup DAWebGroup = CreateObjectFromPage();
            DAWebGroup.fGroupID = this.KeyID;
            DAWebGroup.USP_WebGroup_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAWebGroup daWebGroup = new DAWebGroup();
            daWebGroup.USP_WebGroup_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }
}