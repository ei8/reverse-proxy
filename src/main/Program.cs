using LettuceEncrypt;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLettuceEncrypt();
builder.Services.AddSingleton<ICertificateSource, FilePemSource>();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();

app.Run();
