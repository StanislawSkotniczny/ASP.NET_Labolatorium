using Data.Entities;
using Laboratorium_3.Models;
using Laboratorium_3.Models;
using Microsoft.EntityFrameworkCore;
//using Laboratorium_33.Models;
using System.Reflection;

namespace Laboratorium_3.Models
{
    public class MemoryContactService : IContactService 
    {
        private Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>()
        {
            {1, new Contact() {Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "123345667", Priority = Priority.Urgent, Created = DateTime.Now,  }}
        };
        private int id = 2;

        private readonly IDateTimeProvider _timeProvider;
        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public int Add(Contact model)
        {
            model.Created = _timeProvider.Now();
            model.Id = id++;
            _contacts[model.Id] = model;
            return model.Id;

        }

        public void DeleteById(int id)
        {
            _contacts.Remove(id);
        }

        public List<Contact> FindAll()
        {
            return _contacts.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _contacts[id];
        }

        public void Update(Contact contact)
        {
            if (_contacts.ContainsKey(contact.Id))
            {
                _contacts[contact.Id] = contact;
            }
        }


        public List<OrganizationEntity> FindAllOrganizations()
        {
            //throw new NotImplementedException();
            return _contacts.Values
         .Select(contact => new OrganizationEntity
         {
             Id = contact.Id, // Assuming there is a mapping between Contact Id and OrganizationEntity Id
             Name = contact.Name // Assuming there is a mapping between Contact Name and OrganizationEntity Name
                                  // Map other properties accordingly
         })
         .ToList();
        }

        public PagingList<Contact> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }
    }
}
