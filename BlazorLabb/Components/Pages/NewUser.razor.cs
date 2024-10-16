using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlazorLabb.Components.Pages
{
	public partial class NewUser
	{
		private string _message;

		[Parameter]
		[Required]
		public string ID { get; set; }
		[Parameter]
		[Required]
		public string Name { get; set; }
		[Parameter]
		[Required]
		public string Email { get; set; }
		[Parameter]
		//Gör till lista
		public Address Address { get; set; }
		[Parameter]
		//Gör till lista
		public Company Company { get; set; }

	}
}