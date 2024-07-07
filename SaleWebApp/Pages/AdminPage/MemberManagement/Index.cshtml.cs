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
    public class IndexModel : PageModel
    {
        private readonly IMemberRepository _memberRepository = null;

        public IndexModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_memberRepository.GetAllMembers() != null)
            {
               Member = _memberRepository.GetAllMembers();
            }
        }
    }
}
