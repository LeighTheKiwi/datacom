// ********************************
// Minimal API Endpoint definitions including OpenApi/Swagger metadata.
// ********************************
using Microsoft.AspNetCore.Mvc;
using MiniValidation;
using tracker.api.Data;

namespace tracker.api
{
    public static class EndpointExtensions
    {
        public static void MapEndpoints(this WebApplication app)
        {
            // Usually I would try and keep the endpoint names following the pattern used in the class names. For instance,
            // I use jobApplication in the api instead of just application (as its too generic), however, the brief specifically 
            // stated using "applications" in the endpoints (I would have used GET /jobApplications for example).

            app.MapGet("/applications", (IJobApplicationRepository repo) => repo.GetAll())
            .WithDescription("Get a list of Job Applications")
            .Produces<JobApplicationDto[]>(StatusCodes.Status200OK);
                

            app.MapGet("/applications/{id:int}", async (int id, IJobApplicationRepository repo) =>
            {
                var application = await repo.Get(id);

                if (application == null)
                    return Results.Problem($"Application {id} not found.", statusCode: 404);

                return Results.Ok(application);
            })
            .WithDescription("Get a Job Application by Id")
            .ProducesProblem(404)
            .Produces<JobApplicationDto>(StatusCodes.Status200OK);


            app.MapPost("/applications", async ([FromBody] JobApplicationCreateDto dto, IJobApplicationRepository repo) =>
            {
                if (!MiniValidator.TryValidate(dto, out var errors))
                    return Results.ValidationProblem(errors);

                var newApplication = await repo.Create(dto);

                return Results.Created($"/application/{newApplication.Id}", newApplication);
            })
            .WithDescription("Create a Job Application")
            .ProducesValidationProblem()
            .Produces<JobApplicationDto>(StatusCodes.Status201Created);


            app.MapPut("/applications", async ([FromBody] JobApplicationUpdateDto dto, IJobApplicationRepository repo) =>
            {
                if (!MiniValidator.TryValidate(dto, out var errors))
                    return Results.ValidationProblem(errors);

                if (await repo.Get(dto.Id) == null)
                    return Results.Problem($"Application {dto.Id} not found", statusCode: 404);

                var updatedApplication = await repo.Update(dto);
                return Results.Ok(updatedApplication);

            })
            .WithDescription("Update a Job Application")
            .ProducesValidationProblem()
            .ProducesProblem(404)
            .Produces<JobApplicationDto>(StatusCodes.Status200OK);
        }
    }
}
