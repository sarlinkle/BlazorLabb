using BlazorLabb;
using BlazorLabb.Components.Pages;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Net.Http.Json;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.WebRequestMethods;

namespace BlazorLabb
{
    public interface IUserDataAccess
	{
		public List<User> Users { get; }
		public string DataSource { get; set; }
		public Task LoadUsersAsync();
	}
}



