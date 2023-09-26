class Fruit : Food
{
    public bool IsRipe { get;set; }

    public Fruit(bool delicious, bool spicy, string name, double price, bool ripe)
     : base(delicious,spicy,name,price)
    {
        IsRipe = ripe;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Is ripe? {IsRipe}");
        
    }
}