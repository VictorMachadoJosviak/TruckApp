using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Infra.DTO.Truck;

namespace TruckApp.Validators.Truck
{
    public class CreateTruckValidator : AbstractValidator<SaveTruckDTO>
    {
        public CreateTruckValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Campo Nome Obrigatório").MaximumLength(150);

            RuleFor(x => x.ModelYear).NotNull().WithMessage("Campo Ano Modelo é Obrigatório")
                                     .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Ano deve ser maior ou igual aou ano atual");

            RuleFor(x => x.ModelId).NotEmpty().WithMessage("Campo Modelo é Obrigatório");

            RuleFor(x => x.YearManufacture).NotNull().WithMessage("Campo Ano de fabricação obrigatório")
                .Equal(DateTime.Now.Year).WithMessage($"Ano deve ser o ano atual {DateTime.Now.Year}");
        }
    }
}
