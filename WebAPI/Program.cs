
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

using (RoadOfRussiaContext db = new RoadOfRussiaContext())
{
    if(db.Departments.Count() == 0)
    {
        Department dep_start = new Department()
        {
            DepartmentName = "start department"
        };
        await db.Departments.AddAsync(dep_start);
        await db.SaveChangesAsync();
        Employee admin_start = new Employee()
        {
            Surname = "ad",
            FirstName = "start",
            Position = "administrator",
            PhoneWork = "+0",
            Cabinet = "0",
            Email = "start_admin@gmail.com",
            IdDepartment = db.Departments.FirstOrDefault(p => p.IdDepartment == 1)!.IdDepartment

        };
        await db.Employees.AddAsync(admin_start);
        await db.SaveChangesAsync();
    }
    
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.Map("/login", async (Employee emp) => {

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

app.MapPost("/register", async (Employee user, RoadOfRussiaContext db) =>
{
    byte[] salt = AuthOptions.GenerateSalt();
    byte[] sha256Hash = AuthOptions.GenerateSha256Hash(user.Password, salt);
    db.Employees.Add(user);
    await db.SaveChangesAsync();
});

app.Run();


public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; //издатель токена
    public const string AUDIENCE = "MyAuthClient"; //потребитель токена
    const string KEY = "my_supersecret_secret_secret_secret_key_1111"; //ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey()=> 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));

    public static byte[] GenerateSalt()
    {
        const int SaltLength = 64;
        byte[] salt = new byte[SaltLength];

        var rngRand = new RNGCryptoServiceProvider();
        rngRand.GetBytes(salt);

        return salt;
    }
    public static byte[] GenerateSha256Hash(string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

        using var hash = new SHA256CryptoServiceProvider();

        return hash.ComputeHash(saltedPassword);
    }
}

//методы шифрования

