﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Interfaces
{
    public interface IBaseRepository<T> where T : class 
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetbyId(int id);
        Task Create(T entity);
        Task Update(T entity);
        T GetbyName(string name);
        bool Exists(T entity);
    }
}
