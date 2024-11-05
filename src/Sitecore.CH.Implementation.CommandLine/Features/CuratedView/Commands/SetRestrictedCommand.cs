using ManyConsole;
using Sitecore.CH.Base.Features.Logging.Services;
using Sitecore.CH.Base.Features.SDK.Services;
using Sitecore.CH.Implementation.CommandLine.Features.CuratedView.Services;


namespace Sitecore.CH.Implementation.CommandLine.Features.CuratedView.Commands;

public class SetRestrictedCommand : ConsoleCommand
{
    private readonly IMClientFactory _mClientFactory;
    private readonly ILoggerService<SetRestrictedCommand> _logger;
    private readonly ICuratedViewService _curatedViewService;

    public SetRestrictedCommand(IMClientFactory mClientFactory,
        ILoggerService<SetRestrictedCommand> logger,
        ICuratedViewService curatedViewService)
    {
        IsCommand("SetRestricted", "Runs a new SetRestricted command");
        this._mClientFactory = mClientFactory;
        this._logger = logger;
        this._curatedViewService = curatedViewService;
    }
    
    public override int Run(string[] remainingArguments)
    {
        throw new System.NotImplementedException();
    }
}