using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.MongoDb;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/{version:apiVersion}/[Controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(ICatalogContext catalogContext, IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ApiVersion("1.0")]
        [Route("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return Ok( await _productRepository.GetAllProducts());
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ApiVersion("1.0")]
        [Route("GetProductByID")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct(string Id)
        {
            return Ok(await _productRepository.GetProductsById(Id));
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("Add")]
        public async Task<ActionResult> AddProduct(Product product)
        {
            await _productRepository.CreateProduct(product);
            return Ok();
        }

    }
}
