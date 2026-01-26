using FluentValidation;
using PacsTest.ComponentTagHelpers;
using PacsTest.Services.Interfaces;

namespace PacsTest.Validators;

public class EmployeeTimeEntryValidator : AbstractValidator<TimeEntryFormComponent>
{
    public EmployeeTimeEntryValidator(ITimeEntryPageService timeEntryPageService)
    {
        RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Employee is required.");
        RuleFor(x => x.Date).NotNull().WithMessage("Date is required.");
        RuleFor(x => x.InTime).NotNull().WithMessage("Time In is required.");
        RuleFor(x => x.OutTime).NotNull().WithMessage("Time Out is required.");

        RuleFor(x => x)
            .Must(x => x.OutTime > x.InTime)
            .WithMessage("Time Out must be after Time In.");

        var fullEntriesList = timeEntryPageService.GetTimeEntriesForEmployees().EntriesList;

        RuleFor(x => x.Date).Must((entry, date) => {
            return !fullEntriesList.Any(te => te.EmployeeId == entry.EmployeeId && te.Date == date);
        })
        .WithMessage("The time entry overlaps with an existing entry for the selected employee on the same date.");


    }
}
