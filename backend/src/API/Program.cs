using API.Extensions;
using Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddMediatR();  

builder.Services.AddControllers();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDatabaseHealthCheck(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler(opt => { });
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
