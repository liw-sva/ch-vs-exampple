using System;
using System.Threading.Tasks;
using Sitecore.CH.Base.Features.Logging.Services;
using Sitecore.CH.Base.Features.SDK.Services;

namespace Sitecore.CH.Implementation.CommandLine.Features.CuratedView.Services;

public class CuratedViewService : ICuratedViewService
{
    private readonly ILoggerService<CuratedViewService> _logger;
    private readonly IMClientFactory _mClientFactory;

    public CuratedViewService(ILoggerService<CuratedViewService> logger, IMClientFactory mClientFactory)
    {
        this._logger = logger;
        this._mClientFactory = mClientFactory;
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}