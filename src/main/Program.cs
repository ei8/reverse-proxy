using LettuceEncrypt;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ei8.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLettuceEncrypt();
if (bool.TryParse(builder.Configuration["LettuceEncrypt:UseStagingServer"], out bool useStagingServer) && useStagingServer)
    builder.Services.AddSingleton<ICertificateSource, FilePemSource>();

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();

app.Run();
