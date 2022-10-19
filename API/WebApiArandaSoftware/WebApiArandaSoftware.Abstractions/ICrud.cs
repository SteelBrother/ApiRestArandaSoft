using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiArandaSoftware.Abstractions
{
    public interface ICrudAsync<T>
    {
        Task<T> SaveAsync(T entity);
        Task<IList<T>> GetAllAsync();
        //Task<IList<T>> GetByCategoryAsync();
        Task<T> GetByIdAsync(int id);
        void DeleteAsync(int id);
    }
    public interface ICrud<T> : ICrudAsync<T>
    {
        T Save(T entity);
        IList<T> GetAll();
        //IList<T> GetByCategory();
        T GetById(int id);
        void Delete(int id);

    }
}
