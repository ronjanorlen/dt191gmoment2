using System.Diagnostics;
using Microsoft.AspNetCore.Mvc; // Använd mvc-mönstret
using dt191gmoment2.Models;

namespace dt191gmoment2.Controllers;

public class HomeController : Controller
{
    // Startsidan
    public IActionResult Index() 
    {
        return View(); // Returnera vy 
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
    public IActionResult Equipment(EquipmentModel model){
        // Validera input 
        if(ModelState.IsValid) {
            // Korrekt
        } else {
            // Ej korrekt
        }
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
