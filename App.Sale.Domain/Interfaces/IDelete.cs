using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sale.Domain.Interfaces
{
    public interface IDelete<TEntityID> 
    {
        Task Delete(TEntityID entityId);
    }
}
