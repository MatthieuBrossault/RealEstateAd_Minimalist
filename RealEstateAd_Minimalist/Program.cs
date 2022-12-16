using RealEstateAd_Minimalist;
using Microsoft.EntityFrameworkCore;
using Tiny.RestClient;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<RealEstateAdDb>(opt => opt.UseInMemoryDatabase("RealEstateAdList"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var client = new TinyRestClient(new HttpClient(), "https://api.open-meteo.com/v1");

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
{
    var ad = await db.Ads.FindAsync(id);

    if (ad is null || ad.PublishStatus == PublishStatus.WaitingValidation)
    {
        return Results.NotFound();
    }

    var forecast = new Forecast();

    try
    {
        forecast = await client
        .GetRequest("forecast")
        .AddQueryParameter("latitude", ad.Location.Latitude)
        .AddQueryParameter("longitude", ad.Location.Longitude)
        .AddQueryParameter("hourly", "temperature_2m")
        .ExecuteAsync<Forecast>();
    }
    catch (HttpException ex) when (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
    {
        // Ignore
    }

    return Results.Ok(new { ad, forecast });
});
    
app.Run();