using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccess;
using DataAccess.Repository.IRepository;

namespace SaleWebApp.Pages.AdminPage.OrderManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public DeleteModel(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _orderRepository.GetAllOrders() == null)
            {
                return NotFound();
            }

            var order = _orderRepository.GetOrderById(id);
            var orderDetail = _orderDetailRepository.GetOrderDetailsByOrderId(id).FirstOrDefault();

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
                OrderDetail = orderDetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _orderRepository.GetAllOrders() == null)
            {
                return NotFound();
            }
            var order = _orderRepository.GetOrderById(id);
            var orderDetail = _orderDetailRepository.GetOrderDetailsByOrderId(id).FirstOrDefault();

            if (order != null)
            {
                if (orderDetail != null && orderDetail.OrderId == order.OrderId)
                {
                    OrderDetail = orderDetail;
                    _orderDetailRepository.DeleteOrderDetail(orderDetail.OrderId);
                }
                Order = order;
                _orderRepository.DeleteOrder(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
