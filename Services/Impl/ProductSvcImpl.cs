using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkeletonNetCore.DAO;
using SkeletonNetCore.Models;
using SkeletonNetCore.Services.Models;

namespace SkeletonNetCore.Services.Impl
{
    public class ProductSvcImpl : ISvc<Product>
    {
        public IDao<ProductDto> productDto;
        public ProductSvcImpl(IDao<ProductDto> _productDto)
        {
            productDto = _productDto;
        }

        public async Task<List<Product>> getAll(string searchQuery)
        {
            IEnumerable<ProductDto> products = await productDto.GetAll();
            return filterProductsBySearchQuery(products, searchQuery);
        }

        public async Task<int> save(Product product)
        {
            ProductDto newProduct = new ProductDto();
            newProduct.name = product.name;
            newProduct.description = product.description;
            newProduct.img = product.img;
            newProduct.review = product.review;
            return await productDto.Save(newProduct);
        }

        public List<Product> filterProductsBySearchQuery(IEnumerable<ProductDto> productsDto, string searchQuery)
        {
            return productsDto.Select(product => new Product
            {
                id = product.id,
                description = product.description,
                img = product.img,
                name = product.name,
                review = product.review
            }).Where(product => product.name.Contains(searchQuery)).ToList();
        }
    }
}