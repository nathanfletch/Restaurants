using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurants.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly RestaurantsContext _db;

    public CuisinesController(RestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index() { 
      //list
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model); 
    }

    public ActionResult Create() 
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine) 
    {
      _db.Cuisines.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine chosenCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(chosenCuisine);
    }

    public ActionResult Edit(int id)
    {
      Cuisine cuisineToEdit = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(cuisineToEdit);
    }

    // [HttpPost]
    // public ActionResult Edit(Category category)
    // {
    //   _db.Entry(category).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

  }
}