using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        // Get Object ID
        T Get(int id);

        // Get all Objects IEnumerable
        IEnumerable<T> GetAll(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = null
        );

        // Get The First Or Default
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
,
            object FilterCollection = null);

        // Add

        void Add(T entity);

        // Remove By ID
        void Remove(int id);

        // Remove the object itself
        void Remove(T entity);

        // Remove (list a objects)
        void RemoveRange(IEnumerable<T> entity);

    }
}
