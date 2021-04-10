using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMasGlobalConsulting.Dal.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get();
    }
}
