using MediatR;
using System.Reflection;
using ViaCepMediator.Apis.ViaCepMediatorHandler;
using ViaCepMediator.Integration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IRequestHandler<ViaCepMediatorRequest, ViaCepMediatorResponse>>(x => new ViaCepMediatorHandler(
        x.GetRequiredService<IViaCepClient>()));

builder.Services.AddScoped<IViaCepClient>(x => new ViaCepClient(
    new HttpClient(),
    x.GetRequiredService<ILogger<ViaCepClient>>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
