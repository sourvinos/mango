using Mango.Services.AuthAPI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// https://localhost:7001/swagger/index.html

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option => {
    option.UseMySql(builder.Configuration.GetConnectionString("LocalDevelopment"), new MySqlServerVersion(new Version(8, 0, 19)), builder => {
        builder.EnableStringComparisonTranslations();
    });
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddControllers();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

