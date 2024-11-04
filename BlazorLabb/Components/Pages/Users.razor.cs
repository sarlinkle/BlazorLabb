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

			//UserCount = 3;
			////GetAllUsers();

			UserCount = 10;


			UserDataAccess = UserDataAccessCreator.Create(DataSource.API);
			await UserDataAccess.LoadUsersAsync();
            DisplaySomeUsersOrderedByName();
            //await GetSomeAPIUsersAsync();
        }

        protected override void OnParametersSet()
		{
			PageTitle = SetPageTitle();
		}

        public string SetPageTitle()
        {
            return UserDataAccess?.DataSource switch
            {
                "DummyUsers" => "Users from dummy data",
                "RandomUsers" => "Randomly generated users",
                "APIUsers" => "Users read from API",
                _ => "APIUsers",
            };
        }
		private void DisplayAllUsers()
		{
			_users = UserDataAccess?.Users;
		}
		private void DisplaySomeUsers()
		{
			_users = UserDataAccess?.Users.GetSomeUsers(0, UserCount);
		}
		private void DisplaySomeUsersOrderedByName()
		{
            _users = UserDataAccess?.Users.GetSomeUsersOrderedByName();
        }
        private void DisplayUsersOrderedByID()
		{
            //Gör så att det blir stigande/fallande varannan gång
            _users = UserDataAccess?.Users.GetUsersOrderedByID();
		}
		private void DisplayUsersOrderedByName()
		{
			
            //Gör så att det blir stigande/fallande varannan gång
            _users = UserDataAccess?.Users.GetUsersOrderedByName();		
		}
		private void DisplayUsersOrderedByCompanyName()
		{
			_users = UserDataAccess?.Users.GetUserOrderedByCompanyName();
		}
		private void DisplayUsersOrderedByCity()
		{
			_users = UserDataAccess?.Users.GetUsersOrderedByCity();
		}
		private void DisplayUserNameFilteredBySearch(string searchText)
		{
			_users = UserDataAccess?.Users.GetUserNameFilteredBySearch(searchText);
        }

		//Make a method searching numbers instead of strings

		private void DisplayUsersFilteredBySearchInt(string searchText)
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