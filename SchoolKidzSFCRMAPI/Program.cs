using SchoolKidzSFCRMAPI.AuthenticationLayer.Models;
using SchoolKidzSFCRMAPI.AuthenticationLayer.Services;
using SchoolKidzSFCRMAPI.Services;
using SchoolKidzSFCRMAPI.Services.Interfaces;
using SchoolKidzSFCRMAPI.Services.RequestLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using SchoolKidzSFCRMAPI.Middlewares.ExceptionHandling;
using SchoolKidzSFCRMAPI.Middlewares.SecurityMiddleware;
using Microsoft.OpenApi.Models;
using SchoolKidzSFCRMAPI.Controllers;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


builder.Services.Configure<AuthenticationOption>(builder.Configuration.GetSection(AuthenticationOption.AuthenticationStrings));
builder.Services.Configure<FilepathOption>(builder.Configuration.GetSection(FilepathOption.Filepathstring));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IQuoteRequestService, QuoteRequestService>();
builder.Services.AddScoped<INotesService, NotesService>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
/*app.UseMiddleware<SecurityHandler>();
*/// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
