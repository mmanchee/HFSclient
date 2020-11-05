using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HFSclient.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace HFSclient.Controllers
{
  public class LeaguesController : Controller
  {
    public readonly HFSclientContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public LeaguesController(UserManager<ApplicationUser> userManager, HFSclientContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public ActionResult Index()
    {
      List<League> model = _db.Leagues.ToList();
      return View(model);
    }

    // [Authorize(Roles = "Administrator")]
    public ActionResult Create()
    {
      return View();
    }

    // [Authorize(Roles = "Administrator")]
    [HttpPost]
    public async Task<ActionResult> Create(League league)
    {
      _db.Leagues.Add(league);
      _db.SaveChanges();
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      Group groupRow = new Group {LeagueId = league.LeagueId, User = currentUser, TeamName = "Commish", LeagueSeason = league.CurrentSeason, OwnerRole = "Commissioner"};
      _db.Groups.Add(groupRow);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public async Task<ActionResult> Details(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var currentGroupId = _db.Groups.FirstOrDefault(x => x.LeagueId == id && x.User.Id == currentUser.Id);
      if(currentGroupId != null)
      {
        if(currentGroupId.OwnerRole == "Commissioner")
        {
          ViewBag.Owner = true;
        }
      }
      var league = _db.Leagues.FirstOrDefault(x => x.LeagueId == id);
      List<Group> model = _db.Groups.Where(x => x.LeagueId == id && x.LeagueSeason == league.CurrentSeason).ToList();
      ViewBag.League = league;
      return View(model);
    }    

    // [Authorize(Roles = "Administrator")]
    public ActionResult Edit(int id)
    {
      var thisLeague = _db.Leagues.FirstOrDefault(x => x.LeagueId == id);
      return View(thisLeague);
    }
    
    // [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Edit(League league)
    {
      _db.Entry(league).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = league.LeagueId});
    }
    [HttpPost]
    public ActionResult Index(string Name)
    {
      List<League> model = _db.Leagues.Where(x => x.LeagueName.Contains(Name)).ToList();
      return View("Index", model);
    }
    public ActionResult Join(int id)
    {
      ViewBag.League = _db.Leagues.FirstOrDefault(x => x.LeagueId == id);
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Join(Group group)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisLeague = _db.Leagues.FirstOrDefault(x => x.LeagueId == group.LeagueId);
      Group league = new Group {LeagueId = group.LeagueId, User = currentUser, TeamName = group.TeamName, LeagueSeason = thisLeague.CurrentSeason, OwnerRole = "Owner"};
      _db.Groups.Add(league);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = group.LeagueId});
    }
    public ActionResult RemoveOwner(int id)
    {
      var model = _db.Groups.FirstOrDefault(x => x.GroupId == id);
      return View(model); 
    }
    public ActionResult ConfirmRemove(int id)
    {
      Group groupToBeInactive = _db.Groups.FirstOrDefault(x => x.GroupId == id);
      groupToBeInactive.Active = 0;
      _db.Entry(groupToBeInactive).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {groupToBeInactive.LeagueId});
    }

    public ActionResult Commish(int id)
    {
      League l = _db.Leagues.FirstOrDefault(x => x.LeagueId == id);
      
      return View(l);
    }
  }
}