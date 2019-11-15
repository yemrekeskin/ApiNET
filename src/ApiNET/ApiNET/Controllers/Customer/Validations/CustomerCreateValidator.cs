using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Controllers
{
    public class CustomerCreateValidator
        : AbstractValidator<CustomerCreate>
    {
        public CustomerCreateValidator()
        {
            RuleFor(d => d.Age)
                .NotNull()
                .GreaterThan(0)
                .LessThanOrEqualTo(80);
        }
    }
}
