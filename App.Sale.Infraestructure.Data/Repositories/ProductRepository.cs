
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Sale.Domain;
using App.Sale.Domain.Interfaces.Repositories;
using App.Sale.Infraestructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace App.Sale.Infraestructure.Data.Repositories
{
    public class ProductRepository : IRepositoryBase<Product, Guid>
    {

        #region [ VARIBALES GLOBALS ]
        private SaleContext _db;
        #endregion


        #region [ CONSTRUCTOR ]
        public ProductRepository(SaleContext db)
        {
            _db = db;
        }
        #endregion



        public async Task<Product> Add(Product entity)
        {
            entity.ProductId = Guid.NewGuid();
            await _db.Products.AddAsync(entity);

            return entity;
        }



        public async Task Delete(Guid entityId)
        {
            var productSelected = await _db.Products.Where(p => p.ProductId == entityId).FirstOrDefaultAsync();

            if (productSelected != null)
            {
                _db.Products.Remove(productSelected);
            }
        }



        public async Task Edit(Product entity)
        {
            var productSelected = await _db.Products.Where(p => p.ProductId == entity.ProductId).FirstOrDefaultAsync();

            if (productSelected != null)
            {
                productSelected.Name = entity.Name;
                productSelected.Description = entity.Description;
                productSelected.Cost = entity.Cost;
                productSelected.Price = entity.Price;
                productSelected.QuantityInStock = entity.QuantityInStock;

                _db.Entry(productSelected).State = EntityState.Modified;
            }
        }



        public async Task<List<Product>> Lists()
        {
            return await _db.Products.ToListAsync();
        }



        public async Task SaveAllChanges()
        {
            await _db.SaveChangesAsync();
        }



        public async Task<Product> SelectByID(Guid entityId)
        {
            var productSelected = await _db.Products.Where(p => p.ProductId == entityId).FirstOrDefaultAsync();

            return productSelected;

        }


    }
}
