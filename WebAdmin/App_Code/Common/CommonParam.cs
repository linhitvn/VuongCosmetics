using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonParam
/// </summary>
public class CommonParam
{
	public CommonParam()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

public static class MessageText
{
    public const string MESSAGE_TITLE = "MSGTITLE";
    public const string DELETE_SUCC = "DELSUCC";
    public const string SAVE_SUCC = "SAVESUCC";
    public const string ANY_SUCC = "ANYSUCC";
    public const string SYSTEM_ERROR = "SYSERROR";
    public const string ERROR = "ERROR";
    public const string WARNING = "WARNING";
}

public static class Act
{
    public const string New = "new";
    public const string Edit = "edit";
    public const string Clone = "clone";
    public const string Delete = "delete";
}

public static class ActParam
{
    public const string view = "view";
    public const string New = "new";
    public const string Edit = "edit";
    public const string Clone = "clone";
}

public static class ActRow
{
    public const string Delete = "deleteRow";
    public const string Edit = "editRow";
    public const string Clone = "cloneRow";
}

public static class Role
{
    public const int View = 1;
    public const int Create = 2;
    public const int Edit = 4;
    public const int Delete = 8;
}

//public static class SQL_MODE
//{
//    public const int Insert = 1;
//    public const int Update = 2;
//}

public enum SQL_MODE { 
    Insert = 1,
    Update = 2
}

public class UserLevel
{
    public int LevelID
    {
        get;
        set;
    }
    public string LevelName
    {
        get;
        set;
    }
}