using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Sale.Domain.Interfaces;

namespace App.Sale.Application.Interfaces
{
    public interface IServiceMovement<TEntity, TEntityID> : IAdd<TEntity>, IToList<TEntity, TEntityID>
    {

        Task Cancel(TEntityID entityId);
    }
}
