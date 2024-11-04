namespace BlazorLabb
{
    public static class UserDataAccessCreator
	{
		public static IUserDataAccess Create(DataSource dataSource)
		{
            return dataSource switch
            {
                DataSource.Random => new RandomlyGeneratedUserDataAccess(),
                DataSource.Dummy => new DummyUserDataAccess(),
                DataSource.API => new APIUserDataAccess(),
                _ => throw new ArgumentException("Argument is not valid", nameof(dataSource)),
            };
        }
	}	
}



