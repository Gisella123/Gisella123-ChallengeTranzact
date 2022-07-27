using log4net;
using Microsoft.EntityFrameworkCore;
using Tranzact.Aplication.Contract;
using Tranzact.Aplication.Service;
using Tranzact.Dominio.Contract.Repository;
using Tranzact.Persistencia.RepositorioProduct;
using Tranzact.Persistencia.RepositorioProduct.Repository;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("BDConnection");

// Add services to the container.

builder.Services.AddControllers()
.AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescription => apiDescription.First());
});


builder.Services.AddDbContext<AppDBTranzactContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddTransient<IAplicationServicioProduct, AplicationServicioProduct>();
builder.Services.AddTransient<IRepositoryProduct, RepositoryProduct>();
#region Logger

builder.Services.AddSingleton<Tranzact.Infraestruture.ILogger,Tranzact.Infraestruture.Logger>();

#endregion
//builder.Services.AddScoped<IMemoryCache, MemoryCache>();
builder.Services.AddTransient<AppDBTranzactContext>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
