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

        return View(equipment); // Returnera vy 
    }

    // Om-sida

    [HttpGet("/om")] // Routing till om-sida

    public IActionResult About()
    {
        return View(); // Returnera vy
    }

    // Utrustning-sida 

    [HttpGet("/utrustning")] // Routing till utrustning-sida

    public IActionResult Equipment()
    {
        return View(); // Returnera vy 
    }

    // Ta emot data från formuläret 
    [HttpPost]
    public IActionResult Equipment(EquipmentModel model)
    { // Ta emot instans av formuläret 
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
        else
        {
            // Ej korrekt ifyllt 
        }
        return View(); // Returnera vy
    }


    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
