﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Chaso.Push.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for PushOperations.
    /// </summary>
    public static partial class PushOperationsExtensions
    {
            /// <summary>
            /// Return all Channel listening by SignalR
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static object GetChannels(this IPushOperations operations)
            {
                return Task.Factory.StartNew(s => ((IPushOperations)s).GetChannelsAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Return all Channel listening by SignalR
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetChannelsAsync(this IPushOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetChannelsWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Notify a channel that an event was trigged
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='notify'>
            /// </param>
            public static object Notify(this IPushOperations operations, Notify notify)
            {
                return Task.Factory.StartNew(s => ((IPushOperations)s).NotifyAsync(notify), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Notify a channel that an event was trigged
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='notify'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> NotifyAsync(this IPushOperations operations, Notify notify, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.NotifyWithHttpMessagesAsync(notify, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
