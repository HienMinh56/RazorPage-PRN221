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
    public class IndexModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMemberRepository _memberRepository;

        public IndexModel(IOrderRepository orderRepository, IMemberRepository memberRepository)
        {
            _orderRepository = orderRepository;
            _memberRepository = memberRepository;
        }

        public List<Order> Order { get;set; } = default!;
        public List<Member> Member { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_orderRepository != null)
            {
                Order = _orderRepository.GetAllOrders();
                Member = _memberRepository.GetAllMembers();                
            }
        }
    }
}
