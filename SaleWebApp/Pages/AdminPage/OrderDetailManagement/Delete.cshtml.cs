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

namespace SaleWebApp.Pages.AdminPage.OrderDetailManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public DeleteModel(IOrderRepository orderRepository, IProductRepository productRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;
        //public Order Order { get; set; } = default!;
        //public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _orderDetailRepository.GetAllDetails() == null)
            {
                return NotFound();
            }

            var orderdetail = _orderDetailRepository.GetOrderDetailsByOrderId(id).FirstOrDefault();
            //var order = _orderRepository.GetOrderById(id);
            //var product = _productRepository.GetProductById(orderdetail.ProductId);

            if (orderdetail == null)
            {
                return NotFound();
            }
            else
            {
                //Order = order;
                //Product = product;
                OrderDetail = orderdetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _orderDetailRepository.GetAllDetails() == null)
            {
                return NotFound();
            }
            var orderdetail = _orderDetailRepository.GetOrderDetailsByOrderId(id).FirstOrDefault();

            if (orderdetail != null)
            {
                OrderDetail = orderdetail;
                _orderDetailRepository.DeleteOrderDetail(OrderDetail.OrderId);
            }

            return RedirectToPage("./Index");
        }
    }
}
