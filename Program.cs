using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ModuleOperations>();
builder.Services.AddScoped<AuxiliarTOperations>();
builder.Services.AddScoped<CommentOperations>();
builder.Services.AddScoped<NotificationOperations>();
builder.Services.AddScoped<OperacionesOperation>();
builder.Services.AddScoped<Operation_RolOperations>();
builder.Services.AddScoped<ProyectsOperations>();
builder.Services.AddScoped<RolOperation>();
builder.Services.AddScoped<TasksOperations>();
builder.Services.AddScoped<UsersOperations>();
builder.Services.AddScoped<ApplicationDbcontext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Asignacion de tareas", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor ingrese el Token",
        Name = "Authorizacion",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {{
        new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
        }, new List<string>()
        }
    });
    c.OperationFilter<AuthorizeCheckOperationFilter>();
});

builder.Services.AddDbContext<ApplicationDbcontext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("CadenaPostgre"))
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbcontext>();
    dbContext.Database.Migrate();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHttpsRedirection();

app.UseExceptionHandler(a => a.Run(async context =>
{
    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>(); var exception = exceptionHandlerPathFeature.Error;
    context.Response.StatusCode = 500; await context.Response.WriteAsJsonAsync(new { Error = "An unexpected error occurred" });
}));

app.UseAuthentication();

app.UseMiddleware<AutorizationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
