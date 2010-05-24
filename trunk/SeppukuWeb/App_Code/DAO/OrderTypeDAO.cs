using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Seppuku.Domain;
using Seppuku.Core;

namespace Seppuku.DAO
{
    public class OrderTypeDAO : IDAO<OrderType>
    {
        public OrderType DataObject { get; set; }

        public int Add(OrderType o)
        {
            DataObject = o;
            return DAO<OrderTypeDAO, OrderType>.Add("SepOrderTypeAdd", this);
        }

        public OrderType GetById(int orderId)
        {
            return DAO<OrderTypeDAO, OrderType>.GetSingleObject("SepOrderTypeGetById", orderId);
        }

        public OrderType GetByName(string orderName)
        {
            return DAO<OrderTypeDAO, OrderType>.GetSingleObject("SepOrderTypeGetByName", orderName);
        }

       
        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.OrderTypeId > 0)
            {
                db.AddInParameter(cmd, "OrderTypeId", DbType.Int32, this.DataObject.OrderTypeId);
            }
            db.AddInParameter(cmd, "OrderTypeName", DbType.String, this.DataObject.OrderTypeName);
     
        }

        public OrderType GetFromRow(DataRow dr)
        {
            OrderType obj = new OrderType();
            obj.OrderTypeId = Helper.GetData<int>(dr, "OrderTypeId");
            obj.OrderTypeName = Helper.GetData<string>(dr, "OrderTypeName");
           
            return obj;
        }  
    }
}