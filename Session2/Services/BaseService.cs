using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Services
{
    public abstract class BaseService<T>
    {
        public abstract Task<List<T>> GetAll();
        public abstract Task<bool> Add(T obj);
        public abstract Task<bool> Update(T obj);
        public abstract Task<bool> Delete(T obj);
    }
}
