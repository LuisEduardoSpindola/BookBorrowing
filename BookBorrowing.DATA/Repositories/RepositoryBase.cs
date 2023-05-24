using BookBorrowing.DATA.Interfaces;
using BookBorrowing.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowing.DATA.Repositories
{
    public class RepositoryBase<T> : IDisposable ,IRepositoryModel<T> where T : class
    {
        private BookBorrowingContext _Context;
        public bool _SaveChanges = true;

        public RepositoryBase(bool SaveChanges)
        {
            _Context = new BookBorrowingContext();
            _SaveChanges = SaveChanges; 
        }

        //Create

        public T Create(T entity)
        {
            _Context.Set<T>().Add(entity);
        
            if(_SaveChanges) 
            {
                _Context.SaveChanges();
            }

            return entity;
        }

        // Read

        public List<T> GetAll()
        {
            return _Context.Set<T>().ToList();
        }

        public T GetById(params object[] id)
        {
            return _Context.Set<T>().Find(id);
        }

        // Update


        public T Update(T entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;

            if (_SaveChanges)
            {
                _Context.SaveChanges();
            }

            return entity;
        }

        // Delete


        public void Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);

            if (_SaveChanges)
            {
                _Context.SaveChanges();
            }
        }

        public void DeleteById(params object[] id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        // ----- Dispose / SaveChanges -----

        public void Dispose()
        {
            _Context.Dispose();  
        }


        public void SaveChanges(T entity)
        {
            _Context.SaveChanges();
        }

    }
}
