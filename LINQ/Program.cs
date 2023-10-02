using System.Reflection.Metadata;

List<VideoGame> Games = new()
{
    new VideoGame("Apex Legends", "Riot", "E", 0, "Xbox, PC"),
    new VideoGame("The Last of Us", "Naughty Dog", "M", 39.99, "PlayStation"),
    new VideoGame("Untitled Goose Game", "House House", "E", 29.99, "PC"),
    new VideoGame("Super Mario World", "Nintendo", "E", 49.99, "SNES"),
    new VideoGame("Elden Ring", "FromSoftware", "M", 59.99, "PC"),
    new VideoGame("World of Warcraft", "Blizzard", "E", 49.99, "PC"),
    new VideoGame("Overwatch 2", "Blizzard", "T", 0, "PC"),
    new VideoGame { Title = "The Legend of Zelda: Breath of the Wild", Studio = "Nintendo", Rating = "E10+", Price = 59.99, Platform = "Nintendo Switch"},
    new VideoGame { Title = "MonsterHunterWorld", Studio = "Capcom", Rating = "M", Price = 40.99, Platform = "PlayStation 4" },
    new VideoGame { Title = "Grand Theft Auto V", Studio = "Rockstar Games", Rating = "M", Price = 29.99, Platform = "PlayStation 4" },
    new VideoGame { Title = "Minecraft", Studio = "Mojang", Rating = "E10+", Price = 26.95, Platform = "PC" },
    new VideoGame { Title = "Fortnite", Studio = "Epic Games", Rating = "T", Price = 0, Platform = "Various" },
    new VideoGame { Title = "Red Dead Redemption 2", Studio = "Rockstar Games", Rating = "M", Price = 39.99, Platform = "Xbox One" },
    new VideoGame { Title = "Super Mario Odyssey", Studio = "Nintendo", Rating = "E10+", Price = 49.99, Platform = "Nintendo Switch"},
    new VideoGame { Title="Kirby's Air Ride",Studio="Nintendo",Rating="E",Price=20.00,Platform="Gamecube"},
    new VideoGame { Title = "Hades", Studio ="Supergiant Games", Rating = "T", Price = 24.99, Platform ="Various"},
    new VideoGame { Title = "Cuphead", Studio ="Studio MDHR", Rating = "E", Price = 19.99, Platform ="Various"},
    new VideoGame { Title = "Undertale", Studio = "Toby Fox", Rating = "E10+", Price = 9.99, Platform = "Various"}
};


// Getting a single result based on criteria
// VideoGame EldenRing = Games.First( g => g.Title == "Eldne Ring"); // using first will throw a runtime error if no matches found

// VideoGame? EldenRing = Games.FirstOrDefault(g => g.Title.Contains("Elden"));
// if (EldenRing == null)
// {
//     Console.WriteLine("Not Found");
// }
// else 
// {
//     Console.WriteLine(EldenRing);
// }




// // Getting multiple results based on criteria
// List<VideoGame> Affordable = Games.Where(game => game.Price < 30.00).ToList();
// // Affordable.ForEach(Console.WriteLine);

// // Getting select pieces of data
// List<string> AffordableGameNames = Affordable.Select(ag => ag.Title).ToList();
// AffordableGameNames.ForEach(Console.WriteLine);

List<string> AffordableGameNames = Games.Where(g=>g.Price < 30.00).Select(g=>g.Title).ToList();
AffordableGameNames.ForEach(Console.WriteLine);

// Ordering / Top 3
List<VideoGame> MostExpensive = Games.OrderByDescending(g => g.Price).Take(3).ToList();
MostExpensive.ForEach(Console.WriteLine);

// Logical testing
bool FreeGames = Games.Any(g => g.Price == 0.00);
bool FreeGamesTwo = !Games.All(g => g.Price != 0.00);
Console.WriteLine($"Free games exist: {FreeGames} {FreeGamesTwo}");



Flavor Vanilla = new("Vanilla", false);
Flavor Chocolate = new("Chocolate", false);
Flavor Strawberry = new("Strawberry", false);
Flavor PeanutButter = new("Peanut Butter", true);
Flavor RockyRoad = new("Rocky Road", true);
Flavor MintChocolateChip = new("Mint Chocolate Chip", false);
Flavor CookieDough = new("Cookie Dough", false);
Flavor GreenTea = new( "Green Tea", false);
Flavor Spumoni = new("Spumoni", true);


IceCreamStore Alices = new("Alice's All Flavors", new(){Vanilla,Chocolate,Strawberry,PeanutButter,RockyRoad,MintChocolateChip,CookieDough,GreenTea,Spumoni});
IceCreamStore Fionas = new("Fiona's Few Flavors", new(){Strawberry,GreenTea,MintChocolateChip});
IceCreamStore Carls = new("Carl's Classics", new(){Vanilla,Chocolate,Strawberry,CookieDough,MintChocolateChip,RockyRoad});
IceCreamStore Bobs = new("Bob's Binary Choice",new(){PeanutButter,Chocolate});
IceCreamStore Alexs = new("Alex Miller Goes Nuts",new(){RockyRoad,Spumoni,PeanutButter});

List<IceCreamStore> StoreDirectory = new(){Alices,Fionas,Carls,Bobs,Alexs};

// nested queries 
List<IceCreamStore> NutFreeStores = StoreDirectory.Where(store => store.AvailableFlavors.All(f => !f.ContainsNuts)).ToList();
List<IceCreamStore> SellsCookieDough = StoreDirectory.Where(store => store.AvailableFlavors.Any(f => f.Name == "Cookie Dough")).ToList();
NutFreeStores.ForEach(Console.WriteLine);
SellsCookieDough.ForEach(Console.WriteLine);





