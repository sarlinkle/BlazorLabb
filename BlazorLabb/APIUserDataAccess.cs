using System.Text.Json;

namespace BlazorLabb
{
    public class APIUserDataAccess : IUserDataAccess
    {
        private List<User>? _users;
        public string DataSource { get; set; }

        public List<User> Users
        {
            get
            {
                //_users ??= GetUsers();
                _users ??= new List<User>();
                return _users;
            }
            private set
            {
                _users = value;
            }
        }
        public APIUserDataAccess()
        {
            DataSource = "APIUsers";
        }
        public async Task<string?> GetAPIResponseStringAsync()
        {
            using var client = new HttpClient();
            return await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
        }
        public List<User>? DeserializeJson(string json)
        {
            List<User>? deserializedJson = JsonSerializer.Deserialize<List<User>>(json);
            return deserializedJson;
        }

        public User? DeserializeFirstUserJson(string json)
        {
            User? deserializedJson = JsonSerializer.Deserialize<User>(json);
            return deserializedJson;
        }
        public async Task<List<User>?> GetUsers()
        {
            var result = await GetAPIResponseStringAsync();
            if (result != null)
            {
                var users = DeserializeJson(result);

                if (users == null)
                {
                    throw new Exception("Deserialization failed");
                }
                return users;
            }
            else
            {
                throw new Exception("No response from API");
            }
        }
    }
}



