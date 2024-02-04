using HackerNewsScraperAPI.Endpoints;
using HackerNewsScraperAPI.Interfaces;
using HackerNewsScraperAPI.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddHttpClient<IHackerNewsAPI, HackerNewsAPI>();
builder.Services.AddSingleton<IHackerNewsAPI, HackerNewsAPI>();
builder.Services.AddSingleton<IHackerNewsScraper, HackerNewsScraper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/bestStories/{count:int}", BestStoriesEndpoint.GetBestStories)
.WithName("GetBestStories")
.WithOpenApi()
.CacheOutput();

app.Run();
