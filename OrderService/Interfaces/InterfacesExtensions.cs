namespace OrderService.Interfaces;

internal static class InterfacesExtensions
{
    internal static IServiceCollection AddInterfaces(this IServiceCollection services)
    {
        services.AddSingleton<IInvoiceGenerator, ImplementingClass>();
        services.AddSingleton<IPaymentService, ImplementingClass>();
        services.AddSingleton<IOrderSettings, ImplementingClass>();
        services.AddSingleton<INotificationPublisher, ImplementingClass>();
        services.AddSingleton<IEmailSender, ImplementingClass>();
        services.AddSingleton<IOrderDataService, ImplementingClass>();
        services.AddSingleton<IOrderValidator, ImplementingClass>();
        return services;
    }
}

public class ImplementingClass : IInvoiceGenerator, IPaymentService, IOrderSettings, INotificationPublisher, IEmailSender, IOrderDataService, IOrderValidator
{
    
}
