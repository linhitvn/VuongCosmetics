using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }
    private void LoadData(string ProductName="")
    {
        DAProduct daProduct = new DAProduct();
        RadComboBox2.DataSource = daProduct.USP_Product_SearchByName(ProductName);
        RadComboBox2.DataBind();
    }
    protected void RadComboBox2_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        LoadData(e.Text.ToString());
    }
    protected void RadComboBox2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        div_check.InnerText = "Checked";
    }
}