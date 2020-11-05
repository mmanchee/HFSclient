using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HFSclient.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HFSclient.Controllers
{
  public class TrackersController : Controller 
  {
    public readonly HFSclientContext _db;  
    public TrackersController(HFSclientContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Tracker> model = _db.Trackers.ToList();
      return View(model);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Create()
    {
      return View(); 
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Create(Tracker Tracker)
    {
      _db.Trackers.Add(Tracker);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisTracker = _db.Trackers
        .Include(owner => owner.TrackerId)
        .FirstOrDefault(Tracker => Tracker.TrackerId == id);
      return View(thisTracker);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Edit(int id)
    {
      var thisTracker = _db.Trackers.FirstOrDefault(x => x.TrackerId == id);
      return View(thisTracker);
    }
    
    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Edit(Tracker Tracker)
    {
      _db.Entry(Tracker).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = Tracker.TrackerId});
    }
  }
}