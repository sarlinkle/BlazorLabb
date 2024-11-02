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

		private IEnumerable<User>? _users;

		public string? PageTitle;
		public int UserCount { get; set; }
        //public string? DataSource { get; set; }

		public IUserDataAccess? UserDataAccess { get; set; }
		public string SearchText = "";

        protected override async Task OnInitializedAsync()
		{
			await Task.Delay(500);

			//UserDataAccess = new DummyUserDataAccess();
			//PageTitle = SetPageTitle();
			//UserCount = 3;
			//GetAllUsers();

			UserCount = 10;

			//UserDataAccess = new RandomlyGeneratedUserDataAccess();
			//PageTitle = SetPageTitle();
			//GetSomeUsersOrderedByName();

			UserDataAccess = new APIUserDataAccess();
			PageTitle = SetPageTitle();
			GetSomeUsersOrderedByName();
			//_users = await UserDataAccess.GetUsers();
		}

		protected override void OnParametersSet()
		{
			PageTitle = SetPageTitle();
		}

        public string SetPageTitle()
        {
			if (UserDataAccess.DataSource == "DummyUsers")
			{
				return "Users from dummy data";
			}
			else if (UserDataAccess.DataSource == "RandomUsers")
			{
				return "Randomly generated users";
			}
			//else if (APIUserDataAccess.UserDataAccess.DataSource == "APIUsers")
			//{
			//	return "Users read from API";
			//}
			else
			{
				return "APIUsers";
			}
        }
   //     private IEnumerable<User> GetAllUsersForGrid()
   //     {
			//return _users.GetSomeUsers(0, _users.Count()); 
   //     }

        private void GetAllUsers()
		{
			_users = UserDataAccess?.Users;
		}
		private void GetSomeUsers()
		{
			_users = UserDataAccess?.Users.GetSomeUsers(0, UserCount);
		}
		private void GetSomeUsersOrderedByName()
		{
            _users = UserDataAccess?.Users.GetSomeUsersOrderedByName();
        }
        private void GetUsersOrderedByID()
		{
            //Gör så att det blir stigande/fallande varannan gång
            _users = UserDataAccess?.Users.GetUsersOrderedByID();
		}
		private void GetUsersOrderedByName()
		{
			
            //Gör så att det blir stigande/fallande varannan gång
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
		private void GetUserNameFilteredBySearch(string searchText)
		{
			_users = UserDataAccess?.Users.GetUserNameFilteredBySearch(searchText);
        }

		//Make a method searching numbers instead of strings

		private void GetUsersFilteredBySearchInt(string searchText)
		{
			_users = UserDataAccess?.Users.GetUserIDFilteredBySearch(searchText);
		}
        private int SetStateToDecideAscendingOrDescendingOrder(int state)
        {
            if (state == 0) { state++; }
            else { state--; }
            return state;
        }
    }
}