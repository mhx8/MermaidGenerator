using OrderService.Interfaces;
using WorkflowEngine;

namespace OrderService.Steps;

public class SendShippingNotificationStep(
    INotificationPublisher notificationPublisher,
    ILogger<SendShippingNotificationStep> logger) : IWorkflowStep
{
    public Task ExecuteAsync()
    {
        logger.LogInformation("Executing SendShippingNotificationStep");
        return Task.CompletedTask;
    }

    public int Sequence => 6;
}