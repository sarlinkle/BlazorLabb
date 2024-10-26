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

		private IEnumerable<User>? _users;

		[Parameter]
		public string? PageTitle {  get; set; }
		[Parameter]
		public int UserCount { get; set; }
		[Parameter]
		public IUserDataAccess? UserDataAccess { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await Task.Delay(500);
            //UserDataAccess = new DummyUserDataAccess();		
			UserDataAccess ??= new RandomlyGeneratedUserData();
            //UserDataAccess ??= new APIUserDataAccess();

			UserCount = 10;

            if (UserCount < 1)
            {
                UserCount = 10;
            }

            GetSomeUsers();
		}

		protected override void OnParametersSet()
		{
			SetPageTitle();
		}

        private void SetPageTitle()
        {
			if (UserDataAccess?.DataSource == "DummyUsers")
			{
				PageTitle = "Users from dummy data";
			}
			else if (UserDataAccess?.DataSource == "RandomUsers")
			{
				PageTitle = "Randomly generated users";
			}
			else if (UserDataAccess?.DataSource == "APIUsers")
			{
				PageTitle = "Users read from API";
			}
			else
			{
				PageTitle = "Users";
			}
        }
        private void GetAllUsers()
		{
			_users = UserDataAccess?.Users;
		}
		private void GetSomeUsers()
		{
			_users = UserDataAccess?.Users.GetSomeUsers(0, UserCount);
		}
		private void GetUsersOrderedByID()
		{
			_users = UserDataAccess?.Users.GetUsersOrderedByID();
		}
		private void GetUsersOrderedByName()
		{
			_users = UserDataAccess?.Users.GetUsersOrderedByName();
		}
		private void GetUsersOrderedByCompanyName()
		{
			_users = UserDataAccess?.Users.GetUserOrderedByCompanyName();
		}
		private void GetUsersOrderedByCity()
		{
			_users = UserDataAccess?.Users.GetUsersOrderedByCity();
		}
	}
}