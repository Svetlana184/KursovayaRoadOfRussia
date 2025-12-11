
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
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


builder.Services.AddDbContext<RoadOfRussiaKorushkContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IService<Department>, DepartmentService>();
builder.Services.AddScoped<IService<Employee>, EmployeeService>();
builder.Services.AddScoped<IService<Event>, EventService>();
builder.Services.AddScoped<IService<Calendar_>, CalendarService>();
builder.Services.AddScoped<IService<WorkingCalendar>, WorkingCalendarService>();

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

app.Map("/login", async (User emp) => {

    User employee = null;
    using (RoadOfRussiaKorushkContext db = new RoadOfRussiaKorushkContext())
    {

        employee = await db.Users.FirstOrDefaultAsync(p => p.Email == emp.Email)!;

        string password = AuthOptions.GenerateSha256Hash(emp.Password);
        if (employee == null || employee.Password != password) return Results.Unauthorized();
    }
    
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, employee.Email) };
    var jwt = new JwtSecurityToken(issuer: AuthOptions.ISSUER, 
        audience: AuthOptions.AUDIENCE, 
        claims: claims, 
        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
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

app.MapPost("/register", async (User user, RoadOfRussiaKorushkContext db) =>
{
   
    user.Password = AuthOptions.GenerateSha256Hash(user.Password);
    db.Users.Add(user);
    await db.SaveChangesAsync();
    User createdUser = db.Users.FirstOrDefault(p => p.Email == user.Email)!;
    return Results.Ok(createdUser);
});

var context = app.Services.CreateScope().ServiceProvider.
    GetRequiredService<RoadOfRussiaKorushkContext>();
SeedData.SeedDatabase(context);

app.Run();

byte[] StringToByte(string str)
{
    string[] strings = str.Trim().Split(" ");
    byte[] bytes = new byte[strings.Length];
    for(int i = 0; i < strings.Length; i++)
    {
        bytes[i] = byte.Parse(strings[i]);
    }
    return bytes;
}

string ByteToString(byte[] bytes)
{
    string result = "";
    for (int i = 0; i < bytes.Length; i++)
    {
        result+= bytes[i]+" ";
    }
    return result;
}



public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; //издатель токена
    public const string AUDIENCE = "MyAuthClient"; //потребитель токена
    const string KEY = "my_supersecret_secret_secret_secret_key_1111"; //ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey()=> 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));

    
    public static string GenerateSha256Hash(string password)
    {
        var sha = new SHA1Managed();
        byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hash);
    }
}

//методы шифрования

