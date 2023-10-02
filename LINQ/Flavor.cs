public class Flavor
{
    public string Name { get;set; }
    public bool ContainsNuts { get;set; }

    public Flavor (string name, bool containsNuts)
    {
        Name = name;
        ContainsNuts = containsNuts;
    }
}