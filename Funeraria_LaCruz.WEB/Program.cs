using CurrieTechnologies.Razor.SweetAlert2;
using Funeraria_LaCruz.WEB;
using Funeraria_LaCruz.WEB.Auth;
using Funeraria_LaCruz.WEB.Repositories;
using Funeraria_LaCruz.WEB.Auth;
using Funeraria_LaCruz.WEB;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;




var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7162/") });

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationProviderJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
builder.Services.AddScoped<ILoginService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());


//builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderTest>();


await builder.Build().RunAsync();