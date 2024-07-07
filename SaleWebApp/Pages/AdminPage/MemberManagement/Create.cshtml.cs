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

namespace SaleWebApp.Pages.AdminPage.MemberManagement
{
    public class CreateModel : PageModel
    {
        private readonly IMemberRepository _memberRepository = null;

        public CreateModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _memberRepository.GetAllMembers() == null || Member == null)
            {
                return Page();
            }

            _memberRepository.AddMember(Member);

            return RedirectToPage("./Index");
        }
    }
}
