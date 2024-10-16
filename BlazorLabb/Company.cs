using BlazorLabb.Components.Pages;
using Microsoft.AspNetCore.Components;

namespace BlazorLabb
{
    public class Company
    {
        [Parameter]
        public string CompanyName { get; set; }
        [Parameter]
        public string CatchPhrase { get; set; }

        public string DisplayCompany(NewUser user)
        {
            return $"Company name: {CompanyName} - {CatchPhrase}";
        }
    }

}