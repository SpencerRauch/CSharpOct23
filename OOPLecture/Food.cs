class Food
{

    private bool _Delicious;
    public bool Delicious { get { return _Delicious; } }
    private bool _Spicy;
    // private string _Name;
    // public string Name {get {return _Name;}}
    public string Name { get; set; }
    private double _Price;
    public double Price { get { return _Price; } set { if (value >= 0) _Price = value; } }

    public Food(bool delicious, bool spicy, string name, double price)
    {
        _Delicious = delicious;
        _Spicy = spicy;
        Name = name;
        _Price = price;
    }

    public Food(bool spicy, string name, double price)
    {
        _Delicious = true;
        _Spicy = spicy;
        Name = name;
        _Price = price;
    }

    public Food(bool delicious, bool spicy, string name)
    {
        _Delicious = delicious;
        _Spicy = spicy;
        Name = name;
        _Price = 0.00;
    }

    public Food()
    {
        _Delicious = true;
        _Spicy = true;
        Name = "Generic Food";
        _Price = 0.00;

    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"{Name}");
        Console.WriteLine($"Is delicious? {_Delicious}");
        Console.WriteLine($"Is spicy? {_Spicy}");
        Console.WriteLine($"Price: {Price}");
    }

    public virtual void PrintInfo(int times)
    {
        for (int i = 0; i < times; i++)
        {
            this.PrintInfo();
        }
    }

}