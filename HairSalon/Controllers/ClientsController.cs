using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;
    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }
    public Client FindClient(string id) =>
      _db.Clients.FirstOrDefault(a => a.ClientId == id);

    public ActionResult Index()
    {
      ViewBag.NoStylists = _db.Stylists.ToList().Count == 0;
      return View(_db.Clients.Include(a => a.Stylist).ToList());
    }

    public ActionResult Details(string id) => View(FindClient(id));

    public ActionResult Create()
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Client c)
    {
      _db.Clients.Add(c);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(string id)
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View(FindClient(id));
    }
    [HttpPost]
    public ActionResult Edit(Client c)
    {
      _db.Entry(c).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(string id) => View(FindClient(id));
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(string id)
    {
      _db.Clients.Remove(FindClient(id));
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}