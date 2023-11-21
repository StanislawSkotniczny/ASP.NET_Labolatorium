using Data;
using Data.Entities;
using Laboratorium_3.Models;

namespace Labolatorium_3.Models
{
    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Contact contact)
        {
            var e = _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
            return e.Entity.ContactId;
        }


        public void DeleteById(int id)
        {
            ContactEntity? find = _context.Contacts.Find(id);
            if (find != null)
            {
                _context.Contacts.Remove(find);
            }
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList(); ;
        }

        public List<OrganizationEntity> FindAllOrganizations()
        {
            return _context.Organizations.ToList();
        }

        public Contact? FindById(int id)
        {
            return ContactMapper.FromEntity(_context.Contacts.Find(id));
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));
        }
    }
}
