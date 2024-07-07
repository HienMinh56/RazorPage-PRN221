using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        private readonly SaleManagerContext _context = null;
        private OrderDetailDAO instance = null;
        public OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }
        public OrderDetailDAO()
        {
            _context = new SaleManagerContext();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }
        public List<OrderDetail> GetAllDetails()
        {
            return _context.OrderDetails.ToList();
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            OrderDetail existingOrderDetail = GetOrderDetailsByOrderId(orderDetail.OrderId).FirstOrDefault();
            if (existingOrderDetail != null)
            {
                existingOrderDetail.Quantity = orderDetail.Quantity;
                existingOrderDetail.UnitPrice = orderDetail.UnitPrice;
                existingOrderDetail.Discount = orderDetail.Discount;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Order detail not found");
            }
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }
        public void DeleteOrderDetail(int id)
        {
            var orderDetail = GetOrderDetailsByOrderId(id).FirstOrDefault();
            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();
        }
    }
}
