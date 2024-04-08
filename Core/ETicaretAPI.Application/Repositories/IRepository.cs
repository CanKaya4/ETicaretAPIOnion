using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    //IReadRepository, IWriteRepository için base arayüz, ortak DbSetler burada tanımlanacak
    public interface IRepository<T> where T : BaseEntity // Sorgular için
    {
        DbSet<T> Table { get; }
    }
}
