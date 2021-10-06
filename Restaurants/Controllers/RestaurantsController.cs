using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Restaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly RestaurantsContext _db;

    public RestaurantsController(RestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList();
      return View(model);
    }
    
    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant chosenRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(chosenRestaurant);
    }

    public ActionResult Edit(int id)
    {
      Restaurant restaurantToEdit = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View(restaurantToEdit);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Entry(restaurant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id)
    {
      Restaurant restaurantToDelete = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(restaurantToDelete);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Restaurant restaurantToDelete = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      _db.Restaurants.Remove(restaurantToDelete);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}