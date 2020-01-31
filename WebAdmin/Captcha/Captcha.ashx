<%@ WebHandler Language="C#" Class="Captcha" %>

using System;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;
using NDL.Framework.Common.Cryptography;
using NDL.Framework.Common.Captcha;
using System.Web.Configuration;
//using System.Web.SessionState;

public class Captcha : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.BufferOutput = false;

        // Get text
        string s = "No Text";
        if (context.Request.QueryString["c"] != null &&
            context.Request.QueryString["c"] != "")
        {
            string enc = context.Request.QueryString["c"].ToString();

            // space was replaced with + to prevent error
            enc = enc.Replace(" ", "+");
            string key = WebConfigurationManager.AppSettings["CaptchaKey"];
            string salt = WebConfigurationManager.AppSettings["CaptchaSalt"];
            try
            {
                if (key == null) key = string.Empty;
                if (salt == null) salt = string.Empty;
                s = Encryptor.Decrypt(enc, key, Convert.FromBase64String(salt));
            }
            catch
            {
                s = "No Text";
            }           
        }
        // Get dimensions
        int w = 120;
        int h = 50;
        // Width
        if (context.Request.QueryString["w"] != null &&
            context.Request.QueryString["w"] != "")
        {
            try
            {
                w = Convert.ToInt32(context.Request.QueryString["w"]);
            }
            catch { }
        }
        // Height
        if (context.Request.QueryString["h"] != null &&
            context.Request.QueryString["h"] != "")
        {
            try
            {
                h = Convert.ToInt32(context.Request.QueryString["h"]);
            }
            catch { }
        }
        // Color
        Color Bc = Color.White;
        if (context.Request.QueryString["bc"] != null &&
            context.Request.QueryString["bc"] != "")
        {
            try
            {
                string bc = context.Request.QueryString["bc"].ToString().Insert(0, "#");
                Bc = ColorTranslator.FromHtml(bc);
            }
            catch { }
        }
        // Generate image
        CaptchaImage ci = new CaptchaImage(s, Bc, w, h);

        // Return
        ci.Image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        // Dispose
        ci.Dispose();
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

}