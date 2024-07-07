using BusinessObject;
using DataAccess.DAO;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberDAO _memberDAO = null;
        public MemberRepository()
        {
            if (_memberDAO == null) 
            {
                _memberDAO = new MemberDAO();
            }
        }

        public void AddMember(Member member)
        {
            _memberDAO.AddMember(member);
        }

        public void DeleteMember(int id)
        {
            _memberDAO.DeleteMember(id);
        }

        public List<Member> GetAllMembers()
        {
            return _memberDAO.GetAllMembers();
        }

        public Member GetMemberById(int id)
        {
            return _memberDAO.GetMemberById(id);
        }

        public Member LoginMember(string email, string password)
        {
            return _memberDAO.LoginMember(email, password);
        }

        public void UpdateMember(Member member)
        {
            _memberDAO.UpdateMember(member);
        }
    }
}
