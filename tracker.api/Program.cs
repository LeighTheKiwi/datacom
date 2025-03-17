using tracker.api;
using tracker.api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

//builder.Services.AddDbContext<JobApplicationDbContext>(options => options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddDbContext<JobApplicationDbContext>();
builder.Services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins(builder.Configuration["AllowedCORS"]??"").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

app.MapEndpoints();

app.Run();
