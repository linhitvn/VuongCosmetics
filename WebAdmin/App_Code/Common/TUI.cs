using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TUI
/// </summary>
public class TUI
{
    public static string NotiFiFormat(TUIMesCode code, string message)
    {
        string cssStyle = "";
        if (code == TUIMesCode.Error)
        {
            cssStyle = " style='color: red;'";
        }

        string html = "<div " + cssStyle + " class='alert alert-info'>";
        html += message + "<button data-dismiss='alert' class='close'>×</button>";
        html += "</div>";
        return html;
    }

    public static FileType GetFileType(string fileUrl)
    {
        try
        {
            string[] file = new string[2];
            file = fileUrl.Split('.');
            if (file[1] == "pdf")
                return FileType.pdf;
            else if (file[1] == "doc")
                return FileType.doc;
            else if (file[1] == "docx")
                return FileType.docx;
            else if (file[1] == "xls")
                return FileType.xls;
            else if (file[1] == "xlsx")
                return FileType.xlsx;
            else
                return FileType.other;
        }
        catch
        {
            return FileType.other;
        }
    }

    public static string GetLinkTypeFile(string fileUrl)
    {
        FileType fileType = GetFileType(fileUrl);
        switch (fileType)
        {
            case FileType.doc:
            case FileType.docx:
                return "/images/docFileType.png";
            case FileType.pdf:
                return "/images/pdfFileType.png";
            case FileType.xls:
            case FileType.xlsx:
                return "/images/ExcelFileType.jpg";
            default:
                return "/images/DefaultFileType.jpg";
        }
    }
}

public enum TUIMesCode
{
    Success = 0,
    Error = -1
}

public enum FileType{
    doc = 0,
    docx = 1,
    pdf = 2, 
    xls = 3,
    xlsx = 4,
    other = 10

}