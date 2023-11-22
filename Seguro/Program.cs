using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Seguro;
using Seguro.Dominio.Entidades;
using Seguro.Dominio.Repositories;
using Seguro.Services;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Admin", policy => policy.RequireRole("manager"));
    option.AddPolicy("Employer", policy => policy.RequireRole("employee"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/login", (User model) =>
{
    var user = UserRepository.Get(model.UserName, model.Password);

    if (user == null)
        return Results.NotFound(new { message = "Invalid Token" });
    var token = TokenService.GenerateToken(user);

    user.Password = "";
    return Results.Ok(new
    {
        user = user,
        token = token
    });
});

app.MapGet("/anonymous", () => {
    Console.WriteLine("Teste");
    Results.Ok("anonymous"); 
}).AllowAnonymous();

app.MapGet("/authenticated", (ClaimsPrincipal user) =>
{
    Console.WriteLine("Caiu aqui");
    Results.Ok(new { message = $"Authenticated as {user.Identity.Name}" });
}).RequireAuthorization();

app.MapGet("/employee", (ClaimsPrincipal user) =>
{
    Results.Ok(new
    {
        message = $"Authenticated as {user.Identity.Name}"
    });
}).RequireAuthorization();


app.MapControllers();

app.Run();
