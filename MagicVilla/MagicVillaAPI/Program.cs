using MagicVillaAPI.Data;
using MagicVillaAPI.Logging;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// database connection 
builder.Services.AddDbContext<ApplicationDbContext>(option=>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});


// register the serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("log/villacatalog.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();// to use serilog in the project


// to return 406 not acceptable if the format is not supported (which is json format)
builder.Services.AddControllers(option => { option.ReturnHttpNotAcceptable = true; }).
    AddNewtonsoftJson().
    AddXmlDataContractSerializerFormatters(); // to support xml format


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// registering the Ilogging and Logging class from the logging folder
builder.Services.AddSingleton<ILogging, Logging>();


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
// get all the villas
// get will by id where we need to ssepcify the id in the http get
// add the ActionResult and return Ok() and baqdrequest and notfound
// add the producesresponse type to document the possible status codes that a endpoint will return
// create a post method to create a new villa usage of [FromBody] to get the data from the body -> use it to create a new villa -> usage of createdatroute 
// add data annotation to the villadto file 
// we can also add custom error message in the data annotation using modelstate 
// add a custom validation error using modelstate if the villa name already exists in createvilla method 
// add the method delete villa 
// add the method update villa
// add extra property in villadto occupancy , and sqft and update the villlastore list
// inorder to add patch method we need to do nuget packages Microsoft.AspNetCore.JsonPatch Microsoft.AspNetCore.Mvc.NewtonsoftJson
// add the patch method to update a single property of villa 
// usage of jasonpatchdocument and look at the jsonpatch replace syntax on web // op ,path , value
// after that use postman to check all endpoints 
// add json and xml in the accept header to check the format in program.cs and check using the postman 
// implementing the logger in the controller using dependency injection
// to the check the logger see the command window in visual studio
// install serilog.aspnetcore nuget package and serilog.sinks.file
// register the serilog in the program.cs file
// check the villacatalog.txt file in the log folder to check all the logs 
// implemetation of custom logger 
// create a new folder called Logging -> interface ->ILogging.cs -> implement that in Logging.cs class 
// we use this Ilogging interface for logging information in controller
// explicitly define or register services int the container  for Ilogging telling that we have to implement the Logging.cs class 
// we used logging using ILogger , Serilog , custom logging
// using database to store villa data (table )
// install nuget packages Microsoft.EntityFrameworkCore.SqlServer and Microsoft.EntityFrameworkCore.Tools
// create a new folder called Data -> ApplicationDbContext.cs (this is used to connect to the database)
// add the connection string in the appsettings.json file
// in program.cs file register the database context
// add the dbcontext options in the ApplicationDbContext constructor
// add the migration in the package manager console
