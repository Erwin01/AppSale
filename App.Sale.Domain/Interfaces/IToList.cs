using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Domain.Interfaces
{
    public interface IToList<TEntity, TEntityID>
    {

        Task<List<TEntity>> Lists();

        Task<TEntity> SelectByID(TEntityID entityId);
    }
}
