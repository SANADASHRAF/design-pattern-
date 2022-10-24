using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOFWork.Core.interfaces;

namespace RepositoryPatternWithUnitOFWork.EF
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected context _context;

        public BaseRepository(context context)
        {
            _context = context;
        }


        public T GetById(int id)
        {
            return   _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T find(Expression<Func<T, bool>>match )
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        //include
       public T find(Expression<Func<T, bool>> match, string[] incldess = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if(incldess != null)
            
                foreach (var inqules in incldess)
                    query = query.Include(inqules);
            
            return query.SingleOrDefault(match);
        }

        IEnumerable<T> findAll(Expression<Func<T, bool>> match, string[] incldess = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (incldess != null)

                foreach (var inqules in incldess)
                    query = query.Include(inqules);

            return query.Where(match).ToList();
        }
        public IEnumerable< T> findAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().ToList();
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            //_context.SaveChanges(); i wiil use unit of work
            return entity;
        }
        public IEnumerable< T> Addrange(IEnumerable<T> entites)
        {
            _context.Set<T>().AddRange(entites);
            _context.SaveChanges();
            return entites;
        }

        IEnumerable<T> IBaseRepository<T>.findAll(Expression<Func<T, bool>> match, string[] incldess)
        {
            throw new NotImplementedException();
        }

        public T update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void attached(T entity)
        {
            _context.Set<T>().Attach(entity);
        }
        public int count()
        {
            return _context.Set<T>().Count();
        }

        public int count(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Count(match);
        }
    } 
}
