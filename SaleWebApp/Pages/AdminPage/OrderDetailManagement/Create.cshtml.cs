using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using DataAccess;
using DataAccess.Repository.IRepository;

namespace SaleWebApp.Pages.AdminPage.OrderDetailManagement
{
    public class CreateModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        //private readonly IOrderRepository _orderRepository;
        //private readonly IProductRepository _productRepository;
        public CreateModel(/*IOrderRepository orderRepository, IProductRepository productRepository,*/ IOrderDetailRepository orderDetailRepository)
        {
            //_orderRepository = orderRepository;
            //_productRepository = productRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_orderDetailRepository.GetAllDetails() == null || OrderDetail == null)
            {
                return Page();
            }

            _orderDetailRepository.AddOrderDetail(OrderDetail);

            return RedirectToPage("./Index");
        }
    }
}
