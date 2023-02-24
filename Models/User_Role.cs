using System.ComponentModel.DataAnnotations;
using static SSM2.Models.User_Role;
using SSM2.Models;

namespace SSM2.Models
{
    public class User_Role
    {

        [Key]
            public int Id { get; set; }
            public string UName { get; set; }
            public string password { get; set; }


            public Role role { get; set; }
        }
        public enum Role
        {
           
            admin,
             user
    }


public static class User_RoleEndpoints
{
	public static void MapUser_RoleEndpoints (this IEndpointRouteBuilder routes)
    {
       

        routes.MapGet("/api/User_Role/{id}", async (int Id, AppdbContext db) =>
        {
            return await db.user_role.FindAsync(Id)
                is User_Role model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetUser_RoleById");

        routes.MapPut("/api/User_Role/{id}", async (int Id, User_Role user_Role, AppdbContext db) =>
        {
            var foundModel = await db.user_role.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(user_Role);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })   
        .WithName("UpdateUser_Role");

        routes.MapPost("/api/User_Role/", async (User_Role user_Role, AppdbContext db) =>
        {
            db.user_role.Add(user_Role);
            await db.SaveChangesAsync();
            return Results.Created($"/User_Roles/{user_Role.Id}", user_Role);
        })
        .WithName("CreateUser_Role");


        routes.MapDelete("/api/User_Role/{id}", async (int Id, AppdbContext db) =>
        {
            if (await db.user_role.FindAsync(Id) is User_Role user_Role)
            {
                db.user_role.Remove(user_Role);
                await db.SaveChangesAsync();
                return Results.Ok(user_Role);
            }

            return Results.NotFound();
        })
        .WithName("DeleteUser_Role");
    }
}
       






       
        
    
}
