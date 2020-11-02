using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HFSclient.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HFSclient.Controllers
{
  public class OwnersController : Controller
  {
    public readonly HFSclientContext _db;
    public OwnersController(HFSclientContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Owner> model = _db.Owners.ToList();
      return View(model);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [Authorize]
    [HttpPost]
    public ActionResult Create(Owner owner)
    {
      _db.Owners.Add(owner);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisOwner = _db.Owners
        .FirstOrDefault(owner => owner.OwnerId == id);
      return View(thisOwner);
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
      var thisOwner = _db.Owners.FirstOrDefault(x => x.OwnerId == id);
      return View(thisOwner);
    }
    
    [Authorize]
    [HttpPost]
    public ActionResult Edit(Owner owner)
    {
      _db.Entry(owner).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = owner.OwnerId});
    }
    [HttpPost]
    public ActionResult Search(string ownerName)
    {
      List<Owner> model = _db.Owners.Where(x => x.OwnerName.Contains(ownerName)).ToList();
      return View("Index", model);
    }    
  }
}