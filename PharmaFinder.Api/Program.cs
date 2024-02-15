using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PharmaFinder.Api.Settings;
using PharmaFinder.Core.Common;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using PharmaFinder.Infra.Common;
using PharmaFinder.Infra.Repository;
using PharmaFinder.Infra.Service;
using System.Text;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IPharmacyRepository, PharmacyRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserTestmonialRepository, UserTestmonialRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderMedRepository, OrderMedRepository>();
builder.Services.AddScoped<IReadPrescriptionRepository, ReadPrescriptionRepository>();
builder.Services.AddScoped<IHomeRepository, HomeRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();

//Services
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IContactUsService, ContactUsService>();
builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IPharmacyService, PharmacyService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserTestimonialService, UserTestimonialService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderMedService, OrderMedService>();
builder.Services.AddScoped<IReadPrescriptionService, ReadPrescriptionService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IPhMedServices, PhMedService>();
builder.Services.AddScoped<IPhMedRepsitory, PhMedRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.Configure<EmailConfiguration>(configuration.GetSection("EmailConfiguration"));
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddControllers();

//
builder.Services.AddSingleton<IConverter>(new SynchronizedConverter(new PdfTools()));
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue;
    options.BufferBodyLengthLimit = int.MaxValue;
    options.ValueLengthLimit = int.MaxValue;
});
//

builder.Services.AddScoped<IJWTRepository, JWTRepository>();
builder.Services.AddScoped<IJWTService, JWTService>();


builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("policy",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
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

app.UseAuthorization();
app.UseCors("policy");
app.MapControllers();

app.Run();
