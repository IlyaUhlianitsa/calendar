﻿using Calendar.Models;
using Calendar.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ValidationService validationService;
        public CalendarController(ValidationService validationService)
        {
            this.validationService = validationService;
        }

        public IActionResult Index(string year, string month)
        {
            var result = validationService.Validate(year, month, out var date);

            if (!string.IsNullOrEmpty(result))
                return View("Error", result);

            var model = new CalendarModel
            {
                Title = date.ToString("yyyy MMMM").ToUpper(),
                StartDayOfWeak = (int) date.DayOfWeek,
                EndDay = date.AddMonths(1).AddSeconds(-1).Day
            };

            return View(model);
        }

    }
}