using App.Sale.Application.Interfaces;
using App.Sale.Domain;
using App.Sale.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Application.Services
{
    public class SaleService : IServiceMovement<Sales, Guid>
    {

        #region [ VARIABLES GLOBALS ]
        IRepositoryMovement<Sales, Guid> _repositorySale;
        IRepositoryBase<Product, Guid> _repositoryProduct;
        IRepositoryDetail<SaleDetail, Guid> _repositoryDetail;
        #endregion



        #region [ CONSTRUCTOR ]
        public SaleService(IRepositoryMovement<Sales, Guid> repositorySale, IRepositoryBase<Product, Guid> repositoryProduct, IRepositoryDetail<SaleDetail, Guid> repositoryDetail)
        {
            _repositorySale = repositorySale;
            _repositoryProduct = repositoryProduct;
            _repositoryDetail = repositoryDetail;
        }
        #endregion


        public async Task<Sales> Add(Sales entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException("The 'sale' is required");
            };

            var saleAdd = await _repositorySale.Add(entity);

            entity.SaleDetails.ForEach(detail =>
            {
                var productSelected = _repositoryProduct.SelectByID(detail.ProductId);

                if (productSelected == null)

                    throw new NullReferenceException("You are trying to sell a product that does not exist!");

                //var detailNew = new SaleDetail
                //{
                //    SaleId = saleAdd.SaleId,
                //    ProductId = detail.ProductId,
                //    CostUnit = productSelected.Result.Cost,
                //    PriceUnit = productSelected.Result.Price,
                //    QuantitySale = detail.QuantitySale
                //};

                detail.CostUnit = productSelected.Result.Cost;
                detail.PriceUnit = productSelected.Result.Price;

                detail.Subtotal = detail.PriceUnit * detail.QuantitySale;
                detail.Tax = detail.Subtotal * 19 / 100;
                detail.Total = detail.Subtotal + detail.Tax;
                _repositoryDetail.Add(detail);

                productSelected.Result.QuantityInStock -= detail.QuantitySale;
                _repositoryProduct.Edit(productSelected.Result);

                entity.Subtotal += detail.Subtotal;
                entity.Tax += detail.Tax;
                entity.Total += detail.Total;


            });

            await _repositoryProduct.SaveAllChanges();

            return entity;

        }


        public async Task Cancel(Guid entityId)
        {
            await _repositorySale.Cancel(entityId);
            await _repositorySale.SaveAllChanges();

        }


        public async Task<List<Sales>> Lists()
        {
            return await _repositorySale.Lists();
        }


        public async Task<Sales> SelectByID(Guid entityId)
        {
            return await _repositorySale.SelectByID(entityId);
        }
    }
}
