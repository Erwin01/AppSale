using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Can't Edit and Delete - The sales do not include these operations.
    /// IEdit and IDelete - Annular method Abort method in case a problem occurs
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityID"></typeparam>
    public interface IRepositoryMovement<TEntity, TEntityID> : IAdd<TEntity>, IToList<TEntity, TEntityID>, ITransaction
    {

        Task Cancel(TEntityID entityId);
    }
}
