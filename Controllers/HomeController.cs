using FluentValidation;
using Htmx;
using Microsoft.AspNetCore.Mvc;
using PacsTest.ComponentTagHelpers;
using PacsTest.Data.Repositories.Interfaces;
using PacsTest.Extensions;
using PacsTest.Models;
using PacsTest.Services.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PacsTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITimeEntryPageService _timeEntryPageService;
        private IValidator<TimeEntryFormComponent> _validator;

        public HomeController(ILogger<HomeController> logger, ITimeEntryPageService timeEntryService, IValidator<TimeEntryFormComponent> validator)
        {
            _logger = logger;
            _timeEntryPageService = timeEntryService;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] int? employeeId, [FromQuery] DateOnly? date)
        {
            var timeEntries = _timeEntryPageService.GetTimeEntriesForEmployees(employeeId, date);

            return View(timeEntries);
        }

        [HttpPost]
        public async Task<IActionResult> SaveTimeEntry([FromForm] TimeEntryFormComponent model)
        {
            var res = await _validator.ValidateAsync(model);
            
            if (!res.IsValid)
            {
                res.AddToModelState(this.ModelState);
            }
            else
            {
                _timeEntryPageService.InsertTimeEntry(model);
                ViewData["RefreshAfterSuccess"] = true;
            }

            model.EmployeeList = _timeEntryPageService.GetEmployeesForFilter();

            return PartialView("~/Views/Components/TimeEntryForm.cshtml", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
