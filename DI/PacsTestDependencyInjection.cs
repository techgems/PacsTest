using FluentValidation;
using PacsTest.ComponentTagHelpers;
using PacsTest.Data.Repositories;
using PacsTest.Data.Repositories.Interfaces;
using PacsTest.Services;
using PacsTest.Services.Interfaces;
using PacsTest.Validators;

namespace PacsTest.DI;

public static class PacsTestDependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ITimeEntryPageService, TimeEntryPagesService>();
        services.AddScoped<IValidator<TimeEntryFormComponent>, EmployeeTimeEntryValidator>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<ITimeEntryRepository, TimeEntryRepository>(); 
    }
}
