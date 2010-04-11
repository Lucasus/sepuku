using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Helper
/// </summary>
namespace DN.Core
{
    public class Helper
    {
        public static ObjectType GetData<ObjectType>(DataRow row,string fieldName)
        {
            return GetData<ObjectType>(ref row,fieldName);
        }

        public static ObjectType GetData<ObjectType>(ref DataRow row, string fieldName)
        {
            if (row.Table.Columns.Contains(fieldName) && row[fieldName] != DBNull.Value)                
            {
                if (typeof(ObjectType) != row[fieldName].GetType())
                {
                    return (ObjectType)Convert.ChangeType(row[fieldName], typeof(ObjectType));
                }
                else
                    return (ObjectType)row[fieldName];
            }
            else
            {
                if (typeof(ObjectType) == Type.GetType("System.String"))
                {
                    object emptyString = String.Empty;
                    return (ObjectType)emptyString;
                }
                else if (typeof(ObjectType) == Type.GetType("System.DateTime"))
                {
                    object dateTime = DateTime.MinValue;
                    return (ObjectType)dateTime;
                }
                else if (typeof(ObjectType) == Type.GetType("System.Guid"))
                {
                    object guid = Guid.Empty;
                    return (ObjectType)guid;
                }
                else if (typeof(ObjectType) == Type.GetType("System.Byte[]"))
                {
                    object byteTable = null;
                    return (ObjectType)byteTable;
                }
                else
                    return Activator.CreateInstance<ObjectType>();                    
            }
        }

       
    }
}
