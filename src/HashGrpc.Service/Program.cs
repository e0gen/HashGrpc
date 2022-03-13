using HashService.Application.Core;
using HashService.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddScoped<IHashLogic, HashLogic>();

var app = builder.Build();


app.MapGrpcService<HashServiceGrpc>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();
