using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity //  Select ile başlayan sorgu işlemleri için kullanacağım arayüz. Veritabanı sorgularını modellemiş olduk.
        //IEnumerable : bellekte çalışır, çekilen verileri belleğe alır
        //IQuerayble : gönderilen sorguları veritabanı sorgusuna ekler.
    {
        //Tüm Productları getir.
        IQueryable<T> GetAll();
        //Şarta göre veriler gelsin
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        //Verilen şarta göre tekil veri getirecek
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method); // Asenkron Çalışacak
        //Id'ye göre getir
        Task<T> GetByIdAsync(string id); // Asenkron Çalışacak
    }
}
