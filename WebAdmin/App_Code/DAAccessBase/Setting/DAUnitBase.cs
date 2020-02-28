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

public class DAUnitBase : TDatabase
{
    public Int32 fID;
    public String fUnitName;
    public String fDecription;
    public Int32 fExpandUnitID;
    public Double fRate;
    public Boolean fIsOrginalUnit;

    public DAUnitBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Unit";
        mKeyName = "ID";
    }
    public int USP_Unit_Insert()
    {
        mCmd.CommandText = "USP_Unit_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = fUnitName;
        mCmd.Parameters.Add("@Decription", SqlDbType.NVarChar).Value = fDecription;
        mCmd.Parameters.Add("@ExpandUnitID", SqlDbType.Int).Value = fExpandUnitID;
        mCmd.Parameters.Add("@Rate", SqlDbType.Float).Value = fRate;
        mCmd.Parameters.Add("@IsOrginalUnit", SqlDbType.Bit).Value = fIsOrginalUnit;

        return Execute();
    }
    public int USP_Unit_Insert(Int32 ID, String UnitName, String Decription, Int32 ExpandUnitID, Double Rate, Boolean IsOrginalUnit)
    {
        mCmd.CommandText = "USP_Unit_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = UnitName;
        mCmd.Parameters.Add("@Decription", SqlDbType.NVarChar).Value = Decription;
        mCmd.Parameters.Add("@ExpandUnitID", SqlDbType.Int).Value = ExpandUnitID;
        mCmd.Parameters.Add("@Rate", SqlDbType.Float).Value = Rate;
        mCmd.Parameters.Add("@IsOrginalUnit", SqlDbType.Bit).Value = IsOrginalUnit;

        return Execute();
    }

    public int USP_Unit_Update()
    {
        mCmd.CommandText = "USP_Unit_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = fUnitName;
        mCmd.Parameters.Add("@Decription", SqlDbType.NVarChar).Value = fDecription;
        mCmd.Parameters.Add("@ExpandUnitID", SqlDbType.Int).Value = fExpandUnitID;
        mCmd.Parameters.Add("@Rate", SqlDbType.Float).Value = fRate;
        mCmd.Parameters.Add("@IsOrginalUnit", SqlDbType.Bit).Value = fIsOrginalUnit;

        return Execute();
    }
    public int USP_Unit_Update(Int32 ID, String UnitName, String Decription, Int32 ExpandUnitID, Double Rate, Boolean IsOrginalUnit)
    {
        mCmd.CommandText = "USP_Unit_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = UnitName;
        mCmd.Parameters.Add("@Decription", SqlDbType.NVarChar).Value = Decription;
        mCmd.Parameters.Add("@ExpandUnitID", SqlDbType.Int).Value = ExpandUnitID;
        mCmd.Parameters.Add("@Rate", SqlDbType.Float).Value = Rate;
        mCmd.Parameters.Add("@IsOrginalUnit", SqlDbType.Bit).Value = IsOrginalUnit;

        return Execute();
    }

    public int USP_Unit_Delete(int ID)
    {
        mCmd.CommandText = "USP_Unit_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Unit_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Unit_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Unit_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Unit_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Unit_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Unit_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Unit_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Unit_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Unit_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Unit_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Unit_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Unit_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Unit_Fetch()
    {
        return 0;
    }
    public bool USP_Unit_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Unit_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fUnitName = mDataReader["UnitName"].ToString();
            fDecription = mDataReader["Decription"].ToString();
            fExpandUnitID = Convert.ToInt32(mDataReader["ExpandUnitID"]);
            fRate = Convert.ToDouble(mDataReader["Rate"]);
            fIsOrginalUnit = Convert.ToBoolean(mDataReader["IsOrginalUnit"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Unit_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Unit_GetByID";
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
            fUnitName = mDataReader["UnitName"].ToString();
            fDecription = mDataReader["Decription"].ToString();
            fExpandUnitID = Convert.ToInt32(mDataReader["ExpandUnitID"]);
            fRate = Convert.ToDouble(mDataReader["Rate"]);
            fIsOrginalUnit = Convert.ToBoolean(mDataReader["IsOrginalUnit"]);

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

    public List<DAUnit> USP_VAT_GetAll(int First, int Count)
    {
        SqlDataReader reader = USP_Unit_GetAll_Reader(First, Count);
        List<DAUnit> units = new List<DAUnit>();
        while (reader.Read())
        {
            units.Add(new DAUnit()
            {
                fID = Convert.ToInt32(reader["ID"]),
                fUnitName = reader["UnitName"].ToString(),
                fDecription = reader["Decription"].ToString(),
                fExpandUnitID = Convert.ToInt32(reader["ExpandUnitID"]),
                fRate = Convert.ToDouble(reader["Rate"]),
                fIsOrginalUnit = Convert.ToBoolean(reader["IsOrginalUnit"])
            });
        }
        return units;
    }

}
public partial class DAUnit : DAUnitBase
{
    public SqlDataReader USP_Unit_GetOrinal()
    {
        mCmd.CommandText = "USP_Unit_GetOrinal";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Unit_GetWithRate()
    {
        mCmd.CommandText = "USP_Unit_GetWithRate";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }

    
}
