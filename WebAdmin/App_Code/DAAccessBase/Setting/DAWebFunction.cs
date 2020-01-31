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

public class DAWebFunctionBase : TDatabase
{
    public Int32 fFuncID;
    public Int32 fParentID;
    public String fVNName;
    public String fENName;
    public String fUKey;
    public String fUControl;
    public String fURLLink;
    public Int32 fRole;
    public String fCssClass;
    public String fIcon;
    public String fIconHover;
    public Boolean fActive;
    public Int32 fDisplayOrder;
    public Boolean fisShow;

    public DAWebFunctionBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "WebFunction";
        mKeyName = "FuncID";
    }
    public int USP_WebFunction_Insert()
    {
        mCmd.CommandText = "USP_WebFunction_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = fFuncID;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@VNName", SqlDbType.NVarChar).Value = fVNName;
        mCmd.Parameters.Add("@ENName", SqlDbType.NVarChar).Value = fENName;
        mCmd.Parameters.Add("@UKey", SqlDbType.VarChar).Value = fUKey;
        mCmd.Parameters.Add("@UControl", SqlDbType.VarChar).Value = fUControl;
        mCmd.Parameters.Add("@URLLink", SqlDbType.VarChar).Value = fURLLink;
        mCmd.Parameters.Add("@Role", SqlDbType.Int).Value = fRole;
        mCmd.Parameters.Add("@CssClass", SqlDbType.VarChar).Value = fCssClass;
        mCmd.Parameters.Add("@Icon", SqlDbType.VarChar).Value = fIcon;
        mCmd.Parameters.Add("@IconHover", SqlDbType.VarChar).Value = fIconHover;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = fDisplayOrder;
        mCmd.Parameters.Add("@isShow", SqlDbType.Bit).Value = fisShow;

        return Execute();
    }
    public int USP_WebFunction_Insert(Int32 FuncID, Int32 ParentID, String VNName, String ENName, String UKey, String UControl, String URLLink, Int32 Role, String CssClass, String Icon, String IconHover, Boolean Active, Int32 DisplayOrder, Boolean isShow)
    {
        mCmd.CommandText = "USP_WebFunction_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = FuncID;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@VNName", SqlDbType.NVarChar).Value = VNName;
        mCmd.Parameters.Add("@ENName", SqlDbType.NVarChar).Value = ENName;
        mCmd.Parameters.Add("@UKey", SqlDbType.VarChar).Value = UKey;
        mCmd.Parameters.Add("@UControl", SqlDbType.VarChar).Value = UControl;
        mCmd.Parameters.Add("@URLLink", SqlDbType.VarChar).Value = URLLink;
        mCmd.Parameters.Add("@Role", SqlDbType.Int).Value = Role;
        mCmd.Parameters.Add("@CssClass", SqlDbType.VarChar).Value = CssClass;
        mCmd.Parameters.Add("@Icon", SqlDbType.VarChar).Value = Icon;
        mCmd.Parameters.Add("@IconHover", SqlDbType.VarChar).Value = IconHover;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
        mCmd.Parameters.Add("@isShow", SqlDbType.Bit).Value = isShow;

        return Execute();
    }

    public int USP_WebFunction_Update()
    {
        
        mCmd.CommandText = "USP_WebFunction_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = fFuncID;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = fParentID;
        mCmd.Parameters.Add("@VNName", SqlDbType.NVarChar).Value = fVNName;
        mCmd.Parameters.Add("@ENName", SqlDbType.NVarChar).Value = fENName;
        mCmd.Parameters.Add("@UKey", SqlDbType.VarChar).Value = fUKey;
        mCmd.Parameters.Add("@UControl", SqlDbType.VarChar).Value = fUControl;
        mCmd.Parameters.Add("@URLLink", SqlDbType.VarChar).Value = fURLLink;
        mCmd.Parameters.Add("@Role", SqlDbType.Int).Value = fRole;
        mCmd.Parameters.Add("@CssClass", SqlDbType.VarChar).Value = fCssClass;
        mCmd.Parameters.Add("@Icon", SqlDbType.VarChar).Value = fIcon;
        mCmd.Parameters.Add("@IconHover", SqlDbType.VarChar).Value = fIconHover;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = fDisplayOrder;
        mCmd.Parameters.Add("@isShow", SqlDbType.Bit).Value = fisShow;

        return Execute();
    }
    public int USP_WebFunction_Update(Int32 FuncID, Int32 ParentID, String VNName, String ENName, String UKey, String UControl, String URLLink, Int32 Role, String CssClass, String Icon, String IconHover, Boolean Active, Int32 DisplayOrder, Boolean isShow)
    {
        mCmd.CommandText = "USP_WebFunction_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = FuncID;
        mCmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = ParentID;
        mCmd.Parameters.Add("@VNName", SqlDbType.NVarChar).Value = VNName;
        mCmd.Parameters.Add("@ENName", SqlDbType.NVarChar).Value = ENName;
        mCmd.Parameters.Add("@UKey", SqlDbType.VarChar).Value = UKey;
        mCmd.Parameters.Add("@UControl", SqlDbType.VarChar).Value = UControl;
        mCmd.Parameters.Add("@URLLink", SqlDbType.VarChar).Value = URLLink;
        mCmd.Parameters.Add("@Role", SqlDbType.Int).Value = Role;
        mCmd.Parameters.Add("@CssClass", SqlDbType.VarChar).Value = CssClass;
        mCmd.Parameters.Add("@Icon", SqlDbType.VarChar).Value = Icon;
        mCmd.Parameters.Add("@IconHover", SqlDbType.VarChar).Value = IconHover;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
        mCmd.Parameters.Add("@isShow", SqlDbType.Bit).Value = isShow;

        return Execute();
    }

    public int USP_WebFunction_Delete(int FuncID)
    {
        mCmd.CommandText = "USP_WebFunction_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = FuncID;
        return Execute();
    }

    public int USP_WebFunction_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = fFuncID;
        return Execute();
    }

    //public DataSet USP_WebFunction_GetAll()
    //{
    //    return USP_GetAll(First, Count);
    //}

    public DataSet USP_WebFunction_GetAll(int First, int Count)
    {
        mCmd.CommandText = "USP_WebFunction_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteDataSet();
        return mDataSet;
    }

    public SqlDataReader USP_WebFunction_GetAll_Reader()
    {
        mCmd.CommandText = "USP_WebFunction_GetAll";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_WebFunction_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_WebFunction_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_WebFunction_GetByID(int FuncID)
    {
        mCmd.CommandText = "USP_WebFunction_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = FuncID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_WebFunction_GetByID_Reader(int FuncID)
    {
        mCmd.CommandText = "USP_WebFunction_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = FuncID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_WebFunction_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_WebFunction_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_WebFunction_Fetch()
    {
        return 0;
    }
    public bool USP_WebFunction_GetFullID(int FuncID)
    {
        mCmd.CommandText = "USP_WebFunction_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = FuncID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fFuncID = Convert.ToInt32(mDataReader["FuncID"]);
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fVNName = mDataReader["VNName"].ToString();
            fENName = mDataReader["ENName"].ToString();
            fUKey = mDataReader["UKey"].ToString();
            fUControl = mDataReader["UControl"].ToString();
            fURLLink = mDataReader["URLLink"].ToString();
            fRole = Convert.ToInt32(mDataReader["Role"]);
            fCssClass = mDataReader["CssClass"].ToString();
            fIcon = mDataReader["Icon"].ToString();
            fIconHover = mDataReader["IconHover"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fDisplayOrder = Convert.ToInt32(mDataReader["DisplayOrder"]);
            fisShow = Convert.ToBoolean(mDataReader["isShow"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_WebFunction_GetFullID_Reader(int FuncID)
    {
        mCmd.CommandText = "USP_WebFunction_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = FuncID;
        ExecuteReader();
        return mDataReader;
    }

    public int USP_NewKey()
    {
        fFuncID = USP_GetKey();
        return fFuncID;
    }

    public bool Fetch_Reader(bool bClose)
    {
        if (mDataReader.IsClosed)
            return false;
        if (mDataReader.Read())
        {
            fFuncID = Convert.ToInt32(mDataReader["FuncID"]);
            fParentID = Convert.ToInt32(mDataReader["ParentID"]);
            fVNName = mDataReader["VNName"].ToString();
            fENName = mDataReader["ENName"].ToString();
            fUKey = mDataReader["UKey"].ToString();
            fUControl = mDataReader["UControl"].ToString();
            fURLLink = mDataReader["URLLink"].ToString();
            fRole = Convert.ToInt32(mDataReader["Role"]);
            fCssClass = mDataReader["CssClass"].ToString();
            fIcon = mDataReader["Icon"].ToString();
            fIconHover = mDataReader["IconHover"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fDisplayOrder = Convert.ToInt32(mDataReader["DisplayOrder"]);
            fisShow = Convert.ToBoolean(mDataReader["isShow"]);

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
public partial class DAWebFunction : DAWebFunctionBase
{
    public SqlDataReader USP_WebFunction_GetDataForComboBox_Parent()
    {
        mCmd.CommandText = "USP_WebFunction_GetDataForComboBox_Parent";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }
    
}
