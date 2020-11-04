using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HFSclient.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using HFSclient.Wrappers;
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
    public  ActionResult  Index()
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
    public ActionResult Create(int GroupId1, int GroupId2, int Week, int Team1Score, int Team2Score )
    {
      Schedule schedule = new Schedule();
      if(GroupId1 != 0)
      {
        schedule.GroupId1 = GroupId1;
      }
      if(GroupId2 != 0)
      {
        schedule.GroupId2 = GroupId2;
      }
      if(Week != 0)
      {
        schedule.Week = Week;
      }
      if(Team1Score != 0)
      {
        schedule.Team1Score = Team1Score;
      }
      if(Team2Score != 0)
      {
        schedule.Team2Score = Team2Score;
      }

      _db.Schedules.Add(schedule);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisSchedule = _db.Schedules
        .FirstOrDefault(x => x.ScheduleId == id);
      return View(thisSchedule);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Edit(int id)
    {
      var thisSchedule = _db.Schedules
        .FirstOrDefault(x => x.ScheduleId == id);
      return View(thisSchedule);
    }
    
    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Edit(Schedule schedule)
    {
      _db.Entry(schedule).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = schedule.ScheduleId});
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public async Task<ActionResult> Sim(int GroupId1, int GroupId2, int Week ) //might be schedule id
    {
      Schedule schedule = new Schedule(); //likely be changed
      schedule.ScheduleId = _db.Schedules.Count() + 1; //likely be changed
      if(GroupId1 != 0)
      {
        schedule.GroupId1 = GroupId1;
      }
      if(GroupId2 != 0)
      {
        schedule.GroupId2 = GroupId2;
      }
      if(Week != 0)
      {
        schedule.Week = Week;
      }
      List<Roster> roster1 = _db.Rosters.Where(x => x.GroupId == schedule.GroupId1).ToList();
      List<Roster> roster2 = _db.Rosters.Where(x => x.GroupId == schedule.GroupId2).ToList();
      int teamscore = 0;
      foreach (Roster roster in roster1)
      {
          Game game = await Game.GetGameByWeek(schedule.Week, roster.PlayerId); //get game by roster.GameId;
          Tracker tracker = new Tracker();
          tracker.GameId = game.GameId;
          tracker.GroupId = GroupId1;
          tracker.Position = roster.Position;
          tracker.Points = game.CalcScore(); //calculate fantasy points here 
          if(tracker.Position != "bench")//make sure not a bench player and add to schedule points for the team
          {
            teamscore += tracker.Points;
          }
          tracker.ScheduleId = schedule.ScheduleId;
          _db.Trackers.Add(tracker);
      }
      schedule.Team1Score = teamscore;
      teamscore = 0;
      foreach (Roster roster in roster2)
      {
          Game game = await Game.GetGameByWeek(schedule.Week, roster.PlayerId); //get game by roster.GameId;
          Tracker tracker = new Tracker();
          tracker.GameId = game.GameId;
          tracker.GroupId = GroupId1;
          tracker.Position = roster.Position;
          tracker.Points = game.CalcScore(); //calculate fantasy points here 
          if(tracker.Position != "bench")//make sure not a bench player and add to schedule points for the team
          {
            teamscore += tracker.Points;
          }
          tracker.ScheduleId = schedule.ScheduleId;
          _db.Trackers.Add(tracker);
          
      }
      schedule.Team2Score = teamscore;
      _db.Schedules.Add(schedule);
      _db.SaveChanges();
      return RedirectToAction("Index"); //enter proper view / next sim
    }
    
  }
}

