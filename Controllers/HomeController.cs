using System.Diagnostics;
using Microsoft.AspNetCore.Mvc; // Använd mvc-mönstret
using dt191gmoment2.Models;
using System.Text.Json; // läsa in och behandla json-data 

namespace dt191gmoment2.Controllers;

public class HomeController : Controller
{
    // Startsidan
    public IActionResult Index()
    {
        // läs in equipment.json
        string jsonStr = System.IO.File.ReadAllText("equipment.json");
        // Deserialize json 
        var equipment = JsonSerializer.Deserialize<List<EquipmentModel>>(jsonStr);

        ViewBag.Hello = "Välkommen till fjällkompisar!"; // Välkomstmeddelande med ViewBag 
        ViewBag.MyName = HttpContext.Session.GetString("MyName"); // Hämta ev inmatat namn med ViewBag

        return View(equipment); // Returnera vy med skidutrustning
    }

    // Formulär för att fylla i sitt namn 
    [HttpPost]
    public IActionResult SaveMe(string myName)
    {
        if (!string.IsNullOrWhiteSpace(myName))
        {
            // Spara namn i session 
            HttpContext.Session.SetString("MyName", myName);
        }

        return RedirectToAction("Index");
    }

    // Om-sida

    [Route("/om")] // Routing till om-sida

    public IActionResult About()
    {
        ViewBag.MyName = HttpContext.Session.GetString("MyName"); // Hämta inmatat namn

        return View(); // Returnera vy
    }

    // Utrustning-sida 

    [Route("/utrustning")] // Routing till utrustning-sida

    public IActionResult Equipment()
    {
        ViewBag.MyName = HttpContext.Session.GetString("MyName"); // Hämta inmatat namn 
        return View(); // Returnera vy 
    }

    // Ta emot data från formuläret 
    [HttpPost]
    [Route("/utrustning")] // Routing till utrustning-sida
    // Ta emot instans av formuläret 
    public IActionResult Equipment(EquipmentModel model)
    {
        ViewBag.MyName = HttpContext.Session.GetString("MyName"); // Hämta inmatat namn
        // Validera input 
        if (ModelState.IsValid)
        // Korrekt ifyllt
        {
            // läs in equipment.json
            string jsonStr = System.IO.File.ReadAllText("equipment.json");
            // Deserialize json 
            var equipment = JsonSerializer.Deserialize<List<EquipmentModel>>(jsonStr);

            // Lägg till ny utrustning 
            if (equipment != null)
            {
                equipment.Add(model);
                // Serialize json 
                jsonStr = JsonSerializer.Serialize(equipment);
                // Skriv ändringar till equipment.json 
                System.IO.File.WriteAllText("equipment.json", jsonStr);
            }

            ModelState.Clear(); // Rensa 

            return RedirectToAction("Index", "Home"); // Returnera startsidan 
        }

        return View(); // Returnera vy
    }
}
