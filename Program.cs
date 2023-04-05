using Api_blog.Context;
using Api_blog.Repositório;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BloggingContext>(
        o => o.UseNpgsql(builder.Configuration.GetConnectionString("BloggingContext")));

builder.Services.AddScoped<IBlogRepository, BlogRepository>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API DO BLOG", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI(options =>
{
   options.SwaggerEndpoint("/swagger/v1/swagger.json", "API DO BLOG v1");
   options.RoutePrefix = String.Empty;
});
    // Te default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Posts}/{action=Index}/{id?}");

app.Run();
