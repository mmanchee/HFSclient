using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HFSclient.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace HFSclient.Controllers
{
   public class Standings : Controller
  {
  
    public IActionResult Index()
    {
      return View();
    }
  }
}