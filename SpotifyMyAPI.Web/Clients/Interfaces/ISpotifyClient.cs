﻿using System.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyMyAPI.Web.Http;

namespace SpotifyMyAPI.Web
{
    public interface ISpotifyClient
    {
        /// <summary>
        /// The default paginator used by the Paginator methods
        /// </summary>
        /// <value></value>
        IPaginator DefaultPaginator { get; }

        /// <summary>
        /// Operations related to Spotify User Profiles
        /// </summary>
        /// <value></value>
        IUserProfileClient UserProfile { get; }

        /// <summary>
        /// Operations related to Spotify Search
        /// </summary>
        /// <value></value>
        ISearchClient Search { get; }

        /// <summary>
        /// Operations related to Spotify Artists
        /// </summary>
        /// <value></value>
        IArtistsClient Artists { get; }

        /// <summary>
        /// Returns the last response received by an API call.
        /// </summary>
        /// <value></value>
        IResponse? LastResponse { get; }

        /// <summary>
        /// Fetches all pages and returns them grouped in a list.
        /// The default paginator will fetch all available resources without a delay between requests.
        /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
        /// </summary>
        /// <param name="firstPage">The first page, will be included in the output list!</param>
        /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
        /// <typeparam name="T">The Paging-Type</typeparam>
        /// <returns>A list containing all fetched pages</returns>
        Task<IList<T>> PaginateAll<T>(IPaginatable<T> firstPage, IPaginator? paginator = default!);

        /// <summary>
        /// Fetches all pages and returns them grouped in a list.
        /// Some responses (e.g search response) have the pagination nested in a JSON Property.
        /// To workaround this limitation, the mapper is required and needs to point to the correct next pagination.
        /// The default paginator will fetch all available resources without a delay between requests.
        /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
        /// </summary>
        /// <param name="firstPage">A first page, will be included in the output list!</param>
        /// <param name="mapper">A function which maps response objects to the next paging object</param>
        /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
        /// <typeparam name="T">The Paging-Type</typeparam>
        /// <typeparam name="TNext">The Response-Type</typeparam>
        /// <returns>A list containing all fetched pages</returns>
        Task<IList<T>> PaginateAll<T, TNext>(
          IPaginatable<T, TNext> firstPage,
          Func<TNext, IPaginatable<T, TNext>> mapper,
          IPaginator? paginator = default!
        );

#if NETSTANDARD2_1
        /// <summary>
        /// Paginate through pages by using IAsyncEnumerable, introduced in C# 8
        /// The default paginator will fetch all available resources without a delay between requests.
        /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
        /// </summary>
        /// <param name="firstPage">A first page, will be included in the output list!</param>
        /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
        /// <param name="cancellationToken">An optional Cancellation Token</param>
        /// <typeparam name="T">The Paging-Type</typeparam>
        /// <returns>An iterable IAsyncEnumerable</returns>
        IAsyncEnumerable<T> Paginate<T>(
          IPaginatable<T> firstPage,
          IPaginator? paginator = default!,
          CancellationToken cancellationToken = default!
        );

        /// <summary>
        /// Paginate through pages by using IAsyncEnumerable, introduced in C# 8
        /// Some responses (e.g search response) have the pagination nested in a JSON Property.
        /// To workaround this limitation, the mapper is required and needs to point to the correct next pagination.
        /// The default paginator will fetch all available resources without a delay between requests.
        /// This can drain your request limit quite fast, so consider using a custom paginator with delays.
        /// </summary>
        /// <param name="firstPage">A first page, will be included in the output list!</param>
        /// <param name="mapper">A function which maps response objects to the next paging object</param>
        /// <param name="paginator">Optional. If not supplied, DefaultPaginator will be used</param>
        /// <param name="cancellationToken">An optional Cancellation Token</param>
        /// <typeparam name="T">The Paging-Type</typeparam>
        /// <typeparam name="TNext">The Response-Type</typeparam>
        /// <returns></returns>
        IAsyncEnumerable<T> Paginate<T, TNext>(
          IPaginatable<T, TNext> firstPage,
          Func<TNext, IPaginatable<T, TNext>> mapper,
          IPaginator? paginator = default!,
          CancellationToken cancellationToken = default!
        );

#endif
    }
}