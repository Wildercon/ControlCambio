using FluentValidation;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControlCambio.Validators
{
    public class AccountValidator: AbstractValidator<AccountDTO>
    {
        public AccountValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Nombre es Requerido");
            RuleFor(a => a.AccountNumber).NotEmpty().WithMessage("Cuenta es Requerida");
            RuleFor(a => a.Country).NotEmpty().WithMessage("Sellecione un Pais");
        }

    }
}
