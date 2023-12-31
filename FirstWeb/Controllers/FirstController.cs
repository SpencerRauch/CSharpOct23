using Microsoft.AspNetCore.Mvc;

namespace FirstWeb.Controllers;

public class FirstController : Controller
{
    [HttpGet]
    [Route("")] //we do not need leading slashes in these routes in C#
    public string Index()
    {
        return "<h1>Hello from our controller!</h1>";
    }

    [HttpGet("two")]
    public string PageTwo()
    {
        return "Yup this is page two!";
    }

    [HttpGet("params/{id}/{name}")]
    public string Params(int id, string name)
    {
        return $"{name} is id number {id}";
        
    }

    [HttpGet("view")]
    public ViewResult MyView()
    {
        ViewBag.Name = "Bob";
        ViewBag.Number = 10;
        ViewBag.Flavors = new List<string>(){"vanilla", "strawberry"};
        return View(); // we can leave out the view name if it matches the action name
        //return View("MyView");
    }

    [HttpGet("form")]
    public ViewResult MyForm()
    {
        return View();
    }

    // [HttpPost("process")]
    // public RedirectResult Process(string Name, int Passcode)
    // {
    //     Console.WriteLine($"Got credentials: {Name} {Passcode}");
    //     return Redirect("form");
        
    // }

    // [HttpPost("process")]
    // public RedirectToActionResult Process(string Name, int Passcode)
    // {
    //     Console.WriteLine($"Got credentials: {Name} {Passcode}");
    //     return RedirectToAction("MyForm");
        
    // }

    [HttpPost("process")]
    public IActionResult Process(string Name, int Passcode)
    {
        Console.WriteLine($"Got credentials: {Name} {Passcode}");
        if (Passcode == 1234)
        {
            return RedirectToAction("MyView");
        }
        return View("TryAgain");
        
    }


    [HttpGet("{**path}")]
    public string Lost()
    {
        return "I think you are lost!";
    }

}