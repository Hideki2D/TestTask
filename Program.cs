using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Core;
using TestTask.Interfaces;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies()
                                                                      .UseSqlServer(connection));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IAllOwnerships, SqlOwnerships>();
builder.Services.AddScoped<IAllUsers, SqlUsers>();
builder.Services.AddCors();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5133/") });
var app = builder.Build();


app.UseCors(builder => builder.AllowAnyOrigin()
                             .AllowAnyHeader()
                            .AllowAnyMethod());
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
