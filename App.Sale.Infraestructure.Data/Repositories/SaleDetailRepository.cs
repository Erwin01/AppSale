using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Sale.Domain;
using App.Sale.Domain.Interfaces.Repositories;
using App.Sale.Infraestructure.Data.Contexts;


namespace App.Sale.Infraestructure.Data.Repositories
{
    public class SaleDetailRepository : IRepositoryDetail<SaleDetail, Guid>
    {

        #region [ VARIBALES GLOBALS ]
        private SaleContext _db;
        #endregion


        #region [ CONSTRUCTOR ]
        public SaleDetailRepository(SaleContext db)
        {
            _db = db;
        }
        #endregion



        public async Task<SaleDetail> Add(SaleDetail entity)
        {
            await _db.SaleDetails.AddAsync(entity);

            return entity;
        }



        public async Task SaveAllChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
