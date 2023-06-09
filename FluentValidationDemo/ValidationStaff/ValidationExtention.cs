using FluentValidationDemo.Domain;

namespace FluentValidationDemo.ValidationStaff
{
    public static class ValidationExtention
    {
        public static ValidResult IsValidModel(this MotherBoard motherBoard)
        {
            var test = new Validator<MotherBoard>(motherBoard);
            test.RuleFor(x => x.RAMMax).LessThat(2).WithErrorMessage("Ramm max more that 2");
            test.RuleFor(x => x.RAMSlots).GreatestThat(3);
            test.RuleFor(x => x.FormFactor).Equals("ATX");
            test.RuleFor(x => x.ProcessorSupport).Must(y=>y.StartsWith("i"));
            return new ValidResult(test.AllRulesSucceed());
        }
    }
}
