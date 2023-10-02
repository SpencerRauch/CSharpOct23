#pragma warning disable CS8618
public class IceCreamStore
{
    public string StoreName { get; set; }
    public List<Flavor> AvailableFlavors { get; set; } = new();

    public IceCreamStore() { }

    public IceCreamStore(string storeName, List<Flavor> flavors)
    {
        StoreName = storeName;
        AvailableFlavors = flavors;
    }

    public override string ToString()
    {
        string StoreInfo = @$"{StoreName}
        Available flavors: ";
        foreach (Flavor flavor in AvailableFlavors)
        {
            StoreInfo += $@"
            {flavor.Name}";
        }
        return StoreInfo;
    }
}