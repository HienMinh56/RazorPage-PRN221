using BusinessObject;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleWebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get; set; }

        private readonly IMemberRepository _memberRepository = null;
        private readonly IConfiguration _configuration;

        public LoginModel(IMemberRepository memberRepository, IConfiguration configuration)
        {
            _memberRepository = memberRepository;
            _configuration = configuration;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (Email == _configuration["AdminAccount:Email"] &&
                Password == _configuration["AdminAccount:Password"])
            {
                HttpContext.Session.SetString("UserRole", "Admin");
                return Redirect("AdminPage/AdminDashboard");
            }

            Member member = _memberRepository.LoginMember(Email, Password);
            if (member != null)
            {
                HttpContext.Session.SetString("UserRole", "Member");
                HttpContext.Session.SetString("Email", member.Email);
                HttpContext.Session.SetString("Password", member.Password);
                HttpContext.Session.SetInt32("MemberId", member.MemberId);
                return Redirect("MemberPage/Profile/Profile");
            }
            else
            {
                TempData["LoginFailMessage"] = "Login failed. Please try again.";
                return Redirect("Login");
            }
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}
