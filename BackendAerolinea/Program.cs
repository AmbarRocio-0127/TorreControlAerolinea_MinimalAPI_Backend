using Microsoft.EntityFrameworkCore;
using BackendAerolinea;
using BackendAerolinea.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
object value = builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


    //Se obtienen datos directamente de la base de datos utilizando el metodo asincrónico.
    app.MapGet("/Avion", async (DataContext context) =>

    await context.Avion.ToListAsync());

    /*Metodo Get para obtener datos de un avion específico directamente de la base de datos utilizando 
    el metodo asincrónico y en caso de no ser encontrado se retorna el mensaje correspondiente a la 
    informacion no encontrada.*/

    app.MapGet("/Avion/{Id}", async (DataContext context, int id) =>
    await context.Avion.FindAsync(id) is Avion avion ?
    Results.Ok(avion) :
    Results.NotFound("Informacion de avion no encontrada"));

    /*Se agregan datos directamente a la base de datos*/

    app.MapPost("/Avion", async (DataContext context ,Avion avion) => 
    {
        //validacion limite peso Y el Peso Maximo
        int LimiteMaximo = 10000;

        if (avion.LimitePeso_ > LimiteMaximo)
        {
            // El peso total del equipaje excede el límite del avión
            return Results.BadRequest("El peso total del equipaje excede el límite del avión.");
        }

        else
        {
            context.Avion.Add(avion);
            await context.SaveChangesAsync();
            return Results.Ok(await context.Avion.ToListAsync());
        }
    });

    // Proceso para actualizar los datos corrrespondientes a los aviones
    app.MapPut("/Avion/{id}", async (DataContext context, Avion Actualizaravion, int id) =>
{
    var avion = await context.Avion.FindAsync(id);
    if (avion is null)
    return Results.NotFound("Informacion de avion no encontrado");

    avion.NombreAvion_ = Actualizaravion.NombreAvion_;
    avion.Horasalida_ = Actualizaravion.Horasalida_;
    avion.Horallegada_ = Actualizaravion.Horallegada_;
    avion.Aeropuertosalida_ = Actualizaravion.Aeropuertosalida_;
    avion.Aeropuertollegada_ = Actualizaravion.Aeropuertollegada_;
    avion.StatusVuelo_ = Actualizaravion.StatusVuelo_;
    avion.LimitePeso_ = Actualizaravion.LimitePeso_;
    avion.PasajerosLimite = Actualizaravion.PasajerosLimite;

    await context.SaveChangesAsync();

    return Results.Ok(await context.Avion.ToListAsync());
});

    // Endpoint que elimina los datos de la base de datos

    app.MapDelete("/Avion/{Id}", async (DataContext context, int id) =>
    {
    var avion = await context.Avion.FindAsync(id);
    if (avion is null)
        return Results.NotFound("Informacion Eliminada");
        context.Avion.Remove(avion);
        await context.SaveChangesAsync();

        return Results.Ok(await context.Avion.ToListAsync());
    });

    //Los procesos anteriores realizados en los endpoints son realizados en las demas entidades: Pasajero y Aeropuerto.

    app.MapGet("/Pasajero", async(DataContext context) =>

    await context.pasajeros.ToListAsync());

    app.MapGet("/Pasajero/{Id}", async (DataContext context, int id) =>
    await context.pasajeros.FindAsync(id) is Pasajero pasajero ?
    Results.Ok(pasajero) :
    Results.NotFound("Informacion del pasajero no encontrada"));

    app.MapPost("/Pasajero", async (DataContext context, Pasajero pasajero) => {
    context.pasajeros.Add(pasajero);
    await context.SaveChangesAsync();
    return Results.Ok(await context.pasajeros.ToListAsync());
    });

    app.MapDelete("/Pasajero/{Id}", async (DataContext context, int id) =>
    {
    var pasajero = await context.pasajeros.FindAsync(id);
    if (pasajero is null)
        return Results.NotFound("Informacion Eliminada.");
    context.pasajeros.Remove(pasajero);
    await context.SaveChangesAsync();

    return Results.Ok(await context.pasajeros.ToListAsync());

    });
/*------------------------------------------------------------------------------------------------------*/

    app.MapGet("/Aeropuerto", async (DataContext context) =>
    await context.Aeropuerto.ToListAsync());

    app.MapGet("/Aeropuerto/{Id}", async (DataContext context, int id) =>
    await context.Aeropuerto.FindAsync(id) is Aeropuerto aeropuerto ?
    Results.Ok(aeropuerto) :
    Results.NotFound("Informacion del aeropuerto no encontrada"));

    app.MapPost("/Aeropuerto", async (DataContext context, Aeropuerto aeropuerto) => {
    context.Aeropuerto.Add(aeropuerto);
    await context.SaveChangesAsync();
    return Results.Ok(await context.Aeropuerto.ToListAsync());
    });

    app.MapDelete("/Aeropuerto/{Id}", async (DataContext context, int id) =>
    {
    var aeropuerto = await context.Aeropuerto.FindAsync(id);
    if (aeropuerto is null)
        return Results.NotFound("Informacion Eliminada");
    context.Aeropuerto.Remove(aeropuerto);
    await context.SaveChangesAsync();


    return Results.Ok(await context.Aeropuerto.ToListAsync());
    });

app.Run();
