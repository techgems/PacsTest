using Microsoft.AspNetCore.Razor.TagHelpers;
using TechGems.RazorComponentTagHelpers;

namespace PacsTest.ComponentTagHelpers;


[HtmlTargetElement("bs-modal")]
public class BootstrapModalComponent : RazorComponentTagHelper
{

    public BootstrapModalComponent() : base("~/Views/Components/BootstrapModal.cshtml")
    {

    }
}