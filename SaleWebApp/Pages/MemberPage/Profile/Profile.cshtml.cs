using BusinessObject;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleWebApp.Pages.MemberPage.Profile
{
    public class ProfileModel : PageModel
    {
        private readonly IMemberRepository _memberRepository;

        public ProfileModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Member Member { get; set; }

        public IActionResult OnGet()
        {
            // Get the logged-in user's username
            var memberId = HttpContext.Session.GetInt32("MemberId");

            // Retrieve the member details using the username
            Member = _memberRepository.GetMemberById(memberId.Value);

            if (Member == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
