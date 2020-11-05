using Microsoft.AspNetCore.Mvc;
using HFSclient.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
namespace HFSclient.Controllers
{
   public class Standings : Controller
  {
    private readonly HFSclientContext _db;
    
    public IActionResult Index(int id)
    {
      List<Standing> model= _db.Standings.Where(x => x.LeagueId == id).OrderByDescending(x => x.Wins).ToList();
      return View(model);
    }
  }
}