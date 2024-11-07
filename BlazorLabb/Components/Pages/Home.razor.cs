using Microsoft.AspNetCore.Components.Web;
using System.Diagnostics;

namespace BlazorLabb.Components.Pages
{
	public partial class Home
	{
		private string? catImage;
		public bool buttonClicked = false;

		public async Task FetchRandomCatImageAsync()
		{
			buttonClicked = true;
			try
			{
				using (var httpClient = new HttpClient())
				{
					var imageBytes = await httpClient.GetByteArrayAsync("https://cataas.com/cat");
					var base64Image = Convert.ToBase64String(imageBytes);
					catImage = $"data:image/gif;base64,{base64Image}";
				}
			}
			catch (Exception ex) 
			{ 
				Debug.WriteLine($"Could not fetch image from API - {ex.Message}");
			}
		}
	}
}