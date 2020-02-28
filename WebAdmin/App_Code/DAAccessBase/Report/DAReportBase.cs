using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
using NDL.Framework.MSSQL;

public class DAReportBase : TDatabase
{
    public Int32 fID;
    public String fMenuName;
    public String fDescription;
    public Boolean fActive;

    public DAReportBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Report";
        mKeyName = "ID";
    }

}
public partial class DAReport : DAReportBase
{
    public SqlDataReader USP_Report_DashBoard()
    {
        mCmd.CommandText = "USP_Report_DashBoard";
        mCmd.Parameters.Clear();
        ExecuteReader();

        return mDataReader;
    }
}
