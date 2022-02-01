using Microsoft.EntityFrameworkCore;
using SkeletonNetCore.Models;

namespace SkeletonNetCore.Config
{
    public class ApiDbContext : DbContext
    {
        public DbSet<ProductDto> Products { get; set; }
        public DbSet<ContactDto> Contacts { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

    }
}
