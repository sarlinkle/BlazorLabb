using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace BlazorLabb.Components.Pages
{
	public partial class Users
	{
		private IEnumerable<User>? _users;		
		public string? PageTitle;
		public int UserCount { get; set; }
		public IUserDataAccess? UserDataAccess { get; set; }
		public string SearchText = "";
        public static HttpClient httpClient = new HttpClient();

        protected override async Task OnInitializedAsync()
		{
			await Task.Delay(800);

			////UserDataAccess = new DummyUserDataAccess();
			////PageTitle = SetPageTitle();
			////UserCount = 3;
			////GetAllUsers();

			UserCount = 10;

			//UserDataAccess = new RandomlyGeneratedUserDataAccess();
			//PageTitle = SetPageTitle();
			//GetSomeUsersOrderedByName();

			UserDataAccess = new APIUserDataAccess();
			PageTitle = SetPageTitle();
			await GetAPIUsersAsync();
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
			else if (UserDataAccess.DataSource == "APIUsers")
			{
				return "Users read from API";
			}
			else
			{
				return "APIUsers";
			}
        }

        public async Task GetAPIUsersAsync()
        {
            _users = await httpClient.GetFromJsonAsync<List<User>>("https://jsonplaceholder.typicode.com/users");
        }
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