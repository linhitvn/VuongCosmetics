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

public class DAWebGroupBase : TDatabase
{
    public Int32 fGroupID;
    public String fGroupName;
    public String fDescription;
    public Boolean fActive;
    public Int32 fLevel;

    public DAWebGroupBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "WebGroup";
        mKeyName = "GroupID";
    }
    public int USP_WebGroup_Insert()
    {
        mCmd.CommandText = "USP_WebGroup_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = fGroupID;
        mCmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = fGroupName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Level", SqlDbType.Int).Value = fLevel;

        return Execute();
    }
    public int USP_WebGroup_Insert(Int32 GroupID, String GroupName, String Description, Boolean Active, Int32 Level)
    {
        mCmd.CommandText = "USP_WebGroup_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        mCmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = GroupName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Level", SqlDbType.Int).Value = Level;

        return Execute();
    }

    public int USP_WebGroup_Update()
    {
        mCmd.CommandText = "USP_WebGroup_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = fGroupID;
        mCmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = fGroupName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Level", SqlDbType.Int).Value = fLevel;

        return Execute();
    }
    public int USP_WebGroup_Update(Int32 GroupID, String GroupName, String Description, Boolean Active, Int32 Level)
    {
        mCmd.CommandText = "USP_WebGroup_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        mCmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = GroupName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Level", SqlDbType.Int).Value = Level;

        return Execute();
    }

    public int USP_WebGroup_Delete(int GroupID)
    {
        mCmd.CommandText = "USP_WebGroup_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        return Execute();
    }

    public int USP_WebGroup_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = fGroupID;
        return Execute();
    }

    public DataSet USP_WebGroup_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_WebGroup_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_WebGroup_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_WebGroup_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_WebGroup_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_WebGroup_GetByID(int GroupID)
    {
        mCmd.CommandText = "USP_WebGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_WebGroup_GetByID_Reader(int GroupID)
    {
        mCmd.CommandText = "USP_WebGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_WebGroup_Fetch()
    {
        return 0;
    }
    public bool USP_WebGroup_GetFullID(int GroupID)
    {
        mCmd.CommandText = "USP_WebGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fGroupID = Convert.ToInt32(mDataReader["GroupID"]);
            fGroupName = mDataReader["GroupName"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fLevel = Convert.ToInt32(mDataReader["Level"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_WebGroup_GetFullID_Reader(int GroupID)
    {
        mCmd.CommandText = "USP_WebGroup_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_WebGroup_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_WebGroup_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_WebGroup_CheckDuplicate(string GroupName)
    {
        mCmd.CommandText = "USP_WebGroup_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupName", SqlDbType.VarChar).Value = GroupName;
        //ExecuteReader();
        return Execute();
    }

    public int USP_NewKey()
    {
        fGroupID = USP_GetKey();
        return fGroupID;
    }

    public bool Fetch_Reader(bool bClose)
    {
        if (mDataReader.IsClosed)
            return false;
        if (mDataReader.Read())
        {
            fGroupID = Convert.ToInt32(mDataReader["GroupID"]);
            fGroupName = mDataReader["GroupName"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fLevel = Convert.ToInt32(mDataReader["Level"]);

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
public partial class DAWebGroup : DAWebGroupBase
{
    //Kiểm tra trước khi xóa
    public int USP_WebGroup_CheckForDelete(Int32 GroupID)
    {
        mCmd.CommandText = "USP_WebGroup_CheckForDelete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = GroupID;
        return Execute();
    }

    public DataSet USP_WebGroup_GetForCombo()
    {
        mCmd.CommandText = "USP_WebGroup_GetForCombo";
        mCmd.Parameters.Clear();
        ExecuteDataSet();
        return mDataSet;
    }

    public DataSet USP_WebGroup_GetAllByCombo()
    {
        mCmd.CommandText = "USP_WebGroup_GetAllByCombo";
        mCmd.Parameters.Clear();
        ExecuteDataSet();
        return mDataSet;
    }

    //Kiểm tra trước khi xóa
    
    public DataSet USP_WebGroup_GetAllByComboByUserID(int UserID)
    {
        mCmd.CommandText = "USP_WebGroup_GetAllByComboByUserID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        ExecuteDataSet();
        return mDataSet;
    }

    public int USP_WebGroup_GetLevelByUserID(int UserID)
    {
        mCmd.CommandText = "USP_WebGroup_GetLevelByUserID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        return Execute();
    }


    public int USP_WebGroup_GetCountBelongTo(int ID)
    {
        mCmd.CommandText = "USP_WebGroup_GetCountBelongTo";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public DataSet USP_WebGroup_GetAllByUserID(int UserID)
    {
        mCmd.CommandText = "USP_WebGroup_GetAllByUserID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        ExecuteDataSet();
        return mDataSet;
    }
}
