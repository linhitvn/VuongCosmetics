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

public class DASupportBase : TDatabase
{
    public Int32 fID;
    public String fSupportName;
    public String fImage;
    public Int32 fPos;
    public String fPhone;
    public String fEmail;
    public String fSkype;
    public String fYahoo;
    public String fGoogle;
    public String fFaceBook;

    public DASupportBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "Support";
        mKeyName = "ID";
    }
    public int USP_Support_Insert()
    {
        mCmd.CommandText = "USP_Support_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@SupportName", SqlDbType.NVarChar).Value = fSupportName;
        mCmd.Parameters.Add("@Image", SqlDbType.NVarChar).Value = fImage;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = fPhone;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Skype", SqlDbType.NVarChar).Value = fSkype;
        mCmd.Parameters.Add("@Yahoo", SqlDbType.NVarChar).Value = fYahoo;
        mCmd.Parameters.Add("@Google", SqlDbType.NVarChar).Value = fGoogle;
        mCmd.Parameters.Add("@FaceBook", SqlDbType.NVarChar).Value = fFaceBook;

        return Execute();
    }
    public int USP_Support_Insert(Int32 ID, String SupportName, String Image, Int32 Pos, String Phone, String Email, String Skype, String Yahoo, String Google, String FaceBook)
    {
        mCmd.CommandText = "USP_Support_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@SupportName", SqlDbType.NVarChar).Value = SupportName;
        mCmd.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        mCmd.Parameters.Add("@Skype", SqlDbType.NVarChar).Value = Skype;
        mCmd.Parameters.Add("@Yahoo", SqlDbType.NVarChar).Value = Yahoo;
        mCmd.Parameters.Add("@Google", SqlDbType.NVarChar).Value = Google;
        mCmd.Parameters.Add("@FaceBook", SqlDbType.NVarChar).Value = FaceBook;

        return Execute();
    }

    public int USP_Support_Update()
    {
        mCmd.CommandText = "USP_Support_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@SupportName", SqlDbType.NVarChar).Value = fSupportName;
        mCmd.Parameters.Add("@Image", SqlDbType.NVarChar).Value = fImage;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;
        mCmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = fPhone;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Skype", SqlDbType.NVarChar).Value = fSkype;
        mCmd.Parameters.Add("@Yahoo", SqlDbType.NVarChar).Value = fYahoo;
        mCmd.Parameters.Add("@Google", SqlDbType.NVarChar).Value = fGoogle;
        mCmd.Parameters.Add("@FaceBook", SqlDbType.NVarChar).Value = fFaceBook;

        return Execute();
    }
    public int USP_Support_Update(Int32 ID, String SupportName, String Image, Int32 Pos, String Phone, String Email, String Skype, String Yahoo, String Google, String FaceBook)
    {
        mCmd.CommandText = "USP_Support_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@SupportName", SqlDbType.NVarChar).Value = SupportName;
        mCmd.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;
        mCmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        mCmd.Parameters.Add("@Skype", SqlDbType.NVarChar).Value = Skype;
        mCmd.Parameters.Add("@Yahoo", SqlDbType.NVarChar).Value = Yahoo;
        mCmd.Parameters.Add("@Google", SqlDbType.NVarChar).Value = Google;
        mCmd.Parameters.Add("@FaceBook", SqlDbType.NVarChar).Value = FaceBook;

        return Execute();
    }

    public int USP_Support_Delete(int ID)
    {
        mCmd.CommandText = "USP_Support_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_Support_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_Support_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_Support_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Support_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Support_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_Support_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_Support_GetByID(int ID)
    {
        mCmd.CommandText = "USP_Support_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_Support_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Support_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_Support_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_Support_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_Support_Fetch()
    {
        return 0;
    }
    public bool USP_Support_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_Support_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fSupportName = mDataReader["SupportName"].ToString();
            fImage = mDataReader["Image"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fPhone = mDataReader["Phone"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fSkype = mDataReader["Skype"].ToString();
            fYahoo = mDataReader["Yahoo"].ToString();
            fGoogle = mDataReader["Google"].ToString();
            fFaceBook = mDataReader["FaceBook"].ToString();

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_Support_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_Support_GetByID";
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
            fSupportName = mDataReader["SupportName"].ToString();
            fImage = mDataReader["Image"].ToString();
            fPos = Convert.ToInt32(mDataReader["Pos"]);
            fPhone = mDataReader["Phone"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fSkype = mDataReader["Skype"].ToString();
            fYahoo = mDataReader["Yahoo"].ToString();
            fGoogle = mDataReader["Google"].ToString();
            fFaceBook = mDataReader["FaceBook"].ToString();

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
public partial class DASupport : DASupportBase
{
}
