namespace GhibliFoodApi.Models;

public class GhibliFood
{
    public int Id { get; set; }
    public string? AnimeName { get; set; }
    public string? FoodName { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? RecipeUrl { get; set; }
    public string? RestaurantId { get; set; }
}