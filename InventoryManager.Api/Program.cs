using InventoryManager.Api.DbContexts;
using InventoryManager.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(
    x=> x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventoryManagerDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:InventoryManagerConnectionString"]);
    });

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
