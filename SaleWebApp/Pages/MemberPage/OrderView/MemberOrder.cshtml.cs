using BusinessObject;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleWebApp.Pages.MemberPage.OrderView
{
    public class MemberOrderModel : PageModel
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IMemberRepository _memberRepository;

        public MemberOrderModel(IOrderRepository orderRepository, IMemberRepository memberRepository)
        {
            _orderRepository = orderRepository;
            _memberRepository = memberRepository;
        }

        public List<Order> Orders { get; set; }
        public Member Member { get; set; }

        public IActionResult OnGet(int memberId)
        {
            var Email = HttpContext.Session.GetString("Email");
            var Password = HttpContext.Session.GetString("Password");

            // Retrieve the member details using the username
            Member = _memberRepository.LoginMember(Email, Password);
            // Retrieve the orders for the specified member ID
            Orders = _orderRepository.GetOrdersByMemberId(Member.MemberId);

            if (Orders == null)
            {
                return NotFound();
            }

            return Page();

        }
    }
}
