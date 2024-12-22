namespace WorkflowEngine;

public interface IWorkflowStep
{
    Task ExecuteAsync();
 
    int Sequence { get; }
}