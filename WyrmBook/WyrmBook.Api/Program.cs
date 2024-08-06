using System.Text.Json.Serialization;
using WyrmBook.Api.Results.DependencyInjection;
using WyrmBook.Core.Services;
using WyrmBook.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DragonService>();
builder.Services.AddMediatR(r => r.RegisterServicesFromAssemblyContaining(typeof(MediatRMarkingClass)));

ResultSetup.Setup();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();