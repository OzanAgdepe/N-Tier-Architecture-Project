using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri Adı Boş Geçilemez");
            RuleFor(x => x.CustomerCity).NotEmpty().WithMessage("Müşteri Şehir Bilgisi Boş Geçilemez");
            RuleFor(x => x.CustomerName).MinimumLength(3).WithMessage("Müşteri Adı En az 3 karakter olmalı");
        }
    }
}
