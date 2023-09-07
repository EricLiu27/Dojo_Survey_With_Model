using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey_With_Model.Models;

namespace Dojo_Survey_With_Model.Controllers;

public class HomeController : Controller
{
    static SurveyModel surveymodel;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("submit")]
    public IActionResult Submit(SurveyModel newSurveyModel)
    {
        surveymodel = newSurveyModel;
        return RedirectToAction("Display");
    }

    [HttpGet("display")]
    public IActionResult Display()
    {
        return View(surveymodel);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
