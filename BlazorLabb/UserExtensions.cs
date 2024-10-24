namespace BlazorLabb
{
	//public class UserDataAccess : IUserDataAccess
	//{
	//	private List<User> _users;
	//	public List<User> Users
	//	{
	//		get
	//		{
	//			return _users;
	//		}
	//	}
	//	public UserDataAccess()
	//	{

	//	}

	//	private List<User> GetUsers()
	//	{
	//		//private readonly int _id = (new Random().Next(1, 1000));
	//		var _names = new[] { "Göran", "Berit", "Bengt", "Hasse", "Lars", "Ragnar", "Ingrid", "Elvie", "Tore", "Solveig", "Siv", "Anne", "Siri", "Hilda", "Asta" };
	//		var _emailAddresses = new[] { "email1@email.com", "email2@email.com", "email3.email.com", "email4@email.com", "email5@email.com", "email6@email.com", "email7@email.com", "email8@email.com", "email9@email.com", "email10@email.com", "email11@email.com", "email12@email.com", "email13@email.com" };
	//		var _cities = new[] { "Stockholm", "Malmö", "Gothenburg", "Västerås", "Örebro", "London", "Rom", "Copenhagen", "Helsinki", "Oslo", "Paris", "Berlin", "Gdansk", "Krakow", "Umeå", "Luleå", "Lyon", "Barcelona", "Lisbon" };
	//		var _streets = new[] { "streetA", "streetB", "streetC", "streetD", "streetE", "streetF", "streetG", "streetH", "streetI", "streetJ", "streetK", "streetL", "streetM", "streetN", "streetO", "streetP", "streetQ", "streetR", "streetS", "streetT", "streetU", "streetV", "streetW", "streetX", "streetY", "streetZ", };

	//		return Enumerable.Range(1, 10).Select(i => new User
	//		{
	//			ID = new Random().Next(1, 1000),
	//			Name = _names[Random.Shared.Next(_names.Length)],
	//			Email = _emailAddresses[Random.Shared.Next(_emailAddresses.Length)]

	//			//Lägg till generering av address

	//		}).ToList();

	//	}
	//}



	public static class UserExtensions
	{
		public static IEnumerable<User> GetAllUsers(this IEnumerable<User> users)
		{
			return users.GetFilteredUsers(0, users.Count());
		}
		public static IEnumerable<User> GetFilteredUsers(this IEnumerable<User> users, int startIndex, int count)
		{
			if (startIndex < 0 || startIndex >= users.Count())
			{
				throw new ArgumentOutOfRangeException(nameof(startIndex));
			}
			if (count < 0 || startIndex + count > users.Count())
			{
				throw new ArgumentOutOfRangeException(nameof(count));
			}

			//if (startIndex == 0)
			//{
			//	return users.Take(count).ToList();
			//}
			//else
			//{
			//	return users.Skip(startIndex).Take(count).ToList();
			//}

			return users.Take(count).ToList();
		}
		public static IEnumerable<User> GetUsersOrderedByID(this IEnumerable<User> users)
		{
			return users.OrderBy(x => x.ID).ToList();
		}

		public static IEnumerable<User> GetUsersOrderedByName(this IEnumerable<User> users, string name)
		{
			return users.OrderBy(x => x.Name).ToList();
		}
		public static IEnumerable<User> GetUserOrderedByCompanyName(this IEnumerable<User> users, string company)
		{
			return users.OrderBy(x => x.Company.CompanyName).ToList();
		}
		public static IEnumerable<User> GetUsersOrderedByCity(this IEnumerable<User> users, string city)
		{
			return users.OrderBy(x => x.Address.City).ToList();
		}
	}

}


