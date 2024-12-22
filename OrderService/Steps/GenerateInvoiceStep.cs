using OrderService.Interfaces;
using WorkflowEngine;

namespace OrderService.Steps;

public class GenerateInvoiceStep(
    IInvoiceGenerator invoiceGenerator,
    ILogger<GenerateInvoiceStep> logger) : IWorkflowStep
{
    public Task ExecuteAsync()
    {
        logger.LogInformation("Executing GenerateInvoiceStep");
        return Task.CompletedTask;
    }

    public int Sequence => 4;
}