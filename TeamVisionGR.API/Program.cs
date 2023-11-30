using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using TeamVisionGR.API.Filters;
using TeamVisionGR.API.Middleware;
using TeamVisionGR.Application.Repositories;
using TeamVisionGR.Application.Services;
using TeamVisionGR.Application.Services.Mail;
using TeamVisionGR.Application.Settings;
using TeamVisionGR.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(options => {
    builder.Configuration.GetSection("MySettings").Bind(options);
});

// Autenticação
var jwtService = new JwtService(builder.Configuration);
jwtService.AddJwtAuthentication(builder.Services);

// Conexão com banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetSection("MySettings:ConnectionStrings:DefaultConnection").Value)
);

// Repositórios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserActivationRepository, UserActivationRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
builder.Services.AddScoped<ICollaboratorProjectRepository, CollaboratorProjectRepository>();

// Serviços
builder.Services.AddScoped<TeamVisionGR.Application.Services.Authentication.IAuthenticationService, TeamVisionGR.Application.Services.Authentication.AuthenticationService>();
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddScoped<IPasswordHashService, PasswordHashService>();
builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserActivationService, UserActivationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ICollaboratorService, CollaboratorService>();
builder.Services.AddScoped<ICollaboratorProjectService, CollaboratorProjectService>();

builder.Services.AddControllers(options => {
    options.Filters.Add<CustomResponseFilter>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "MovieSeeker API",
        Version = "v1"
    });

    // Configuração do esquema de segurança JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autenticação JWT usando o schema Bearer. Exemplo: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Autenticação (permitir/negar acesso à rotas)
app.UseAuthentication();

// Autorização (permitir/negar ações específicas do usuário)
app.UseAuthorization();

// Middlewares
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
