

class Ostrich : Bird, IRun
{
    public Ostrich(string name):base(name){}

    public int LandSpeed { get; set; } = 45;

    public void Run()
    {
        Console.WriteLine($"{Name} runs off at a rate of {LandSpeed} mph");
    }
}