using System.ComponentModel.DataAnnotations;
using SSM2.Models;

namespace SSM2.Models
{
    public class Category
    {
        [Key]
        public int CId { get; set; }
        public string CName { get; set; }
    }


public static class CategoryEndpoints
{
	public static void MapCategoryEndpoints (this IEndpointRouteBuilder routes)
    {
       

        routes.MapGet("/api/Category/{id}", async (int CId, AppdbContext db) =>
        {
            return await db.Category.FindAsync(CId)
                is Category model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetCategoryById");

        routes.MapPut("/api/Category/{id}", async (int CId, Category category, AppdbContext db) =>
        {
            var foundModel = await db.Category.FindAsync(CId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(category);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })   
        .WithName("UpdateCategory");

        routes.MapPost("/api/Category/", async (Category category, AppdbContext db) =>
        {
            db.Category.Add(category);
            await db.SaveChangesAsync();
            return Results.Created($"/Categorys/{category.CId}", category);
        })
        .WithName("CreateCategory");


        routes.MapDelete("/api/Category/{id}", async (int CId, AppdbContext db) =>
        {
            if (await db.Category.FindAsync(CId) is Category category)
            {
                db.Category.Remove(category);
                await db.SaveChangesAsync();
                return Results.Ok(category);
            }

            return Results.NotFound();
        })
        .WithName("DeleteCategory");
    }
}}
