using BusinessObject;
using DataAccess.DAO;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderDetailDAO _orderDetailDAO = null;
        public OrderDetailRepository()
        {
            if (_orderDetailDAO == null)
            {
                _orderDetailDAO = new OrderDetailDAO();
            }
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailDAO.AddOrderDetail(orderDetail);
        }

        public void DeleteOrderDetail(int orderId)
        {
            _orderDetailDAO.DeleteOrderDetail(orderId);
        }

        public List<OrderDetail> GetAllDetails()
        {
            return _orderDetailDAO.GetAllDetails();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _orderDetailDAO.GetOrderDetailsByOrderId(orderId);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailDAO.UpdateOrderDetail(orderDetail);
        }
    }
}
