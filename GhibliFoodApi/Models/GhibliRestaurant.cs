namespace GhibliFoodApi.Models;

public class GhibliRestaurant
{
    public int Id { get; set; }
    public string? RestaurantName { get; set; }
    public string? RestaurantAddress { get; set; }
    public string? ImageUrl { get; set; }
    public string? MainDish { get; set; }
}