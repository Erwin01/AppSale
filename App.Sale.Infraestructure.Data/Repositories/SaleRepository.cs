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
    public class SaleRepository : IRepositoryMovement<Sales, Guid>
    {

        #region [ VARIBALES GLOBALS ]
        private SaleContext _db;
        #endregion


        #region [ CONSTRUCTOR ]
        public SaleRepository(SaleContext db)
        {
            _db = db;
        }
        #endregion



        public async Task<Sales> Add(Sales entity)
        {
            entity.SaleId = Guid.NewGuid();
            await _db.Sales.AddAsync(entity);

            return entity;
        }



        public async Task Cancel(Guid entityId)
        {
            var saleSelected = await _db.Sales.Where(s => s.SaleId == entityId).FirstOrDefaultAsync();

            if (saleSelected == null)
            {
                throw new NullReferenceException("You are trying to cancel a sale that does not exist!");
            }

            saleSelected.Cancel = true;
            _db.Entry(saleSelected).State = EntityState.Modified;

        }



        public async Task<List<Sales>> Lists()
        {
            return await _db.Sales.ToListAsync();
        }



        public async Task SaveAllChanges()
        {
            await _db.SaveChangesAsync();
        }

        

        public async Task<Sales> SelectByID(Guid entityId)
        {
            var saleSelected = await _db.Sales.Where(s => s.SaleId == entityId).FirstOrDefaultAsync();

            return saleSelected;
        }
    }
}
