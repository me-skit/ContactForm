

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkeletonNetCore.Config;
using SkeletonNetCore.Models;

namespace SkeletonNetCore.DAO.Impl
{
    public class ContactDaoImpl : IDao<ContactDto>
    {
        ApiDbContext apiDbContext;
        public ContactDaoImpl(ApiDbContext _apiDbContext)
        {
            apiDbContext = _apiDbContext;
        }

        public async Task<List<ContactDto>> GetAll()
        {
            //return await Task.FromResult(new List<ProductDto>());
            return await apiDbContext.Contacts.ToListAsync();
        }

        public async Task<int> Save(ContactDto contact)
        {
            apiDbContext.Add(contact);
            return await apiDbContext.SaveChangesAsync();
            //return await Task.FromResult(1);
        }
    }
}