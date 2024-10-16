using BlazorLabb.Components.Pages;
using Microsoft.AspNetCore.Components;

namespace BlazorLabb
{
    public class Address
    {
        [Parameter]
        public string Street { get; set; }
        [Parameter]
        public string City { get; set; }
        [Parameter]
        public string ZipCode { get; set; }

        public string DisplayAddress(NewUser user)
        {
            return $"Address:\n{user.Address.Street}\n{user.Address.ZipCode}\n{user.Address.City}";
        }
    }

}