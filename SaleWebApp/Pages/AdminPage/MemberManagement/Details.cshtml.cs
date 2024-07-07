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

namespace SaleWebApp.Pages.AdminPage.MemberManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IMemberRepository _memberRepository = null;
        public DetailsModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

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
            else
            {
                Member = member;
            }
            return Page();
        }
    }
}
