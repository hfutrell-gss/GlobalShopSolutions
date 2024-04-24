using System.Reflection;
using GlobalShopSolutions.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GlobalShopSolutions;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        AppDomain.CurrentDomain.AssemblyResolve += ResolveAssemblies;
        AppDomain.CurrentDomain.UnhandledException += HandleUnhandledExceptions;
        var services = new ServiceCollection()
                .AddLogging(c => c.AddConsole())
                .AddGlobalShopSolutionsDesktop(null)
            ;

        Start();
    }

    static void Start()
    {
         ApplicationConfiguration.Initialize();
         Application.Run(new MainForm());       
    }

    private static void HandleUnhandledExceptions(object sender, UnhandledExceptionEventArgs e)
    {
        throw new NotImplementedException();
    }

    private static Assembly? ResolveAssemblies(object? sender, ResolveEventArgs args)
    {
        throw new NotImplementedException();
    }
}