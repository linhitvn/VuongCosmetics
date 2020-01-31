using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.IO;
using Excel;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections;

public partial class Pages_Product_cImportExport : TUserControlForList
{
    DAProducer tData = new DAProducer();
    override protected Boolean SetServerControl()
    {
        try
        {
            this.messBox = message_box;
        }
        catch
        {
            return false;
        }

        return true;
    }
    /// <summary>
    /// Import Product
    /// - Read File Excel
    /// - Insert to database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Import_Click(object sender, EventArgs e)
    {
        List<DAProductBase> products = new List<DAProductBase>();
        List<DAProductProductCatBase> productCats = new List<DAProductProductCatBase>();
        //readExcelFile(ref products);
    }

    protected void readExcelFile(string fileName)
    {
        List<DAProductBase> products = new List<DAProductBase>();
        DataSet dataSet = new DataSet();
        FileStream stream;
        //try
        //{
            string filepath = Server.MapPath(fileName);
            stream = File.Open(filepath, FileMode.Open, FileAccess.Read);
        //}
        //catch (Exception e) { return; }
        

        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        excelReader.IsFirstRowAsColumnNames = true;
        dataSet = excelReader.AsDataSet();
        int rowNo = 0;
        //Get sheet danh sach san pham
        DataTable productSheet = dataSet.Tables[0];
        while (rowNo < productSheet.Rows.Count)
        {
            DataRow dataRow = productSheet.Rows[rowNo];
            if (getStringCellValue(dataRow, EnumProduct.fProductName) == String.Empty)
            {
                break;
            }
            //Get product data from sheet
            products.Add(new DAProductBase()
            {
                //fID = USP_GetKey(),
                fProductName = getStringCellValue(dataRow, EnumProduct.fProductName),
                fDescription = getStringCellValue(dataRow, EnumProduct.fDescription),
                fProductCode = getStringCellValue(dataRow, EnumProduct.fProductCode),
                fUnitName = getStringCellValue(dataRow, EnumProduct.fUnitName),
                fProducerID = getIntCellValue(dataRow, EnumProduct.fProducerID),
                fPrice = getIntCellValue(dataRow, EnumProduct.fPrice),
                fSalePrice = getIntCellValue(dataRow, EnumProduct.fSalePrice),
                fSchSalePrice = getIntCellValue(dataRow, EnumProduct.fSchSalePrice),
                fScheSaleFrom = DateTime.Now,//Convert.ToDateTime(dataRow[EnumProduct.fProductCode].ToString()),
                fScheSaleTo = DateTime.Now,//Convert.ToDateTime(dataRow[EnumProduct.fProductCode].ToString()),
                fVATID = getIntCellValue(dataRow, EnumProduct.fVATID),
                fThumbLink = String.Empty,//dataRow[EnumProduct.fThumbLink].ToString(),
                fImgLink1 = String.Empty,//dataRow[EnumProduct.fImgLink1].ToString(),
                fImgLink2 = String.Empty,//dataRow[EnumProduct.fImgLink2].ToString(),
                fImgLink3 = String.Empty,//dataRow[EnumProduct.fImgLink3].ToString(),
                fImgLink4 = String.Empty,//dataRow[EnumProduct.fImgLink4].ToString(),
                fImgLink5 = String.Empty,//dataRow[EnumProduct.fImgLink5].ToString(),
                fIsManagerQuantity = getYesNoCellValue(dataRow, EnumProduct.fProductCode),
                fQuantity = getIntCellValue(dataRow, EnumProduct.fQuantity),
                fNumSaled = getIntCellValue(dataRow, EnumProduct.fNumSaled),
                fRewriteURL = getStringCellValue(dataRow, EnumProduct.fRewriteURL),
                fPageTitle = getStringCellValue(dataRow, EnumProduct.fPageTitle),
                fMetaTitle = getStringCellValue(dataRow, EnumProduct.fMetaTitle),
                fMetaDescription = getStringCellValue(dataRow, EnumProduct.fMetaDescription),
                fMetaKeywords = getStringCellValue(dataRow, EnumProduct.fMetaKeywords),
                fTags = getStringCellValue(dataRow, EnumProduct.fTags),
                fDesShort = getStringCellValue(dataRow, EnumProduct.fDesShort),
                fDesBeforPrice = getStringCellValue(dataRow, EnumProduct.fDesBeforPrice),
                fDesAfterPrice = getStringCellValue(dataRow, EnumProduct.fDesAfterPrice),
                fIsNewProduct = getYesNoCellValue(dataRow, EnumProduct.fIsNewProduct),
                fIsShow = getYesNoCellValue(dataRow, EnumProduct.fIsShow),
                fIsHiddenWhenOutoff = getYesNoCellValue(dataRow, EnumProduct.fIsHiddenWhenOutoff),
                fIsShowYouSaving = getYesNoCellValue(dataRow, EnumProduct.fIsShowYouSaving),
                fBuyButtonText = getStringCellValue(dataRow, EnumProduct.fBuyButtonText),
                fShowInProductTyleID = getIntCellValue(dataRow, EnumProduct.fShowInProductTyleID),
                fMinOrder = getIntCellValue(dataRow, EnumProduct.fMinOrder),
                fMaxForWarrning = getIntCellValue(dataRow, EnumProduct.fMaxForWarrning),
                fBonusPoint = getIntCellValue(dataRow, EnumProduct.fBonusPoint),
                fIsAllowComment = getYesNoCellValue(dataRow, EnumProduct.fIsAllowComment),
                fPos = getIntCellValue(dataRow, EnumProduct.fPos),
                fSysDate = DateTime.Now,
                fOperator = MySession.UserName,
                fProductCats = "," + getIntCellValue(dataRow, EnumProduct.fProductCatID1)
                     + "," + getIntCellValue(dataRow, EnumProduct.fProductCatID2)
                     + "," + getIntCellValue(dataRow, EnumProduct.fProductCatID3)
                     + "," + getIntCellValue(dataRow, EnumProduct.fProductCatID4)
                     + "," + getIntCellValue(dataRow, EnumProduct.fProductCatID5) + ","
            });
            rowNo++;
        }
        excelReader.Close();
        saveProductListToDatabase(products);
    }

