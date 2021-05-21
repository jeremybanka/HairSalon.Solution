using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;
    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }
    public Stylist FindStylist(string id) =>
      _db.Stylists.FirstOrDefault(a => a.StylistId == id);

    public ActionResult Index() => View(_db.Stylists.ToList());

    public ActionResult Create() => View();
    [HttpPost]
    public ActionResult Create(Stylist s)
    {
      _db.Stylists.Add(s);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(string id) => View(FindStylist(id));
    // seriously what the HECK is WRONG with microsoft.
    // For real, you cannot call the param anything but 'id' 
    // i wasted like thirty minutes because i wanted to call it guid 
    // and dotnet gives NO CLEAR ERRORS and has NO TOOLING 
    // re: its hyperspecific arbitrary naming conventions
    // 😬︻╦╤─ 💥MICROSOFT CORPORATION ®

    public ActionResult Edit(string id) => View(FindStylist(id));
    [HttpPost]
    public ActionResult Edit(Stylist s)
    {
      _db.Entry(s).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(string id) => View(FindStylist(id));
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(string id)
    {
      _db.Stylists.Remove(FindStylist(id));
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}