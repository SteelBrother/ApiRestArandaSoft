using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiArandaSoftware.Abstractions;

namespace WebApiArandaSoftware.DataAccess
{
    public class DbContext<T> : IDbContext<T> where T : class, IEntity
    {
        DbSet<T> _items;
        ApiDbContext _ctx;
        public DbContext(ApiDbContext apiDbContext)
        {
            _ctx = apiDbContext;
            _items = _ctx.Set<T>();
        }
        public void Delete(int id)
        {
            try
            {
                var tmp = _items.Find(id);
                if (tmp != null)
                {
                    _items.Remove(tmp);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception e) when (LogException(e))
            {
            }
            Console.WriteLine("Exception must have been handled");
        }

        public void DeleteAsync(int id)
        {
            try
            {
                var tmp = _items.Find(id);
                if (tmp != null)
                {
                    _items.Remove(tmp);
                    _ctx.SaveChangesAsync();
                }
            }
            catch (Exception e) when (LogException(e))
            {
            }
            Console.WriteLine("Exception must have been handled");
        }

        public IList<T> GetAll()
        {
            try
            {
                return _items.ToList();
            }
            catch (Exception e) when (LogException(e))
            {
                Console.WriteLine("La excepción esta siendo controlada");
            }
            return null;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            try
            {
                return await _items.ToListAsync();
            }
            catch (Exception e) when (LogException(e))
            {
                Console.WriteLine("La excepción esta siendo controlada");
            }
            return null;
        }

        public T GetById(int id)
        {
            try
            {
                return _items.Find(id);
            }
            catch (Exception e) when (LogException(e))
            {
                Console.WriteLine("La excepción esta siendo controlada");
            }
            return null;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _items.FindAsync(id);
            }
            catch (Exception e) when (LogException(e))
            {
                Console.WriteLine("La excepción esta siendo controlada");
            }
            return null;
        }

        public T Save(T entity)
        {
            try
            {
                if (entity.id.Equals(0))
                {
                    _items.Add(entity);
                }
                else
                {
                    _items.Update(entity);
                }

                _ctx.SaveChanges();
                return entity;
            }
            catch (Exception e) when (LogException(e))
            {
                Console.WriteLine("La excepción esta siendo controlada");
            }
            return null;
        }

        public async Task<T> SaveAsync(T entity)
        {
            try
            {
                if (entity.id.Equals(0))
                {
                    await _items.AddAsync(entity);
                }
                else
                {
                    _items.Update(entity);
                }

                await _ctx.SaveChangesAsync();
                return entity;
            }
            catch (Exception e) when (LogException(e))
            {
                Console.WriteLine("La excepción esta siendo controlada");
            }
            return null;
        }

        private static bool LogException(Exception e)
        {
            Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
            Console.WriteLine($"\tMessage: {e.Message}");
            return false;
        }
    }
}

