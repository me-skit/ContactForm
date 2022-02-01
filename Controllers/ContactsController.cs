using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkeletonNetCore.Services;
using SkeletonNetCore.Services.Models;

namespace SkeletonNetCore.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ISvc<Contact> contactSvc;

        public ContactsController(ISvc<Contact> _contactSvc)
        {
            //productSvc = new ProductSvcImpl(new ProductDaoImpl(apiDbContext));
            contactSvc = _contactSvc;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <response code="200">Returns a list of Products</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<List<Contact>> Get([FromQuery] string search = "")
        {
            return await contactSvc.getAll(search);
        }

        /// <summary>
        /// Creates a Contact.
        /// </summary>
        /// <returns>A newly created Contact</returns>
        /// <response code="201">Contact created</response>
        /// <response code="404">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<int> Post([FromBody] Contact Contact)
        {
            return await contactSvc.save(Contact);
        }
    }
}
