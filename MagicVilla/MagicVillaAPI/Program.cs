using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
