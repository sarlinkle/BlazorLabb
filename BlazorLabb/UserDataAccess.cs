using BlazorLabb;
using System;

namespace BlazorLabb
{
	public interface IUserDataAccess
	{
		public List<User> Users { get; }
	}


	public class DummyUserDataAccess : IUserDataAccess
	{
		public DummyUserDataAccess()
		{

		}

		public List<User> Users => new List<User>
		{
			new User
			{
				ID = 123,
				Name = "Fox Mulder",
				Email = "fox.mulder@fbi.com",
				Address = new Address
				{
					Street = "935 Pennsylvania Avenue",
					ZipCode = "ABC 123",
					City = "Washingon D.C."
				},
				Company = new Company
				{
					CompanyName = "X-Files Bureau",
					CatchPhrase = "I want to believe"
				}
			},
			new User
			{
				ID = 456,
				Name = "Dana Scully",
				Email = "dana.scully@fbi.com",
				Address = new Address
				{
					Street = "935 Pennsylvania Avenue",
					ZipCode = "ABC 123",
					City = "Washingon D.C."
				},
				Company = new Company
				{
					CompanyName = "X-Files Bureau",
					CatchPhrase = "Mulder, it's me"
				}
			},
			new User
			{
				ID = 789,
				Name = "Smoking Man",
				Email = "smoking.man@fbi.com",
				Address = new Address
				{
					Street = "11 Top Secret Street",
					ZipCode = "DEF 456",
					City = "Washingon D.C."
				},
				Company = new Company
				{
					CompanyName = "Conspiracy Central",
					CatchPhrase = "That goddamn Mulder"
				}
			}
		};
	}

	public class RandomlyGeneratedUserData : IUserDataAccess
	{
		private List<User> _users;
		public List<User> Users
		{
			get
			{
				if (_users == null)
				{
					_users = GetRandomUsers();
				}
				return _users;
			}
		}
		//private readonly int _id = (new Random().Next(1, 1000));
		private readonly string[] _names = new string[] { "Göran", "Berit", "Bengt", "Hasse", "Lars", "Ragnar", "Ingrid", "Elvie", "Tore", "Solveig", "Siv", "Anne", "Siri", "Hilda", "Asta" };
		//{ "Göran Persson", "Gudrun Schyman", "Olof Palme", "Jonas Sjöstedt", "Joe Biden", "Bernie Sanders", "Johan Pehrson", "Annie Lööf", "Jimmie Åkesson", "Ebba Bush", "Hannah Gedin", "Nooshi Dadgstar", "Madgalena Andersson", "Ulf Kristersson", "Muharrem Demirok"};
		private readonly string[] _emailAddresses = new string[] { "email1@email.com", "email2@email.com", "email3.email.com", "email4@email.com", "email5@email.com", "email6@email.com", "email7@email.com", "email8@email.com", "email9@email.com", "email10@email.com", "email11@email.com", "email12@email.com", "email13@email.com" };
		private readonly string[] _cities = new[] { "Stockholm", "Malmö", "Gothenburg", "Västerås", "Örebro", "London", "Rom", "Copenhagen", "Helsinki", "Oslo", "Paris", "Berlin", "Gdansk", "Krakow", "Umeå", "Luleå", "Lyon", "Barcelona", "Lisbon" };
		private readonly string[] _streets = new[] { "streetA", "streetB", "streetC", "streetD", "streetE", "streetF", "streetG", "streetH", "streetI", "streetJ", "streetK", "streetL", "streetM", "streetN", "streetO", "streetP", "streetQ", "streetR", "streetS", "streetT", "streetU", "streetV", "streetW", "streetX", "streetY", "streetZ", };
		public List<Address> RandomAddress = new List<Address>();

		public RandomlyGeneratedUserData()
		{

		}

		private List<User> GetRandomUsers()
		{
			return Enumerable.Range(1, 10).Select(i => new User
			{
				ID = new Random().Next(1, 1000),
				Name = _names[Random.Shared.Next(_names.Length)],
				Email = _emailAddresses[Random.Shared.Next(_emailAddresses.Length)]

				//Lägg till generering av address

			}).ToList();
		}
	}

	public class APIUserDataAccess : IUserDataAccess
	{
		public List<User> Users => new List<User>();
		public APIUserDataAccess()
		{


		}
	}

}


