class Duck : Bird, IFly, ISwim
{
    public Duck(string name): base(name){}

    public int AirSpeed { get ; set ; } = 5;
    public int NauticalSpeed { get ; set ; } = 2;

    public void Fly()
    {
        Console.WriteLine($"{Name} takes to the sky at a rate of {AirSpeed} mph");
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} parts the seas at {NauticalSpeed} knots");
    }
}