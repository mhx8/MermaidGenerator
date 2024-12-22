using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WorkflowEngine.ExecutionPlan;

namespace WorkflowEngine.Endpoints;

public static class WorkflowEngineEndpoints
{
    public static void MapWorkflowEngine(
        this IEndpointRouteBuilder endpoints)
        => endpoints.MapGet(
            "/execution-plan",
            (
                [FromServices] IExecutionPlanGenerator planGenerator) => Results.Content(
                planGenerator.Generate(),
                "text/html"));
}