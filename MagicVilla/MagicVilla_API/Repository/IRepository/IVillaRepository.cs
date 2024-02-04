using MagicVilla_API.Models;
using System.Linq.Expressions;

namespace MagicVilla_API.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAll(Expression<Func<Villa>> filter = null);
        Task<List<Villa>> Get(Expression<Func<Villa>> filter = null, bool tracked);
        Task Create(Villa entity);
        Task Update(Villa entity);

        Task Delete(Villa entity);

        Task Save();
    }
}
