using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetParty.Models;

namespace PetParty.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static List<Pet> FakePetDb = new();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        ViewBag.Choices = new List<SelectListItem>()
        {
            new SelectListItem("--pick one--","",true,true),
            new SelectListItem("Bear","Bear"),
            new SelectListItem("Bobcat","Bobcat"),
            new SelectListItem("Deer","Deer")
        };
        return View("Index");
    }

    [HttpPost("pets/create")]
    public IActionResult CreatePet(Pet newPet)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
        }
        // Console.WriteLine($"{newPet.Name} is a {newPet.Age} year old {newPet.Species} and they {newPet.IsAdorable}");
        if (!ModelState.IsValid)
        {
            return Index();
        }
        FakePetDb.Add(newPet);
        HttpContext.Session.SetString("LastPet",newPet.Name);
        return RedirectToAction("AllPets"); //we will change this in a bit
    }

    [HttpGet("pets")]
    public IActionResult AllPets()
    {
        // string? LastPet = HttpContext.Session.GetString("LastPet");
        if (HttpContext.Session.GetString("LastPet") == null)
        {
            return RedirectToAction("Index");
        }
        return View("AllPets", FakePetDb);
    }

    [HttpPost("pets/filter")]
    public RedirectToActionResult SetFilter(int limit)
    {
        HttpContext.Session.SetInt32("Limit", limit);
        return RedirectToAction("AllPets");
    }

    [HttpPost("pets/filter/clear")]
    public RedirectToActionResult ClearFilter()
    {
        // HttpContext.Session.Clear();
        HttpContext.Session.Remove("Limit");
        return RedirectToAction("AllPets");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
