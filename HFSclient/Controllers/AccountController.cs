using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HFSclient.Models;
using System.Threading.Tasks;
using HFSclient.ViewModels;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;  

namespace HFSclient.Controllers 
{
  public class AccountController : Controller
  {
    private readonly HFSclientContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, HFSclientContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db; 
    } 
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userLeagues = _db.Groups.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userLeagues);
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost] 
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email } ;
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Login");
      }
      else
      {
        ViewBag.err = "Login not excepted";
        return View();
      }
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.err = "Login not excepted";
        return View();
      }
    } 

    public async Task<ActionResult> LogOut()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }
    public ActionResult RemoveLeague(int id)
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
      return RedirectToAction("Index");
    }
  }
}