using Microsoft.AspNetCore.Components;

namespace BlazorLabb.Components.Pages
{
	public partial class Users
	{
		/*

		När användar-data laddats ska detta visas upp i en lista eller tabell
		- sidan visar de första 5 användarna sorterade på förnamn (LINQ ska användas)
		- när man trycker på knappen "visa alla" ska alla användare visas (minst 10)

		Sidan kräver ett datalager:
		- Datalagret ska ha metoden GetUsers() som returnerar användarna
		- Följande användardata ska representeras av minst 3 klasser
			-  id, name, email, adress (bestående av street, city, zipcode), company (name & catchphrase)
			- Metoden ska generera minst 10 användare, där ordningen inte är sorterad
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
			//Om users kommer från API:
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