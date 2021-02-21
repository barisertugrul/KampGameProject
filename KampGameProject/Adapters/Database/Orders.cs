using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KampGameProject.Adapters.Database
{
    public class Orders : IDbAdapterService<Order>
    {
        private List<Order> _orders;

        public Orders()
        {
            //Normalde Veritabanındaki veriler burada listeye ekleniyor
            //Aşağıdaki işlem veritabanının boş olması durumunu simgeliyor
            _orders = new List<Order>();
        }
        public void Add(Order order)
        {
            order.OrderId = LastIndex() + 1;
            _orders.Add(order);
            Console.WriteLine("The order has been successfully added");
        }

        public void Delete(Order order)
        {
            Order currentOrder = _orders.SingleOrDefault(o => o.OrderId == order.OrderId);
            _orders.Remove(currentOrder);
        }

        public Order GetById(int orderId)
        {
            return _orders.SingleOrDefault(o => o.OrderId == orderId);
        }

        public List<Order> GetList()
        {
            return _orders;
        }

        public void Update(Order order)
        {
            Order currentOrder = _orders.SingleOrDefault(o => o.OrderId == order.OrderId);
            currentOrder.GamerId = order.GamerId;
            currentOrder.OrderDate = order.OrderDate;
        }

        public int LastIndex()
        {
            if (_orders.Count > 0)
            {
                Order order = _orders[_orders.Count - 1];
                return order.OrderId;
            }
            else
            {
                return 0;
            }
        }
    }
}
