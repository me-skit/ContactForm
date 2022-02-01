using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkeletonNetCore.DAO;
using SkeletonNetCore.Models;
using SkeletonNetCore.Services.Models;

namespace SkeletonNetCore.Services.Impl
{
    public class ContactSvcImpl : ISvc<Contact>
    {
        public IDao<ContactDto> ContactDto;
        public ContactSvcImpl(IDao<ContactDto> _productDto)
        {
            ContactDto = _productDto;
        }

        public async Task<List<Contact>> getAll(string searchQuery)
        {
            IEnumerable<ContactDto> contacts = await ContactDto.GetAll();
            return filterProductsBySearchQuery(contacts, searchQuery);
        }

        public async Task<int> save(Contact contact)
        {
            ContactDto newContact = new ContactDto();
            newContact.firstName = contact.strFirstName;
            newContact.lastName = contact.strLastName;
            newContact.company = contact.strCompany;
            newContact.phoneNumber = contact.strPhoneNumber;
            newContact.email = contact.strEmail;
            return await ContactDto.Save(newContact);
        }

        public List<Contact> filterProductsBySearchQuery(IEnumerable<ContactDto> contacts, string searchQuery)
        {
            return contacts.Select(contact => new Contact
            {
                intId = contact.id,
                strFirstName = contact.firstName,
                strLastName = contact.lastName,
                strCompany = contact.company,
                strPhoneNumber = contact.phoneNumber,
                strEmail = contact.email
            }).Where(product => product.strFirstName.Contains(searchQuery)).ToList();
        }
    }
}