using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HFSclient.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HFSclient.Controllers
{
  public class SchedulesController : Controller
  {
    public readonly HFSclientContext _db;
    public SchedulesController(HFSclientContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      
      List<Schedule> model = _db.Schedules.ToList();
      return View(model);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Create()
    {
      return View();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Create(League league)
    {
      _db.Leagues.Add(league);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisLeague = _db.Leagues
        .FirstOrDefault(league => league.LeagueId == id);
      return View(thisLeague);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Edit(int id)
    {
      var thisLeague = _db.Leagues.FirstOrDefault(x => x.LeagueId == id);
      return View(thisLeague);
    }
    
    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Edit(League league)
    {
      _db.Entry(league).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = league.LeagueId});
    }
    [HttpPost]
    public ActionResult Search(string leagueName)
    {
      List<League> model = _db.Leagues.Where(x => x.LeagueName.Contains(leagueName)).ToList();
      return View("Index", model);
    }    
  }
}