namespace FluentValidationDemo.ValidationStaff
{
    public class ValidResult
    {
        private readonly bool succeed;
        private readonly string errMessage;

        public ValidResult(string errMessage)
        {
            succeed = errMessage == "";
            this.errMessage = errMessage;
        }

        public bool IsValid()
        {

            return succeed;
        }

        public override string ToString()
        {

            return errMessage;
        }
    }
}
