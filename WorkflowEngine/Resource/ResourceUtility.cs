using System.Reflection;

namespace WorkflowEngine.Resource;

internal static class ResourceUtility
{
    private const string HtmlFileName = "workflow-plan.html";

    internal static string GetHtmlContent()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Resource.{HtmlFileName}")
                        ?? throw new ArgumentException($"Resource '{HtmlFileName}' not found in assembly '{assembly.FullName}'");

        return new StreamReader(stream).ReadToEnd();
    }
}
