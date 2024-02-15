// using System.Reflection;
//
// namespace Jellyfin.Plugin.MediathekViewWeb.PVR;
//
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Http;
// using System.Threading;
// using System.Threading.Tasks;
// using MediaBrowser.Controller.LiveTv;
// using MediaBrowser.Model.Dto;
// using Microsoft.Extensions.Logging;
//
// /// <author email="dersyth@gmail.com">Sythelux Rikd.</author>
// /// <summary>
// /// Class LiveTvService.
// /// </summary>
// public class LiveTvService : ILiveTvService
// {
//     private readonly IHttpClientFactory httpClientFactory;
//     private readonly ILogger<LiveTvService> logger;
//     private DateTime lastUpdatedSidDateTime;
//
//     /// <summary>Initializes a new instance of the <see cref="LiveTvService"/> class.</summary>
//     /// <param name="httpClientFactory">Http Factory from Jellyfin.</param>
//     /// <param name="logger">Logger from Jellyfin.</param>
//     /// <param name="liveTvManager">liveTv Manager.</param>
//     public LiveTvService(IHttpClientFactory httpClientFactory, ILogger<LiveTvService> logger, ILiveTvManager liveTvManager)
//     {
//         logger.LogCritical("init: " + liveTvManager);
//         this.httpClientFactory = httpClientFactory;
//         this.logger = logger;
//         this.LastUpdatedSidDateTime = DateTime.UtcNow;
//     }
//
//     /// <summary>
//     /// Gets or sets the Last Updated Time.
//     /// </summary>
//     public DateTime LastUpdatedSidDateTime
//     {
//         get { return this.lastUpdatedSidDateTime; }
//         set { this.lastUpdatedSidDateTime = value; }
//     }
//
//     /// <summary>
//     /// Gets Name of Service.
//     /// </summary>
//     public string Name => "Mediathek View Web";
//
//     /// <summary>
//     /// Gets Homepage.
//     /// </summary>
//     public string HomePageUrl => "jellyfin-plugin-mediathekviewweb-pvr.sythelux.github.io";
//
//     /// <inheritdoc/>
//     public async Task<IEnumerable<ChannelInfo>> GetChannelsAsync(CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//         return Array.Empty<ChannelInfo>();
//     }
//
//     /// <inheritdoc/>
//     public async Task CancelTimerAsync(string timerId, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//     }
//
//     /// <inheritdoc/>
//     public async Task CancelSeriesTimerAsync(string timerId, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//     }
//
//     /// <inheritdoc/>
//     public async Task CreateTimerAsync(TimerInfo info, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//     }
//
//     /// <inheritdoc/>
//     public async Task CreateSeriesTimerAsync(SeriesTimerInfo info, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//     }
//
//     /// <inheritdoc/>
//     public async Task UpdateTimerAsync(TimerInfo updatedTimer, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//     }
//
//     /// <inheritdoc/>
//     public async Task UpdateSeriesTimerAsync(SeriesTimerInfo info, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//     }
//
//     /// <inheritdoc/>
//     public async Task<IEnumerable<TimerInfo>> GetTimersAsync(CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//         return Array.Empty<TimerInfo>();
//     }
//
//     /// <inheritdoc/>
//     public async Task<SeriesTimerInfo> GetNewTimerDefaultsAsync(CancellationToken cancellationToken, ProgramInfo program)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//         return new SeriesTimerInfo();
//     }
//
//     /// <inheritdoc/>
//     public async Task<IEnumerable<SeriesTimerInfo>> GetSeriesTimersAsync(CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//         return Array.Empty<SeriesTimerInfo>();
//     }
//
//     /// <inheritdoc/>
//     public async Task<IEnumerable<ProgramInfo>> GetProgramsAsync(string channelId, DateTime startDateUtc, DateTime endDateUtc, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//         return Array.Empty<ProgramInfo>();
//     }
//
//     /// <inheritdoc/>
//     public async Task<MediaSourceInfo> GetChannelStream(string channelId, string streamId, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//         return new MediaSourceInfo();
//     }
//
//     /// <inheritdoc/>
//     public async Task<List<MediaSourceInfo>> GetChannelStreamMediaSources(string channelId, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//         return Array.Empty<MediaSourceInfo>().ToList();
//     }
//
//     /// <inheritdoc/>
//     public async Task CloseLiveStream(string id, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//     }
//
//     /// <inheritdoc/>
//     public async Task RecordLiveStream(string id, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//     }
//
//     /// <inheritdoc/>
//     public async Task ResetTuner(string id, CancellationToken cancellationToken)
//     {
//         logger.LogCritical(MethodBase.GetCurrentMethod() + string.Empty);
//         await Task.CompletedTask.ConfigureAwait(false);
//     }
// }
