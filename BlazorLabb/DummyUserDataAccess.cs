
using System.Diagnostics;

namespace BlazorLabb
{
    public class DummyUserDataAccess : IUserDataAccess
	{

        public string DataSource { get; set; }

        public DummyUserDataAccess(int userCount)
		{
			DataSource = "DummyUsers";
			userCount = 3;
		}

		public List<User> Users => new List<User>
		{
			new User
			(
				123,
				"Fox Mulder",
				"fox.mulder@fbi.com",
				new Address
				(
					"935 Pennsylvania Avenue",
					"ABC 123",
					"Washingon D.C."
				),
				new Company
				(
					"X-Files Bureau",
					"I want to believe"
				)
			),
			new User
			(
				456,
				"Dana Scully",
				"dana.scully@fbi.com",
				new Address
				(
					"935 Pennsylvania Avenue",
						"ABC 123",
					"Washingon D.C."
				),
				new Company
				(
					"X-Files Bureau",
					"Mulder, it's me"
				)
			),
			new User
			(
				789,
				"Smoking Man",
				"smoking.man@fbi.com",

				new Address (
					"11 Top Secret Street",
					"DEF 456",
					"Washingon D.C."
				),
				new Company
				(
					"Conspiracy Central",
					"That goddamn Mulder"
				)
			)
		};

        public async Task LoadUsersAsync()
        {
            //Does nothing
            await Task.Run(() => Debug.WriteLine("Users loaded but doesn't really load users"));
        }
    }
}



