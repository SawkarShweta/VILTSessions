using Microsoft.EntityFrameworkCore;
using MVCEntityFramework.Data;
using MVCEntityFramework.Models;
namespace MVCEntityFramework.Controllers;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Employee", async (MVCEntityFrameworkContext db) =>
        {
            return await db.Employee.ToListAsync();
        })
        .WithName("GetAllEmployees");

        routes.MapGet("/api/Employee/{id}", async (int Id, MVCEntityFrameworkContext db) =>
        {
            return await db.Employee.FindAsync(Id)
                is Employee model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetEmployeeById");

        routes.MapPut("/api/Employee/{id}", async (int Id, Employee employee, MVCEntityFrameworkContext db) =>
        {
            var foundModel = await db.Employee.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here
            foundModel.Name=employee.Name;
            foundModel.Address=employee.Address;
            
            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateEmployee");

        routes.MapPost("/api/Employee/", async (Employee employee, MVCEntityFrameworkContext db) =>
        {
            db.Employee.Add(employee);
            await db.SaveChangesAsync();
            return Results.Created($"/Employees/{employee.Id}", employee);
        })
        .WithName("CreateEmployee");

        routes.MapDelete("/api/Employee/{id}", async (int Id, MVCEntityFrameworkContext db) =>
        {
            if (await db.Employee.FindAsync(Id) is Employee employee)
            {
                db.Employee.Remove(employee);
                await db.SaveChangesAsync();
                return Results.Ok(employee);
            }

            return Results.NotFound();
        })
        .WithName("DeleteEmployee");
    }
}
