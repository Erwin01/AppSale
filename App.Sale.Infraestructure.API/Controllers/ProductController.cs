using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Sale.Domain.Interfaces.Repositories;

using App.Sale.Domain;
using App.Sale.Application.Services;
using App.Sale.Infraestructure.Data.Repositories;
using App.Sale.Infraestructure.Data.Contexts;

namespace App.Sale.Infraestructure.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        #region [ CREATE SERVICE ]
        static ProductService CreateService()
        {
            SaleContext _db = new SaleContext();
            ProductRepository repository = new ProductRepository(_db);
            ProductService service = new ProductService(repository);

            return service;
        }
        #endregion


        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAsync()
        {

            var service = CreateService();

            return Ok(await service.Lists());
        }



        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetByIdAsync(Guid id)
        {

            var service = CreateService();

            return Ok(await service.SelectByID(id));
        }



        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Product product)
        {

            var service = CreateService();
            await service.Add(product);

            return Ok("Successfully!");
        }



        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromBody] Product product)
        {

            var service = CreateService();
            product.ProductId = id;
            await service.Edit(product);

            return Ok("Edited successfully!");

        }



        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {

            var service = CreateService();
            await service.Delete(id);

            return Ok("Deleted successfully!");
        }
    }
}
