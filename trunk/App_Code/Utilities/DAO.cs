using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

namespace DN.Core
{
    public static class DAO<T,V> where T: IDAO<V>, new() where V : new()
    {
        static Database db = DatabaseFactory.CreateDatabase();

        public static void ExecuteNonQuery(string storedProcedureName, params object[] parameters)
        {
           db.ExecuteNonQuery(storedProcedureName, parameters);
        }

        public static object ExecuteScalar(string storedProcedureName, params object[] parameters)
        {
            return ExecuteScalar(storedProcedureName, new CommandStatus(), parameters);
        }

        public static object ExecuteScalar(string storedProcedureName, CommandStatus status, params object[] parameters)
        {
            object result = null;
            try
            {
                result = db.ExecuteScalar(storedProcedureName, parameters);
                return result;
            }
            catch (SqlException e)
            {
                if (status != null)
                {
                    status.IsError = true;
                    status.Message = e.Message;
                }
                return null;
            }
        }

        public static int Add(string storedProcedureName, T t)
        {
            DbCommand cmd = db.GetStoredProcCommand(storedProcedureName);
            t.FillParametersFromProperties(db, ref cmd);
            object tempId = db.ExecuteScalar(cmd);
            int id = 0;
            if (tempId != null)
            {
                Int32.TryParse(tempId.ToString(), out id);
            }
            return id;
        }

        public static void Update(string storedProcedureName, T t)
        {
            DbCommand cmd = db.GetStoredProcCommand(storedProcedureName);            
            t.FillParametersFromProperties(db, ref cmd);
            db.ExecuteNonQuery(cmd);
        }

        public static V GetSingleObject(string storedProcedureName, params object[] parameters)
        {
            CommandStatus status = new CommandStatus();
            return GetSingleObject(storedProcedureName, status, parameters);
        }

        public static V GetSingleObject(string storedProcedureName, CommandStatus status, params object[] parameters)
        {
            try
            {
                DataSet ds = db.ExecuteDataSet(storedProcedureName, parameters ?? new object[] { });

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                        return new T().GetFromRow(ds.Tables[0].Rows[0]);
                }
                return new V();
            }
            catch (SqlException e)
            {
                if (status != null)
                {
                    status.IsError = true;
                    status.Message = e.Message;
                }
                return new V();
            }
        }

        public static List<V> GetObjectList(string storedProcedureName, params object[] parameters)
        {
            DataSet ds = db.ExecuteDataSet(storedProcedureName, parameters ?? new object[] { });

            List<V> returnList = new List<V>();

            if (ds.Tables.Count > 0)
            {
                 T t = new T();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    returnList.Add(t.GetFromRow(dr));
                }
            }
            return returnList;
        }
                
        

    }
}