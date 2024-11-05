﻿using BlazorLabb.Components.Pages;
using System.Net.Http;
using System.Text.Json;

namespace BlazorLabb
{
    public class APIUserDataAccess : IUserDataAccess
    {
        private List<User>? _users;
        public string DataSource { get; set; }

        public List<User> Users
        {
            get
            {
                _users ??= new List<User>();
                return _users;
            }
            private set
            {
                _users = value;
            }
        }
        public APIUserDataAccess(int userCount)
        {
            DataSource = "APIUsers";
            userCount = 10;
        }

        public async Task LoadUsersAsync()
        {
            using (var httpClient = new HttpClient())
            {
                _users = await httpClient.GetFromJsonAsync<List<User>>("https://jsonplaceholder.typicode.com/users");
            }
        }
    }
}



