using Microsoft.AspNetCore.Razor.TagHelpers;
using PacsTest.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TechGems.RazorComponentTagHelpers;

namespace PacsTest.ComponentTagHelpers;

[HtmlTargetElement("time-entry-modal-form")]
public class TimeEntryModalFormComponent : RazorComponentTagHelper
{
    public TimeEntryModalFormComponent() : base("~/Views/Components/TimeEntryModalForm.cshtml")
    {
        
    }


    [HtmlAttributeName("employee-list")]
    public List<EmployeeFilterModel> EmployeeList { get; set; } = new List<EmployeeFilterModel>();

    //Form Submission Properties
    [DisplayName("Employee")]
    public int EmployeeId { get; set; }

    [DisplayName("Date")]
    public DateOnly? Date { get; set; }

    [DisplayName("Time In")]
    public TimeOnly? TimeIn { get; set; }

    [DisplayName("Time Out")]
    public TimeOnly? TimeOut { get; set; }

}
