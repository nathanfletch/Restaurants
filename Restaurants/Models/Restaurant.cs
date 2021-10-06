namespace Restaurants.Models
{
  public class Restaurant
  {

    public string Name {get; set;}
    public string Dishes {get; set;}
    public string Phone {get; set;}
    // [Display("Takes Reservations")]
    public bool Reservations {get; set;}
    public int RestaurantId {get; set;}
    public int CuisineId {get; set;}

    public virtual Cuisine Cuisine { get; set; }
  }
  
}