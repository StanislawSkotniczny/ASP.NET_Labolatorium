using Laboratorium_3.Models;
//using Laboratorium_33.Models;
using System.Reflection;

namespace Laboratorium_3.Models
{
    public class MemoryContactService : IContactService 
    {
        private Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>()
        {
            {1, new Contact() { Name = "adam" , Email="adada2@.pl" , Phone="112312313412312" , Priority = Priority.Normal } }
        };
        private int id = 2;

        private readonly IDateTimeProvider _timeProvider;

        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }


        public int Add(Contact model)
        {
            model.Created = _timeProvider.GetDateTime();
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

        public Contact FindById(int id)
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
    }
}
