using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HFSclient.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HFSclient.Controllers
{
  public class RostersController : Controller
  {
    public readonly HFSclientContext _db;
    public RostersController(HFSclientContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Roster> model = _db.Rosters.ToList();
      return View(model);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Create()
    {
      return View();
    }

    [Authorize(Roles = "Administrator")]
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

    [Authorize(Roles = "Administrator")]
    public ActionResult Edit(int id)
    {
      var thisRoster = _db.Rosters.FirstOrDefault(x => x.RosterId == id);
      return View(thisRoster);
    }
    
    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Edit(Roster roster)
    {
      _db.Entry(roster).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = roster.RosterId});
    }
  }
}