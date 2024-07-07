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
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _orderDAO = null;
        public OrderRepository()
        {
            if (_orderDAO == null)
            {
                _orderDAO = new OrderDAO();
            }
        }

        public void AddOrder(Order order)
        {
            _orderDAO.AddOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _orderDAO.DeleteOrder(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderDAO.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return _orderDAO.GetOrderById(id);
        }

        public void UpdateOrder(Order order)
        {
            _orderDAO.UpdateOrder(order);
        }
        public List<Order> GetOrdersByMemberId(int memberId)
        {
            return _orderDAO.GetOrdersByMemberId(memberId);
        }
        public List<Order> GetOrderByPeriod(DateTime startDate, DateTime endDate)
        {
            return _orderDAO.GetOrdersByPeriod(startDate, endDate);
        }
    }
}
