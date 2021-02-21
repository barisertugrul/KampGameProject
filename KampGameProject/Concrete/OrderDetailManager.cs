using KampGameProject.Abstract;
using KampGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KampGameProject.Concrete
{
    public class OrderDetailManager : BaseTableOperationsManager<OrderDetail>
    {
        private IDbAdapterService<OrderDetail> _dbService;

        public OrderDetailManager(IDbAdapterService<OrderDetail> dbService) : base(dbService)
        {
            _dbService = dbService;
        }

        public List<OrderDetail> DetailsOfOrder(int orderId)
        {
            List<OrderDetail> orderDetailsList = _dbService.GetList().Where(o => o.OrderId == orderId).ToList();
            return orderDetailsList;
        }

        public override void ConsoleMenu()
        {
            throw new NotImplementedException();
        }

        public override void ConsoleAddForm()
        {
            throw new NotImplementedException();
        }

        public override void ConsoleUpdateForm()
        {
            throw new NotImplementedException();
        }

        public override void ConsoleDeleteForm()
        {
            throw new NotImplementedException();
        }

        public override void ConsoleListView()
        {
            throw new NotImplementedException();
        }
    }
}
