using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ICrudRepository<T>
    {
        void Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);
        bool Exists(int id);
        IEnumerable<T> GetAll();
        void SaveChanges();
    }
}
