// Ignore Spelling: Metrology

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Bb.Metrology
{


    /// <summary>
    /// Managing initialize activity source.
    /// </summary>
    public static class JsltActivityProvider
    {

        #region Create Activity

        /// <summary>
        /// Creates a new <see cref="Activity"/> object if there is any listener to the Activity, returns null otherwise.
        /// </summary>
        /// <param name="name">The operation name of the Activity</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any event listener.</returns>
        /// <remarks>
        /// If the Activity object is created, it will not start automatically. Callers need to call <see cref="Activity.Start()"/> to start it.
        /// </remarks>
        /// <exception cref="InvalidOperationException">If the Activity already exists.</exception>"
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Activity? CreateActivity(string name, ActivityKind kind)
        {

            if (!WithTelemetry)
                return null;

            var current = Source.CreateActivity(name, kind);
            WithTelemetry = current != null;

            return current;

        }

        /// <summary>
        /// Creates a new <see cref="Activity"/> object if there is any listener to the Activity, returns null otherwise.
        /// If the Activity object is created, it will not automatically start. Callers will need to call <see cref="Activity.Start()"/> to start it.
        /// </summary>
        /// <param name="name">The operation name of the Activity.</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <param name="parentContext">The parent <see cref="ActivityContext"/> object to initialize the created Activity object with.</param>
        /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
        /// <param name="links">The optional <see cref="ActivityLink"/> list to initialize the created Activity object with.</param>
        /// <param name="idFormat">The default Id format to use.</param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any listener.</returns>
        /// <remarks>
        /// If the Activity object is created, it will not start automatically. Callers need to call <see cref="Activity.Start()"/> to start it.
        /// </remarks>
        /// <exception cref="InvalidOperationException">If the Activity already exists.</exception>"
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Activity? CreateActivity(string name, ActivityKind kind, ActivityContext parentContext, IEnumerable<KeyValuePair<string, object?>>? tags = null, IEnumerable<ActivityLink>? links = null, ActivityIdFormat idFormat = ActivityIdFormat.Unknown)
        {

            if (!WithTelemetry)
                return null;

            var current = Source.CreateActivity(name, kind, parentContext, tags, links, idFormat);
            WithTelemetry = current != null;

            return current;

        }

        /// <summary>
        /// Creates a new <see cref="Activity"/> object if there is any listener to the Activity, returns null otherwise.
        /// </summary>
        /// <param name="name">The operation name of the Activity.</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <param name="parentId">The parent Id to initialize the created Activity object with.</param>
        /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
        /// <param name="links">The optional <see cref="ActivityLink"/> list to initialize the created Activity object with.</param>
        /// <param name="idFormat">The default Id format to use.</param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any listener.</returns>
        /// <remarks>
        /// If the Activity object is created, it will not start automatically. Callers need to call <see cref="Activity.Start()"/> to start it.
        /// </remarks>
        /// <exception cref="InvalidOperationException">If the Activity already exists.</exception>"
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Activity? CreateActivity(string name, ActivityKind kind, string parentId, IEnumerable<KeyValuePair<string, object?>>? tags = null, IEnumerable<ActivityLink>? links = null, ActivityIdFormat idFormat = ActivityIdFormat.Unknown)
        {

            if (!WithTelemetry)
                return null;

            var current = Source.CreateActivity(name, kind, parentId, tags, links, idFormat);
            WithTelemetry = current != null;

            return current;

        }

        /// <summary>
        /// Creates and starts a new <see cref="Activity"/> object if there is any listener to the Activity, returns null otherwise.
        /// </summary>
        /// <param name="name">The operation name of the Activity</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any event listener.</returns>
        /// <exception cref="InvalidOperationException">If the Activity already exists.</exception>"
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Activity? StartActivity([CallerMemberName] string name = "", ActivityKind kind = ActivityKind.Internal)
        {

            if (!WithTelemetry)
                return null;

            var current = Source.StartActivity(name, kind);
            WithTelemetry = current != null;

            return current;

        }

        /// <summary>
        /// Creates and starts a new <see cref="Activity"/> object if there is any listener to the Activity events, returns null otherwise.
        /// </summary>
        /// <param name="name">The operation name of the Activity.</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <param name="parentContext">The parent <see cref="ActivityContext"/> object to initialize the created Activity object with.</param>
        /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
        /// <param name="links">The optional <see cref="ActivityLink"/> list to initialize the created Activity object with.</param>
        /// <param name="startTime">The optional start timestamp to set on the created Activity object.</param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any listener.</returns>
        /// <exception cref="InvalidOperationException">If the Activity already exists.</exception>"
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Activity? StartActivity(string name, ActivityKind kind, ActivityContext parentContext, IEnumerable<KeyValuePair<string, object?>>? tags = null, IEnumerable<ActivityLink>? links = null, DateTimeOffset startTime = default)
        {

            if (!WithTelemetry)
                return null;

            var current = Source.StartActivity(name, kind, parentContext, tags, links, startTime);
            WithTelemetry = current != null;

            return current;

        }

        /// <summary>
        /// Creates and starts a new <see cref="Activity"/> object if there is any listener to the Activity events, returns null otherwise.
        /// </summary>
        /// <param name="name">The operation name of the Activity.</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <param name="parentId">The parent Id to initialize the created Activity object with.</param>
        /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
        /// <param name="links">The optional <see cref="ActivityLink"/> list to initialize the created Activity object with.</param>
        /// <param name="startTime">The optional start timestamp to set on the created Activity object.</param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any listener.</returns>
        /// <exception cref="InvalidOperationException">If the Activity already exists.</exception>"
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Activity? StartActivity(string name, ActivityKind kind, string parentId, IEnumerable<KeyValuePair<string, object?>>? tags = null, IEnumerable<ActivityLink>? links = null, DateTimeOffset startTime = default)
        {

            if (!WithTelemetry)
                return null;

            var current = Source.StartActivity(name, kind, parentId, tags, links, startTime);
            WithTelemetry = current != null;

            return current;

        }

        /// <summary>
        /// Creates and starts a new <see cref="Activity"/> object if there is any listener to the Activity events, returns null otherwise.
        /// </summary>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <param name="parentContext">The parent <see cref="ActivityContext"/> object to initialize the created Activity object with.</param>
        /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
        /// <param name="links">The optional <see cref="ActivityLink"/> list to initialize the created Activity object with.</param>
        /// <param name="startTime">The optional start timestamp to set on the created Activity object.</param>
        /// <param name="name">The operation name of the Activity.</param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any listener.</returns>
        /// <exception cref="InvalidOperationException">If the Activity already exists.</exception>"
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Activity? StartActivity(ActivityKind kind, ActivityContext parentContext = default, IEnumerable<KeyValuePair<string, object?>>? tags = null, IEnumerable<ActivityLink>? links = null, DateTimeOffset startTime = default, [CallerMemberName] string name = "")
        {

            if (!WithTelemetry)
                return null;

            var current = Source.StartActivity(kind, parentContext, tags, links, startTime, name);
            WithTelemetry = current != null;

            return current;

        }

        #endregion


        #region Append infos

        /// <summary>
        /// Gets the current Activity object for the current execution context.
        /// </summary>
        /// <param name="action">action to run with current activity</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Set(Action<Activity> action)
        {
            if (WithTelemetry && action != null)
            {
                var current = Activity.Current;
                if (current != null)
                    action(current);
            }
        }

        /// <summary>
        /// Add custom property to the current Activity object for the current execution context.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddProperty(string key, object value)
        {
            if (WithTelemetry)
            {
                var current = Activity.Current;
                if (current != null)
                    current.SetCustomProperty(key, value);
            }
        }

        /// <summary>
        /// Add custom property to the current Activity object for the current execution context.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddBaggage(string key, string value)
        {
            if (WithTelemetry)
            {
                var current = Activity.Current;
                if (current != null)
                    current.AddBaggage(key, value);
            }
        }

        /// <summary>
        /// Add custom event to the current Activity object for the current execution context.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="tags"></param>
        public static void AddEvent(string eventName, params (string key, string value)[] tags)
        {
            if (WithTelemetry)
            {
                var current = Activity.Current;
                if (current != null)
                {

                    var _tags = new ActivityTagsCollection();

                    foreach (var item in tags)
                        _tags.Add(item.key, item.value);

                    current.AddEvent(new ActivityEvent(eventName, default, _tags));

                }
            }
        }

        #endregion Append infos

        /// <summary>
        /// Initializes the <see cref="ActivitySource"/> object.
        /// </summary>
        static JsltActivityProvider()
        {
            Name = nameof(JsltActivityProvider);
            Name = Name.Substring(0, Name.Length - "Provider".Length);
            Version = typeof(JsltActivityProvider).Assembly.GetName().Version;
            Source = new ActivitySource(Name, Version?.ToString());
        }

        internal static ActivitySource Source;
        public static readonly string Name;
        public static readonly Version Version;
        public static bool WithTelemetry = true;

    }

}
