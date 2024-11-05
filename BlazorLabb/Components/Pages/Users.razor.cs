using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace BlazorLabb.Components.Pages
{
	public partial class Users
	{
		private IEnumerable<User>? _users;		
		public string? PageTitle;
		public bool IsClicked { get; set; } = true;
		public int UserCount { get; set; }
		public IUserDataAccess? UserDataAccess { get; set; }
		public string SearchText = "";

        protected override async Task OnInitializedAsync()
		{
			await Task.Delay(800);
			UserDataAccess = UserDataAccessCreator.Create(DataSource.API, 10);
			await UserDataAccess.LoadUsersAsync();
            DisplayFirstFiveUsersOrderedByName();
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
		private void DisplayFirstFiveUsersOrderedByName()
		{
            IsClicked = !IsClicked;
            _users = UserDataAccess?.Users.GetSomeUsersOrderedByName(IsClicked);
        }
        private void DisplayUsersOrderedByID()
		{
            IsClicked = !IsClicked;
            _users = UserDataAccess?.Users.GetUsersOrderedByID(IsClicked);
		}
		private void DisplayUsersOrderedByName()
		{
			IsClicked = !IsClicked;
            _users = UserDataAccess?.Users.GetUsersOrderedByName(IsClicked);		
		}
		private void DisplayUsersOrderedByCompanyName()
		{
            IsClicked = !IsClicked;
            _users = UserDataAccess?.Users.GetUserOrderedByCompanyName(IsClicked);
		}
		private void DisplayUsersOrderedByCity()
		{
            IsClicked = !IsClicked;
            _users = UserDataAccess?.Users.GetUsersOrderedByCity(IsClicked);
		}
		private void DisplayUserNameFilteredBySearch(string searchText)
		{
			_users = UserDataAccess?.Users.GetUserNameFilteredBySearch(searchText);
        }
    }
}