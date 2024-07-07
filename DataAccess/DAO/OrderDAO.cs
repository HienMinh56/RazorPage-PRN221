using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        private readonly SaleManagerContext _context = null;
        private OrderDAO _instance = null;
        public OrderDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderDAO();
                }
                return _instance;
            }
        }
        public OrderDAO()
        {
            _context = new SaleManagerContext();
        }

        public List<Order> GetAllOrders() => _context.Orders.ToList();
        public Order GetOrderById(int id) => _context.Orders.SingleOrDefault(o => o.OrderId == id);
        public void AddOrder(Order order)
        {
            try
            {
                using (var saleManagement = new SaleManagerContext())
                {
                    // Tìm OrderId lớn nhất
                    int maxOrderId = saleManagement.Orders.Max(o => (int?)o.OrderId) ?? 0;

                    // Tạo OrderId mới
                    order.OrderId = maxOrderId + 1;

                    // Kiểm tra xem OrderId đã tồn tại chưa
                    Order existingOrder = saleManagement.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
                    if (existingOrder == null)
                    {
                        saleManagement.Orders.Add(order);
                        saleManagement.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("The order with the generated OrderId already exists.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding order: " + e.Message);
            }
        }
        public void UpdateOrder(Order order)
        {
            Order existingOrder = GetOrderById(order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.RequiredDate = order.RequiredDate;
                existingOrder.ShippedDate = order.ShippedDate;
                existingOrder.Freight = order.Freight;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Order not found");
            }
        }
        public void DeleteOrder(int id)
        {
            Order order = GetOrderById(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Order not found");
            }
        }

        public List<Order> GetOrdersByMemberId(int memberId) => _context.Orders.Where(o => o.MemberId == memberId).ToList();

        public List<Order> GetOrdersByPeriod(DateTime startDate, DateTime endDate)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .OrderByDescending(o => o.OrderDetails.Sum(od => (decimal)od.Quantity * od.UnitPrice * (decimal)(1 - od.Discount)))
                .ToList();
        }
    }
}
