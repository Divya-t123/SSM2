using System.ComponentModel.DataAnnotations;
using SSM2.Models;

namespace SSM2.Models
{
    public class Cart
    {

        [Key]
            public int Id { get; set; }
            public int quntity { get; set; }
            public decimal Totalprice { get; set; }
            public User user { get; set; }
            public Product Product { get; set; }




    }


public static class CartEndpoints
{
	public static void MapCartEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Cart/{id}", async (int Id, AppdbContext db) =>
        {
            return await db.cart.FindAsync(Id)
                is Cart model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetCartById");

        routes.MapPut("/api/Cart/{id}", async (int Id, Cart cart, AppdbContext db) =>
        {
            var foundModel = await db.cart.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(cart);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })   
        .WithName("UpdateCart");

        routes.MapPost("/api/Cart/", async (Cart cart, AppdbContext db) =>
        {
            db.cart.Add(cart);
            await db.SaveChangesAsync();
            return Results.Created($"/Carts/{cart.Id}", cart);
        })
        .WithName("CreateCart");


        routes.MapDelete("/api/Cart/{id}", async (int Id, AppdbContext db) =>
        {
            if (await db.cart.FindAsync(Id) is Cart cart)
            {
                db.cart.Remove(cart);
                await db.SaveChangesAsync();
                return Results.Ok(cart);
            }

            return Results.NotFound();
        })
        .WithName("DeleteCart");
    }
}}
