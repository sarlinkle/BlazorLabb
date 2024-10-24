using BlazorLabb;
using Microsoft.AspNetCore.Components;

namespace BlazorLabb
{
    public class Address
    {
        [Parameter]
        public string? Street { get; set; }
        [Parameter]
        public string? City { get; set; }
        [Parameter]
        public string? ZipCode { get; set; }

        public Address()
        {
            Street = string.Empty;
            City = string.Empty;
            ZipCode = string.Empty;
        }
        public string DisplayAddress()
        {
            return $"Address:\n{Street}\n{ZipCode}\n{City}";
        }
    }

}