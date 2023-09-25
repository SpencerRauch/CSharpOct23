// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! Edited");

int Num = 9;
string Name = "Bob";
string Flavor = "Chocolate";

Console.WriteLine($"{Name} has {Num} coconuts");

// int[] IntArray = new int[5];
int[] IntArray = new int[]{1,2,3,4,5};

foreach (int num in IntArray)
{
    Console.WriteLine(num);
}

List<string> Names = new();

// adding to a list
Names.Add("Spencer");
Names.Add("Christian");
Names.Add("Bobby");
Names.Add("Kenneth");

Names.ForEach(Console.WriteLine);




// Num = "Bob";
Dictionary<string, int> PetAges = new()
{
    { "Wiley", 4 },
    { "Bella", 10 },
    { "Shiro", 2 },
    { "Groot", 1 },
    { "Cooper", 8 },
};
// PetAges.Add("Wiley",99999);
PetAges["Wiley"]=999;


foreach(KeyValuePair<string,int> OnePet in PetAges)
{
    Console.WriteLine($"{OnePet.Key} - {OnePet.Value}");
}

static void SayHello()
{
    Console.WriteLine("Hello how are you doing today?");
}

static int MathingTheMath(int numOne, int numTwo=100)
{
    return numOne + numTwo;
}

SayHello();

int Result = MathingTheMath(5);
Console.WriteLine(Result);
