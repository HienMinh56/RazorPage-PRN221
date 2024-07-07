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

namespace SaleWebApp.Pages.AdminPage.OrderManagement
{
    public class CreateModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMemberRepository _memberRepository;

        public CreateModel(IOrderRepository orderRepository, IMemberRepository memberRepository)
        {
            _orderRepository = orderRepository;
            _memberRepository = memberRepository;
        }

        public IActionResult OnGet()
        {
        ViewData["MemberId"] = new SelectList(_memberRepository.GetAllMembers(), "MemberId", "Email");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        public Member Member { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_orderRepository.GetAllOrders() == null || Order == null)
            {
                return Page();
            }

            _orderRepository.AddOrder(Order);

            return RedirectToPage("./Index");
        }
    }
}
