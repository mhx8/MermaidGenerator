using Microsoft.AspNetCore.Mvc;
using OrderService.Interfaces;
using WorkflowEngine;
using WorkflowEngine.Endpoints;
using WorkflowEngine.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddInterfaces();
builder.Services.AddWorkflowEngine(
    options =>
    {
        options.WorkflowName = "OrderProcessing";
        options.AutoDiscoverWorkflowSteps = true;
    });

WebApplication app = builder.Build();

app.MapGet(
    "/process-order",
    async (
        [FromServices] IEnumerable<IWorkflowStep> workflowSteps) =>
    {
        foreach (IWorkflowStep workflowStep in workflowSteps.GetOrderedSteps())
        {
            await workflowStep.ExecuteAsync();
        }

        return Results.Ok("Order processed successfully.");
    });

app.MapWorkflowEngine();
app.Run();