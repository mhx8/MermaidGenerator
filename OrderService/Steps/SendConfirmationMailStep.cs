using OrderService.Interfaces;
using WorkflowEngine;

namespace OrderService.Steps;

public class SendConfirmationMailStep(
    IEmailSender emailSender,
    ILogger<SendConfirmationMailStep> logger) : IWorkflowStep
{
    public Task ExecuteAsync()
    {
        logger.LogInformation("Executing SendConfirmationMailStep");
        return Task.CompletedTask;
    }

    public int Sequence => 5;
}