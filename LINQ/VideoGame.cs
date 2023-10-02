#pragma warning disable CS8618
public class VideoGame
{
    public string Title { get; set; }
    public string Studio { get; set; }
    public string Rating { get; set; }
    public double Price { get; set; }
    public string Platform { get; set; }

    public VideoGame() { }

    public VideoGame(string title, string studio, string rating, double price, string platform)
    {
        Title = title;
        Studio = studio;
        Rating = rating;
        Price = price;
        Platform = platform;
    }

    public override string ToString()
    {
        // the @ symbol will make this a raw string "verbatim string"
        return $@"
    Title:     {Title}
    Studio:    {Studio}
    Rating:    {Rating}
    Price:     {Price}
    Platform:    {Platform}";
    }
}