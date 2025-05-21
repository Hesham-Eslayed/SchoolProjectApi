using System.Globalization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using SchoolProject.Api.Json;
using SchoolProject.Core;
using SchoolProject.Core.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(op
    =>
        {
            op.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            op.JsonSerializerOptions.TypeInfoResolver = MyJsonContext.Default;
        }
        );


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddOutputCache();

#region Dependency Injection

builder.Services.AddInfrastructureDependencies()
    .AddInServiceDependencies()
    .AddCoreDependencies();

#endregion Dependency Injection



#region Localization

builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt => opt.ResourcesPath = "");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
            new("en-US"),
            new("ar-EG")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion Localization

#region AllowCORS

string CORS = "_cors";
builder.Services.AddCors(options => options.AddPolicy(name: CORS,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      }));

#endregion AllowCORS

builder.Services.AddDbContextPool<AppDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("default")
?? throw new Exception("No conn found"))
);

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

#region Localization Middleware

var options = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

#endregion Localization Middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(op =>
    op.WithTheme(ScalarTheme.Mars)
    .WithDefaultHttpClient(ScalarTarget.Shell, ScalarClient.Curl)
    );

}

app.UseRouting();

app.UseHttpsRedirection();

app.UseOutputCache();

app.UseAuthorization();

app.MapControllers();

app.Run();