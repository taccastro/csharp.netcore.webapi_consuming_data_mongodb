using csharp.netcore.api_consuming_data_mongodb.Models;
using csharp.netcore.api_consuming_data_mongodb.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var configuration = builder.Configuration;

// This method gets called by the runtime. Use this method to add services to the container.  
builder.Services.Configure<EmployeeDatabaseSettings>(
    configuration.GetSection(nameof(EmployeeDatabaseSettings)));

builder.Services.AddSingleton<IEmployeeDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<EmployeeDatabaseSettings>>().Value);

builder.Services.AddSingleton<EmployeeService>();

var app = builder.Build();

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
