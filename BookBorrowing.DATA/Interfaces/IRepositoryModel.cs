using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowing.DATA.Interfaces
{
    public interface IRepositoryModel<T> where T : class
    {
        T Create(T entity);
        List<T> GetAll();
        T GetById(params object[] id);
        T Update(T entity);
        void Delete(T entity);
        void DeleteById(params object[] id);
        void SaveChanges(T entity);
    }
}
