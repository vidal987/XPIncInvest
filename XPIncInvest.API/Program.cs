using MediatR;
using System.Reflection;
using System.Text.Json.Serialization;
using XPIncInvest.API.ConfigurationServices;
using XPIncInvest.BuildingBlocks.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddScannedIoC()
    .AddDataContext()
    .AddMediator()
    .AddSwagger();

builder.Services.AddProblemDetails();
builder.Services.AddApiVersioning();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Support string to enum conversions
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


// Build the app
var app = builder.Build();


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStatusCodePages();

app.UseAuthorization();
app.MapControllers();
app.Run();