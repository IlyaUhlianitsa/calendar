using Calendar.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    public class CalendarController : Controller
    {
        private ValidationService validationService;
        public CalendarController(ValidationService validationService)
        {
            this.validationService = validationService;
        }

        public IActionResult Index(string year, string month)
        {
            var result = validationService.Validate(year, month, out var date);

            if (!string.IsNullOrEmpty(result))
                return View("Error", result);

            return View(date);
        }

    }
}