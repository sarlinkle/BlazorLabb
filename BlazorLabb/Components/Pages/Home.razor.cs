using Microsoft.AspNetCore.Components.Web;

namespace BlazorLabb.Components.Pages
{
	public partial class Home
	{

		private string? catImage;

		protected override async Task OnInitializedAsync()
		{
			await Task.Delay(500);
			await FetchRandomCatImageAsync();
		}

		public async Task FetchRandomCatImageAsync()
		{
			// Make an HTTP request to an API to get a new random cat picture
			using (var httpClient = new HttpClient())
			{
				// Fetch the raw image content (GIF or PNG)
				var imageBytes = await httpClient.GetByteArrayAsync("https://cataas.com/cat");

				// Convert the image bytes to base64
				var base64Image = Convert.ToBase64String(imageBytes);

				// Set the image URL as a data URL with base64 encoding
				catImage = $"data:image/gif;base64,{base64Image}";
			}
		}
	}
}