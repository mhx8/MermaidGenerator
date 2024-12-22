namespace WorkflowEngine.Extensions;

public static class WorkflowStepExtensions
{
    public static IEnumerable<IWorkflowStep> GetOrderedSteps(
        this IEnumerable<IWorkflowStep> steps)
        => steps.OrderBy(s => s.Sequence);
}