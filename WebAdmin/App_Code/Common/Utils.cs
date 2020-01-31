using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Telerik.Web.UI;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

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

    //public static void UploadImage(Image fImage, RadAsyncUpload radAsyncUpload, HttpServerUtility Server, bool isThumb = false)
    //{
    //    string uploadFolder = "~/Media/"+MySession.WebSite+"/Images";
    //    string uploadFolderMap = Server.MapPath(uploadFolder);
    //    string filePath = string.Empty;
    //    foreach (UploadedFile file in radAsyncUpload.UploadedFiles)
    //    {
    //        DirectoryInfo ObjSearchDir = new DirectoryInfo(uploadFolderMap);
    //        DirectoryInfo ObjThumbDir = new DirectoryInfo(uploadFolderMap + "/" + "thumb");
    //        if (!ObjSearchDir.Exists)
    //        {
    //            ObjSearchDir.Create();
    //        }
    //        //thumb folder
    //        if (!ObjThumbDir.Exists)
    //        {
    //            ObjThumbDir.Create();
    //        }
    //        string newFileName = CreateUniqueFileName(file.GetExtension());
    //        while (File.Exists((uploadFolder + "/" + newFileName)))
    //        {
    //            newFileName = CreateUniqueFileName(file.GetExtension());
    //        }
    //        try
    //        {
    //            filePath = Path.Combine(uploadFolderMap, newFileName);
    //            file.SaveAs(Path.Combine(uploadFolderMap, newFileName));
    //            fImage.ImageUrl = uploadFolder + "/" + newFileName;
    //            //save thumbnail
    //            //string fileNameThumb = 
    //            if (isThumb)
    //            {
    //                System.Drawing.Image imgThumb = System.Drawing.Image.FromFile(filePath);
    //                System.Drawing.Image thumb = imgThumb.GetThumbnailImage(150, 150, null, IntPtr.Zero);
    //                thumb.Save(Path.Combine(Path.Combine(uploadFolderMap + "/" + "thumb", newFileName)));
    //                //fThumbLinkUrl = uploadFolder + "/thumb/" + newFileName;
    //            }
    //        }
    //        catch { }
    //    }
    //}


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
            catch (Exception ex) {
            }
            
        }

        return fileName;
    }

    //public static string UploadFile(HttpPostedFile file, HttpServerUtility Server)
    //{
    //    string fileName = string.Empty;
    //    string uploadFolder = "~/Media/" + MySession.WebSite + "/Files";
    //    string uploadFolderMap = Server.MapPath(uploadFolder);

    //    //check file was submitted
    //    if (file != null && file.ContentLength > 0)
    //    {
    //        DirectoryInfo ObjSearchDir = new DirectoryInfo(uploadFolderMap);
    //        if (!ObjSearchDir.Exists)
    //        {
    //            ObjSearchDir.Create();
    //        }
    //        fileName = file.FileName;
    //        try
    //        {
    //            file.SaveAs(Path.Combine(uploadFolderMap, fileName));
    //            fileName = uploadFolder.Replace("~", "") + "/" + fileName;
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //    return fileName;
    //}

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
        foreach(string path in paths)
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

}
