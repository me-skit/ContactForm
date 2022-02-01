

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkeletonNetCore.Config;
using SkeletonNetCore.Models;

namespace SkeletonNetCore.DAO.Impl
{
    public class ProductDaoImpl : IDao<ProductDto>
    {
        ApiDbContext apiDbContext;
        public ProductDaoImpl(ApiDbContext _apiDbContext)
        {
            apiDbContext = _apiDbContext;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            //return await Task.FromResult(new List<ProductDto>());
            return await apiDbContext.Products.ToListAsync();
        }

        public async Task<int> Save(ProductDto user)
        {
            apiDbContext.Add(user);
            return await apiDbContext.SaveChangesAsync();
            //return await Task.FromResult(1);
        }
    }
}