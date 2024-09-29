using CozaStoreAPI.Core.Services;
using CozaStoreAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddAppIdentity();
builder.Services.AddAppServices();
builder.Services.AddCorsPolicy();
builder.Services.AddHostedService<DailyDataRetrievalService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ValidateUserIdMiddleware>();

app.MapControllers();

await app.RunAsync();
