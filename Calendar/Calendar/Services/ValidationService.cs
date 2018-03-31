using System;

namespace Calendar.Services
{
    public class ValidationService
    {
        public string Validate(string year, string month, out DateTime date)
        {
            date = DateTime.Now;
            if (string.IsNullOrEmpty(year) && string.IsNullOrEmpty(month))
                return null;

            if (string.IsNullOrEmpty(month))
                return "Month is required";

            if (!int.TryParse(year, out var yearNumber))
                return "Year is invalid";

            if (yearNumber > 2100 || yearNumber < 1900)
                return "Year should be between 1900 and 2100";

            if (!int.TryParse(month, out var monthNumber) || monthNumber > 12 || monthNumber < 1)
                return "Month is invalid";

            date = new DateTime(yearNumber, monthNumber, 1);

            return null;
        }
    }
}
