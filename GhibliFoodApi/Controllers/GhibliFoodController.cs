using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
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
        var ghibliFood = await cnn.QueryAsync<GhibliFood>("SELECT * FROM GhibliFood INNER JOIN GhibliRestaurant ON GhibliFood.RestaurantId = GhibliRestaurant.Id WHERE GhibliFood.AnimeName = @AnimeName", new { AnimeName = animeName });
        if (!ghibliFood.Any()) return NotFound();
        return Ok(ghibliFood);
    }
    
    [HttpGet("search/{searchTerm}", Name = "SearchGhibliFood")]
    public async Task<IActionResult> Search(string searchTerm)
    {
        using IDbConnection cnn = new SqlConnection(CnnString);
        var ghibliFood = await cnn.QueryAsync<GhibliFood>("SELECT * FROM GhibliFood INNER JOIN GhibliRestaurant ON GhibliFood.RestaurantId = GhibliRestaurant.Id WHERE GhibliFood.AnimeName LIKE @SearchTerm", new { SearchTerm = $"%{searchTerm}%" });
        if (!ghibliFood.Any()) return NotFound();
        return Ok(ghibliFood);
    }
    

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GhibliFood ghibliFood)
    {
        using IDbConnection cnn = new SqlConnection(CnnString);
        var result = await cnn.ExecuteAsync("INSERT INTO GhibliFood (Name, AnimeName, RestaurantId) VALUES (@Name, @AnimeName, @RestaurantId)", ghibliFood);
        if (result == 0) return BadRequest();
        return CreatedAtRoute("GetGhibliFood", new { animeName = ghibliFood.AnimeName }, ghibliFood);
    }
    
    [HttpPut("{animeName}")]
    public async Task<IActionResult> Put(string animeName, [FromBody] GhibliFood ghibliFood)
    {
        using IDbConnection cnn = new SqlConnection(CnnString);
        var result = await cnn.ExecuteAsync("UPDATE GhibliFood SET FoodName = @FoodName WHERE AnimeName = @AnimeName", new { AnimeName = animeName, FoodName = ghibliFood.FoodName });
        if (result == 0) return BadRequest();
        return NoContent();
    }
    
    [HttpDelete("{animeName}")]
    public async Task<IActionResult> Delete(string animeName)
    {
        using IDbConnection cnn = new SqlConnection(CnnString);
        var result = await cnn.ExecuteAsync("DELETE FROM GhibliFood WHERE AnimeName = @AnimeName", new { AnimeName = animeName });
        if (result == 0) return BadRequest();
        return NoContent();
    }
}