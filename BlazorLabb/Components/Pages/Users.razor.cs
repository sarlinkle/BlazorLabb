using Microsoft.AspNetCore.Components;

namespace BlazorLabb.Components.Pages
{
	public partial class Users
	{
		/*

		N�r anv�ndar-data laddats ska detta visas upp i en lista eller tabell
		- sidan visar de f�rsta 5 anv�ndarna sorterade p� f�rnamn (LINQ ska anv�ndas)
		- n�r man trycker p� knappen "visa alla" ska alla anv�ndare visas (minst 10)

		Sidan kr�ver ett datalager:
		- Datalagret ska ha metoden GetUsers() som returnerar anv�ndarna
		- F�ljande anv�ndardata ska representeras av minst 3 klasser
			-  id, name, email, adress (best�ende av street, city, zipcode), company (name & catchphrase)
			- Metoden ska generera minst 10 anv�ndare, d�r ordningen inte �r sorterad
				*/

		//private User[]? users;

		private List<User>? _users;

		[Parameter]
		public string? Heading {  get; set; }
		[Parameter]
		public int? UserCount { get; set; }
		[Parameter]
		public IUserDataAccess UserDataAccess { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await Task.Delay(500);
			UserDataAccess = new DummyUserDataAccess();
			//UserDataAccess = new RandomUserDataAccess();
			//UserDataAccess = new APIUserDataAccess();

			//if (UserCount < 1)
			//{
			UserCount = 10;
			//}

			DisplaySomeUsers();
			DisplayAllUsers();
		}

		protected override void OnParametersSet()
		{
			Heading = "Users from randomly generated data";
			//Om users kommer fr�n API:
			//Heading = "Users from Json placeholder API";
		}
		private void DisplayAllUsers()
		{
			throw new NotImplementedException();
		}
		private void DisplaySomeUsers()
		{
			throw new NotImplementedException();
		}
	}
}