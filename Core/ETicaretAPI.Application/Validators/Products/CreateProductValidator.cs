using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("lütfen ürün adını boş geçmeyiniz").MaximumLength(150).MinimumLength(2).WithMessage("Lütfen ürün adını 2 ile 150 karakter arasında giriniz.");
            RuleFor(p => p.Stock).NotNull().WithMessage("Lütfen stok bilgisini boş geçmeyiniz").GreaterThanOrEqualTo(0).WithMessage("Lütfen stok bilgisi lütfen adam gibi giriniz.");
            RuleFor(p => p.Price).NotNull().WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz").GreaterThanOrEqualTo(0).WithMessage("Lütfen fiyat bilgisi lütfen adam gibi giriniz.");
        }
    }
}
