using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowing.DATA.Interfaces
{
    public interface IRepositoryModel<Entity> where Entity : class
    {
        Entity Create(Entity entity);
        List<Entity> GetAll();
        Entity GetById(params object[] id);
        Entity Update(Entity entity);
        void Delete(Entity entity);
        void DeleteById(params object[] id);
        void SaveChanges(Entity entity);
    }
}
