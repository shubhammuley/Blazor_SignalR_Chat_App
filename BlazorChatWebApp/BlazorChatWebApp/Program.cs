using BlazorChatWebApp.ChatHubs;
using BlazorChatWebApp.Client.ChatServices;

using BlazorChatWebApp.Components;
using BlazorChatWebApp.Data;
using BlazorChatWebApp.Migrations.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<AppDbContext>(
    o => o.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ChatRepo>();
builder.Services.AddSignalR();
builder.Services.AddScoped<ChatService>();


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorChatWebApp.Client._Imports).Assembly);

app.MapHub<ChatHub>("/chathub");

app.Run();
