using System;
using System.Collections.Generic;

namespace Bb.JsonParser;

/// <summary>
/// Object to follow the parsing of the reader
/// </summary>
public class JsonReaderArgs : EventArgs
{

    public JsonReaderArgs(string path, IStore model, EventEnum e, Progress progress)
    {
        Progress = progress;
        Path = path;
        Item = model;
        Event = e;
        _array = new List<IStore>(20);
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
    public string Path { get; }

    /// <summary>
    /// Current item
    /// </summary>
    public IStore Item { get; }

    /// <summary>
    /// Event type
    /// </summary>
    public EventEnum Event { get; }

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
        _array.Add(token);
    }

    /// <summary>
    /// Number of items in the block
    /// </summary>
    public int Count => _array.Count;

    /// <summary>
    /// Items in the block
    /// </summary>
    internal IEnumerable<IStore> Items => _array;

    /// <summary>
    /// Last removed item
    /// </summary>
    public IStore Removed { get; internal set; }

    private readonly List<IStore> _array;

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