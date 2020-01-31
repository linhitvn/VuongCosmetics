using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for TWebUserControlBase
/// </summary>
public class TWebUserControlBase : System.Web.UI.UserControl
{
    public int ControlID;
    public string param = "";
    public string ControlTitle = "";
    protected int _ControlPos; // postion of Control in Page.

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoadPageControl(HtmlGenericControl div_containner)
    {
        _ControlPos = 0; // Reset to 1.
        DAControl daControl = new DAControl();
        DataTable dataTable = daControl.Client_USP_Control_ByParentID_DataTable(this.ControlID);
        foreach (DataRow dataRow in dataTable.Rows)
        {
            //try
            //{
            string Ucontrol = "~/WebUser/" + dataRow["UControl"].ToString();
            string Param = dataRow["param"].ToString();
            string ControlTitle = dataRow["ControlName"].ToString();
            int ControlID = int.Parse(dataRow["ID"].ToString());

            TWebUserControlBase tControl = (TWebUserControlBase)LoadControl(Ucontrol);
            tControl.param = Param;
            tControl.ControlTitle = ControlTitle;
            tControl.ControlID = ControlID;

            div_containner.Controls.AddAt(_ControlPos, tControl);

            _ControlPos++;
            //}
            //catch { }
        }
    }
}