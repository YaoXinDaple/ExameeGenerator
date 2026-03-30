using ExameeGenerator.Application.Commands;
using ExameeGenerator.Application.Dtos;
using ExameeGenerator.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ExameeGenerator.Api.Endpoints
{
    public static class ExamEndpoints
    {
        public static IEndpointRouteBuilder MapExamEndpoints(this IEndpointRouteBuilder app)
        {

            var group = app.MapGroup("/api/exam")
                .WithTags("exams");

            group.MapPost("/", async (
                [FromBody] CreateExamCommand command,
                [FromServices] CreateExamCommandHandler handler,
                CancellationToken cancellationToken) =>
            {
                var dto = await handler.HandleAsync(command, cancellationToken);
                return Results.Created($"/api/exam/{dto.Id}", dto);
            })
            .WithName("CreateExam")
            .Produces<ExamDto>(StatusCodes.Status201Created)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status503ServiceUnavailable);

            group.MapGet("/{id:guid}", async (
                Guid id,
                [FromServices] GetExamByIdQueryHandler handler,
                CancellationToken cancellationToken) =>
            {
                var dto = await handler.HandleAsync(new GetExamByIdQuery(id), cancellationToken);
                return Results.Ok(dto);
            })
            .WithName("GetExamById")
            .Produces<ExamDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);

            return app;
        }
    }
}
