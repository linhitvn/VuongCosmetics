using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using Telerik.Web.UI;

public partial class Pages_Marketing_Reward_RewardAlter : TUserControlForAlter
{
    override protected Boolean SetServerControl()
    {
        try
        {
            // Set Message Value
            this.messBox = message_box;

            // Set button Controller
            this.BtSave1 = Save;
            //this.BtSaveAndCreate1 = SaveAndCreate;
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
            DARecordType rewardType = new DARecordType();
            fRewardTypeID.DataSource = rewardType.USP_RecordType_GetComboBox_ByTableName("Reward");
            fRewardTypeID.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DAReward CreateObjectFromPage()
    {
        // check 
        DAReward daReward = new DAReward();
        //
        daReward.fRewardTypeID = Convert.ToInt32(fRewardTypeID.Value.Trim());
        daReward.fPointToMoney = Convert.ToInt32(fPointToMoney.Value.Trim());
        daReward.fMinForChange = Convert.ToInt32(fMinForChange.Value.Trim());
        daReward.fAfterDayForChange = Convert.ToInt32(fAfterDayForChange.Value.Trim());
        daReward.fDayForResetAll = Convert.ToInt32(fDayForResetAll.Value.Trim());
        daReward.fActive = fActive.Checked;
        daReward.fNote = fNote.Value.Trim();
        daReward.fOperator = MySession.UserName;

        //

        return daReward;
    }

    private void LoadRewardOrder()
    {
        DARewardOrder daRewardOrder = new DARewardOrder();
        RadGrid1.DataSource = daRewardOrder.USP_GetAll(0, 0);
        RadGrid1.DataBind();
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DAReward daReward = new DAReward();
            daReward.USP_Reward_GetFullID(this.KeyID);
            //
            fRewardTypeID.Value = daReward.fRewardTypeID.ToString();
            fPointToMoney.Value = daReward.fPointToMoney.ToString();
            fMinForChange.Value = daReward.fMinForChange.ToString();
            fAfterDayForChange.Value = daReward.fAfterDayForChange.ToString();
            fDayForResetAll.Value = daReward.fDayForResetAll.ToString();
            fActive.Checked = daReward.fActive;
            fNote.Value = daReward.fNote.ToString();

            // Load RewardOrder 
            LoadRewardOrder();

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
            DAReward DAReward = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DAReward.fID = DAReward.USP_GetKey();
                this.KeyID = DAReward.fID; // --> Update new SessionID for continue edit.
            }
            else
            { DAReward.fID = 0; }

            DAReward.USP_Reward_Insert();
            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DAReward DAReward = CreateObjectFromPage();
            DAReward.fID = this.KeyID;

            DAReward.USP_Reward_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DAReward DAReward = new DAReward();
            DAReward.USP_Reward_Delete(pID);
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

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        int lKeyID = 0;
        string lEvent = e.CommandName;
        switch (lEvent)
        {
            case ActRow.Delete:
                lKeyID = int.Parse(e.CommandArgument.ToString());
                DARewardOrder daRewardOrder = new DARewardOrder();
                daRewardOrder.USP_RewardOrder_Delete(lKeyID);
                LoadRewardOrder();
                ShowSuccessMes("Đã xóa");
                break;
        }
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        try
        {
            int valueOfOrder = int.Parse(aValue.Value);
            int point = int.Parse(aPoint.Value);

            DARewardOrder rewardOrder = new DARewardOrder();
            rewardOrder.fID = 0;
            rewardOrder.fMinPrice = valueOfOrder;
            rewardOrder.fPoint = point;
            rewardOrder.fRewardID = this.KeyID;

            rewardOrder.USP_RewardOrder_Insert();

            LoadRewardOrder();
        }
        catch
        {
            ShowErrorMes("Định dạng dữ liệu phải là số");
        }
    }
}