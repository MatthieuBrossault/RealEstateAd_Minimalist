using RealEstateAd_Minimalist;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<RealEstateAdDb>(opt => opt.UseInMemoryDatabase("RealEstateAdList"));

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

app.UseHttpsRedirection();

app.MapPost("/ad", async (RealEstateAd ad, RealEstateAdDb db) =>
{
    db.Ads.Add(ad);
    await db.SaveChangesAsync();

    return Results.Created($"/ad/{ad.Id}", ad.Id);
});

app.MapPut("/ad/{id}", async (int id, RealEstateAd ad, RealEstateAdDb db) =>
{
    var dbAd = await db.Ads.FindAsync(id);

    if (dbAd is null) return Results.NotFound();

    dbAd.PublishStatus = ad.PublishStatus;

    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapGet("/ad/{id}", async (int id, RealEstateAdDb db) =>
    await db.Ads.FindAsync(id)
        is RealEstateAd ad && ad.PublishStatus != PublishStatus.WaitingValidation
            ? Results.Ok(ad)
            : Results.NotFound());

app.Run();