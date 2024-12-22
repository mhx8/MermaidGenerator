using Microsoft.Extensions.DependencyInjection;
using WorkflowEngine.ExecutionPlan;

namespace WorkflowEngine.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWorkflowEngine(
        this IServiceCollection services,
        Action<WorkflowOptions> workflowOptions)
    {
        WorkflowOptions options = new();
        workflowOptions.Invoke(options);

        services.AddSingleton(options);
        services.AddSingleton<IExecutionPlanGenerator, ExecutionPlanGenerator>();
        if (options.AutoDiscoverWorkflowSteps)
        {
            services.Scan(
                scan => scan
                    .FromApplicationDependencies()
                    .AddClasses(
                        classes =>
                            classes.AssignableTo(typeof(IWorkflowStep)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
        }

        return services;
    }
}
