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
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public IndexModel(IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        [BindProperty]
        public IList<OrderDetail> OrderDetail { get;set; } = default!;
        [BindProperty]
        public IList<Order> Order { get; set; } = default!;
        [BindProperty]
        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_orderDetailRepository.GetAllDetails() != null)
            {
                OrderDetail = _orderDetailRepository.GetAllDetails();
                Order = _orderRepository.GetAllOrders();
                Product = _productRepository.GetAllProducts();
            }
        }
    }
}
