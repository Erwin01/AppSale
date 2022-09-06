using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Domain.Interfaces
{
    public interface IEdit<TEntity>
    {
        Task Edit(TEntity entity);
    }
}
