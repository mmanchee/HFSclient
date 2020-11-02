using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HFSclient.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HFSclient.Controllers
{
  public class RostersController : Controller
  {
    public readonly HFSclientContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public RostersController(HFSclientContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
      _db = db;
      _userManager = userManager;
      _signInManager = signInManager;
    }
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      
      List<Roster> roster = _db.Rosters.Where(x => x.OwnerId == )
      query = query.
      List<Roster> model = _db.Rosters.ToList();
      return View(model);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [Authorize]
    [HttpPost]
    public ActionResult Create(Roster roster)
    {
      _db.Rosters.Add(roster);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisRoster = _db.Rosters
        .FirstOrDefault(roster => roster.RosterId == id);
      return View(thisRoster);
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
      var thisRoster = _db.Rosters.FirstOrDefault(x => x.RosterId == id);
      return View(thisRoster);
    }
    
    [Authorize]
    [HttpPost]
    public ActionResult Edit(Roster roster)
    {
      _db.Entry(roster).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = roster.RosterId});
    }
  }
}