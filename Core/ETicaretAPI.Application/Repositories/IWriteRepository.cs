using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity //CRUD OPERASYONLARI
    {
        //Ekleme
        Task<bool> AddAsync(T model);
        //Birden fazla ekleme, koleksiyon ekleme. AddAsync Overload
        Task<bool> AddRangeAsync(List<T> datas);
        //Silme
        bool Remove(T model);
        //Birden fazla silme, koleksiyon silme. AddAsync Overload
        bool RemoveRange(List<T> datas);
        //hedef id'yi silme
        Task<bool> RemoveAsync(string id);
        //Güncelleme
        bool Update(T model);
        //Yapılan işlem sonrası SaveChanges'i çağırabilmek için ekledim.
        Task<int> SaveAsync();
    }
}
