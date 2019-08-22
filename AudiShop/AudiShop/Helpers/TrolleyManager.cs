using AudiShop.DataAccess;
using AudiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.Helpers
{
    public class TrolleyManager
    {
        private AudiContext _db;
        private ISessionManager _session;
        public TrolleyManager(ISessionManager session, AudiContext db)
        {
            _session = session;
            _db = db;
        }

        public List<PositionTrolley> GetTrolley()
        {
            //If trolley is empty it gets new trolley.
            if (_session.Get<List<PositionTrolley>>(Consts.TrolleySessionKey) == null)
            {
                return new List<PositionTrolley>();
            }

            //It gets current trolley.
            return _session.Get<List<PositionTrolley>>(Consts.TrolleySessionKey) as List<PositionTrolley>;
        }

        public void AddToTrolley(int modelID)
        {
            List<PositionTrolley> trolley = GetTrolley();
            PositionTrolley positionTrolley = trolley.Find(t => t.Model.ModelID == modelID);

            if (positionTrolley != null)
                positionTrolley.Count++;
            else
            {
                var modelToAdd = _db.Models.Where(m => m.ModelID == modelID).SingleOrDefault();

                if (modelToAdd != null)
                {
                    var newPositionTrolley = new PositionTrolley()
                    {
                        Model = modelToAdd,
                        Count = 1,
                        Value = modelToAdd.Price
                    };

                    trolley.Add(newPositionTrolley);
                }
            }

            _session.Set(Consts.TrolleySessionKey, trolley);
        }

        public int RemoveFromTrolley(int modelID)
        {
            var trolley = GetTrolley();
            var positionTrolley = trolley.Find(t => t.Model.ModelID == modelID);

            if (positionTrolley != null)
            {
                if (positionTrolley.Count > 1)
                {
                    positionTrolley.Count--;

                    return positionTrolley.Count;
                }

                trolley.Remove(positionTrolley);
            }

            return 0;
        }

        public decimal GetValueOfTrolley()
        {
            return GetTrolley().Sum(t => t.Count * t.Value);
        }

        public int GetCountOfTrolley()
        {
            return GetTrolley().Sum(t => t.Count);
        }

        public Order CreateOrder(Order newOrder, string userID)
        {
            var trolley = GetTrolley();

            newOrder.CreatedDate = DateTime.Now;
            //newOrder.userID = userID;

            _db.Orders.Add(newOrder);

            if (newOrder.OrderDetails == null)
                newOrder.OrderDetails = new List<OrderDetail>();

            decimal valueOfTrolley = 0;

            foreach(var item in trolley)
            {
                var newOrderDetail = new OrderDetail()
                {
                    ModelID = item.Model.ModelID,
                    Amount = item.Count,
                    PriceValue = item.Model.Price
                };

                valueOfTrolley += item.Count * item.Model.Price;
                newOrder.OrderDetails.Add(newOrderDetail);
            }

            newOrder.Value = valueOfTrolley;
            _db.SaveChanges();

            return newOrder;
        }

        public void EmptyTrolley()
        {
            _session.Set<List<PositionTrolley>>(Consts.TrolleySessionKey, null);
        }
    }
}