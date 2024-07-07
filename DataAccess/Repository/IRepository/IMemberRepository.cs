using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IMemberRepository
    {
        Member LoginMember(string email, string password);
        List<Member> GetAllMembers();
        Member GetMemberById(int id);
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);
    }
}
