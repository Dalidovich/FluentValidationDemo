namespace FluentValidationDemo.Domain
{
    public class MotherBoard
    {
        public Guid Id { get; set; }
        public string ProcessorSupport { get; set; } = "";
        public string FormFactor { get; set; } = "";
        public short RAMSlots { get; set; }
        public short RAMMax { get; set; }
    }
}
