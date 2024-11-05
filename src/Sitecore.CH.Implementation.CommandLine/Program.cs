using ManyConsole;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.CH.Base.Features.Logging.Services;
using Sitecore.CH.Base.Features.SDK.Services;
using Sitecore.CH.Implementation.CommandLine.Features.CuratedView.Commands;
using Sitecore.CH.Implementation.CommandLine.Features.CuratedView.Services;

namespace Sitecore.CH.Implementation.CommandLine
{
    class Program
    {
        public static Application Application;
        static void Main(string[] args)
        {                    
            Application = new Application();
            Application.Startup();
           // ConsoleCommandDispatcher.DispatchCommand(Application.ServiceProvider.GetServices<ConsoleCommand>(), args, Console.Out);
           var serviceProvider = Application.ServiceProvider;
           var services = new List<ConsoleCommand>
           {
               new SetRestrictedCommand(
                   serviceProvider.GetRequiredService<IMClientFactory>(),
                   serviceProvider.GetRequiredService<ILoggerService<SetRestrictedCommand>>(),
                   serviceProvider.GetRequiredService<ICuratedViewService>()
               )
           }; // serviceProvider.GetServices<ConsoleCommand>().ToList();

           ConsoleCommandDispatcher.DispatchCommand(services, args, Console.Out);
           
        }
    }
}
