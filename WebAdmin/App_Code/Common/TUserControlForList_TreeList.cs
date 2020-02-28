using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web;
using Telerik.Web.UI;

/// <summary>
/// Summary description for TUserControlForList
/// </summary>
public class TUserControlForList_TreeList: TUserControlBase
{
    protected RadTreeList Grid;

    protected System.Web.UI.HtmlControls.HtmlButton BtCreate;
    protected System.Web.UI.HtmlControls.HtmlButton BtClone;
    protected System.Web.UI.HtmlControls.HtmlButton BtDelete;

    protected void Page_Load(object sender, EventArgs e)
    {
        Boolean flagChecker = true;
        flagChecker = Page_Load_Pre();

        flagChecker = flagChecker && GetDataComboBox();
        flagChecker = flagChecker && SetServerControl();

        if (!Page.IsPostBack)
        {

            flagChecker = flagChecker && LoadData();

        }
        flagChecker = flagChecker && Page_Load_Pos();

        if (flagChecker)
            checkRoleAndShowFuntion();

        ShowVisibleMes();
    }

    private void DisableControl()
    {
        if (BtCreate != null)
            BtCreate.Visible = false;

        if (BtClone != null)
            BtClone.Visible = false;

        if (BtDelete != null)
            BtDelete.Visible = false;
    }

    private Boolean ShowControlByRole()
    {
        //if ((Role.Create & this.UserRole) == Role.Create)
        //{
        //    if (BtSave1 != null)
        //        BtSave1.Visible = true;

        //    if (BtSaveAndCreate1 != null)
        //        BtSaveAndCreate1.Visible = true;
        //}
        return true;
    }

    override protected bool checkRoleAndShowFuntion()
    {
        //DisableControl();
        return ShowControlByRole();
    }

    virtual protected Boolean Page_Load_Pre() { return true; }

    virtual protected Boolean Page_Load_Pos() { return true; }

    virtual protected Boolean LoadData() { return true; }

    virtual protected Boolean SetServerControl() { return true; }

    virtual protected Boolean GetDataComboBox() { return true; }

    // Event in Row.
    protected void RadGrid1_ItemCommand(object sender, TreeListCommandEventArgs e)
    {
        int lKeyID = 0;
        string lEvent = e.CommandName;
        string page = "";
        switch (lEvent)
        {
            case ActRow.Delete:
                lKeyID = int.Parse(e.CommandArgument.ToString());
                int lRowDeleted = DeleteByID(lKeyID); // Delete Row
                ShowSuccessMes(lRowDeleted + " dòng đã được xoá");  // show Mes.
                LoadData();
                break;
            case ActRow.Edit:
                lKeyID = int.Parse(e.CommandArgument.ToString());
                page = Page.Request.QueryString["module"];
                TNavigation.EditPage(page, lKeyID);
                break;
            case ActRow.Clone:
                lKeyID = int.Parse(e.CommandArgument.ToString());
                page = Page.Request.QueryString["module"];
                TNavigation.ClonePage(page, lKeyID);
                break;
        }
    }

    // Event New's button Click
    public void New_Click(object sender, EventArgs e)
    {
        string page = Page.Request.QueryString["module"];
        TNavigation.NewPage(page, 0);
    }
    // Event Clone's button Click
    public void Clone_Click(object sender, EventArgs e)
    {
        if (this.Grid == null)
            return;

        int lKeyID = 0;
        int count = 0;
        foreach (TreeListDataItem item in this.Grid.SelectedItems)
        {
            if (item.Selected)
            {
                lKeyID = int.Parse(item.GetDataKeyValue(this.Grid.DataKeyNames[0]).ToString());
                count++;
            }
        }
        switch (count)
        {
            case 0:
                ShowErrorMes("Vui lòng chọn 1 hàng để sao chép");
                break;
            case 1:
                string page = Page.Request.QueryString["module"];
                TNavigation.ClonePage(page, lKeyID);
                break;
            default: // Have more than 1 Row be selected !
                ShowErrorMes("Chỉ được phép chọn tối đa 1 dòng để sao chép");
                break;
        }
    }
    // Event Delete's button Click
    public void Delete_Click(object sender, EventArgs e)
    {
        if (this.Grid == null)
            return;
     
        int lKeyID = 0;
        int Success = 0;
        int Error = 0;
        int Warning = 0;
        int count = 0;
        int result = 0;
        string mesError = "";
        string mesWarrning = "";
        string mesSuccess = "";
        

        try
        {
            foreach (TreeListDataItem item in this.Grid.SelectedItems)
            {
                if (item.Selected)
                {
                    lKeyID = int.Parse(item.GetDataKeyValue(this.Grid.DataKeyNames[0]).ToString());
                    result = DeleteByID(lKeyID);
                    switch (result)
                    {
                        case -1:
                            Error++;
                            break;
                        case 0:
                            Warning++;
                            break;
                        case 1:
                            Success++;
                            break;
                    }
                    count++;
                    
                }
            }
            if (count == 0)
            {
                ShowErrorMes("Vui lòng chọn 1 dòng để Xóa !");
                return;
            }
            else
            {
                if (Warning != 0)
                {
                    mesWarrning = Warning + " dòng dữ liệu không thể xóa vì có dữ liệu liên quan !  ";
                }
                if (Error != 0)
                {
                    mesError = Error + " dòng dữ liệu không thể xóa vì lỗi hệ thống ! ";
                }
                if (Success != 0)
                {
                    mesSuccess = Success + " dòng dữ liệu xóa thành công !";
                }
            }

            ShowMes(mesSuccess, mesWarrning, mesError);
            LoadData();
        }
        catch { }
        

    }
}