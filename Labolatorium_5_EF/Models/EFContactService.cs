using Data;

namespace Labolatorium_5_EF.Models
{
    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Contact model)
        {
            _context.Contacts.Add(ContactMapper.ToEntity(model));
            _context.SaveChanges();
            return e.Entity.ContactId;
        }

        public void DeleteById(int id)
        {
            var find = _context.Contacts.Find(id);
            if(find is not null)
            {
                _context.Contacts.Remove(find);
                _context.SaveChanges();
            }
            

        }

        public List<Contact> FindAll()
        {
            return _context
                .Contacts.
                Select(e => ContactMapper.FromEntity(e))
                .ToList();
        }

        public Contact FindById(int id)
        {
            var find = _context.Contacts.Find(id);
            return  find is null ? null : ContactMapper.FromEntity(find);

        }

        public void Update(Contact model)
        {
            var entity = ContactMapper.ToEntity(model);
            _context.Contacts.Update(entity);
        }
    }
}
