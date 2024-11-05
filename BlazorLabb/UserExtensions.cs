namespace BlazorLabb
{
	public static class UserExtensions
	{
		public static List<User> GetAllUsers(this IEnumerable<User> users)
		{
				return users.ToList();
		}
		public static List<User> GetSomeUsers(this IEnumerable<User> users, int startIndex, int count)
		{
			return users.Take(5).ToList();
        }
        public static List<User> GetSomeUsersOrderedByName(this IEnumerable<User> users, bool isClicked)
        {
            return isClicked ? users.Take(5).OrderBy(x => x.Name).ToList() : users.Take(5).OrderByDescending(x => x.Name).ToList();
        }
        public static List<User> GetUsersOrderedByID(this IEnumerable<User> users, bool isClicked)
        {
            return isClicked ? users.OrderBy(x => x.ID).ToList() : users.OrderByDescending(x => x.ID).ToList();
        }
        public static List<User> GetUsersOrderedByName(this IEnumerable<User> users, bool isClicked)
        {
            return isClicked ? users.OrderBy(x => x.Name).ToList() : users.OrderByDescending(x => x.Name).ToList();
        }
        public static List<User> GetUserOrderedByCompanyName(this IEnumerable<User> users, bool isClicked)
		{
			return isClicked ? users.OrderBy(x => x.Company.Name).ToList() : users.OrderByDescending(x => x.Company.Name).ToList();
		}
		public static List<User> GetUsersOrderedByCity(this IEnumerable<User> users, bool isClicked)
		{
			return isClicked ? users.OrderBy(x => x.Address.City).ToList() : users.OrderByDescending(x => x.Address.City).ToList();
		}
		public static List<User> GetUserNameFilteredBySearch(this IEnumerable<User> users, string searchText)
		{
			return users.Where(x => x.Name.ToLower().Contains(searchText.ToLower())).ToList();
		}
        public static IEnumerable<User> GetUserIDFilteredBySearch(this IEnumerable<User> users, string searchText)
        {
            return users.Where(x => x.ID.ToString().Contains(searchText.ToLower())).ToList();
        }
    }

}


