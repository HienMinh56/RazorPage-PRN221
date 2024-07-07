using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        public List<OrderDetail> GetAllDetails();
        public void UpdateOrderDetail(OrderDetail orderDetail);
        public void AddOrderDetail(OrderDetail orderDetail);
        public void DeleteOrderDetail(int orderId);
    }
}
