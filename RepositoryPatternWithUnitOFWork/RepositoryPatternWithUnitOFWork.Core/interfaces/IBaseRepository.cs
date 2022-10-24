using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOFWork.Core.interfaces
{
    public interface IBaseRepository<T> where T : class
    {

        T GetById(int id);
        IEnumerable<T> GetAll();
        T find(Expression<Func<T, bool>>match);

        T find(Expression<Func<T, bool>> match, string[] incldess = null);
        IEnumerable<T> findAll(Expression<Func<T, bool>> match, string[] incldess = null);
        IEnumerable<T> findAll(Expression<Func<T, bool>> match);

        T Add(T entity);
        IEnumerable<T>Addrange(IEnumerable<T> entities);


        T update(T entity);
        void delete(T entity);
        void attached(T entity);
        int count();
        int count(Expression<Func<T, bool>> match);


    }
}


