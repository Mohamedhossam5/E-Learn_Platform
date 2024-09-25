using API.Extensions;
using API.Extensions.Migrations;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Core.Entities.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Services.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlite(builder.Configuration.GetConnectionString("constr")));

builder.Services.AddDbContext<AppIdentityDbContext>(x =>
    x.UseSqlite(builder.Configuration.GetConnectionString("constr")));

// builder.Services.AddIdentityServices();


builder.Services.AddIdentity<AppUser , IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddApiEndpoints();

builder.Services.AddScoped<IAuthService , AuthService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = false;
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience =  builder.Configuration["JWT:Audience"],
        IssuerSigningKey  = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
// });

// builder.Services.AddIdentityServices();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapIdentityApi<AppUser>();
app.ApplyMigrations();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();  
app.UseAuthorization();

app.MapControllers();  // Assuming Identity API routing is handled within controllers

app.Run();

