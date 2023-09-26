// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Food Kiwi = new(true,false,"Kiwi",0.50);

Console.WriteLine($"{Kiwi.Name} {(Kiwi.Delicious ? "is" : "is not")} delicious");

Kiwi.Price = 100.00;
Console.WriteLine(Kiwi.Price);
Kiwi.Price = -100.00;
Console.WriteLine(Kiwi.Price);
Kiwi.Name = "Super Special Kiwi";
Console.WriteLine($"{Kiwi.Name} {(Kiwi.Delicious ? "is" : "is not")} delicious");

Kiwi.PrintInfo();

Fruit Apple = new(true,false,"granny smith",0.49,true);
Apple.PrintInfo();

Food Generic = new();
Generic.PrintInfo(100);

Food NewFood = new(true, "jalapeno", 0.24);