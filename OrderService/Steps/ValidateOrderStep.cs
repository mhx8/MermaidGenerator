using OrderService.Interfaces;
using WorkflowEngine;

namespace OrderService.Steps;

public class ValidateOrderStep(
    IOrderValidator orderValidator,
    IOrderSettings orderSettings,
    ILogger<ValidateOrderStep> logger) : IWorkflowStep
{
    public Task ExecuteAsync()
    {
        logger.LogInformation("Executing ValidateOrderStep");
        return Task.CompletedTask;
    }

    public int Sequence => 1;
}