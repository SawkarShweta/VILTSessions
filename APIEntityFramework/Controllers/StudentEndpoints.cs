using Microsoft.EntityFrameworkCore;
using APIEntityFramework.Data;
using APIEntityFramework.Model;
namespace APIEntityFramework.Controllers;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Student", async (APIEntityFrameworkContext db) =>
        {
            return await db.Student.ToListAsync();
        })
        .WithName("GetAllStudents");

        routes.MapGet("/api/Student/{id}", async (int Id, APIEntityFrameworkContext db) =>
        {
            return await db.Student.FindAsync(Id)
                is Student model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetStudentById");

        routes.MapPut("/api/Student/{id}", async (int Id, Student student, APIEntityFrameworkContext db) =>
        {
            var foundModel = await db.Student.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here
            foundModel.Name=student.Name;
            foundModel.Addess=student.Addess;

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateStudent");

        routes.MapPost("/api/Student/", async (Student student, APIEntityFrameworkContext db) =>
        {
            db.Student.Add(student);
            await db.SaveChangesAsync();
            return Results.Created($"/Students/{student.Id}", student);
        })
        .WithName("CreateStudent");

        routes.MapDelete("/api/Student/{id}", async (int Id, APIEntityFrameworkContext db) =>
        {
            if (await db.Student.FindAsync(Id) is Student student)
            {
                db.Student.Remove(student);
                await db.SaveChangesAsync();
                return Results.Ok(student);
            }

            return Results.NotFound();
        })
        .WithName("DeleteStudent");
    }
}
