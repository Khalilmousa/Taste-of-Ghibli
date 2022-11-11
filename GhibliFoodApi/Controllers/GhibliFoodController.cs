using System.Data;
using System.Data.SqlClient;
using Dapper;
using GhibliFoodApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace GhibliFoodApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GhibliFoodController : ControllerBase
{
    // Read connection string from appsettings.json

    readonly string CnnString = @"Server=localhost,1433;Database=GhibliDB;User Id=sa;Password=Password_2_Change_4_Real_Cases_&";
    
    [HttpGet (Name = "GetAllGhibliFood")]
    public async Task<IEnumerable<GhibliViewModel>> Get()
    {
        using IDbConnection cnn = new SqlConnection(CnnString);

        var result = await cnn.QueryAsync("SELECT * FROM GhibliFood INNER JOIN GhibliRestaurant ON GhibliFood.RestaurantId = GhibliRestaurant.Id");
        var ghibliFood = result.Select(g => new GhibliViewModel(){
            Id = g.Id,
            AnimeName = g.AnimeName,
            FoodName = g.FoodName,
            Description = g.Description,
            ImageUrl = g.ImageUrl,
            RecipeUrl = g.RecipeUrl,
            RestaurantId = g.RestaurantId,
            RestaurantName = g.RestaurantName,
            RestaurantAddress = g.RestaurantAddress,
            RestaurantImageUrl = g.RestaurantImageUrl
        }); 
        return ghibliFood; 
    }

        [HttpGet("{animeName}", Name = "GetGhibliFood")]
    public async Task<IActionResult> Get(string animeName)
    {
        using IDbConnection cnn = new SqlConnection(CnnString);

        var result = await cnn.QueryAsync("SELECT * FROM GhibliFood INNER JOIN GhibliRestaurant ON GhibliFood.RestaurantId = GhibliRestaurant.Id WHERE AnimeName = @AnimeName", new { AnimeName = animeName });
        var ghibliFood = result.Select(g => new GhibliViewModel(){
            Id = g.Id,
            AnimeName = g.AnimeName,
            FoodName = g.FoodName,
            Description = g.Description,
            ImageUrl = g.ImageUrl,
            RecipeUrl = g.RecipeUrl,
            RestaurantId = g.RestaurantId,
            RestaurantName = g.RestaurantName,
            RestaurantAddress = g.RestaurantAddress,
            RestaurantImageUrl = g.RestaurantImageUrl
        }); 
        return Ok(ghibliFood); 
    }
    
    [HttpGet("search/{searchTerm}", Name = "SearchGhibliFood")]
    public async Task<IActionResult> Search(string searchTerm)
    {
        using IDbConnection cnn = new SqlConnection(CnnString);

        var result = await cnn.QueryAsync("SELECT * FROM GhibliFood INNER JOIN GhibliRestaurant ON GhibliFood.RestaurantId = GhibliRestaurant.Id WHERE FoodName LIKE @SearchTerm OR Description LIKE @SearchTerm", new { SearchTerm = $"%{searchTerm}%" });
        var ghibliFood = result.Select(g => new GhibliViewModel(){
            Id = g.Id,
            AnimeName = g.AnimeName,
            FoodName = g.FoodName,
            Description = g.Description,
            ImageUrl = g.ImageUrl,
            RecipeUrl = g.RecipeUrl,
            RestaurantId = g.RestaurantId,
            RestaurantName = g.RestaurantName,
            RestaurantAddress = g.RestaurantAddress,
            RestaurantImageUrl = g.RestaurantImageUrl
        }); 
        return Ok(ghibliFood); 
    }
    

    [HttpPost("food")]
    public async Task<IActionResult> Post([FromBody] GhibliFood ghibliFood)
    {
        using IDbConnection cnn = new SqlConnection(CnnString);

        var result = await cnn.ExecuteAsync("INSERT INTO GhibliFood (AnimeName, FoodName, Description, RecipeUrl, RestaurantId) VALUES (@AnimeName, @FoodName, @Description, @RecipeUrl, @RestaurantId)", ghibliFood);
        return Ok(result);
    }
    
    [HttpPost("restaurant")]
    public async Task<IActionResult> Post([FromBody] GhibliRestaurant ghibliRestaurant)
    {
        using IDbConnection cnn = new SqlConnection(CnnString);

        var result = await cnn.ExecuteAsync("INSERT INTO GhibliRestaurant (RestaurantName, RestaurantAddress) VALUES (@RestaurantName, @RestaurantAddress)", ghibliRestaurant);
        return Ok(result); 
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] GhibliViewModel ghibliFood)
    {
        using IDbConnection cnn = new SqlConnection(CnnString);

        var result = await cnn.ExecuteAsync("UPDATE GhibliFood SET AnimeName = @AnimeName, FoodName = @FoodName, Description = @Description, ImageUrl = @ImageUrl, RecipeUrl = @RecipeUrl, RestaurantId = @RestaurantId WHERE Id = @Id", new { Id = id, AnimeName = ghibliFood.AnimeName, FoodName = ghibliFood.FoodName, Description = ghibliFood.Description, RecipeUrl = ghibliFood.RecipeUrl, RestaurantId = ghibliFood.RestaurantId });
        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        using IDbConnection cnn = new SqlConnection(CnnString);

        var result = await cnn.ExecuteAsync("DELETE FROM GhibliFood WHERE Id = @Id", new { Id = id });
        return Ok(result);
    }
}