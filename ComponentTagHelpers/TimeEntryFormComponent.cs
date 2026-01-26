using Microsoft.AspNetCore.Razor.TagHelpers;
using PacsTest.Models;
using System.ComponentModel;
using TechGems.RazorComponentTagHelpers;

namespace PacsTest.ComponentTagHelpers;

[HtmlTargetElement("time-entry-form")]
public class TimeEntryFormComponent : RazorComponentTagHelper
{

    public TimeEntryFormComponent() : base("~/Views/Components/TimeEntryForm.cshtml")
    {
        
    }

    [HtmlAttributeName("employee-list")]
    public List<EmployeeFilterModel> EmployeeList { get; set; } = new List<EmployeeFilterModel>();

    [DisplayName("Employee")]
    public int EmployeeId { get; set; }

    [DisplayName("Date")]
    public DateOnly? Date { get; set; }

    [DisplayName("Time In")]
    public TimeOnly? InTime { get; set; }

    [DisplayName("Time Out")]
    public TimeOnly? OutTime { get; set; }
}
