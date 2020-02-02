using System;

namespace Buco.Validation
{
    public class DateValidation : IDateValidation
    {
        public bool ValidateDates(DateTime startDate, DateTime endDate)
        {
            return startDate <= endDate;
        }
    }
}
