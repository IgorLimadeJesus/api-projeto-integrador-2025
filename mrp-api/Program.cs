using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mrp_api.Data;
using mrp_api.Repositorios;
using mrp_api.Repositorios.Interface;
using mrp_api.Services;
using mrp_api.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

//Liberar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configuração das Portas
builder.WebHost.UseUrls("http://0.0.0.0:5000", "https://0.0.0.0:5001");

// Configuração do Entity Framework Core com SQL Server
builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<MrpDBContext>(
                    option => option.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                    );

builder.Services.AddScoped<IFuncionarioRepositorio, FucionarioRepostorio>();
builder.Services.AddScoped<IMachineRepositorio, MachinesRepositorio>();
builder.Services.AddScoped<ICargoRepositorio, CargoRepositorio>();
builder.Services.AddScoped<ISetorRepositorio, SetorRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IInsumoRepositorio, InsumosRepositorio>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ISetorRepositorio, SetorRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}  //Swagger Desativado, não mecher

app.UseCors("PermitirTudo");

app.MapGet("/", () => "API está viva!");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
