using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HFSclient.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HFSclient.Controllers
{
  public class WeeksController : Controller
  {
    public readonly HFSclientContext _db;
    public WeeksController(HFSclientContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Week> model = _db.Weeks.ToList();
      return View(model);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Create()
    {
      return View();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Create(Week week)
    {
      _db.Weeks.Add(week);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisWeek = _db.Weeks
        .Include(owner => owner.WeekId)
        .FirstOrDefault(week => week.WeekId == id);
      return View(thisWeek);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Edit(int id)
    {
      var thisWeek = _db.Weeks.FirstOrDefault(x => x.WeekId == id);
      return View(thisWeek);
    }
    
    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Edit(Week week)
    {
      _db.Entry(week).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = week.WeekId});
    }
  }
}