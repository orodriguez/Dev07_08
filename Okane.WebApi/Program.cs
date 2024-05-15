/*
NOTES:
Add services to the container.
Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Ok Got it !, Thanks !*/
// Using my App 

using Okane.Application;
// Using for handlers and for requesting and more handlers 
using Okane.Application.Expenses.Create;

/* This is for setting up middleware,routing, services, web host configuration
   various aspects of the web*/
var builder = WebApplication.CreateBuilder(args);

// This method registers the services needed for endpoint routing, including route matching, endpoint discovery, and request processing.
builder.Services.AddEndpointsApiExplorer();
/*
 * These services analyze your API's controllers, routes, and data models to create a Swagger JSON document
 * describing your API's endpoints, request/response formats, and other metadata.
 */
builder.Services.AddSwaggerGen();
// Using Our Services ServiceCollections
builder.Services.AddOkane();
// 
var app = builder.Build();
// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // For doc the Api 
    app.UseSwagger();
    // For See The Api xD  GUI WEB
    app.UseSwaggerUI();
}
// Making it secure protocol
app.UseHttpsRedirection();
// Retrive By Specific ID 
app.MapGet("/expenses/{id}", (Okane.Application.Expenses.Retrieve.Handler handler, int id) =>
        handler.HandleById(id))
    .WithOpenApi();
/* Using get on this endpoint will retrive all the items in the expense database
 Now Has Description field it can be optional*/
app.MapGet("/expenses", (Okane.Application.Expenses.Retrieve.Handler handler) =>
        handler.HandleAll())
    .WithOpenApi();
// Use POST to create an Expanse 
app.MapPost("/expenses", (Handler handler, Request request) =>
        handler.Handle(request))
    .WithOpenApi();
// Start the Backend 
app.Run();