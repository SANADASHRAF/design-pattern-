using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPatternWithUnitOFWork.Core;
using RepositoryPatternWithUnitOFWork.Core.interfaces;
using RepositoryPatternWithUnitOFWork.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//////////////////////////////////////////////////////////////coonection string
builder.Services.AddDbContext<context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        //the place wherr dbcontext(context) is exist
        b=>b.MigrationsAssembly(typeof(context).Assembly.FullName)
        
        );
});

// to use the intefsce in the repositoryofcore (because i will use this inteface and it's class from __Api(main layer))

//builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>)); 
builder.Services.AddTransient<IunitOfWork, unitOfWork>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
