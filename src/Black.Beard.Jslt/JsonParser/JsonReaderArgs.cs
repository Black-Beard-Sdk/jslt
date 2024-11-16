using System;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

namespace Bb.JsonParser;

/// <summary>
/// Object to follow the parsing of the reader
/// </summary>
public class JsonReaderArgs : EventArgs
{

    public JsonReaderArgs(Progress progress, Action<IStore> action)
    {
        Progress = progress;
        _action = action;
    }

    /// <summary>
    /// The current item will be skipped
    /// </summary>
    public bool Skip { get; internal set; }

    /// <summary>
    /// The current item will be returned
    /// </summary>
    public bool ToReturn { get; internal set; }

    /// <summary>
    /// Progress cursor for the reader
    /// </summary>
    public Progress Progress { get; }

    /// <summary>
    /// Current path
    /// </summary>
    public string Path { get; internal set; }

    /// <summary>
    /// Current item
    /// </summary>
    public IStore Item { get; internal set; }

    /// <summary>
    /// Event type
    /// </summary>
    public EventEnum Event { get; internal set; }

    private readonly Action<IStore> _action;

    /// <summary>
    /// Strategy to follow
    /// </summary>
    public StrategyEnum Strategy { get; set; }

    /// <summary>
    /// Add a new item in the Reader
    /// </summary>
    /// <param name="token"></param>
    public void Append(IStore token)
    {
        _action?.Invoke(token);
    }

    /// <summary>
    /// Last removed item
    /// </summary>
    public IStore Removed { get; internal set; }

}



public enum StrategyEnum
{
    Ok,
    Skip,
    NotAddItem,
}
public enum EventEnum
{
    PreparingToRead,
    EndedToRead

}