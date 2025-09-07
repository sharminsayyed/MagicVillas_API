var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// step 1 - create a controller in the controller folder 
//step 2 - create a model folder add a class(table ) in it 
// make a dto folder and add the villadto file 
// use that dto in the controller for the httpget
// create a data folder -> add villastore class which is static -> add the list of villas there -> when returning in the controller use villastore.villalist
//