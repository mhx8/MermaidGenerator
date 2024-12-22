using OrderService.Interfaces;
using WorkflowEngine;

namespace OrderService.Steps;

public class ProcessPaymentStep(
    IPaymentService paymentService,
    ILogger<ProcessPaymentStep> logger) : IWorkflowStep
{
    public Task ExecuteAsync()
    {
        logger.LogInformation("Executing ProcessPaymentStep");
        return Task.CompletedTask;
    }

    public int Sequence => 3;
}