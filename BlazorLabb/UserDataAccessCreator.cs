namespace BlazorLabb
{
    public static class UserDataAccessCreator
	{
		public static IUserDataAccess Create(DataSource dataSource, int userCount)
		{
            return dataSource switch
            {
                DataSource.Random => new RandomlyGeneratedUserDataAccess(userCount),
                DataSource.Dummy => new DummyUserDataAccess(userCount),
                DataSource.API => new APIUserDataAccess(userCount),
                _ => throw new ArgumentException("Argument is not valid", nameof(dataSource)),
            };
        }
	}	
}



