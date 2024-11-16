using Bb.Json.Linq;
using System.Collections.Generic;

namespace Bb.JsonParser;

/// <summary>
/// Hierarchy value of the json model
/// </summary>
public struct StoreValue : IStore
{

    /// <summary>
    /// Initialize the value
    /// </summary>
    /// <param name="value"></param>
    public StoreValue(JValue value)
    {
        Name = null;
        JsonModel = value;
    }

    /// <summary>
    /// Dispose the value
    /// </summary>
    public void Dispose()
    {

    }

    /// <summary>
    /// Return true if the store should be skipped
    /// </summary>
    public bool Skip => false;

    /// <summary>
    /// Return true if the store should be keep
    /// </summary>
    public bool ToReturn => false;

    /// <summary>
    /// Return the name of the store
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Return the json model
    /// </summary>
    public JToken? JsonModel { get; }

    /// <summary>
    /// Return the type of the store
    /// </summary>
    public StoreType Type => StoreType.Value;

    /// <summary>
    /// Add a new item child to the store
    /// </summary>
    /// <param name="newItem"></param>
    public void Add(IStore newItem)
    {

    }

    /// <summary>
    /// Return the children of the store
    /// </summary>
    public IEnumerable<IStore> GetChilds
    {
        get
        {
            yield break;
        }
    }

    public bool PathToRemove => false;

    public string Path => string.Empty;

}
