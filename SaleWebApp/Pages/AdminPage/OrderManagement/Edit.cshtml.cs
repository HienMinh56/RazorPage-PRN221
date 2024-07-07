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

namespace SaleWebApp.Pages.AdminPage.OrderManagement
{
    public class EditModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        public EditModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _orderRepository.GetAllOrders() == null)
            {
                return NotFound();
            }

            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {                
                // Update other properties as needed
                _orderRepository.UpdateOrder(Order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.OrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            // Redirect to the Index page after a successful update
            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return (_orderRepository.GetAllOrders().Any(e => e.OrderId == id));
        }
    }
}
