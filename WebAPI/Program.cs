
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models;
using WebAPI.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<RoadOfRussiaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IService<Department>, DepartmentService>();
builder.Services.AddScoped<IService<Employee>, EmployeeService>();
builder.Services.AddScoped<IService<Event>, EventService>();
builder.Services.AddScoped<IService<Calendar_>, CalendarService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
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

app.Map("/login", (Employee emp) => {

    Employee employee = null;
    using (RoadOfRussiaContext db = new RoadOfRussiaContext())
    {
        employee = db.Employees.FirstOrDefault(p=>p.Email == emp.Email&&p.Password == emp.Password)!;
        if (employee == null) return Results.Unauthorized();
    }
    
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, employee.Email) };
    var jwt = new JwtSecurityToken(issuer: AuthOptions.ISSUER, 
        audience: AuthOptions.AUDIENCE, 
        claims: claims, 
        expires: DateTime.UtcNow.AddMinutes(30),
        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    var encodedJWT = new JwtSecurityTokenHandler().WriteToken(jwt);
    var response = new
    {
        access_token = encodedJWT,
        email = employee.Email,
    };

    return Results.Json(response);

});

app.UseAuthorization();


app.MapControllers();

app.Run();


public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; //издатель токена
    public const string AUDIENCE = "MyAuthClient"; //потребитель токена
    const string KEY = "my_supersecret_secret_secret_secret_key_1111"; //ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey()=> 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}