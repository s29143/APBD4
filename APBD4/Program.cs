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
app.MapGet("/api/animals/{id}", ([FromRoute] int id) =>
{
    var animal = Db.Animals.FirstOrDefault(e => e.Id == id);
    return animal is null ? Results.NotFound() : Results.Ok(animal);
});

app.MapPost("/api/animal", ([FromBody] Animal animal) => {
    Db.Animals.Add(animal);
    return Results.Created();
});

app.MapPut("/api/animals/{id}", ([FromRoute] int id, [FromBody] Animal body) =>
{
    var animal = Db.Animals.FirstOrDefault(e => e.Id == id);
    if (animal is null)
    {
        return Results.NotFound();
    }

    animal.Category = body.Category;
    animal.FirstName = body.FirstName;
    animal.Color = body.Color;
    animal.Weight = body.Weight;

    return Results.Ok();
});

app.MapDelete("/api/animals/{id}", ([FromRoute] int id) => {
    var animal = Db.Animals.FirstOrDefault(e => e.Id == id);
    if (animal is null)
    {
        return Results.NotFound();
    }
    return Db.Animals.Remove(animal) ? Results.NoContent() : Results.Conflict();
});

app.MapGet("/api/visits", ([FromQuery] int animalId) => Results.Ok(Db.Visits.FindAll(visit => visit.Animal.Id == animalId)));
app.MapPost("/api/visits", ([FromBody] Visit body) =>
{
    Db.Visits.Add(body);
    return Results.Created();
});

app.UseHttpsRedirection();

app.Run();