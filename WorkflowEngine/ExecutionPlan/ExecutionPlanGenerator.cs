using System.Reflection;
using System.Text;
using Microsoft.Extensions.Logging;
using WorkflowEngine.Extensions;
using WorkflowEngine.Resource;

namespace WorkflowEngine.ExecutionPlan
{
    public class ExecutionPlanGenerator(
        IEnumerable<IWorkflowStep> steps,
        WorkflowOptions options) : IExecutionPlanGenerator
    {
        private const int MaxRandomValue = 1000;

        public string Generate()
        {
            if (!steps.Any())
            {
                return "Please register any workflow steps.";
            }

            string resourceText = ResourceUtility.GetHtmlContent();

            resourceText = resourceText
                .Replace(
                    "__MERMAID__",
                    GenerateGraph(steps))
                .Replace(
                    "__DEPENDENCIES__",
                    GenerateDependencies(steps))
                .Replace(
                    "__TITLE__",
                    options.WorkflowName);

            return resourceText;
        }

        private static string GenerateDependencies(
            IEnumerable<IWorkflowStep> steps)
        {
            StringBuilder dependencies = new();
            foreach (IWorkflowStep workflowStep in steps)
            {
                Type stepType = workflowStep.GetType();
                ConstructorInfo actionCtor = stepType.GetConstructors()[0];

                string?[] serviceDependencyArgs = actionCtor
                    .GetParameters()
                    .Where(p => !IsLogger(p.ParameterType))
                    .Select(
                        p => p.ParameterType.Name)
                    .ToArray();
                if (serviceDependencyArgs.Length == 0)
                {
                    continue;
                }

                StringBuilder subgraphBuilder = new();
                int random = Random.Shared.Next(MaxRandomValue);
                subgraphBuilder.AppendLine($"subgraph {random}-DEP [\" \"]");
                foreach (string? serviceDependency in serviceDependencyArgs
                             .Where(dependency => dependency is not null))
                {
                    subgraphBuilder.AppendLine($"{Random.Shared.Next(MaxRandomValue)}[\"{serviceDependency}\"]");
                }

                subgraphBuilder.AppendLine("end");
                subgraphBuilder.AppendLine($"{GetDisplayName(workflowStep)} --> {random}-DEP");
                dependencies.AppendLine(subgraphBuilder.ToString());
            }

            return dependencies.ToString();
        }

        private static bool IsLogger(
            Type type)
            => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ILogger<>);

        private static string GenerateGraph(
            IEnumerable<IWorkflowStep> steps)
            => string.Join(
                "-->",
                steps
                    .GetOrderedSteps()
                    .Select(GetDisplayName));

        private static string GetDisplayName(
            IWorkflowStep step)
            => step
                .GetType()
                .Name
                .Replace(
                    "Step",
                    string.Empty);
    }
}