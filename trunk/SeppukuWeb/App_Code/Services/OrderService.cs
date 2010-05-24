using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;
using Seppuku.Domain;

namespace Seppuku.Services
{
    public class OrderService
    {
        public int Add(Order o)
        {
            return new OrderDAO().Add(o);
        }

        public Order GetById(int orderId)
        {
            return new OrderDAO().GetById(orderId);
        }

        public IList<Order> GetByEpoch(int epoch)
        {
            return new OrderDAO().GetByEpoch(epoch);
        }

    }
}