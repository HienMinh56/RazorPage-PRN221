using BusinessObject;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleWebApp.Pages.MemberPage.OrderView
{
    public class OrderDetailViewModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;

        public OrderDetailViewModel(IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public OrderDetail OrderDetail { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }

        public IActionResult OnGet(int orderId)
        {
            OrderId = orderId;
            OrderDetail = _orderDetailRepository.GetOrderDetailsByOrderId(orderId).FirstOrDefault();          
            Product = _productRepository.GetProductById(OrderDetail.ProductId);

            if (OrderDetail == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
