using BlazorLabb;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace BlazorLabb
{
	public class User
	{
		[Required]
		[RegularExpression("^(0|[1-9][0-9]*)$")]
		public int? ID { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 2)]
		public string? Name { get; set; }
		[Required]
		[EmailAddress]
		public string? Email { get; set; }
		public Address? Address { get; set; } = new Address();
		public Company? Company { get; set; } = new Company();

		public User(int id, string name, string email, Address address, Company company)
		{
			ID = id;
			Name = name;
			Email = email;
			Address = address;
			Company = company;
		}
		public User()
		{

		}
	}
}