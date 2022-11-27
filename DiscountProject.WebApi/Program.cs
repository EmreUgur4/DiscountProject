using DiscountProject.Business.Containers.MicrosoftIOC;
using DiscountProject.Business.Interfaces;
using DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using DiscountProject.WebApi;
using DiscountProject.WebApi.CustomFilters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("global", cors =>
    {
        cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
}).AddFluentValidation();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DiscountProject.WebApi",
        Version = "v1",
        Description = "DiscountProject Api Document",
        Contact = new OpenApiContact
        {
            Email = "emreugur4@hotmail.com",
            Name = "Emre Uður"
        }
    });
   
});

builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped(typeof(ValidId<>));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DiscountProject.WebApi v1"));

app.UseExceptionHandler("/api/Error");

app.UseRouting();
app.UseAuthentication();
app.UseCors("global");


using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dataContext.Database.Migrate();
}

using (var scope = app.Services.CreateScope())
{
    Initializer.SeedData(scope.ServiceProvider.GetRequiredService<IAppUserService>(), scope.ServiceProvider.GetRequiredService<IInvoiceService>(), scope.ServiceProvider.GetRequiredService<IDiscountService>()).Wait();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
