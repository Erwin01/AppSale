using App.Sale.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Application.Interfaces
{
    interface IServiceBase<TEntity, TEntityID> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityID>, IToList<TEntity, TEntityID>
    {
    }
}
