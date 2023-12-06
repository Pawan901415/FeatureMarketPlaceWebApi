using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.Entity;
using ServiceContracts.Feature;


using Services.Feature;
using Services.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var myconstring = builder.Configuration.GetConnectionString("ConString");
builder.Services.AddCors(options =>
     options.AddPolicy("prodpolicy", (polbuilder) =>
     {
         polbuilder.AllowAnyHeader()
                .AllowAnyMethod().AllowAnyOrigin();
     }));


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(myconstring);
});

//builder.Services.AddDbContext<TestContext>(options =>
//{
//    options.UseInMemoryDatabase(databaseName: "Test");


//});


builder.Services.AddScoped<IEntityRepository,EntityRepository>();
builder.Services.AddScoped<IFeatureRepository,FeatureRepository>();

builder.Services.AddScoped<IEntityAdderService,EntityAdderService>();

builder.Services.AddScoped<IEntityDeleterService,EntityDeleterService>();
builder.Services.AddScoped<IEntityUpdaterService,EntityUpdaterService>();

builder.Services.AddScoped<IEntityGetterService,EntityGetterService>();
builder.Services.AddScoped<IFeatureAdderService,FeatureAdderService>();
builder.Services.AddScoped<IFeatureGetterService,FeatureGetterService>();

builder.Services.AddScoped<IFeatureDeleterService,FeatureDeleterService>();
builder.Services.AddScoped<IFeatureUpdaterService,FeatureUpdaterService>();


var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.UseCors("prodpolicy");


app.Run();
