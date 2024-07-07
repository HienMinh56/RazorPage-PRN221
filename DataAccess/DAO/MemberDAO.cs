using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MemberDAO
    {
        private readonly SaleManagerContext _context = null;
        private static MemberDAO _instance = null;

        public MemberDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MemberDAO();
                }
                return _instance;
            }
        }

        public MemberDAO()
        {
            _context = new SaleManagerContext();
        }

        public Member LoginMember(string email, string password)
        {
            return _context.Members.SingleOrDefault(m => m.Email == email && m.Password == password);
        }

        public List<Member> GetAllMembers() => _context.Members.ToList();

        public void AddMember(Member member)
        {
            try
            {
                using (var saleManagement = new SaleManagerContext())
                {
                    Member p = saleManagement.Members.FirstOrDefault(item => item.Email.Equals(member.Email));
                    if (p == null)
                    {
                        // Generate new userId
                        int maxUserId = saleManagement.Members.Max(item => (int?)item.MemberId) ?? 0;
                        member.MemberId = maxUserId + 1;

                        saleManagement.Members.Add(member);
                        saleManagement.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("The member already exists");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UpdateMember(Member member)
        {
            Member existingMember = GetMemberById(member.MemberId);
            if (existingMember != null)
            {
                existingMember.Email = member.Email;
                existingMember.Password = member.Password;
                existingMember.City = member.City;
                existingMember.CompanyName = member.CompanyName;
                existingMember.Country = member.Country;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Member not found");
            }
        }
        public void DeleteMember(int id)
        {
            Member member = GetMemberById(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Member not found");
            }
        }

        public Member GetMemberById(int memberId)
        {
            return _context.Members.SingleOrDefault(m => m.MemberId == memberId);
        }
    }
}
