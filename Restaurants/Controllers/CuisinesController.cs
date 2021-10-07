using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

    public ActionResult Details(int id,bool filtered)
    {
      Cuisine chosenCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);

      ViewBag.Filtered = filtered;
      
      if(filtered){
        List<Restaurant> associatedRestaurants = _db.Restaurants.ToList().Where(restaurant => restaurant.CuisineId == id).ToList();

        ViewBag.AssociatedRestaurants = associatedRestaurants; 
      }
      
    
      
      return View(chosenCuisine);
    }

    // [HttpPost, ActionName("Details")]
    // public ActionResult DetailsFilter(int id)
    // {
    //   Cuisine chosenCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      
    //   chosenCuisine.Showing = true;
    //   RedirectToAction("Details");
    // }

    //post route from a form in details, -have another property - boolean? ShowingAllRestauraunts - if true, set to true, then if true in 

    public ActionResult Edit(int id)
    {
      Cuisine cuisineToEdit = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(cuisineToEdit);
    }

    [HttpPost]
    public ActionResult Edit(Cuisine cuisine)
    {
      _db.Entry(cuisine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Cuisine cuisineToDelete = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(cuisineToDelete);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Cuisine cuisineToDelete = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      _db.Cuisines.Remove(cuisineToDelete);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}