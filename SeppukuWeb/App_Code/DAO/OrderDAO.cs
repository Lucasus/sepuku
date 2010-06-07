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

        public void DeleteById(int orderId)
        {
            DAO<OrderDAO, Order>.ExecuteScalar("SepOrderDeleteById", orderId);
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

        public List<Order> GetByFieldEpoch(int epoch, int fieldDest)
        {
            return DAO<OrderDAO, Order>.GetObjectList("SepOrderGetByFieldEpoch", epoch, fieldDest);
        }

        public List<Order> GetByKingdomEpoch(int KindgomId, int epoch)
        {
            return DAO<OrderDAO, Order>.GetObjectList("SepOrderGetCurrentByKingdomId", KindgomId, epoch);
        }

        public Order GetByFieldEpochOrderTypeName(int epoch, int fieldSour, int fieldDest, string orderTypeName)
        {
            return DAO<OrderDAO, Order>.GetSingleObject("SepOrderGetByFieldEpochOrderTypeName", epoch,fieldSour, fieldDest,orderTypeName);
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
            db.AddInParameter(cmd, "Count", DbType.Int32, this.DataObject.Count);
            db.AddInParameter(cmd, "UnitTypeId", DbType.Int32, this.DataObject.UnitTypeId);
            db.AddInParameter(cmd, "KingdomId", DbType.Int32, this.DataObject.KingdomId);
        }

        public Order GetFromRow(DataRow dr)
        {
            Order obj = new Order();
            obj.OrderId = Helper.GetData<int>(dr, "OrderId");
            obj.OrderTypeId = Helper.GetData<int>(dr, "OrderTypeId");
            obj.OrderTypeName = Helper.GetData<string>(dr, "OrderTypeName");
            obj.FieldId = Helper.GetData<int>(dr, "FieldId");
            obj.FieldIdDestination = Helper.GetData<int>(dr, "FieldIdDestination");
            obj.OrderTime = Helper.GetData<DateTime>(dr, "OrderTime");
            obj.Epoch = Helper.GetData<int>(dr, "Epoch");
            obj.Count = Helper.GetData<int>(dr, "Count");
            obj.UnitTypeId = Helper.GetData<int>(dr, "UnitTypeId");
            obj.KingdomId = Helper.GetData<int>(dr, "KingdomId");
            return obj;
        }  
    }
}