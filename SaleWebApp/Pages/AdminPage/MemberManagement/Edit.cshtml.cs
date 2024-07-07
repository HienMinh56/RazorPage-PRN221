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

namespace SaleWebApp.Pages.AdminPage.MemberManagement
{
    public class EditModel : PageModel
    {
        private readonly IMemberRepository _memberRepository = null;

        public EditModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [BindProperty]
        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _memberRepository.GetAllMembers() == null)
            {
                return NotFound();
            }

            var member = _memberRepository.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }
            Member = member;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _memberRepository.UpdateMember(Member);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(Member.MemberId))
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

        private bool MemberExists(int id)
        {
          return (_memberRepository.GetAllMembers().Any(e => e.MemberId == id));
        }
    }
}
