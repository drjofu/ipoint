using Microsoft.EntityFrameworkCore;
using FirstWebApiExample.Data;
using FirstWebApiExample.Models;
namespace FirstWebApiExample.Controllers;

public static class PersonEndpoints
{
    public static void MapPersonEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Person", async (FirstWebApiExampleContext db) =>
        {
            return await db.Person.ToListAsync();
        })
        .WithName("GetAllPersons");

        routes.MapGet("/api/Person/{id}", async (int Id, FirstWebApiExampleContext db) =>
        {
            return await db.Person.FindAsync(Id)
                is Person model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetPersonById");

        routes.MapPut("/api/Person/{id}", async (int Id, Person person, FirstWebApiExampleContext db) =>
        {
            var foundModel = await db.Person.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(person);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdatePerson");

        routes.MapPost("/api/Person/", async (Person person, FirstWebApiExampleContext db) =>
        {
            db.Person.Add(person);
            await db.SaveChangesAsync();
            return Results.Created($"/Persons/{person.Id}", person);
        })
        .WithName("CreatePerson");

        routes.MapDelete("/api/Person/{id}", async (int Id, FirstWebApiExampleContext db) =>
        {
            if (await db.Person.FindAsync(Id) is Person person)
            {
                db.Person.Remove(person);
                await db.SaveChangesAsync();
                return Results.Ok(person);
            }

            return Results.NotFound();
        })
        .WithName("DeletePerson");
    }
}
