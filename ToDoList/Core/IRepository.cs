using System;
using System.Collections.Generic;

namespace ToDoList.Core
{
    interface IRepository<T> : IDisposable
    where T : class
    {
        IEnumerable<T> GetList();
        T GetID(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();

    }
}
