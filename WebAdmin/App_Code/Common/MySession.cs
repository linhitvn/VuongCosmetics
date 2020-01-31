using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for MySession
/// </summary>
public class MySession
{
    public MySession()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string WebSite
    {
        get
        {
            return MyConfig.GetValueByKey("WebSite");
        }
    }
    public static string UserID
    {
        get
        {
            return MyConfig.GetValueByKey("UserID");
        }
    }
    public static string UserName
    {
        get
        {
            return MyConfig.GetValueByKey("UserName");
        }
    }
    public static string PassWord
    {
        get
        {
            return MyConfig.GetValueByKey("PassWord");
        }
    }
    public static int Level
    {
        get
        {
            try
            {
                return int.Parse(MyConfig.GetValueByKey("Level"));
            }
            catch
            {
                return -1;
            }

        }
    }
    public static string ClockScren
    {
        get
        {
            if (HttpContext.Current.Session["ClockScren"] != null)
                return HttpContext.Current.Session["ClockScren"].ToString();
            else
                return "False";
        }
        set
        {
            HttpContext.Current.Session["ClockScren"] = value;
        }
    }
}

public static class PageKeyID
{
    public static int KeyID(string page)
    {
        Dictionary<string, string> pageKeyID = (Dictionary<string, string>)HttpContext.Current.Session["PageKeyID"];
        if (pageKeyID.ContainsKey(page))
        {
            return int.Parse(pageKeyID[page]);
        }
        else
            return -1;
    }

    public static bool AddKeyID(string page, int KeyID)
    {
        try
        {
            if (HttpContext.Current.Session["PageKeyID"] == null)
                HttpContext.Current.Session["PageKeyID"] = new Dictionary<string, string>();
            Dictionary<string, string> pageKeyID = (Dictionary<string, string>)HttpContext.Current.Session["PageKeyID"];
            if (pageKeyID == null)
                pageKeyID = new Dictionary<string, string>();

            if (pageKeyID.ContainsKey(page))
                pageKeyID[page] = KeyID.ToString();
            else
            {
                pageKeyID.Add(page, KeyID.ToString());
            }

            HttpContext.Current.Session["PageKeyID"] = pageKeyID;

            return true;
        }
        catch
        {
            return false;
        }
    }
}

public static class MyConfig
{
    public static Boolean CheckPermission(String key)
    {
        Boolean value = false;
        key = key.ToUpper();
        Int32 module;
        bool result = Int32.TryParse(key, out module);
        if (HttpContext.Current.Session["UPermission"] != null && result == true)
        {
            Dictionary<Int32, Boolean> myMenu = (Dictionary<Int32, Boolean>)HttpContext.Current.Session["UPermission"];
            if (myMenu.ContainsKey(module))
                value = myMenu[module];
        }
        return value;
    }

    public static string GetValueByKey(string key)
    {
        string value = string.Empty;
        if (HttpContext.Current.Session["USysConfig"] != null)
        {
            Dictionary<string, string> mykey = (Dictionary<string, string>)HttpContext.Current.Session["USysConfig"];
            //if (myNav.ContainsKey(key))
            //    value = myNav[key];
            mykey.TryGetValue(key, out value);
        }
        return value;
    }

    public static Boolean DevMode
    {
        get
        {
            Boolean DevMode = false;
            try
            {
                DevMode = Boolean.Parse(WebConfigurationManager.AppSettings["DevMode"].ToString());
            }
            catch { DevMode = false; }

            return DevMode;
        }
    }

    public static Boolean IsRoleSa
    {
        get
        {
            Boolean IsRoleSa = false;
            try
            {
                IsRoleSa = int.Parse(MyConfig.GetValueByKey("Level")) == 1;
            }
            catch
            {
                IsRoleSa = false;
            }

            return IsRoleSa;
        }
    }
}