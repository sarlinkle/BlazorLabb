using Microsoft.AspNetCore.Components.Web;
using System.Diagnostics;

namespace BlazorLabb.Components.Pages
{
	public partial class Home
	{

		private string? catImage;

		protected override async Task OnInitializedAsync()
		{
			await FetchRandomCatImageAsync();
		}

		public async Task FetchRandomCatImageAsync()
		{
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
				Debug.WriteLine(ex.Message);
			}
		}
	}
}