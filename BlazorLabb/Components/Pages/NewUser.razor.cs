using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace BlazorLabb.Components.Pages
{
	public partial class NewUser
	{
		public string message = string.Empty;
		public string savedUserInfo = string.Empty;
		public bool displayForm = true;

		User newUser = new User();

		public void HandleFormSubmission()
		{
			//SaveData();
			//Ska kolla om det faktiskt �r success
			bool success = true;

			if (success)
			{
				displayForm = false;
				message = $"You have saved the following information:";
				savedUserInfo =	$"\nID: {newUser.ID}" + 
					$"\nName: {newUser.Name}" +
					$"\nEmail: {newUser.Email}" +
					$"\n{newUser.Address.DisplayAddress()}" +
					$"\n{newUser.Company.DisplayCompany()}";
			}
		}
	}
}
