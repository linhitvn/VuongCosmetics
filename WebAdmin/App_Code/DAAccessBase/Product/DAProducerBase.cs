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

public class DAProducerBase : TDatabase
{
    public Int32 fID;
    public String fProducerName;
    public String fDescription;
    public String fLogoLink;
    public String fWebsite;

    public DAProducerBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Producer";
        mKeyName = "ID";
    }
    public int USP_Producer_Insert()
    {
        mCmd.CommandText = "USP_Producer_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProducerName", SqlDbType.NVarChar).Value = fProducerName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@LogoLink", SqlDbType.NVarChar).Value = fLogoLink;
        mCmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = fWebsite;

        return Execute();
    }
    public int USP_Producer_Insert(Int32 ID, String ProducerName, String Description, String LogoLink, String Website)
    {
        mCmd.CommandText = "USP_Producer_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ProducerName", SqlDbType.NVarChar).Value = ProducerName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@LogoLink", SqlDbType.NVarChar).Value = LogoLink;
        mCmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = Website;

        return Execute();
    }

    public int USP_Producer_Update()
    {
        mCmd.CommandText = "USP_Producer_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@ProducerName", SqlDbType.NVarChar).Value = fProducerName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fDescription;
        mCmd.Parameters.Add("@LogoLink", SqlDbType.NVarChar).Value = fLogoLink;
        mCmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = fWebsite;

        return Execute();
    }
    public int USP_Producer_Update(Int32 ID, String ProducerName, String Description, String LogoLink, String Website)
    {
        mCmd.CommandText = "USP_Producer_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@ProducerName", SqlDbType.NVarChar).Value = ProducerName;
        mCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
        mCmd.Parameters.Add("@LogoLink", SqlDbType.NVarChar).Value = LogoLink;
        mCmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = Website;

        return Execute();
    }

    public int USP_Producer_Delete(int ID)
    {
        mCmd.CommandText = "USP_Producer_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Producer_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Producer_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Producer_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Producer_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Producer_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Producer_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Producer_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Producer_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Producer_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Producer_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Producer_Fetch()
    {
        return 0;
    }
    public bool USP_Producer_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Producer_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fProducerName = mDataReader["ProducerName"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fLogoLink = mDataReader["LogoLink"].ToString();
            fWebsite = mDataReader["Website"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Producer_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Producer_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Producer_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Producer_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_Producer_CheckDuplicate(string ProducerName)
    {
        mCmd.CommandText = "USP_Producer_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ProducerName", SqlDbType.VarChar).Value = ProducerName;
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
            fProducerName = mDataReader["ProducerName"].ToString();
            fDescription = mDataReader["Description"].ToString();
            fLogoLink = mDataReader["LogoLink"].ToString();
            fWebsite = mDataReader["Website"].ToString();

            return true;
        }
        else
            if (bClose)
            {
                mDataReader.Close();
            }
        return false;
    }

    public List<DAProducer> USP_Producer_GetList(int First, int Count)
    {
        SqlDataReader reader = USP_Producer_GetAll_Reader(First, Count);
        List<DAProducer> producers = new List<DAProducer>();
        while (reader.Read())
        {
            producers.Add(new DAProducer()
            {
                fID = Convert.ToInt32(reader["ID"]),
                fProducerName = reader["ProducerName"].ToString(),
                fDescription = reader["Description"].ToString(),
                fLogoLink = reader["LogoLink"].ToString(),
                fWebsite = reader["Website"].ToString()
            });
        }
        return producers;
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
public partial class DAProducer : DAProducerBase
{
}
