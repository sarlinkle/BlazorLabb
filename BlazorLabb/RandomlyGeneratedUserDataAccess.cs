namespace BlazorLabb
{
    public class RandomlyGeneratedUserDataAccess : IUserDataAccess
	{
		private List<User>? _users;
		public string DataSource { get; set; }
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
		private readonly string[] _zipCodes = new[] { "112 45", "222 56", "E9 5PT", "NW5 7RT", "725 92", "13456", "SW3 5TG", "ABC 123", "DEF 456", "GHI 789" };
		private readonly string[] _streets = new[] { "streetA", "streetB", "streetC", "streetD", "streetE", "streetF", "streetG", "streetH", "streetI", "streetJ", "streetK", "streetL", "streetM", "streetN", "streetO", "streetP", "streetQ", "streetR", "streetS", "streetT", "streetU", "streetV", "streetW", "streetX", "streetY", "streetZ", };
		private readonly string[] _companyNames = new[] { "Wombat Waffles Inc.", "Quirky Quokkas Consulting", "Silly Sausage Solutions", "Unicorn Umbrella Co.", "Llama Drama Productions", "Pickle Pals Marketing", "Couch Potato Innovations", "Giggly Goose Gadgets", "Bumbling Bumblebee Enterprises", "Sassy Squirrel Systems", "Fuzzy Slipper Delivery", "Ninja Noodles Restaurant", "Jolly Jellybean Technologies", "Cranky Cactus Creations", "Cheesy Grin Media", "Witty Whiskers Pet Care", "Doodlebug Design Co.", "Zany Zebra Travels", "Funky Ferret Fabrics", "Snickerdoodle Software", "Bubble Wrap Ventures", "Laughing Lemur Logistics", "Spaghetti Unicorn Industries", "Goofy Gopher Gardens", "Wacky Walrus Web Services", "Dizzy Duck Drone Co.", "Quizzical Quokka Quarters", "Fluffy Cloud Construction", "Cheeky Chipmunk Chocolates", "Merry Mongoose Marketing" };
		private readonly string[] _companyCatchPhrases = new[] { "Fluffy, Fun, and Absolutely Waffle-tastic!", "Your Ideas, Our Quirks!", "Making Sausages and Smiles!", "Rainbows Never Looked So Good!", "Bringing the Drama, One Llama at a Time!", "Dill-ightful Strategies for Every Crunch!", "Ideas So Easy, You'll Just Sit Back!", "Quack Up Your Life with Our Gadgets!", "Buzzing with Creativity!", "Nuts About Your Success!", "Comfort to Your Doorstep!", "Slurp It Up—Stealthily Delicious!", "Sweet Solutions for a Sticky World!", "Prickly Designs That Stand Out!", "Where Every Project Is Gouda!", "Purr-fect Care for Your Furry Friends!", "Where Ideas Take Flight!", "Stripes of Adventure Await!", "Sew Funky, Sew Fun!", "Sweet Solutions for Every Problem!", "Pop into Success!", "Delivering Smiles, One Package at a Time!", "Pasta That’s Out of This World!", "Digging Up Joy in Every Garden!", "Surfing the Web with Style!", "Fly High, Waddle Far!", "Home Is Where the Quokka Is!", "Building Dreams on a Cloud!", "Nibble on a Little Mischief!", "Sly Strategies for Happy Clients!" };
		public RandomlyGeneratedUserDataAccess()
		{
			DataSource = "RandomUsers";
        }

		private List<User> GetRandomUsers()
		{
			int userCount = 30;

			return Enumerable.Range(1, userCount).Select(i => new User
			(
				new Random().Next(1, 1000),
				_names[Random.Shared.Next(_names.Length)],
                _emailAddresses[Random.Shared.Next(_emailAddresses.Length)],
                new Address
                (
                    _streets[Random.Shared.Next(_streets.Length)],
                    _cities[Random.Shared.Next(_cities.Length)],
                    _zipCodes[Random.Shared.Next(_zipCodes.Length)]

                ),
				new Company
				(
					_companyNames[Random.Shared.Next(_companyNames.Length)],
					_companyCatchPhrases[Random.Shared.Next(_companyCatchPhrases.Length)]
				)
            )).ToList();
		}
	}
    }



