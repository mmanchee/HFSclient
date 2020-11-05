using Microsoft.AspNetCore.Mvc;
using HFSclient.Models;
using System.Collections.Generic;
using System.Linq;

namespace HFSclient.Controllers
{  
  public class HomeController : Controller
  {
    private readonly HFSclientContext _db;
    public HomeController(HFSclientContext db)
    {
      _db = db; 
    }
    public IActionResult Index()
    {
      return View();
    }
  }
}