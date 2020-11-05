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
    public ActionResult Index(int id)
    {
      List<Roster> model = _db.Rosters.Where(x => x.GroupId == id).ToList();
      ViewBag.Group = _db.Groups.FirstOrDefault(x => x.GroupId == id);
      return View(model);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult PlayerSearch(int id)// Search for Players
    {
      ViewBag.Owner.GroupId = id;
      //var model ... find Available players
      return View();
    }

    [HttpPost]
    public ActionResult AddPlayer(int GroupId, int PlayerId) //commish add players to rosterc
    {
      if(_db.Rosters.Where(x => x.GroupId == GroupId).Count() > 12)   //    Sets roster size
      {
        Player p = GetPlayerFromApi(PlayerId)
        Roster roster = new Roster();
        roster.GroupId = GroupId;
        roster.PlayerId = PlayerId;
        roster.Position = "bench";
        roster.LastName = p.LastName;
        roster.FirstName = p.FirstName;
        _db.Rosters.Add(roster);
        _db.SaveChanges();
      }
      else
      {
          //send error back "over roster size limit"
      }
      
      
      return RedirectToAction("Index"); //might have to change which view
    }
    public ActionResult Details(int id)
    {
      int PlayerId = id;
      Player model = GetPlayerFromApi(PlayerId)
      return View(model);
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
    public ActionResult RemovePlayer(int id)
    {
      var model = _db.Rosters.FirstOrDefault(x => x.RosterId == id);
      return View(model);
    }
    public ActionResult ConfirmRemove(int id, int groupId)
    {
      var player = _db.Roster.FirstOrDefault(x => x.PlayerId == id && x.GroupId == groupId);
      _db.EngineerLicense.Remove(player);
      _db.SaveChanges();
      return RedirectToAction("Index", new {});
    }   
  }
}