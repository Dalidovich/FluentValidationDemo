namespace FluentValidationDemo.Domain
{
    public class MotherBoardFormFactors
    {
        public const string MiniITX = "Mini ITX";
        public const string MicroATX = "Micro ATX";
        public const string ATX = "ATX";
        public const string EATX = "E ATX";

        public static readonly string[] Formats = { MiniITX, MicroATX, ATX, EATX };

        public const string Intel = "INTEL";
        public const string AMD = "AMD";

        public static readonly string[] Processors = { Intel, AMD };
    }
}
