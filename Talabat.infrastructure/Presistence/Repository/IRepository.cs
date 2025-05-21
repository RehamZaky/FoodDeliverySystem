using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Infrastructure.Data;

namespace Talabat.Infrastructure.Presistence.Repository
{
    public interface IRepository<T>
    {
        public List<T> GetAll();

        public string Add(T t);
        public string Update(T t);
        public string Delete(int id);

        public T GetById(int id);
    }
}
