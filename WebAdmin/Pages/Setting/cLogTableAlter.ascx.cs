using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDL.Framework.Common.Encryption;
using System.Data;

public partial class Pages_Setting_cLogTableAlter : TUserControlForAlter
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
            DALogTableAllow daLogTableAllow = new DALogTableAllow();
            fTableName.DataSource = daLogTableAllow.USP_LogTableAllow_GetDataForComboBox();
            fTableName.DataBind();

            return true;
        }
        catch (Exception ex)
        {
            ShowErrorMes("Lỗi hệ thống: " + ex.Message);
            return false;
        }
    }

    private DALogTable CreateObjectFromPage()
    {
        // check 
        DALogTable daLogTable = new DALogTable();
        //
        daLogTable.fTableName = fTableName.Value.Trim();

        //

        return daLogTable;
    }

    override protected Boolean LoadData()
    {
        try
        {
            // Load Data For Page.
            DALogTable daLogTable = new DALogTable();
            daLogTable.USP_LogTable_GetFullID(this.KeyID);
            DataSet ds;
            fTableName.Value = daLogTable.fTableName.ToString();

            if (this.KeyID != 0)
            {

                //btEnale.Visible = true;
                //btDisable.Visible = true;

                Save.Visible = false;
                this.BtSave1 = null;

                fTableName.Disabled = true;

                ds = daLogTable.FUNC_GET_STATUS_TABLE_TRIGGER(daLogTable.fTableName);

                RadGrid1.DataSource = ds;
                RadGrid1.DataBind();
                bool isEnable = false, isDisable = false;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    bool check = bool.Parse(ds.Tables[0].Rows[i]["is_visibled"].ToString());
                    if (!isDisable && check) isDisable = true;
                    if (!isEnable && !check) isEnable = true;
                }
                btEnale.Visible = isEnable;
                btDisable.Visible = isDisable;
            }

            else
            {
                btEnale.Visible = false;
                btDisable.Visible = false;

                this.BtSave1 = Save;
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
            DALogTable DALogTable = CreateObjectFromPage();

            if (this.mode == ActParam.New)
            {
                DALogTable.fID = DALogTable.USP_GetKey();
                this.KeyID = DALogTable.fID; // --> Update new SessionID for continue edit.
            }
            else
            {
                DALogTable.fID = 0;
            }

            DALogTable.USP_LogTable_Insert();
            DALogTable.FUNC_CREATE_LOG_FOR_TABLE(fTableName.Value);

            // Reload Data
            LoadData();

            return 1;
        }
        catch { return 0; }
    }

    override protected int ExecUpdate()
    {
        // Update with ID = this.ID       
        try
        {
            DALogTable DALogTable = CreateObjectFromPage();
            DALogTable.fID = this.KeyID;

            DALogTable.USP_LogTable_Update();
            return 1;
        }
        catch { return 0; }
    }

    override protected int DeleteByID(int pID)
    {
        try
        {
            DALogTable DALogTable = new DALogTable();
            DALogTable.USP_LogTable_Delete(pID);
            return 1;
        }
        catch { return 0; }
    }

    override protected Boolean CheckInput()
    {
        if (fTableName.SelectedIndex == 0)
        {
            ShowErrorMes("Bạn chưa chọn Table để Backup dữ liệu!");
            fTableName.Focus();
            return false;
        }
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
            DALogTable daLogTable = new DALogTable();
            if (daLogTable.USP_LogTable_CheckDuplicate(fTableName.Value) == 1)
            {
                ShowErrorMes("Bảng này đã tồn tại");
                return false;
            }
        }
        return true;
    }
    public void Enable_Click(object sender, EventArgs e)
    {
        if (!CheckCreated())
            return;
        try
        {
            DALogTable daLogTable = new DALogTable();
            daLogTable.FUNC_CHANGE_STATUS_TABLE_TRIGGER(fTableName.Value, true);
            ShowSuccessMes("Đã kích hoạt ghi log");
            LoadData();

        }
        catch
        {
            ShowErrorMes("Quá trình thất bại !");
        }
    }

    private bool CheckCreated()
    {
        ShowErrorMes("Bạn phải lưu thông tin trước khi kích hoạt Ghi Log");
        return this.KeyID != 0;
    }

    public void Disable_Click(object sender, EventArgs e)
    {
        if (!CheckCreated())
            return;
        try
        {
            DALogTable daLogTable = new DALogTable();
            daLogTable.FUNC_CHANGE_STATUS_TABLE_TRIGGER(fTableName.Value, false);
            ShowSuccessMes("Đã dừng việc ghi Log");
            LoadData();

        }
        catch
        {
            ShowErrorMes("Quá trình thất bại !");
        }
    }
}