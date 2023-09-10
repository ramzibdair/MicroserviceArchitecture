using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Entities;
using WebApplication1.Model;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("ShortenConnectionString"));
});
builder.Services.AddScoped<IShortenUrlServices,ShortenUrlServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("api/shortenUrl",async (ShortenUrlRequest request, IShortenUrlServices services , ApplicationDBContext dbcontext) => {
    if(!Uri.TryCreate(request.Url , UriKind.Absolute, out _))
    {
        return Results.BadRequest("Invalid Url");
    }
    string shortUrl = await services.CreateShortenUrlAsync(request.Url);
    await dbcontext.ShortenUrls.AddAsync(new WebApplication1.Entities.ShortenUrl { 
            CraetedOnUtc =  DateTime.UtcNow,
            Id = Guid.NewGuid(),
            LongUrl = request.Url,
            ShortUrl = shortUrl
            });
   await dbcontext.SaveChangesAsync();
    return Results.Ok(shortUrl);
});


//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.Run();


