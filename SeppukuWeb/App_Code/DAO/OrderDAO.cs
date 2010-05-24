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
    public class OrderDAO : IDAO<Order>
    {
        public Order DataObject { get; set; }

        public int Add(Order o)
        {
            DataObject = o;
            return DAO<OrderDAO, Order>.Add("SepOrderAdd", this);
        }

        public Order GetById(int orderId)
        {
            return DAO<OrderDAO, Order>.GetSingleObject("SepOrderGetById", orderId);
        }

        public List<Order> GetByAll()
        {
            return DAO<OrderDAO, Order>.GetObjectList("SepOrderGetByAll");
        }

        public List<Order> GetByEpoch(int epoch)
        {
            return DAO<OrderDAO, Order>.GetObjectList("SepOrderGetByEpoch", epoch);
        }


        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.OrderId > 0)
            {
                db.AddInParameter(cmd, "OrderId", DbType.Int32, this.DataObject.OrderId);
            }
            db.AddInParameter(cmd, "OrderTypeId", DbType.Int32, this.DataObject.OrderTypeId);
            db.AddInParameter(cmd, "FieldId", DbType.Int32, this.DataObject.FieldId);
            db.AddInParameter(cmd, "FieldIdDestination", DbType.Int32, this.DataObject.FieldIdDestination);
            db.AddInParameter(cmd, "Epoch", DbType.Int32, this.DataObject.Epoch);
        }

        public Order GetFromRow(DataRow dr)
        {
            Order obj = new Order();
            obj.OrderTypeId = Helper.GetData<int>(dr, "OrderTypeId");
            obj.OrderTypeName = Helper.GetData<string>(dr, "OrderTypeName");
            obj.FieldId = Helper.GetData<int>(dr, "FieldId");
            obj.FieldIdDestination = Helper.GetData<int>(dr, "FieldIdDestination");
            obj.OrderTime = Helper.GetData<DateTime>(dr, "OrderTime");
            obj.Epoch = Helper.GetData<int>(dr, "Epoch");

            return obj;
        }  
    }
}