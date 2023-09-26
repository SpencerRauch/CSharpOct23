// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// Bird birb = new("Birb"); // this cannot happen! We cannot instantiate abstract classes
Hawk Redtail = new("red tail hawk");
Redtail.Fly();
Ostrich Gary = new("Gary");
Duck Daffy = new("Daffy");

List<Bird> AllMyBirds = new(){Gary,Redtail,Daffy};

foreach (Bird birb in AllMyBirds)
{
    if (birb is IFly f)
    {
        f.Fly();
    }

    if (birb is IRun r)
    {
        r.Run();
    }

    if (birb is ISwim s)
    {
        s.Swim();
    }


}