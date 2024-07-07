using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccess;
using DataAccess.Repository.IRepository;

namespace SaleWebApp.Pages.AdminPage.OrderDetailManagement
{
    public class EditModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        //private readonly IOrderRepository _orderRepository;
        //private readonly IProductRepository _productRepository;
        public EditModel(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _orderDetailRepository.GetAllDetails() == null)
            {
                return NotFound();
            }

            var orderDetail = _orderDetailRepository.GetOrderDetailsByOrderId(id).FirstOrDefault();
            if (orderDetail == null)
            {
                return NotFound();
            }
            OrderDetail = orderDetail;            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {            
            try
            {
                _orderDetailRepository.UpdateOrderDetail(OrderDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(OrderDetail.OrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderDetailExists(int id)
        {
            return (_orderDetailRepository.GetAllDetails().Any(e => e.OrderId == id));
        }
    }
}
