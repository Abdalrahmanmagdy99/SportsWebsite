using System.ComponentModel.DataAnnotations;

namespace SprotsWebsite.Services.Validations
{
    public class DateInThePast : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTimeValue)
            {
                return dateTimeValue < DateTime.Now;
            }
            return true;
        }
    }
}
