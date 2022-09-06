using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Domain.Interfaces.Repositories
{
    public interface IRepositoryDetail<TEntity, TMovement> : IAdd<TEntity>, ITransaction
    {

    }
}
