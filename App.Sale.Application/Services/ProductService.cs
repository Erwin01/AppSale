using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Sale.Domain;
using App.Sale.Domain.Interfaces.Repositories;
using App.Sale.Application.Interfaces;

namespace App.Sale.Application.Services
{
    public class ProductService : IServiceBase<Product, Guid>
    {

        private readonly IRepositoryBase<Product, Guid> _repositoryBase;


        #region [ CONSTRUCTOR ]
        public ProductService(IRepositoryBase<Product, Guid> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }



        public async Task<Product> Add(Product entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException("The 'product' is required");
            };

            var resultProduct = await _repositoryBase.Add(entity);
             await _repositoryBase.SaveAllChanges();

            return resultProduct;
        }



        public async Task Delete(Guid entityId)
        {
            await _repositoryBase.Delete(entityId);
            await _repositoryBase.SaveAllChanges();
        }



        public async Task Edit(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("The 'product' is required by edit");
            };

            await _repositoryBase.Edit(entity);
            await _repositoryBase.SaveAllChanges();

        }



        public async Task<List<Product>> Lists()
        {
            return await _repositoryBase.Lists();
        }



        public async Task<Product> SelectByID(Guid entityId)
        {
            return await _repositoryBase.SelectByID(entityId);
        }
        #endregion





    }
}
