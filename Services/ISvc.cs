using System.Collections.Generic;
using System.Threading.Tasks;
using SkeletonNetCore.Services.Models;

namespace SkeletonNetCore.Services
{
    public interface ISvc<T>
    {
        public Task<int> save(T data);
        public Task<List<T>> getAll(string searchQuery);
    }
}