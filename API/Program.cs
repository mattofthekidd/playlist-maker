using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

//I'm guessing this would be different for a real product but I'm not there yet.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")); //sets a CORS policy for our frontend endpoint requests

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

// app.UseHttpsRedirection();


// app.UseAuthentication();
// app.UseAuthorization();


app.MapControllers();

app.Run();
