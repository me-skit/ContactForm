using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkeletonNetCore.Services;
using SkeletonNetCore.Services.Models;

namespace SkeletonNetCore.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ISvc<Product> productSvc;

        public ProductsController(ISvc<Product> _productSvc)
        {
            //productSvc = new ProductSvcImpl(new ProductDaoImpl(apiDbContext));
            productSvc = _productSvc;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <response code="200">Returns a list of Products</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<List<Product>> Get([FromQuery] string search = "")
        {
            return await productSvc.getAll(search);
        }

        /// <summary>
        /// Creates a Product.
        /// </summary>
        /// <returns>A newly created Product</returns>
        /// <response code="201">Product created</response>
        /// <response code="404">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<int> Post([FromBody] Product product)
        {
            return await productSvc.save(product);
        }
    }
}
