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

public class DASupportOnlineBase : TDatabase
{
    public Int32 fID;
    public String fSupportName;
    public String fImgLink;
    public String fPhone;
    public String fEmail;
    public String fSkype;
    public String fYahoo;
    public String fGooglePlus;
    public String fFaceBook;
    public Boolean fActive;
    public Int32 fPos;

    public DASupportOnlineBase()
    {
        //USP_DataAdapter_Init();
        mTableName = "SupportOnline";
        mKeyName = "ID";
    }
    public int USP_SupportOnline_Insert()
    {
        mCmd.CommandText = "USP_SupportOnline_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@SupportName", SqlDbType.NVarChar).Value = fSupportName;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = fPhone;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Skype", SqlDbType.VarChar).Value = fSkype;
        mCmd.Parameters.Add("@Yahoo", SqlDbType.VarChar).Value = fYahoo;
        mCmd.Parameters.Add("@GooglePlus", SqlDbType.VarChar).Value = fGooglePlus;
        mCmd.Parameters.Add("@FaceBook", SqlDbType.VarChar).Value = fFaceBook;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;

        return Execute();
    }
    public int USP_SupportOnline_Insert(Int32 ID, String SupportName, String ImgLink, String Phone, String Email, String Skype, String Yahoo, String GooglePlus, String FaceBook, Boolean Active, Int32 Pos)
    {
        mCmd.CommandText = "USP_SupportOnline_Insert";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@SupportName", SqlDbType.NVarChar).Value = SupportName;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = ImgLink;
        mCmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = Phone;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        mCmd.Parameters.Add("@Skype", SqlDbType.VarChar).Value = Skype;
        mCmd.Parameters.Add("@Yahoo", SqlDbType.VarChar).Value = Yahoo;
        mCmd.Parameters.Add("@GooglePlus", SqlDbType.VarChar).Value = GooglePlus;
        mCmd.Parameters.Add("@FaceBook", SqlDbType.VarChar).Value = FaceBook;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;

        return Execute();
    }

    public int USP_SupportOnline_Update()
    {
        mCmd.CommandText = "USP_SupportOnline_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        mCmd.Parameters.Add("@SupportName", SqlDbType.NVarChar).Value = fSupportName;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = fImgLink;
        mCmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = fPhone;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fEmail;
        mCmd.Parameters.Add("@Skype", SqlDbType.VarChar).Value = fSkype;
        mCmd.Parameters.Add("@Yahoo", SqlDbType.VarChar).Value = fYahoo;
        mCmd.Parameters.Add("@GooglePlus", SqlDbType.VarChar).Value = fGooglePlus;
        mCmd.Parameters.Add("@FaceBook", SqlDbType.VarChar).Value = fFaceBook;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = fActive;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = fPos;

        return Execute();
    }
    public int USP_SupportOnline_Update(Int32 ID, String SupportName, String ImgLink, String Phone, String Email, String Skype, String Yahoo, String GooglePlus, String FaceBook, Boolean Active, Int32 Pos)
    {
        mCmd.CommandText = "USP_SupportOnline_Update";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        mCmd.Parameters.Add("@SupportName", SqlDbType.NVarChar).Value = SupportName;
        mCmd.Parameters.Add("@ImgLink", SqlDbType.NVarChar).Value = ImgLink;
        mCmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = Phone;
        mCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        mCmd.Parameters.Add("@Skype", SqlDbType.VarChar).Value = Skype;
        mCmd.Parameters.Add("@Yahoo", SqlDbType.VarChar).Value = Yahoo;
        mCmd.Parameters.Add("@GooglePlus", SqlDbType.VarChar).Value = GooglePlus;
        mCmd.Parameters.Add("@FaceBook", SqlDbType.VarChar).Value = FaceBook;
        mCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
        mCmd.Parameters.Add("@Pos", SqlDbType.Int).Value = Pos;

        return Execute();
    }

    public int USP_SupportOnline_Delete(int ID)
    {
        mCmd.CommandText = "USP_SupportOnline_Delete";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        return Execute();
    }

    public int USP_SupportOnline_Delete()
    {
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = fID;
        return Execute();
    }

    public DataSet USP_SupportOnline_GetAll(int First, int Count)
    {
        return USP_GetAll(First, Count);
    }

    public SqlDataReader USP_SupportOnline_GetAll_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_SupportOnline_GetAll";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_SupportOnline_Show_Reader(int First, int Count)
    {
        mCmd.CommandText = "USP_SupportOnline_Show";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@First", SqlDbType.Int).Value = First;
        mCmd.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
        ExecuteReader();
        return mDataReader;
    }

    public DataSet USP_SupportOnline_GetByID(int ID)
    {
        mCmd.CommandText = "USP_SupportOnline_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteDataSet();
        //U_Fetch(0);
        return mDataSet;
    }

    public SqlDataReader USP_SupportOnline_GetByID_Reader(int ID)
    {
        mCmd.CommandText = "USP_SupportOnline_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public virtual int USP_SupportOnline_Fetch()
    {
        return 0;
    }
    public bool USP_SupportOnline_GetFullID(int ID)
    {
        mCmd.CommandText = "USP_SupportOnline_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        if (mDataReader.Read())
        {
            fID = Convert.ToInt32(mDataReader["ID"]);
            fSupportName = mDataReader["SupportName"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fPhone = mDataReader["Phone"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fSkype = mDataReader["Skype"].ToString();
            fYahoo = mDataReader["Yahoo"].ToString();
            fGooglePlus = mDataReader["GooglePlus"].ToString();
            fFaceBook = mDataReader["FaceBook"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fPos = Convert.ToInt32(mDataReader["Pos"]);

            mDataReader.Close();
            return true;
        }
        else
            mDataReader.Close();
        return false;
    }

    public SqlDataReader USP_SupportOnline_GetFullID_Reader(int ID)
    {
        mCmd.CommandText = "USP_SupportOnline_GetByID";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        ExecuteReader();
        return mDataReader;
    }

    public SqlDataReader USP_SupportOnline_GetDataForComboBox()
    {
        mCmd.CommandText = "USP_SupportOnline_GetDataForComboBox";
        mCmd.Parameters.Clear();
        ExecuteReader();
        return mDataReader;
    }


    public int USP_SupportOnline_CheckDuplicate(string SupportName)
    {
        mCmd.CommandText = "USP_SupportOnline_CheckDuplicate";
        mCmd.Parameters.Clear();
        mCmd.Parameters.Add("@SupportName", SqlDbType.VarChar).Value = SupportName;
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
            fSupportName = mDataReader["SupportName"].ToString();
            fImgLink = mDataReader["ImgLink"].ToString();
            fPhone = mDataReader["Phone"].ToString();
            fEmail = mDataReader["Email"].ToString();
            fSkype = mDataReader["Skype"].ToString();
            fYahoo = mDataReader["Yahoo"].ToString();
            fGooglePlus = mDataReader["GooglePlus"].ToString();
            fFaceBook = mDataReader["FaceBook"].ToString();
            fActive = Convert.ToBoolean(mDataReader["Active"]);
            fPos = Convert.ToInt32(mDataReader["Pos"]);

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
public partial class DASupportOnline : DASupportOnlineBase
{
}
