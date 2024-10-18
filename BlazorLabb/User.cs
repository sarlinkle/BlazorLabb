using BlazorLabb;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

public class User
{
	[Parameter]
	[Required]
	public string? ID { get; set; }
	[Parameter]
	[Required]
	[StringLength(50, MinimumLength = 2)]
	public string? Name { get; set; }
	[Parameter]
	[Required]
	public string? Email { get; set; }
	[Parameter]
	//Gör till lista
	public Address Address { get; set; }
	[Parameter]
	//Gör till lista
	public Company Company { get; set; }

	public User()
	{
		//Address = new Address();
		//Company = new Company();
		ID = string.Empty;
		Name = string.Empty;
		Email = string.Empty;
		Address = new Address();
		Company = new Company();
	}
}