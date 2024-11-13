using Bb.Json.Linq;
using System;
using System.Collections.Generic;

namespace Bb.JsonParser;

/// <summary>
/// Generic interface for the hierarchy object of the json model
/// </summary>
public interface IStore : IDisposable
{

    /// <summary>
    /// Return the json model
    /// </summary>
    JToken? JsonModel { get; }

    /// <summary>
    /// Add a new item child to the hierarchy
    /// </summary>
    /// <param name="newItem"></param>
    void Add(IStore newItem);

    /// <summary>
    /// Return the type of the hierarchy
    /// </summary>
    StoreType Type { get; }

    /// <summary>
    /// Return the name of the hierarchy
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Return true if the hierarchy must be skipped
    /// </summary>
    bool Skip { get; }

    /// <summary>
    /// Return true if the hierarchy must be keep
    /// </summary>
    bool ToReturn { get; }

    /// <summary>
    /// Return the list of children
    /// </summary>
    IEnumerable<IStore> GetChilds { get; }



}

public enum StoreType
{
    Object,
    Array,
    Property,
    Value
}

