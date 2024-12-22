using WorkflowEngine;

namespace OrderService.Steps;

public class FinalizeOrderStep(ILogger<FinalizeOrderStep> logger) : IWorkflowStep
{
    public Task ExecuteAsync()
    {
        logger.LogInformation("Executing FinalizeOrderStep");
        return Task.CompletedTask;
    }

    public int Sequence => 7;
}