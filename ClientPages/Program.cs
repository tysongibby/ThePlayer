using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using ClientPages;
using Data.Context;
using Data.Repositories;
using Data.Repositories.Interfaces;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDbContext<ThePlayerContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ThePlayerDb")));
builder.Services.AddScoped<IAudioFileRepository, AudioFileRepository>();
builder.Services.AddMudServices();


await builder.Build().RunAsync();
