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
        Console.WriteLine($"{newPet.Name} is a {newPet.Age} year old {newPet.Species} and they {newPet.IsAdorable}");
        if (!ModelState.IsValid)
        {
            return Index();
        }
        FakePetDb.Add(newPet);
        return RedirectToAction("AllPets"); //we will change this in a bit
    }

    [HttpGet("pets")]
    public ViewResult AllPets()
    {
        return View("AllPets",FakePetDb);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