    private int getIntCellValue(DataRow dataRow, string row)
    {
        int value = 0;
        string cellValue = dataRow[row].ToString();
        if (Int32.TryParse(cellValue, out value) == false) {
            value = 0;
        }
        return value;
    }

    private string getStringCellValue(DataRow dataRow, string row)
    {
        return dataRow[row].ToString();
    }

    private bool getYesNoCellValue(DataRow dataRow, string row)
    {
        bool value = false;
        if (dataRow[row].ToString() == Constain.YES)
        {
            value = true;
        }
        return value;
    }

    private void saveProductListToDatabase(List<DAProductBase> productList)
    {
        //Utils.showErrorAlert(Page.ClientScript, this.GetType(), "Folder giao diện này hiện không tồn tại!");
        DAProductProductCat daProductProductCat = new DAProductProductCat();
        foreach (DAProductBase daProduct in productList) {
            daProduct.fID = daProduct.USP_GetKey();
            daProduct.USP_Product_Insert();
            daProductProductCat.USP_ProductProductCat_UpdateCustom(daProduct.fID, daProduct.fProductCats);
        }
    }

    protected void onUploadExcelFile(object sender, EventArgs e)
    {
        string fileName = String.Empty;
        HttpPostedFile file = fileUpload.PostedFile;
        
        if (file != null && file.ContentLength > 0)
        {
            String fileExtension = Path.GetExtension(file.FileName).ToLower();
            ArrayList allowedExtensions = new ArrayList { ".xlsx", ".xls" };
            if (allowedExtensions.Contains(fileExtension))
            {
                fileName = Utils.UploadImage(file, Server, "~/Media/Product");
            }
            else
            {
                ShowErrorMes("File không hợp lệ");
            }
            
        }
        if (fileName != String.Empty)
        {
            fileName = "~" + fileName;
            readExcelFile(fileName);
        }
    }
    protected void DownloadTemplate(object sender, EventArgs e)
    {
        //Utils.showErrorAlert(Page.ClientScript, this.GetType(), "Folder giao diện này hiện không tồn tại!");
        CreateTemplate();
        Response.ContentType = "APPLICATION/OCTET-STREAM";
        String Header = "Attachment; Filename=template.xlsx";
        Response.AppendHeader("Content-Disposition", Header);
        System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath("Media/Demo/Excel/templatev1.0.xlsx"));
        Response.WriteFile(Dfile.FullName);
        //Don't forget to add the following line
        Response.End();
    }

    private void CreateTemplate()
    {
        // change this line to contain the path to the output folder
        DirectoryInfo outputDir = new DirectoryInfo(@"c:\");
        if (!outputDir.Exists) throw new Exception("outputDir does not exist!");

        FileInfo newFile = new FileInfo(Server.MapPath("Media/Demo/Excel/templatev1.0.xlsx"));
        if (newFile.Exists)
        {
            newFile.Delete();  // ensures we create a new workbook
            newFile = new FileInfo(Server.MapPath("Media/Demo/Excel/templatev1.0.xlsx"));
        }

        using (ExcelPackage package = new ExcelPackage(newFile))
        {
            // add a new worksheet to the empty workbook
            ExcelWorksheet workSheet = package.Workbook.Worksheets.Add(EnumProduct.productSheet);
            ExcelWorksheet categorySheet = package.Workbook.Worksheets.Add(EnumProduct.productCatSheet);
            ExcelWorksheet producerSheet = package.Workbook.Worksheets.Add(EnumProduct.producerSheet);
            ExcelWorksheet VATSheet = package.Workbook.Worksheets.Add(EnumProduct.VATSheet);

            //Add the headers
            ArrayList headers = new ArrayList{
                EnumProduct.fProductName,
                EnumProduct.fDescription,
                EnumProduct.fProductCode,
                EnumProduct.fUnitName,
                //EnumProduct.fUnitID,
                EnumProduct.fProducer,
                EnumProduct.fProducerID,
                EnumProduct.fPrice,
                EnumProduct.fSalePrice,
                EnumProduct.fSchSalePrice,
                //EnumProduct.fScheSaleFrom,
                //EnumProduct.fScheSaleTo,
                EnumProduct.fVAT,
                EnumProduct.fVATID,
                //EnumProduct.fImgLink1,
                //EnumProduct.fImgLink2,
                //EnumProduct.fImgLink3,
                //EnumProduct.fImgLink4,
                //EnumProduct.fImgLink5,
                EnumProduct.fProductCat1,
                EnumProduct.fProductCatID1,
                EnumProduct.fProductCat2,
                EnumProduct.fProductCatID2,
                EnumProduct.fProductCat3,
                EnumProduct.fProductCatID3,
                EnumProduct.fProductCat4,
                EnumProduct.fProductCatID4,
                EnumProduct.fProductCat5,
                EnumProduct.fProductCatID5,
                EnumProduct.fIsManagerQuantity,
                EnumProduct.fQuantity,
                EnumProduct.fNumSaled,
                EnumProduct.fRewriteURL,
                EnumProduct.fPageTitle,
                EnumProduct.fMetaTitle,
                EnumProduct.fMetaDescription,
                EnumProduct.fMetaKeywords,
                EnumProduct.fTags,
                EnumProduct.fDesShort,
                EnumProduct.fDesBeforPrice,
                EnumProduct.fDesAfterPrice,
                EnumProduct.fIsNewProduct,
                EnumProduct.fIsShow,
                EnumProduct.fIsHiddenWhenOutoff,
                EnumProduct.fIsShowYouSaving,
                EnumProduct.fBuyButtonText,
                EnumProduct.fShowInProductTyleID,
                EnumProduct.fMinOrder,
                EnumProduct.fMaxForWarrning,
                EnumProduct.fBonusPoint,
                EnumProduct.fPos,
                EnumProduct.fIsAllowComment
            };

            for (int j = 0; j < headers.Count; j++)
                workSheet.Cells[1, j + 1].Value = headers[j];

            //get the categories
            DAProductCat producCat = new DAProductCat();
            List<DAProductCat> productCats = producCat.USP_ProductCat_GetList(0, 0);
            //add category to Category sheet
            int i = 1;
            foreach (DAProductCat productCat in productCats)
            {
                categorySheet.Cells["A" + i].Value = productCat.fProductCat;
                categorySheet.Cells["B" + i].Value = productCat.fID;
                i++;
            }
            //set category to main sheet
            setSelectListCell(workSheet, headers, EnumProduct.productCatSheet, EnumProduct.fProductCat1, EnumProduct.fProductCatID1, productCats.Count);
            setSelectListCell(workSheet, headers, EnumProduct.productCatSheet, EnumProduct.fProductCat2, EnumProduct.fProductCatID2, productCats.Count);
            setSelectListCell(workSheet, headers, EnumProduct.productCatSheet, EnumProduct.fProductCat3, EnumProduct.fProductCatID3, productCats.Count);
            setSelectListCell(workSheet, headers, EnumProduct.productCatSheet, EnumProduct.fProductCat4, EnumProduct.fProductCatID4, productCats.Count);
            setSelectListCell(workSheet, headers, EnumProduct.productCatSheet, EnumProduct.fProductCat5, EnumProduct.fProductCatID5, productCats.Count);

            //get list producer
            DAProducer daProducer = new DAProducer();
            List<DAProducer> producers = daProducer.USP_Producer_GetList(0, 0);
            //add producer to 'Nhà sàn xuất' sheet
            i = 1;
            foreach (DAProducer producer in producers)
            {
                producerSheet.Cells["A" + i].Value = producer.fProducerName;
                producerSheet.Cells["B" + i].Value = producer.fID;
                i++;
            }
            //set producer to main sheet
            setSelectListCell(workSheet, headers, EnumProduct.producerSheet, EnumProduct.fProducer, EnumProduct.fProducerID, producers.Count);

            //get list VAT
            DAVAT daVAT = new DAVAT();
            List<DAVAT> VATs = daVAT.USP_VAT_GetList(0, 0);
            //add VAT to 'Thuế' sheet
            i = 1;
            foreach (DAVAT VAT in VATs)
            {
                VATSheet.Cells["A" + i].Value = VAT.fVATName;
                VATSheet.Cells["B" + i].Value = VAT.fID;
                i++;
            }
            //set VAT to main sheet
            setSelectListCell(workSheet, headers, EnumProduct.VATSheet, EnumProduct.fVAT, EnumProduct.fVATID, producers.Count);

            //set checkbox sheet
            setYesNoCell(workSheet, headers, EnumProduct.fIsManagerQuantity);
            setYesNoCell(workSheet, headers, EnumProduct.fIsNewProduct);
            setYesNoCell(workSheet, headers, EnumProduct.fIsShow);
            setYesNoCell(workSheet, headers, EnumProduct.fIsHiddenWhenOutoff);
            setYesNoCell(workSheet, headers, EnumProduct.fIsShowYouSaving);
            setYesNoCell(workSheet, headers, EnumProduct.fIsAllowComment);

            //set Data format cell
            //setDatetimeCell(workSheet, headers, EnumProduct.fScheSaleFrom);
            //setDatetimeCell(workSheet, headers, EnumProduct.fScheSaleTo);

            //set style
            workSheet.Cells["A1:AR100"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            workSheet.Cells["A1:AR100"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            workSheet.Cells["A1:AR100"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            workSheet.Cells["A1:AR100"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            var range = workSheet.Cells["A1:AR100"];
            var table = workSheet.Tables.Add(range, "tablename");
            table.TableStyle = TableStyles.Medium9;
            workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();

            //set sheet property

            // set some document properties
            package.Workbook.Properties.Title = "Danh sách sản phẩm";
            package.Workbook.Properties.Author = "Tuan Anh";
            package.Workbook.Properties.Comments = "This sample demonstrates how to create an Excel 2007 workbook using EPPlus";

            // set some extended property values
            package.Workbook.Properties.Company = "TMA Solutions";

            // set some custom property values
            package.Workbook.Properties.SetCustomPropertyValue("Checked by", "Jan Källman");
            package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");
            // save our new workbook and we are done!

            //Hide id columns 
            workSheet.Column((headers.IndexOf(EnumProduct.fProducerID) + 1)).Hidden = true;
            workSheet.Column((headers.IndexOf(EnumProduct.fVATID) + 1)).Hidden = true;
            workSheet.Column((headers.IndexOf(EnumProduct.fProductCatID1) + 1)).Hidden = true;
            workSheet.Column((headers.IndexOf(EnumProduct.fProductCatID2) + 1)).Hidden = true;
            workSheet.Column((headers.IndexOf(EnumProduct.fProductCatID3) + 1)).Hidden = true;
            workSheet.Column((headers.IndexOf(EnumProduct.fProductCatID4) + 1)).Hidden = true;
            workSheet.Column((headers.IndexOf(EnumProduct.fProductCatID5) + 1)).Hidden = true;

            //Hide other sheet except main sheet
            categorySheet.Hidden = eWorkSheetHidden.Hidden;
            producerSheet.Hidden = eWorkSheetHidden.Hidden;
            VATSheet.Hidden = eWorkSheetHidden.Hidden;

            package.Save();
        }
    }

    private void setDatetimeCell(ExcelWorksheet workSheet, ArrayList headers, string cellName)
    {
        int maxRow = Constain.MAX_EXCEL_ROW;
        int cellIndex = headers.IndexOf(cellName) + 1;
        string cellAddress = new ExcelAddress(2, cellIndex, maxRow, cellIndex).ToString();
        workSheet.Cells[cellAddress].Value = "=Date(" + DateTime.Now + ")"; 
        workSheet.Cells[cellAddress].Style.Numberformat.Format = "dd/mm/yyyy";
    }

    private void setYesNoCell(ExcelWorksheet workSheet, ArrayList headers, string cellName)
    {
        int maxRow = Constain.MAX_EXCEL_ROW;
        int cellIndex = headers.IndexOf(cellName) + 1;
        var valueList = workSheet.DataValidations.AddListValidation(new ExcelAddress(2, cellIndex, maxRow, cellIndex).ToString());
        valueList.ShowErrorMessage = true;
        valueList.ErrorTitle = "Giá trị không hợp lệ";
        valueList.Error = "Vui lòng chọn trong danh sách!";
        valueList.Formula.Values.Add(Constain.YES);
        valueList.Formula.Values.Add(Constain.NO);
    }

    private void setSelectListCell(ExcelWorksheet workSheet, ArrayList headers, string dataSheet, string cellName, string cellId, int numCat)
    {
        int maxRow = Constain.MAX_EXCEL_ROW;
        int cellIndex = headers.IndexOf(cellName) + 1;
        int cellIdIndex = headers.IndexOf(cellId) + 1;
        string cellAddress = new ExcelAddress(2, cellIndex, maxRow, cellIndex).ToString();
        string cellIdAddress = new ExcelAddress(2, cellIdIndex, maxRow, cellIdIndex).ToString();
        string firstCell = new ExcelAddress(2, cellIndex, 2, cellIndex).ToString();
        var valueList = workSheet.DataValidations.AddListValidation(cellAddress);
        valueList.Formula.ExcelFormula = "'" + dataSheet + "'!$A$1:$A$" + numCat;
        valueList.ShowErrorMessage = true;
        valueList.Error = "Vui lòng chọn trong danh sách!";
        workSheet.Cells[cellIdAddress].Formula = "IF(" + firstCell + "=\"\",\"\",VLOOKUP(" + firstCell + ",'" + dataSheet + "'!$A$1:$B$" + numCat + ",2,0))";
    }
}