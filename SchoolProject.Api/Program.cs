using System.Globalization;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using SchoolProject.Core;
using SchoolProject.Core.MiddleWare;
using SchoolProject.Domain.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
	.AddJsonOptions(op
			=>
		{
			op.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
			op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
			// op.JsonSerializerOptions.TypeInfoResolver = MyJsonContext.Default;
			op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
		}
	);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.Name));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddOutputCache();

#region Dependency Injection

builder.Services.AddInfrastructureDependencies(builder.Configuration)
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

	options.DefaultRequestCulture = new("en-US");
	options.SupportedCultures = supportedCultures;
	options.SupportedUICultures = supportedCultures;
});

#endregion Localization

#region AllowCORS

const string CORS = "_cors";

builder.Services.AddCors(options => options.AddPolicy(CORS,
	policy =>
	{
		policy.AllowAnyHeader();
		policy.AllowAnyMethod();
		policy.AllowAnyOrigin();
	}));

#endregion AllowCORS

builder.Services.AddDbContextPool<AppDbContext>(op =>
	op.UseSqlServer(builder.Configuration.GetConnectionString("default") ?? throw new("No conn found"))
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

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(CORS);

app.UseOutputCache();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();