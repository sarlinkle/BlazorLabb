namespace BlazorLabb
{
	public static class UserExtensions
	{
		public static IEnumerable<User> GetAllUsers(this IEnumerable<User> users)
		{
				return users.GetSomeUsers(0, users.Count());
		}
		public static IEnumerable<User> GetSomeUsers(this IEnumerable<User> users, int startIndex, int count)
		{
			if (startIndex < 0 || startIndex >= users.Count())
			{
				throw new ArgumentOutOfRangeException(nameof(startIndex));
			}
			if (count < 0 || startIndex + count > users.Count())
			{
				throw new ArgumentOutOfRangeException(nameof(count));
			}
			return users.Take(count).ToList();
        }
        public static IEnumerable<User> GetSomeUsersOrderedByName(this IEnumerable<User> users)
        {
            return users.GetSomeUsers(0, 5).OrderBy(x => x.Name).ToList();

            //return users.GetSomeUsers(0, 5).OrderByDescending(x => x.Name).ToList();            
        }

        public static IEnumerable<User> GetUsersOrderedByID(this IEnumerable<User> users)
        {
            return users.OrderBy(x => x.ID).ToList();

            //return users.OrderByDescending(x => x.ID).ToList();
        }

        public static IEnumerable<User> GetUsersOrderedByName(this IEnumerable<User> users)
        {
			return users.GetSomeUsers(0, users.Count()).OrderBy(x => x.Name).ToList();
        }
        public static IEnumerable<User> GetUserOrderedByCompanyName(this IEnumerable<User> users)
		{
			return users.OrderBy(x => x.Company.Name).ToList();
		}
		public static IEnumerable<User> GetUsersOrderedByCity(this IEnumerable<User> users)
		{
			return users.OrderBy(x => x.Address.City).ToList();
		}
		public static IEnumerable<User> GetUserNameFilteredBySearch(this IEnumerable<User> users, string searchText)
		{
			return users.Where(x => x.Name.ToLower().Contains(searchText.ToLower())).ToList();
		}

        //Make a method searching numbers instead of strings

        //public static IEnumerable<User> GetUserFilteredBySearchInt(this IEnumerable<User> users, int searchNumber)
        //{
        //	return users.Where(x => x.ID.Equals(searchNumber));
        //	//return users.Where(x => x.ID).ToList();
        //}

        public static IEnumerable<User> GetUserIDFilteredBySearch(this IEnumerable<User> users, string searchText)
        {
            return users.Where(x => x.ID.ToString().Contains(searchText.ToLower())).ToList();
        }
    }

}


