using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async void Get()
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id = Guid.NewGuid(), Name = "Product 5",Price = 100, Stock =10,CreatedDate = DateTime.UtcNow },
                new(){Id = Guid.NewGuid(), Name = "Product 6",Price = 200, Stock =20,CreatedDate = DateTime.UtcNow },
                new(){Id = Guid.NewGuid(), Name = "Product 7",Price = 300, Stock =30,CreatedDate = DateTime.UtcNow },
            });
            var count = await _productWriteRepository.SaveAsync();
        }
    }
}
