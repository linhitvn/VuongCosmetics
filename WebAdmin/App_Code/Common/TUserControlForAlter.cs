using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for TUserControl
/// </summary>
public class TUserControlForAlter : TUserControlBase
{

    public const string MSG_INSERT_SUCCESS_IN_MODE_Insert = "Dữ liệu đã được tạo thành công. Bạn tiếp tục chỉnh sửa dữ liệu vừa tạo";
    public const string MSG_INSERT_SUCCESS_IN_MODE_Clone = "Dữ liệu đã được tạo thành công. Bạn tiếp tục thêm dữ liệu cho record mới !";
    public const string MSG_INSERT_FAIL = "Thêm dữ liệu thất bại. Vui lòng thử lại";

    public const string MSG_UPDATE_SUCCESS = "Cập nhật dữ liệu thành công";
    public const string MSG_UPDATE_FAIL = "Cập nhật dữ liệu thất bại. Vui lòng thử lại";

    public const string MSG_DELETE_SUCCESS = "Xoá dữ liệu thành công";
    public const string MSG_DELETE_FAIL = "Xoá dữ liệu thất bại";
    public const string MSG_DELETE_CAN_NOT_DELETED = "Không thể xoá khi đang tạo dữ liệu";

    public const string MSG_NOT_PERMITED = "Bạn không được phép thực hiện lệnh này";

    public string urlHelp = "#";
    protected string staticAction = "";
    protected int staticAlterID = -1;

    protected System.Web.UI.HtmlControls.HtmlButton BtSaveAndCreate1;
    protected System.Web.UI.HtmlControls.HtmlButton BtSave1;
    protected System.Web.UI.HtmlControls.HtmlButton BtDelete1;

    public TUserControlForAlter()
    {
    }


    // Return 1: Everything is OK !
    protected bool CheckError()
    {
        if (this.KeyID < 0)
        {
            ShowErrorMes("Dữ liệu của bạn bị xóa vì thời gian chỉnh sửa vượt quá thời gian cho phép.");
            TNavigation.BackPage();
            return false;
        }
        return true;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        Boolean flagChecker = true;

        flagChecker = flagChecker && SetServerControl();
        flagChecker = Page_Load_Pre();
        flagChecker = flagChecker && CheckError();
        if (!Page.IsPostBack)
        {
            flagChecker = flagChecker && GetDataComboBox();
            flagChecker = flagChecker && LoadData();
        }
        flagChecker = flagChecker && Page_Load_Pos();

        if (flagChecker)
            checkRoleAndShowFuntion();
    }


    protected string mode
    {
        get
        {
            if (Request.QueryString["act"] == null)
                return ActParam.view;
            else
            {
                if (this.KeyID != 0 && Request.QueryString["act"].ToString() == ActParam.New)
                    return ActParam.Edit;
                return Request.QueryString["act"].ToString();
            }
        }
    }

    protected string modeParam
    {
        get
        {
            if (Request.QueryString["act"] == null)
                return ActParam.view;
            else
            {
                return Request.QueryString["act"].ToString();
            }
        }
    }

    protected int KeyID
    {
        get
        {
            try
            {
                string page = Page.Request.QueryString["module"];
                return PageKeyID.KeyID(page);
                //if (Session["KeyID"] == null)
                //    return 0;
                //else
                //    return int.Parse(Session["KeyID"].ToString());
            }
            catch
            {
                return -1;
                //return -1;
            }
        }
        set
        {
            string page = Page.Request.QueryString["module"];
            PageKeyID.AddKeyID(page, value);
        }
    }

    private void DisableControl()
    {
        if (BtSave1 != null)
            BtSave1.Visible = false;

        if (BtSaveAndCreate1 != null)
            BtSaveAndCreate1.Visible = false;

        if (BtDelete1 != null)
            BtDelete1.Visible = false;
    }

    private Boolean ShowControlByRole()
    {
        switch (mode)
        {
            case ActParam.New:
                if ((Role.Create & this.UserRole) == Role.Create)
                {
                    if (BtSave1 != null)
                        BtSave1.Visible = true;

                    if (BtSaveAndCreate1 != null)
                        BtSaveAndCreate1.Visible = true;
                }
                break;
            case ActParam.Edit:
                if ((Role.Edit & this.UserRole) == Role.Edit)
                {
                    if (BtSave1 != null)
                        BtSave1.Visible = true;
                }
                if ((Role.Delete & this.UserRole) == Role.Delete)
                {
                    if (BtDelete1 != null)
                        BtDelete1.Visible = true;
                }
                break;
            case ActParam.Clone:
                if ((Role.Create & this.UserRole) == Role.Create)
                {
                    if (BtSaveAndCreate1 != null)
                        BtSaveAndCreate1.Visible = true;
                }
                break;
            default:
                return false;
        }
        return true;
    }

    override protected bool checkRoleAndShowFuntion()
    {
        DisableControl();
        return ShowControlByRole();
    }

    // Virtual Function

    virtual protected Boolean Page_Load_Pre() { return true; }

    virtual protected Boolean Page_Load_Pos() { return true; }

    virtual protected Boolean LoadData() { return true; }

    virtual protected Boolean SetServerControl() { return true; }

    virtual protected Boolean GetDataComboBox() { return true; }

    virtual protected int ExecUpdate() { return 1; }

    virtual protected int ExecInsert() { return 1; }

    virtual protected Boolean CheckInput() { return true; }
    virtual protected Boolean CheckDuplicate() { return true; }

    // Save's Button Click
    public void Save_Click(object sender, EventArgs e)
    {
        int result;
        // Check input
        if (!CheckInput()) return;
        if (!CheckDuplicate()) return;
        switch (this.mode)
        {
            case ActParam.New:
                result = ExecInsert();
                switch(result)
                {
                    case 0:
                        ShowErrorMes(MSG_INSERT_FAIL);
                        this.KeyID = 0;
                        break;
                    case 1:
                        ShowSuccessMes(MSG_INSERT_SUCCESS_IN_MODE_Insert);
                        checkRoleAndShowFuntion();
                        break;
                }
                break;
            default:
            //case ActParam.Edit:
                result = ExecUpdate();
                switch(result)
                {
                    case 0:
                        ShowErrorMes(MSG_UPDATE_FAIL);
                        break;
                    case 1:
                         ShowSuccessMes(MSG_UPDATE_SUCCESS);
                        break;
                }
                break;
            //default:
            //    ShowErrorMes(MSG_NOT_PERMITED);
            //    break;
        }
    }

    // Update's Button Click
    public void SaveAndCreate_Click(object sender, EventArgs e)
    {
        // Check input
        if (!CheckInput()) return;
        if (!CheckDuplicate()) return;
        if (ExecInsert() == 1)
        {
            ShowSuccessMes(MSG_INSERT_SUCCESS_IN_MODE_Clone);
            if (this.modeParam == ActParam.New)
            {
                this.KeyID = 0;
                LoadData();
            }
        }
        else
        {
            ShowErrorMes(MSG_INSERT_FAIL);
        }
    }

    // Delete's Button Click
    public void Delete_Click(object sender, EventArgs e)
    {

        if (this.KeyID != 0)
            if (DeleteByID(this.KeyID) == 1)
            {
                ShowSuccessMes(MSG_DELETE_SUCCESS);
                TNavigation.BackPage();
            }
            else
            {
                ShowErrorMes(MSG_DELETE_FAIL);
            }
        else
        {
            ShowErrorMes(MSG_DELETE_CAN_NOT_DELETED);
        }
    }

    // Back's button CLick
    public void Back_Click(object sender, EventArgs e)
    {
        TNavigation.BackPage();
    }
}