using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HFSclient.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace HFSclient.Controllers
{
  public class RostersController : Controller
  {
    public readonly HFSclientContext _db;
    public RostersController(HFSclientContext db)
    {
      _db = db;
    }
    public ActionResult Index(int id)
    {
      List<Roster> model = _db.Rosters.Where(x => x.GroupId == id).ToList();
      ViewBag.Group = _db.Groups.FirstOrDefault(x => x.GroupId == id);
      return View(model);
    }
    public ActionResult Search(int id)
    {
      ViewBag.GroupId = id;
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Search(int id, string LastName)// Search for Players
    {
      ViewBag.GroupId = id;
      var model = await Player.SearchPlayer(LastName);
      return View("PlayerSearch", model);      
    }
    public ActionResult AddPlayer(int id, int groupId) //commish add players to rosterc
    {
      System.Console.WriteLine(_db.Rosters.Where(x => x.GroupId == groupId).Count());
      if(_db.Rosters.Where(x => x.GroupId == groupId).Count() <= 12)   //    Sets roster size
      {
        System.Console.WriteLine(id);
        System.Console.WriteLine(groupId);
        var p = Player.GetPlayerFromApi(id); 
        Roster roster = new Roster();
        roster.GroupId = groupId;
        roster.PlayerId = id;
        roster.Position = "bench";
        roster.FootballPosition = p.Result.Position;
        roster.LastName = p.Result.LastName;
        roster.FirstName = p.Result.FirstName;
        _db.Rosters.Add(roster);
        _db.SaveChanges();
      }
      else
      {
        //send error back "over roster size limit"
      }
      return RedirectToAction("Index", new { id = groupId}); //might have to change which view
    }
    public ActionResult Details(int id)
    {
      int PlayerId = id;
      var model = Player.GetPlayerFromApi(PlayerId);
      return View(model);
    }

    // public Task<ActionResult> Edit(int id )
    // {
    //   Roster r = _db.Rosters.Where(x => x.RosterId).FirstOrDefault();
    //   View(r);
    // }
    
    // [HttpPost]//may need to be a put
    // [Authorize(Roles = "Administrator")]
    public ActionResult Edit(int id)
    {
      var roster = _db.Rosters.FirstOrDefault(x => x.RosterId == id);
      if(roster.Position == "bench")
      {
        roster.Position = roster.FootballPosition; 
      }
      else
      {
        roster.Position = "bench";
      }
      
      _db.Entry(roster).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", new { id = roster.GroupId});
    }
    public ActionResult RemovePlayer(int id)
    {
      var model = _db.Rosters.FirstOrDefault(x => x.RosterId == id);
      return View(model);
    }
    public ActionResult ConfirmRemove(int id, int groupId)
    {
      var player = _db.Rosters.FirstOrDefault(x => x.PlayerId == id && x.GroupId == groupId);
      _db.Rosters.Remove(player);
      _db.SaveChanges();
      return RedirectToAction("Index", new {});
    }   
  }
}