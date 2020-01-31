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

public class DAControlBase : TDatabase
{
    public Int32 fID;
    public String fControlName;
    public Int32 fPageID;
    public Int32 fParentID;
    public String fUControl;
    public String fParam;
    public Boolean fIsAdsControl;
    public Int32 fPos;
    public Boolean fActive;
    public String fOperator;

    public DAControlBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Control";
        mKeyName = "ID";
    }
    public int USP_Control_Insert()
    {
        mCmd.CommandText = "USP_Control_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ControlName", SqlDbType.NVarChar).Value = fControlName;
        mCmd.Parameters.Add("@PageID", SqlDbType.Int).Value = fPageID;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@UControl", SqlDbType.NVarChar).Value = fUControl;
        mCmd.Parameters.Add("@Param", SqlDbType.VarChar).Value = fParam;
        mCmd.Parameters.Add("@IsAdsControl", SqlDbType.Bit).Value = fIsAdsControl;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;

        return Execute();
    }
    public int USP_Control_Insert(Int32 ID, String ControlName, Int32 PageID, Int32 ParentID, String UControl, String Param, Boolean IsAdsControl, Int32 Pos, Boolean Active, String Operator)
    {
        mCmd.CommandText = "USP_Control_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ControlName", SqlDbType.NVarChar).Value = ControlName;
        mCmd.Parameters.Add("@PageID", SqlDbType.Int).Value = PageID;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@UControl", SqlDbType.NVarChar).Value = UControl;
        mCmd.Parameters.Add("@Param", SqlDbType.VarChar).Value = Param;
        mCmd.Parameters.Add("@IsAdsControl", SqlDbType.Bit).Value = IsAdsControl;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = Operator;

        return Execute();
    }

    public int USP_Control_Update()
    {
        mCmd.CommandText = "USP_Control_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ControlName", SqlDbType.NVarChar).Value = fControlName;
        mCmd.Parameters.Add("@PageID", SqlDbType.Int).Value = fPageID;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@UControl", SqlDbType.NVarChar).Value = fUControl;
        mCmd.Parameters.Add("@Param", SqlDbType.VarChar).Value = fParam;
        mCmd.Parameters.Add("@IsAdsControl", SqlDbType.Bit).Value = fIsAdsControl;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = fOperator;

        return Execute();
    }
    public int USP_Control_Update(Int32 ID, String ControlName, Int32 PageID, Int32 ParentID, String UControl, String Param, Boolean IsAdsControl, Int32 Pos, Boolean Active, String Operator)
    {
        mCmd.CommandText = "USP_Control_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ControlName", SqlDbType.NVarChar).Value = ControlName;
        mCmd.Parameters.Add("@PageID", SqlDbType.Int).Value = PageID;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@UControl", SqlDbType.NVarChar).Value = UControl;
        mCmd.Parameters.Add("@Param", SqlDbType.VarChar).Value = Param;
        mCmd.Parameters.Add("@IsAdsControl", SqlDbType.Bit).Value = IsAdsControl;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = Operator;

        return Execute();
    }

    public int USP_Control_Delete(int ID)
    {
        mCmd.CommandText = "USP_Control_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Control_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Control_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Control_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Control_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Control_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Control_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Control_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Control_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Control_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Control_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Control_Fetch()
    {
        return 0;
    }
    public bool USP_Control_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Control_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fControlName = mDataReader["ControlName"].ToString();
            fPageID = Convert.ToInt32(mDataReader["PageID"]);
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fUControl = mDataReader["UControl"].ToString();
            fParam = mDataReader["Param"].ToString();
            fIsAdsControl = Convert.ToBoolean(mDataReader["IsAdsControl"]);
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fOperator = mDataReader["Operator"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Control_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Control_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Control_GetDataForComboBox_ByPageID(int PageID)
    {
        mCmd.CommandText = "USP_Control_GetDataForComboBox_ByPageID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@PageID", SqlDbType.Int).Value = PageID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Control_Ads_ByPageID(int PageID)
    {
        mCmd.CommandText = "USP_Control_Ads_ByPageID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@PageID", SqlDbType.Int).Value = PageID;
        ExecuteReader();
        return mDataReader;
    }
    
    public SqlDataReader USP_Control_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Control_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Control_CheckDuplicate(string ControlName)
    {
        mCmd.CommandText = "USP_Control_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ControlName", SqlDbType.VarChar).Value = ControlName;
        //ExecuteReader();
        return Execute();
    }

    public int USP_NewKey()
    {
        fID = USP_GetKey();
        return fID;
    }

    public bool Fetch_Reader(bool bClose)
    {
        if (mDataReader.IsClosed)
            return false;
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fControlName = mDataReader["ControlName"].ToString();
            fPageID = Convert.ToInt32(mDataReader["PageID"]);
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fUControl = mDataReader["UControl"].ToString();
            fParam = mDataReader["Param"].ToString();
            fIsAdsControl = Convert.ToBoolean(mDataReader["IsAdsControl"]);
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fOperator = mDataReader["Operator"].ToString();

            return true;
        }
        else
            if (bClose)
            {
                mDataReader.Close();
            }
        return false;
    }

    public bool U_Fetch_Reader(bool bClose)
    {
        return Fetch_Reader(bClose);
    }

    public bool U_Fetch_Reader()
    {
        return Fetch_Reader(true);
    }

}
public partial class DAControl : DAControlBase
{

    public SqlDataReader USP_Control_GetByPageID_Reader(int PageID)
    {
        mCmd.CommandText = "USP_Control_GetByPageID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@PageID", SqlDbType.Int).Value = PageID;
        ExecuteReader();
        return mDataReader;
    }

    public DataTable USP_Control_GetByPageID_DataTable(int PageID)
    {
        mCmd.CommandText = "USP_Control_GetByPageID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@PageID", SqlDbType.Int).Value = PageID;
        ExecuteReader();

        DataTable dataTable = new DataTable();
        dataTable.Load(mDataReader);

        CloseAll();

        return dataTable;
    }

    public DataTable Client_USP_Control_GetByPageCode_DataTable(string PageCode)
    {
        mCmd.CommandText = "Client_USP_Control_GetByPageCode";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@PageCode", SqlDbType.VarChar).Value = PageCode;
        ExecuteReader();

        DataTable dataTable = new DataTable();
        dataTable.Load(mDataReader);

        CloseAll();

        return dataTable;
    }

    public DataTable Client_USP_Control_ByParentID_DataTable(int ParentID)
    {
        mCmd.CommandText = "Client_USP_Control_ByParentID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        ExecuteReader();

        DataTable dataTable = new DataTable();
        dataTable.Load(mDataReader);

        CloseAll();

        return dataTable;
    }

    public DataSet USP_Control_GetByPageID_GetTree(int PageID)
    {
        mCmd.CommandText = "USP_Control_GetByPageID_GetTree";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@PageID", SqlDbType.Int).Value = PageID;
        ExecuteDataSet();
        return mDataSet;
    }
    
}
