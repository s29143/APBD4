using APBD4;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/animals", () => Results.Ok(Db.Animals));
app.MapGet("/api/animals/{animalId}", ([FromRoute] int animalId) =>
{
    var animal = Db.Animals.FirstOrDefault(e => e.Id == animalId);
    return animal is null ? Results.NotFound() : Results.Ok(animal);
});

app.MapPost("/api/animal", ([FromBody] Animal animal) => {
    Db.Animals.Add(animal);
    return Results.Created();
});

app.MapPut("/api/animals/{animalId}", ([FromRoute] int animalId, [FromBody] Animal body) =>
{
    var animal = Db.Animals.FirstOrDefault(e => e.Id == animalId);
    if (animal is null)
    {
        return Results.NotFound();
    }

    return Results.Ok();
});

app.MapDelete("/api/animals/{animalId}", ([FromRoute] int animalId) => {
    var animal = Db.Animals.FirstOrDefault(e => e.Id == animalId);
    if (animal is null)
    {
        return Results.NotFound();
    }
    return Db.Animals.Remove(animal) ? Results.NoContent() : Results.Conflict();
});

app.UseHttpsRedirection();

app.Run();