namespace GhibliFoodApi.Models;

public class GhibliViewModel
{
    public int Id { get; set; }
    public string? AnimeName { get; set; }
    public string? FoodName { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? RecipeUrl { get; set; }
    public int RestaurantId { get; set; }
    public string? RestaurantName { get; set; }
    public string? RestaurantAddress { get; set; }
    public string? RestaurantImageUrl { get; set; }
    public string? MainDish { get; set; }
}