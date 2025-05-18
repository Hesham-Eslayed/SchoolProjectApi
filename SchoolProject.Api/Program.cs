using System.Text.Json.Serialization;

using Scalar.AspNetCore;

using SchoolProject.Core;
using SchoolProject.Core.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(op =>
op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);




// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



#region Dependency Injection

builder.Services.AddInfrastructureDependencies()
    .AddInServiceDependencies()
    .AddCoreDependencies();

#endregion Dependency Injection



builder.Services.AddDbContextPool<AppDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("default")
?? throw new Exception("No conn found"))
);

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(op =>
    op.WithTheme(ScalarTheme.Mars)
    .WithDefaultHttpClient(ScalarTarget.Shell, ScalarClient.Curl)
    );

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();