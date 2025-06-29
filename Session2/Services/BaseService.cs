﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Services
{
    public abstract class BaseService<T>
    {
        public abstract List<T> GetAll();
        public abstract bool Add(T obj);
        public abstract bool Update(T obj);
        public abstract bool Delete(T obj);
    }
}
