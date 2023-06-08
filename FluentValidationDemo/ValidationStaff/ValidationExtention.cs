using FluentValidationDemo.Domain;
using System.Security.Cryptography.X509Certificates;

namespace FluentValidationDemo.ValidationStaff
{
    public static class ValidationExtention
    {
        public static bool isValidModel(this MotherBoard motherBoard)
        {
            return true;
        }
    }
}
