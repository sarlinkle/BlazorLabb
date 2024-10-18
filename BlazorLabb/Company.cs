using BlazorLabb.Components.Pages;
using Microsoft.AspNetCore.Components;

namespace BlazorLabb
{
    public class Company
    {
        [Parameter]
        public string? CompanyName { get; set; }
        [Parameter]
        public string? CatchPhrase { get; set; }
        public Company()
        {
            CompanyName = string.Empty;
            CatchPhrase = string.Empty;
        }

        public string DisplayCompany()
        {
            return $"Company: \n{CompanyName} - {CatchPhrase}";
        }
    }

}