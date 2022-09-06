using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Sale.Domain;
using App.Sale.Application.Services;
using App.Sale.Infraestructure.Data.Repositories;
using App.Sale.Infraestructure.Data.Contexts;

namespace App.Sale.Infraestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {

        #region [ CREATE SERVICE ]
        static SaleService CreateService()
        {
            SaleContext _db = new SaleContext();
            SaleRepository repositorySale = new SaleRepository(_db);
            ProductRepository productRepository = new ProductRepository(_db);
            SaleDetailRepository saleDetailRepository = new SaleDetailRepository(_db);
            SaleService service = new SaleService(repositorySale, productRepository, saleDetailRepository);

            return service;
        }
        #endregion



        // GET: api/<SaleController>
        [HttpGet]
        public async Task<ActionResult<List<Sales>>> GetAsync()
        {
            var service = CreateService();

            return Ok(await service.Lists());

        }



        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> GetByIdAsync(Guid id)
        {

            var service = CreateService();

            return Ok(await service.SelectByID(id));

        }



        // POST api/<SaleController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Sales sales)
        {

            var service = CreateService();
            await service.Add(sales);

            return Ok("Save sale successfully!");

        }


        // No Exists Function By Edit



        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {

            var service = CreateService();
            await service.Cancel(id);

            return Ok("Cancel sale successfully!");
        }
    }
}
