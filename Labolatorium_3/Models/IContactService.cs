using Data.Entities;
using Laboratorium_3.Models;
using Laboratorium_3.Models;
using System.Xml.Serialization;

namespace Laboratorium_3.Models
{
    public interface IContactService
    {
        int Add(Contact contact);
         
        Contact? FindById(int id);

        List <Contact> FindAll();

        void DeleteById (int id);

        void Update(Contact contact);

        List<OrganizationEntity> FindAllOrganizations();

        PagingList<Contact> FindPage(int page, int size);

    }
}
