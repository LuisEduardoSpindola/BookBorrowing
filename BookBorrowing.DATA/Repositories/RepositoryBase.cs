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
    public class RepositoryBase<Entity> : IDisposable ,IRepositoryModel<Entity> where Entity : class
    {
        private BookBorrowingContext _Context;
        public bool _SaveChanges = true;

        public RepositoryBase(bool SaveChanges)
        {
            _Context = new BookBorrowingContext();
            _SaveChanges = SaveChanges; 
        }

        //Create

        public Entity Create(Entity entity)
        {
            _Context.Set<Entity>().Add(entity);
        
            if(_SaveChanges) 
            {
                _Context.SaveChanges();
            }

            return entity;
        }

        // Read

        public List<Entity> GetAll()
        {
            return _Context.Set<Entity>().ToList();
        }

        public Entity GetById(params object[] id)
        {
            return _Context.Set<Entity>().Find(id);
        }

        // Update


        public Entity Update(Entity entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;

            if (_SaveChanges)
            {
                _Context.SaveChanges();
            }

            return entity;
        }

        // Delete


        public void Delete(Entity entity)
        {
            _Context.Set<Entity>().Remove(entity);

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


        public void SaveChanges(Entity entity)
        {
            _Context.SaveChanges();
        }

    }
}
