using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        List<Order> GetOrdersByMemberId(int memberId);
        List<Order> GetOrderByPeriod(DateTime startDate, DateTime endDate);
    }
}
