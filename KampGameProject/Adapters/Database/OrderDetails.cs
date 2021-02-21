using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KampGameProject.Adapters.Database
{
    public class OrderDetails : IDbAdapterService<OrderDetail>
    {
        private List<OrderDetail> _orderDetails;

        public OrderDetails()
        {
            //Normalde Veritabanındaki veriler burada listeye ekleniyor
            //Aşağıdaki işlem veritabanının boş olması durumunu simgeliyor
            _orderDetails = new List<OrderDetail>();
        }
        public void Add(OrderDetail orderDetail)
        {
            orderDetail.OrderDetailId = LastIndex() + 1;
            _orderDetails.Add(orderDetail);
            Console.WriteLine("The order detail has been successfully added");
        }

        public void Delete(OrderDetail orderDetail)
        {
            OrderDetail currentDetail = _orderDetails.SingleOrDefault(o => o.OrderDetailId == orderDetail.OrderDetailId);
            _orderDetails.Remove(currentDetail);
        }

        public OrderDetail GetById(int orderDetailId)
        {
            return _orderDetails.SingleOrDefault(o => o.OrderDetailId == orderDetailId);
        }

        public List<OrderDetail> GetList()
        {
            return _orderDetails;
        }

        public void Update(OrderDetail orderDetail)
        {
            OrderDetail currentOrderDetail = _orderDetails.SingleOrDefault(o => o.OrderDetailId == orderDetail.OrderDetailId);
            currentOrderDetail.OrderId = orderDetail.OrderId;
            currentOrderDetail.GameId = orderDetail.GameId;
            currentOrderDetail.Quantity = orderDetail.Quantity;
            currentOrderDetail.UnitPrice = orderDetail.UnitPrice;
        }

        public int LastIndex()
        {
            if (_orderDetails.Count > 0)
            {
                OrderDetail orderDetail = _orderDetails[_orderDetails.Count - 1];
                return orderDetail.OrderDetailId;
            }
            else
            {
                return 0;
            }
        }
    }
}
