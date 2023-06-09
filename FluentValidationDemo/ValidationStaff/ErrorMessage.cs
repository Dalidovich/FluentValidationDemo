namespace FluentValidationDemo.ValidationStaff
{
    public class ErrorMessage
    {
        public bool RuleSucceed { get; private set; }
        public string Message { get; private set; }

        public ErrorMessage(bool ruleSucceed, string message)
        {
            RuleSucceed = ruleSucceed;
            Message = message;
        }

        public string WithErrorMessage(string message)
        {
            Message = message;

            return Message;
        }
    }
}
