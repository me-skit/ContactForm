using System.Collections.Generic;
using System.Threading.Tasks;
using SkeletonNetCore.Models;


namespace SkeletonNetCore.DAO
{
    public interface IDao<T>
    {
        public Task<int> Save(T data);
        public Task<List<T>> GetAll();
    }
}