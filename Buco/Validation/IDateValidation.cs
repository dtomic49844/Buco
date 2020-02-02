using System;

namespace Buco.Validation
{
    public interface IDateValidation
    {
        bool ValidateDates(DateTime startDate, DateTime endDate);
    }
}
