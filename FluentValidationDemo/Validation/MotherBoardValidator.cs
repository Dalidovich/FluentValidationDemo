using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using FluentValidationDemo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDemo.Validation
{
    public class MotherBoardValidator : AbstractValidator<MotherBoard>
    {
        public MotherBoardValidator()
        {
            RuleFor(x => x.RAMMax).GreaterThan((short)2);
            RuleFor(x => x.RAMSlots).GreaterThan((short)1); 
            RuleFor(x => x.FormFactor).Must(y => MotherBoardFormFactors.Formats.Contains(y.ToUpper()));
            RuleFor(x => x.ProcessorSupport).Must(BeAValidProcessor);
        }

        private bool BeAValidProcessor(string processor)
        {
            return MotherBoardFormFactors.Processors.Contains(processor.ToUpper());
        }
    }
}
