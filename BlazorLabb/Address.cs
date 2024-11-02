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

        public Address(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }
        public Address()
        {
            
        }
        public string DisplayAddress()
        {
            return $"Address:\n{Street}\n{City}\n{ZipCode}";
        }
    }

}