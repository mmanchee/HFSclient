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
      
      List<Schedule> model = _db.Schedules.ToList();
      return View(model);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Create()
    {
      return View();
    }

    [Authorize]
    [HttpPost]
    public ActionResult Create(int GroupId, int PlayerId) //commish add players to rosterc
    {
      if(_db.Rosters.Where(x => x.GroupId == GroupId).Count() > 12)   //    Sets roster size
       {
         Roster roster = new Roster();
        roster.GroupId = GroupId;
        roster.PlayerId = PlayerId;
        roster.Position = "bench";
        _db.Rosters.Add(roster);
        _db.SaveChanges();
      }
      else
      {
          //send error back "over roster size limit"
      }
      
      
      return RedirectToAction("Index"); //might have to change which view
    }
     [Authorize]
    public ActionResult Delete(int id) //commish add players to rosterc
    {
     Roster roster =  _db.Rosters.FirstOrDefault(x => x.RosterId == id);
      _db.Rosters.Remove(roster);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = roster.GroupId});
    }
    public ActionResult Details(int id) //list one fantasy teams roster id ==groupId
    {
      var Roster = _db.Rosters.Where(x => x.GroupId == id).ToList();
      return View(Roster);
    }


    
    [HttpPost]//may need to be a put
    [Authorize(Roles = "Administrator")]
    public ActionResult Edit(int id, string Position)
    {
      var roster = _db.Rosters.FirstOrDefault(x => x.RosterId == id);
      roster.Position = Position;
      _db.Entry(roster).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = roster.GroupId});
    }
    
    // [Authorize(Roles = "Administrator")]
    // [HttpPost]
    // public ActionResult Edit(League league)
    // {
    //   _db.Entry(league).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Details", new { id = league.LeagueId});
    // }
    // [HttpPost]
    // public ActionResult Search(string leagueName)
    // {
    //   List<League> model = _db.Leagues.Where(x => x.LeagueName.Contains(leagueName)).ToList();
    //   return View("Index", model);
    // }    
  }
}