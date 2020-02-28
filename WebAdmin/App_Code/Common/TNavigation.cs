using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TNavigation
/// </summary>
public class TNavigation
{
	public TNavigation()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void EditPage(string page, int pID = 123, string BackPage = "", string BackAct = "")
    {
        PageKeyID.AddKeyID(page, pID);
        HttpContext.Current.Response.Redirect(urlAlter(page, Act.Edit, BackPage, BackAct));
    }

    public static void NewPage(string page, int pID, string BackPage = "", string BackAct = "")
    {
        PageKeyID.AddKeyID(page, pID);
        HttpContext.Current.Response.Redirect(urlAlter(page, Act.New, BackPage, BackAct));
    }

    public static void ClonePage(string page, int pID)
    {
        PageKeyID.AddKeyID(page, pID);
        HttpContext.Current.Response.Redirect(urlAlter(page, Act.Clone));
    }

    public static void BackPage()
    {
        string BackPage = HttpContext.Current.Request.QueryString["BackPage"];
        string BackAct = HttpContext.Current.Request.QueryString["BackAct"];
        if (BackPage !=  null)
        {
            if (BackAct == null)
                HttpContext.Current.Response.Redirect("~/?module=" + BackPage);
            else
            {
                BackAct = "&act=" + BackAct;
                HttpContext.Current.Response.Redirect("~/?module=" + BackPage + BackAct);
            }
        }
        else
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            url = url.Substring(0, url.IndexOf("&act="));
            HttpContext.Current.Response.Redirect(url);
        }
        
    }

    public static string urlAlter(string module, string pAct, string BackPage = "", string BackAct = "")
    {
        if (BackPage != "")
            BackPage = "&BackPage=" + BackPage;
        if (BackAct != "")
            BackAct = "&BackAct=" + BackAct;
        string url = HttpContext.Current.Request.Url.AbsolutePath + "?module=" + module;
        return url + "&act=" + pAct + BackPage + BackAct;
        
    }

    public static string GetControlNavigation(string key)
    {
        string value = string.Empty;
        Int32 module;
        bool result = Int32.TryParse(key, out module);

        if (HttpContext.Current.Session["UCNavigation"] != null && result==true)
        {
            Dictionary<Int32, String> myNav = (Dictionary<Int32, String>)HttpContext.Current.Session["UCNavigation"];
            
            //if (myNav.ContainsKey(key))
            //    value = myNav[key];
            myNav.TryGetValue(module, out value);
        }
        return value;
    }
}



public static class Url
{

    public static string getUrlToSubPage(string currentUrl, string subPage, int ID)
    {
        return currentUrl + "&subPage=" + subPage + "&subPageID=" + ID;
    }
    public static string getBackUrlFromSubPage(string url)
    {
        return url.Substring(0, url.IndexOf("&subPage="));

    }

    public static string getUrlHelp(string module)
    {
        //DAHelp daHelp = new DAHelp();
        //daHelp.USP_Help_GetFullModule(module);

        //try
        //{
        //    int faqcat = daHelp.fHelpID;
        //    return String.Format("admin/PopupHelp.aspx?faqcat={0}", faqcat);
        //}
        //catch
        //{
        //    return String.Format("admin/PopupHelp.aspx?faqcat={0}", 0);
        //}
        return "";
    }
}



