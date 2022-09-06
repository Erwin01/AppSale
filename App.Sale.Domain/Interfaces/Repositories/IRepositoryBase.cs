using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, TentityID> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TentityID>, IToList<TEntity, TentityID>, ITransaction
    {

    }
}
