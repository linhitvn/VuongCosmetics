using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Telerik.Web.UI;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;
using NDL.Framework.Common;
using System.Web.UI;
using System.Net.Mail;

/// <summary>
/// Summary description for Utils
/// </summary>
public static class Utils
{
    public static string CreateUniqueFileName(string extension)
    {
        string fileName = Guid.NewGuid().ToString("N");
        fileName = fileName + extension;
        return fileName;
    }
    public static string CreateOrderNumber(string iOrder)
    {
        string orderNum = "00000" + iOrder;        
        return "VC" + DateTime.Now.Year.ToString().Substring(2,2) + "-" + orderNum.Substring(orderNum.Length-6,6);
    }
    public static void getDateFromReservation(String reservation, out DateTime date1, out DateTime date2)
    {
        reservation = reservation.Trim();
        string[] sDate = reservation.Split('-');
        date1 = DateTime.ParseExact(sDate[0].Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
        date2 = DateTime.ParseExact(sDate[1].Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
        date2 = date2.AddDays(1);
    }
    
    public static void UploadImageCustomFolder(Image fImage, RadAsyncUpload radAsyncUpload, HttpServerUtility Server, String UploadFolder)
    {
        string fileName = string.Empty;
        string uploadFolderMap = Server.MapPath(UploadFolder);
        foreach (UploadedFile file in radAsyncUpload.UploadedFiles)
        {
            DirectoryInfo ObjSearchDir = new DirectoryInfo(uploadFolderMap);

            if (!ObjSearchDir.Exists)
            {
                ObjSearchDir.Create();
            }
            fileName = file.GetNameWithoutExtension();
            fileName = convertToUnSign2(fileName);
            fileName = Regex.Replace(fileName, "[^a-zA-Z0-9_-]+", "-") + file.GetExtension();

            if (File.Exists((UploadFolder + "/" + fileName)))
                DeleteFile(UploadFolder + "/" + fileName, Server);

            //string newFileName = CreateUniqueFileName(file.GetExtension());
            //while (File.Exists((UploadFolder + "/" + newFileName)))
            //{
            //    newFileName = CreateUniqueFileName(file.GetExtension());
            //}
            file.SaveAs(Path.Combine(uploadFolderMap, fileName));
            fImage.ImageUrl = UploadFolder + "/" + fileName;
        }
    }

    public static string UploadImage(HttpPostedFile file, HttpServerUtility Server, String uploadFolder)
    {
        string fileName = string.Empty;
        string uploadFolderMap = Server.MapPath(uploadFolder);

        //check file was submitted
        if (file != null && file.ContentLength > 0)
        {
            DirectoryInfo ObjSearchDir = new DirectoryInfo(uploadFolderMap);
            if (!ObjSearchDir.Exists)
            {
                ObjSearchDir.Create();
            }
            fileName = CreateUniqueFileName(Path.GetExtension(file.FileName));
            while (File.Exists(fileName))
            {
                fileName = CreateUniqueFileName(Path.GetExtension(file.FileName));
            }
            try
            {
                file.SaveAs(Path.Combine(uploadFolderMap, fileName));
                fileName = uploadFolder.Replace("~", "") + "/" + fileName;
            }
            catch
            {
            }

        }

        return fileName;
    }

    public static string UploadFile(RadAsyncUpload radAsyncUpload, HttpServerUtility Server, String UploadFolder)
    {
        string fileName = string.Empty;
        string uploadFolderMap = Server.MapPath(UploadFolder);

        //check file was submitted
        foreach (UploadedFile file in radAsyncUpload.UploadedFiles)
        {
            DirectoryInfo ObjSearchDir = new DirectoryInfo(uploadFolderMap);
            if (!ObjSearchDir.Exists)
            {
                ObjSearchDir.Create();
            }
            fileName = file.GetNameWithoutExtension();
            fileName = convertToUnSign2(fileName);
            fileName = Regex.Replace(fileName, "[^a-zA-Z0-9_-]+", "-") + file.GetExtension();

            try
            {
                if (File.Exists((UploadFolder + "/" + fileName)))
                    DeleteFile(UploadFolder + "/" + fileName, Server);

                file.SaveAs(Path.Combine(uploadFolderMap, fileName));
                fileName = UploadFolder.Replace("~", "") + "/" + fileName;
            }
            catch
            {
                return "";
            }
        }

        return fileName;
    }

    //public static string createThumbnail(string imagePath, HttpServerUtility Server)
    //{
    //    string fileName = string.Empty;
    //    string uploadFolder = "~/Media/" + MySession.WebSite + "/Images/Thumbnail";
    //    string uploadFolderMap = Server.MapPath(uploadFolder);
    //    imagePath = Server.MapPath(imagePath);
    //    if (File.Exists(imagePath))
    //    {
    //        fileName = System.IO.Path.GetFileName(imagePath);
    //        DirectoryInfo ObjSearchDir = new DirectoryInfo(uploadFolderMap);
    //        if (!ObjSearchDir.Exists)
    //        {
    //            ObjSearchDir.Create();
    //        }
    //        try
    //        {
    //            System.Drawing.Image imgThumb = System.Drawing.Image.FromFile(imagePath);
    //            imgThumb = imgThumb.GetThumbnailImage(150, 150, null, IntPtr.Zero);
    //            imgThumb.Save(Path.Combine(uploadFolder, fileName));
    //            fileName = uploadFolder.Replace("~", "") + "/" + fileName;
    //        }
    //        catch (Exception ex)
    //        {
    //            int a = 1;
    //        }
    //    }
    //    return fileName;
    //}

    //public static void UploadFile(Image fImage, RadAsyncUpload radAsyncUpload, HttpServerUtility Server)
    //{
    //    string uploadFolder = "~/Media/" + MySession.WebSite + "/Files";
    //    string uploadFolderMap = Server.MapPath(uploadFolder);
    //    foreach (UploadedFile file in radAsyncUpload.UploadedFiles)
    //    {
    //        DirectoryInfo ObjSearchDir = new DirectoryInfo(uploadFolderMap);

    //        if (!ObjSearchDir.Exists)
    //        {
    //            ObjSearchDir.Create();
    //        }
    //        string newFileName = CreateUniqueFileName(file.GetExtension());
    //        while (File.Exists(newFileName))
    //        {
    //            newFileName = CreateUniqueFileName(file.GetExtension());
    //        }
    //        file.SaveAs(Path.Combine(uploadFolderMap, newFileName));
    //        fImage.ImageUrl = uploadFolder + "/" + newFileName;
    //    }
    //}

    public static bool DeleteFile(List<string> paths, HttpServerUtility Server)
    {
        foreach (string path in paths)
        {
            string fullPath = Server.MapPath(('~' + path));
            if (path != "" && File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
        return true;
    }

    public static bool DeleteFile(string path, HttpServerUtility Server)
    {

        string fullPath = Server.MapPath(path);
        if (path != "" && File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        return true;
    }

    public static void CheckAndCreateFolder(string uploadFolder)
    {
        string uploadFolderMap = HttpContext.Current.Server.MapPath(uploadFolder);
        DirectoryInfo ObjSearchDir = new DirectoryInfo(uploadFolderMap);

        if (!ObjSearchDir.Exists)
        {
            ObjSearchDir.Create();
        }
    }

    public static string FuncParam()
    {
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        int pos = url.IndexOf("?");
        if (pos > 0)
        {
            return url.Substring(pos, url.Length - pos);
        }
        else
        {
            return "";
        }
    }

    public static bool RemoveImageFile(string path, HttpServerUtility Server)
    {
        string fullPath = Server.MapPath((path));
        if (path != "" && File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
        return true;
    }

    public static bool CheckReg(string Rules, string value)
    {
        //string Rules = @"^(([0-9]|[A-F]|[a-f]){12}$)";
        Regex MyRegex = new Regex(Rules);
        return MyRegex.IsMatch(value);
    }

    //Utils.showErrorAlert(Page.ClientScript, this.GetType(), "Folder giao diện này hiện không tồn tại!");
    public static void showErrorAlert(ClientScriptManager clientScript, Type type, string message)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload=function(){");
        sb.Append("alert('");
        sb.Append(message);
        sb.Append("')};");
        sb.Append("</script>");
        clientScript.RegisterClientScriptBlock(type, "alert", sb.ToString());
    }

    public static string ConvertToUnsign1(string str)
    {
        string[] signs = new string[] {
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
        };
        for (int i = 1; i < signs.Length; i++)
        {
            for (int j = 0; j < signs[i].Length; j++)
            {
                str = str.Replace(signs[i][j], signs[0][i - 1]);
            }
        }
        return str;
    }
    public static string convertToUnSign2(string s)
    {
        string stFormD = s.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
        for (int ich = 0; ich < stFormD.Length; ich++)
        {
            System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
            if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                sb.Append(stFormD[ich]);
            }
        }
        sb = sb.Replace('Đ', 'D');
        sb = sb.Replace('đ', 'd');
        return (sb.ToString().Normalize(NormalizationForm.FormD));
    }

    public static DateTime ConvertDateTime(string date)
    {
        DateTime dt = Convert.ToDateTime("1900-01-01");

        if (Utilities.IsNumeric(date))
        {
            dt = DateTime.FromOADate(double.Parse(date));
        }
        else
        {
            DateTime.TryParse(date, out dt);
        }

        return dt; // DateTime.FromOADate(double.Parse(date));
    }

    public static bool CheckDate(String date)
    {
        try
        {
            DateTime dt = DateTime.Parse(date);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static string WarrningHtml(string pMes)
    {
        if (pMes == null)
            return "";
        string html = "<div class='alert alert-warning alert-dismissable'>"
            + "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>"
            + "<h4><i class='icon fa fa-warning'></i> Thông báo!</h4>" + pMes + "</div>";
        return html;
    }
    public static string SuccessHtml(string pMes)
    {
        if (pMes == null)
            return "";
        string html = "<div class='alert alert-success alert-dismissable'>"
            + "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>"
            + "<h4><i class='icon fa fa-check'></i> Thông báo!</h4>" + pMes + "</div>";
        return html;
    }
    public static bool SendMail(string sFromEmail, string sPassEmail, string sInCommingEmail, string sToEmail, string ccToMail, string title, string body)
    {
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(sToEmail);
        if (!string.IsNullOrEmpty(ccToMail))
            mail.Bcc.Add(ccToMail);
       
        mail.From = new MailAddress(sFromEmail, "The Vuong's Cosmetics", System.Text.Encoding.UTF8);
        mail.Subject = title;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = body;
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential(sFromEmail, sPassEmail);
        client.Port = 25;
        client.Host = sInCommingEmail;
        client.EnableSsl = false;
        try
        {
            client.Send(mail);
            //Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            return true;
        }
        catch
        {
            return false;
            //Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
        }
    }
}