using BlazorLabb.Components.Pages;
using Microsoft.AspNetCore.Components;

namespace BlazorLabb
{
    public class Company
    {      
        public string? Name { get; set; }    
        public string? CatchPhrase { get; set; }
        public Company(string name, string catchPhrase)
        {
            Name = name;
            CatchPhrase = catchPhrase;
        }

        public Company()
        {
            
        }
        public string DisplayCompany()
        {
            return $"Company: \n{Name} - {CatchPhrase}";
        }
    }

}