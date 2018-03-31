using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index(string year, string month)
        {
            var result = Validate(year, month);
            if (!string.IsNullOrEmpty(result.error))
                return View("Error", result.error);

            return View(result.date.Value);
        }

        private (DateTime? date, string error) Validate(string year, string month)
        {
            string error = null;
            if (string.IsNullOrEmpty(year) && string.IsNullOrEmpty(month))
            {
                var currentDate = DateTime.Now;
                return (currentDate, error);
            }

            if (string.IsNullOrEmpty(month))
                return (null, "Month is required");

            return (new DateTime(5, 5, 1), error);
        }
    }
}