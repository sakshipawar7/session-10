using WebApplication1.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//ilder.Services.AddSingleton<IStudentRepo,StudentRepo>();
builder.Services.AddSingleton <IStudentRepo0901,StudentRepo0901>();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
