using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Net;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strShow = Request.QueryString["s"] == null ? "" : Request.QueryString["s"].ToString().ToUpper();
        Session["Dropdown"] = strShow;
        //Header
        dvHeader.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/header/cheader.ascx"));
        dvmenu.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/menu/cmenu.ascx"));
        
        // Thêm vào giỏ hàng
        if (Session["WOrderID"] == null)
            Session["WOrderID"] = Guid.NewGuid();

        switch (strShow)
        {            
            case "PRO":
                // Product
                dvProduct.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cProductList.ascx"));
                break;
            case "DPRO":
                // Detail product
                dvProduct.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cProductDetailNew.ascx"));
                break;
            case "ART":
                // blog
                dvProduct.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cArticles.ascx"));
                break;
            case "DART":
                // blog detail
                dvProduct.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cArticleDetail.ascx"));
                break;
            case "CART":
                // cart
                dvProduct.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cOrder.ascx"));
                break;
            case "CATA":
                // company detail
                dvProduct.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cPartnerDetail.ascx"));
                break;
            case "BUY":
                // checkout
                dvProduct.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cCheckoutNew.ascx"));
                break;
            case "CONT":
                // Contact Us
                dvContact.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cContact.ascx"));
                dvBestseller.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cBestseller.ascx"));
                break;
            case "ABOUT":
                // About Us
                dvAbout.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cAbout.ascx"));
                dvBestseller.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cBestseller.ascx"));
                break;
            case "SER":
                // Search
                dvProduct.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cSearch.ascx"));
                break;        
            default:
                //// main home               
                dvSlider.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cSlider.ascx"));
                dvProduct.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/content/cHProducts.ascx"));
                
                break;
        }        
        //Footer        
        dvFooter.Controls.Add(LoadControl(WebConfigurationManager.AppSettings["WebHome"] + "controls/footer/cfooter.ascx"));
    }
   
}