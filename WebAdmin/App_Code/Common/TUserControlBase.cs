using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TUserControlBase
/// </summary>
public class TUserControlBase : System.Web.UI.UserControl
{
    protected string mesStr;
    protected System.Web.UI.HtmlControls.HtmlGenericControl messBox;

    virtual protected int DeleteByID(int pID) { return 1; } // Delete Row by ID.

    protected int UserRole
    {
        get
        {
            return 15;
        }
    }

    public TUserControlBase()
    {
    }

    // Show buttons apporiate with role of user.
    virtual protected bool checkRoleAndShowFuntion()
    {
        return true;
    }

    public void ShowVisibleMes()
    {
        messBox.InnerHtml = "";
    }

    public void ShowMes(string pMesSucess, string pMesWarrning, string pMesError)
    {
        string html = "";
        if (pMesSucess != "")
        {
            html += getSuccessHtml(pMesSucess);
        }
        if (pMesWarrning != "")
        {
            html += getWarrningHtml(pMesWarrning);
        }
        if (pMesError != "")
        {
            html += getErrorHtml(pMesError);
        }

        messBox.InnerHtml = html;
    }

    public void ShowErrorMes(string pMes)
    {
        messBox.InnerHtml = getErrorHtml(pMes);
    }

    public void ShowSuccessMes(string pMes)
    {
        messBox.InnerHtml = getSuccessHtml(pMes);
    }

    public void ShowWarrningMes(string pMes)
    {
        messBox.InnerHtml = getWarrningHtml(pMes);
    }

    private string getSuccessHtml(string pMes)
    {
        string html = "<div class='alert alert-success alert-dismissable'><i class='fa fa-check'></i>"
            + "<button type='submit' class='close' data-dismiss='alert' aria-hidden='true'>×</button>"
            + pMes + "</div>";
        return html;
    }

    private string getWarrningHtml(string pMes)
    {
        string html = "<div class='alert alert-warning alert-dismissable'><i class='fa fa-warning'></i>"
            + "<button type='submit' class='close' data-dismiss='alert' aria-hidden='true'>×</button>"
            + pMes + "</div>";
        return html;
    }

    private string getErrorHtml(string pMes)
    {
        string html = "<div class='alert alert-danger alert-dismissable'>"
                + "<i class='fa fa-ban'></i>"
                + "<button type='submit' class='close' data-dismiss='alert' aria-hidden='true'>×</button>"
                + pMes + "</div>";
        return html;
    }
}

