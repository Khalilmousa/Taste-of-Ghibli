# Taste of Ghibli 🍣

Taste of Ghibli is a RESTful API built with ASP.NET Core. It provides endpoints to retrieve and manipulate data related to Ghibli food and restaurants. This README file provides an overview of the API endpoints and their functionalities.

<img width="1728" alt="1" src="https://user-images.githubusercontent.com/90157472/201305731-7ba1d60f-172e-4311-8cc6-503c5e11fc25.png">
<img width="1728" alt="2" src="https://user-images.githubusercontent.com/90157472/201305792-c10a9136-1f76-4a76-9db9-1c333cc4feaf.png">
<img width="1728" alt="3" src="https://user-images.githubusercontent.com/90157472/201305828-8fb1a0e9-ec64-4de2-9159-61494515eb66.png">

## Table of Contents
- [Installation](#installation)
- [API Endpoints](#api-endpoints)
  - [GET /api/GhibliFood](#get-apighiblifood)
  - [GET /api/GhibliFood/{animeName}](#get-apighiblifoodanimename)
  - [GET /api/GhibliFood/search/{searchTerm}](#get-apighiblifoodsearchsearchterm)
  - [POST /api/GhibliFood/food](#post-apighiblifoodfood)
  - [POST /api/GhibliFood/restaurant](#post-apighiblifoodrestaurant)
  - [PUT /api/GhibliFood/{id}](#put-apighiblifoodid)
  - [DELETE /api/GhibliFood/{id}](#delete-apighiblifoodid)
- [Contributing](#contributing)
- [License](#license)

<img width="1728" alt="4" src="https://user-images.githubusercontent.com/90157472/201306383-2eef7f4c-5207-40ed-ab6f-9fe5bc6a62eb.png">

## Installation
To run this API locally, follow these steps:

1. Clone the repository: `git clone https://github.com/your-username/GhibliFoodApi.git`
2. Navigate to the project directory: `cd GhibliFoodApi`
3. Modify the `CnnString` variable in `GhibliFoodController.cs` to match your database connection string.
4. Build the project: `dotnet build`
5. Run the API: `dotnet run`
6. The API will be accessible at `http://localhost:5000` or `https://localhost:5001`

## API Endpoints

### GET /api/GhibliFood
- Description: Retrieves all Ghibli food items with associated restaurant information.
- Response: Array of GhibliViewModel objects.

### GET /api/GhibliFood/{animeName}
- Description: Retrieves Ghibli food items with associated restaurant information based on the specified anime name.
- Parameters:
  - `animeName`: The name of the anime.
- Response: Array of GhibliViewModel objects.

### GET /api/GhibliFood/search/{searchTerm}
- Description: Searches for Ghibli food items with associated restaurant information based on the specified search term.
- Parameters:
  - `searchTerm`: The term to search for in the food name or description.
- Response: Array of GhibliViewModel objects.

### POST /api/GhibliFood/food
- Description: Creates a new Ghibli food item.
- Request body: GhibliFood object.
- Response: Success message.

### POST /api/GhibliFood/restaurant
- Description: Creates a new Ghibli restaurant.
- Request body: GhibliRestaurant object.
- Response: Success message.

### PUT /api/GhibliFood/{id}
- Description: Updates a Ghibli food item.
- Parameters:
  - `id`: The ID of the food item to update.
- Request body: GhibliViewModel object.
- Response: Success message.

### DELETE /api/GhibliFood/{id}
- Description: Deletes a Ghibli food item.
- Parameters:
  - `id`: The ID of the food item to delete.
- Response: Success message.

## Contributing
Contributions to this project are welcome. To contribute,


<img width="1728" alt="5" src="https://user-images.githubusercontent.com/90157472/201306418-0e0d6718-1c77-4b01-8eb3-50616c4b9283.png">












