using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Controller.LiveTv;
using MediaBrowser.Model.Dto;
using MediaBrowser.Model.LiveTv;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.MediathekViewWeb.PVR;

/// <author email="dersyth@gmail.com">Sythelux Rikd.</author>
/// <summary>
/// Class ListingsProvider.
/// </summary>
public class ListingsProvider : IListingsProvider
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly ILogger<LiveTvService> logger;

    /// <summary>Initializes a new instance of the <see cref="ListingsProvider"/> class.</summary>
    /// <param name="httpClientFactory">Http Factory from Jellyfin.</param>
    /// <param name="logger">Logger from Jellyfin.</param>
    public ListingsProvider(IHttpClientFactory httpClientFactory, ILogger<LiveTvService> logger)
    {
        this.httpClientFactory = httpClientFactory;
        this.logger = logger;
    }

    /// <summary>
    /// Gets Name of Service.
    /// </summary>
    public string Name => "Mediathek View";

    /// <summary>
    /// Gets Homepage.
    /// </summary>
    public string Type => "Web";

    /// <inheritdoc />
    public async Task<IEnumerable<ProgramInfo>> GetProgramsAsync(ListingsProviderInfo info, string channelId, DateTime startDateUtc, DateTime endDateUtc, CancellationToken cancellationToken)
    {
        logger.LogDebug(MethodBase.GetCurrentMethod() + string.Empty);
        await Task.CompletedTask.ConfigureAwait(false);
        return Array.Empty<ProgramInfo>();
    }

    /// <inheritdoc />
    public async Task Validate(ListingsProviderInfo info, bool validateLogin, bool validateListings)
    {
        logger.LogDebug(MethodBase.GetCurrentMethod() + string.Empty);
        await Task.CompletedTask.ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<List<NameIdPair>> GetLineups(ListingsProviderInfo info, string country, string location)
    {
        logger.LogDebug(MethodBase.GetCurrentMethod() + string.Empty);
        await Task.CompletedTask.ConfigureAwait(false);
        return Array.Empty<NameIdPair>().ToList();
    }

    /// <inheritdoc />
    public async Task<List<ChannelInfo>> GetChannels(ListingsProviderInfo info, CancellationToken cancellationToken)
    {
        logger.LogDebug(MethodBase.GetCurrentMethod() + string.Empty);
        await Task.CompletedTask.ConfigureAwait(false);
        return Array.Empty<ChannelInfo>().ToList();
    }
}
