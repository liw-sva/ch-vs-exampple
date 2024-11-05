using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sitecore.CH.Base.Features.Logging.Services;
using Sitecore.CH.Base.Features.SDK.Services;
using Stylelabs.M.Base.Querying;
using Stylelabs.M.Base.Querying.Filters;

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
    
    public async Task SetRestrictedToAssetForAllImagesAsync()
    {
        var client = _mClientFactory.Client;
        var query = new Query
        {
            Filter = new CompositeQueryFilter
            {
                Children = new QueryFilter[]
                {
                    new DefinitionQueryFilter { Name = "M.Asset" },
                    new PropertyQueryFilter
                    {
                        
                        Property = "M.AssetType",
                        Operator = ComparisonOperator.Equals,
                        Value = "Image"
                    }
                },
                CombineMethod = CompositeFilterOperator.And
            }
        };

        var images = await client.Querying.QueryAsync(query).ConfigureAwait(false);

        foreach (var image in images.Items)
        {
            image.SetPropertyValue("DRM.Restricted.RestrictedToAsset", true);
            await client.Entities.SaveAsync(image).ConfigureAwait(false);
            _logger.LogInformation($"Set RestrictedToAsset to true for image with ID: {image.Id}");
        }
    }

}