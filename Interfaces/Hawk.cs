class Hawk : Bird, IFly
{
    public Hawk(string name) : base(name){}

    public int AirSpeed { get; set; } = 10;

    public void Fly()
    {
        Console.WriteLine($"{Name} takes to the sky at a rate of {AirSpeed} mph");
    }
}