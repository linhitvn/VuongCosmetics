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

public class DAWebFuncGroupBase : TDatabase
{

    public int fID;
    public int fGroupID;
    public int fFuncID;
    public object fpView;
    public object fpAdd;
    public object fpDel;
    public object fpEdit;
    public string fServerMsg;
    public DAWebFuncGroupBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "WebFuncGroup";
    }
    public int USP_WebFuncGroup_Insert()
    {
        mCmd.CommandText = "USP_WebFuncGroup_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = fGroupID;
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = fFuncID;
        mCmd.Parameters.Add("@pView", SqlDbType.Bit).Value = fpView;
        mCmd.Parameters.Add("@pAdd", SqlDbType.Bit).Value = fpAdd;
        mCmd.Parameters.Add("@pDel", SqlDbType.Bit).Value = fpDel;
        mCmd.Parameters.Add("@pEdit", SqlDbType.Bit).Value = fpEdit;
        return Execute();
    }
    public int USP_WebFuncGroup_Insert(int ID, int GroupID, int FuncID, bool pView, bool pAdd, bool pDel, bool pEdit)
    {
        mCmd.CommandText = "USP_WebFuncGroup_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = FuncID;
        mCmd.Parameters.Add("@pView", SqlDbType.Bit).Value = pView;
        mCmd.Parameters.Add("@pAdd", SqlDbType.Bit).Value = pAdd;
        mCmd.Parameters.Add("@pDel", SqlDbType.Bit).Value = pDel;
        mCmd.Parameters.Add("@pEdit", SqlDbType.Bit).Value = pEdit;
        return Execute();
    }

    public int USP_WebFuncGroup_Update()
    {
        mCmd.CommandText = "USP_WebFuncGroup_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = fGroupID;
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = fFuncID;
        mCmd.Parameters.Add("@pView", SqlDbType.Bit).Value = fpView;
        mCmd.Parameters.Add("@pAdd", SqlDbType.Bit).Value = fpAdd;
        mCmd.Parameters.Add("@pDel", SqlDbType.Bit).Value = fpDel;
        mCmd.Parameters.Add("@pEdit", SqlDbType.Bit).Value = fpEdit;
        return Execute();
    }
    public int USP_WebFuncGroup_Update(int ID, int GroupID, int FuncID, bool pView, bool pAdd, bool pDel, bool pEdit)
    {
        mCmd.CommandText = "USP_WebFuncGroup_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        mCmd.Parameters.Add("@FuncID", SqlDbType.Int).Value = FuncID;
        mCmd.Parameters.Add("@pView", SqlDbType.Bit).Value = pView;
        mCmd.Parameters.Add("@pAdd", SqlDbType.Bit).Value = pAdd;
        mCmd.Parameters.Add("@pDel", SqlDbType.Bit).Value = pDel;
        mCmd.Parameters.Add("@pEdit", SqlDbType.Bit).Value = pEdit;
        return Execute();
    }

    public int USP_WebFuncGroup_Delete(int ID)
    {
        mCmd.CommandText = "USP_WebFuncGroup_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_WebFuncGroup_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_WebFuncGroup_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_WebFuncGroup_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_WebFuncGroup_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_WebFuncGroup_GetByID(int ID)
    {
        mCmd.CommandText = "USP_WebFuncGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_WebFuncGroup_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_WebFuncGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_WebFuncGroup_Fetch()
    {
        return 0;
    }
    public bool USP_WebFuncGroup_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_WebFuncGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fGroupID = Convert.ToInt32(mDataReader["GroupID"]);
            fFuncID = Convert.ToInt32(mDataReader["FuncID"]);
            fpView = Convert.ToBoolean(mDataReader["pView"]);
            fpAdd = Convert.ToBoolean(mDataReader["pAdd"]);
            fpDel = Convert.ToBoolean(mDataReader["pDel"]);
            fpEdit = Convert.ToBoolean(mDataReader["pEdit"]);
            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_WebFuncGroup_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_WebFuncGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
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
            fGroupID = Convert.ToInt32(mDataReader["GroupID"]);
            fFuncID = Convert.ToInt32(mDataReader["FuncID"]);
            fpView = Convert.ToBoolean(mDataReader["pView"]);
            fpAdd = Convert.ToBoolean(mDataReader["pAdd"]);
            fpDel = Convert.ToBoolean(mDataReader["pDel"]);
            fpEdit = Convert.ToBoolean(mDataReader["pEdit"]);
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
public partial class DAWebFuncGroup : DAWebFuncGroupBase
{
    public DataSet USP_WebFunction_GetAll()
    {
        mCmd.CommandText = "USP_WebFunction_GetAll";
        mCmd.Parameters.Clear();
        ExecuteDataSet();
        return mDataSet;
    }

    public DataSet USP_WebFunction_GetListByGroupID(Int32 GroupID)
    {
        mCmd.CommandText = "USP_WebFunction_GetListByGroupID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        ExecuteDataSet();
        return mDataSet;
    }
    public DataSet USP_WebFunction_GetListByGroupIDAndUserID(Int32 GroupID, Int32 UserID)
    {
        mCmd.CommandText = "USP_WebFunction_GetListByGroupIDAndUserID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        ExecuteDataSet();
        return mDataSet;
    }


    public int USP_WebFuncGroup_UpdateFunc(Int32 GroupID, String IDList)
    {
        mCmd.CommandText = "USP_WebFuncGroup_UpdateFunc";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        mCmd.Parameters.Add("@IDList", SqlDbType.VarChar).Value = IDList;

        return Execute();
    }

    public DataSet USP_WebFuncGroup_GetFuncbyGroupID(Int32 GroupID)
    {
        mCmd.CommandText = "USP_WebFuncGroup_GetFuncbyGroupID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        ExecuteDataSet();
        return mDataSet;
    }

    public DataSet USP_WebFuncGroup_GetRolebyGroupID(Int32 GroupID)
    {
        mCmd.CommandText = "USP_WebFuncGroup_GetRolebyGroupID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        ExecuteDataSet();
        return mDataSet;
    }

    public DataSet USP_webConfig_GetAll(int First, int Count)
    {
        mCmd.CommandText = "USP_webConfig_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteDataSet();
        return mDataSet;
    }
}
