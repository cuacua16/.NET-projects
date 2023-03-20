using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OBwebAPI;
using OBwebAPI.DataAccess;
using OBwebAPI.Services;
//using serilog
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Config Serilog
builder.Host.UseSerilog((hostBuilderCtx, loggerConf) => {
	loggerConf
	.WriteTo.Console()
	.WriteTo.Debug()
	.ReadFrom.Configuration(hostBuilderCtx.Configuration);
});




// Add services to the container.
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//add context:
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

//add service JWT Autorization
builder.Services.AddJwtTokenServices(builder.Configuration);



builder.Services.AddControllers();

builder.Services.AddScoped<IStudentService, StudentService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
	options => {
		//security
		options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
			Name = "Authorization",
			Type = SecuritySchemeType.Http,
			Scheme = "Bearer",
			BearerFormat = "JWT",
			In = ParameterLocation.Header,
			Description = "JWT Authorization Header using Bearer Scheme"
		});

		options.AddSecurityRequirement(new OpenApiSecurityRequirement{
			{
				new OpenApiSecurityScheme{
					Reference = new OpenApiReference{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
				}
			},
				new string[] { }
	} });

	}
	);

//ADD CORS
builder.Services.AddCors(options => {
	options.AddPolicy(name: "CorsPolicy", builder => {
		builder.AllowAnyOrigin();
		builder.AllowAnyMethod();
		builder.AllowAnyHeader();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

//USE SERILOG LOGGER
app.UseSerilogRequestLogging();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
