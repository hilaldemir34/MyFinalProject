﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext northwindContext = new TContext())
            {
                var addEntity = northwindContext.Entry(entity);
                addEntity.State = EntityState.Added;
                northwindContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext northwindContext = new TContext())
            {
                var deletedEntity = northwindContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                northwindContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext northwindContext = new TContext())
            {
                return northwindContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext northwindContext = new TContext())
            {
                return filter == null
                    ? northwindContext.Set<TEntity>().ToList()
                    : northwindContext.Set<TEntity>().Where(filter).ToList();//dbset deki product tablosuna yerleş demek
            }//arka planda select*from products çalıştırım döndürür.filtre null sa iki noktadan önceki yer yani tümünü getirir.

        }
        public void Update(TEntity entity)
        {
            using (TContext northwindContext = new TContext())
            {
                var updatedEntity = northwindContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                northwindContext.SaveChanges();
            }
        }

    }
}
