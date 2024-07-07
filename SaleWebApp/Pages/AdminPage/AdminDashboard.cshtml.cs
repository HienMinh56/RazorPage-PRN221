using BusinessObject;
using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlTypes;

namespace SaleWebApp.Pages.AdminPage
{
    public class AdminDashboardModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;

        public AdminDashboardModel(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        [BindProperty]
        public List<Order> Orders { get; set; } = default!;
        [BindProperty]
        public List<OrderDetail> OrderDetails { get; set; } = default!;
        [BindProperty]
        public List<Product> Products { get; set; } = default!;

        public IActionResult OnGet(DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue && endDate.HasValue)
            {
                Orders = _orderRepository.GetOrderByPeriod(startDate.Value, endDate.Value);
                OrderDetails = _orderDetailRepository.GetAllDetails();
                Products = _productRepository.GetAllProducts();
            }

            return Page();
        }
    }
}
