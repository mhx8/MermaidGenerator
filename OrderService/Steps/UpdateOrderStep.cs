using OrderService.Interfaces;
using WorkflowEngine;

namespace OrderService.Steps;

public class UpdateOrderStep(
    IOrderDataService orderDataService,
    ILogger<UpdateOrderStep> logger) : IWorkflowStep
{
    public Task ExecuteAsync()
    {
        logger.LogInformation("Executing UpdateOrderStep");
        return Task.CompletedTask;
    }

    public int Sequence => 2;
}