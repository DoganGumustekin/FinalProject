using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
    
namespace Core.DataAcces.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> //TEntity tablomuza karşılık geliyordu bende burda diyorum ki ben hangi tabloyu verirsem onun ientityrepository si çalışacak.
        where TEntity : class,IEntity, new() //tentity in kuralları.
        where TContext : DbContext, new() //TContext bir bContex olmalı ve saece newlenebilirler olmalı. 
    {
        public void Add(TEntity entity)
        {                       //using{} = c# a özgü. bir class newlendiğinde garbage collector belli bir zamanda düzenli olarak gelir ve onu bellekten atar.
            using (TContext context = new TContext()) //Bu using işi bitince garbage collectora beni bellekten sil der. ve daha performanslı bir ürün olur.
            {                                                        //context i burda normalde newleyebiliriz.   
                var addedEntity = context.Entry(entity); //verikaynağından benim gönderdiğim product tan bir tane nesneyi eşleştir.referansı yakala
                addedEntity.State = EntityState.Added;    //o referans aslında eklenecek bir nesne
                context.SaveChanges();          //ekle.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter) //expression filtre vermemizi sağlar.
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // tek bir eleman bulduğumuzda döndüren fonksiyon singleordefault yada firstordefault
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                //filter==null ise bütün tabloyu getir değilse filtreye göre listeye ekle 
                //burada filtre koyma işlemi yaptık.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
