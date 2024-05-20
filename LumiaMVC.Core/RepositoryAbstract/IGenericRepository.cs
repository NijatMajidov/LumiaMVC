using LumiaMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumiaMVC.Core.RepositoryAbstract
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Commit();
        T Get (Func<T, bool>? func=null);
        List<T> GetAll(Func<T, bool>? func = null);
    }
}
