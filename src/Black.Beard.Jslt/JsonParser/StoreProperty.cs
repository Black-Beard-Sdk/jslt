using Bb.Json.Linq;
using System.Collections.Generic;

namespace Bb.JsonParser;

/// <summary>
/// /// Hierarchy property of the json model
/// </summary>
public struct StoreProperty : IStore
{

    /// <summary>
    /// Initialize the property
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="toReturn"></param>
    /// <param name="name"></param>
    /// <param name="reader"></param>
    public StoreProperty(bool skip, bool toReturn, string name, IStackStore reader, bool pathToRemove, string path)
    {
        _value = null;
        PathToRemove = pathToRemove;
        Name = name.Substring(1);
        _skip = skip;
        _toReturn = toReturn;
        _parent = reader;
        this.Path = path;
    }

    /// <summary>
    /// Dispose the property
    /// </summary>
    public void Dispose()
    {
        _parent?.Remove(this);
    }

    /// <summary>
    /// Return the name of the store
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Return the json model
    /// </summary>
    public JToken? JsonModel
    {
        get
        {
            //if (_skip)
            //    return null;
            return new JProperty(Name, _value?.JsonModel);
        }
    }

    /// <summary>
    /// Return true if the store should be skipped
    /// </summary>
    public bool Skip => _skip;

    /// <summary>
    /// Return true if the store should be keep
    /// </summary>
    public bool ToReturn => _toReturn;

    /// <summary>
    /// Return the type of the store
    /// </summary>
    public StoreType Type => StoreType.Property;

    /// <summary>
    /// Return the children of the store
    /// </summary>
    public IEnumerable<IStore> GetChilds
    {
        get
        {
            yield return _value;
        }
    }

    /// <summary>
    /// Return the value of the property
    /// </summary>
    public IStore Value => _value;

    public bool PathToRemove { get; }

    /// <summary>
    /// Add a new item child to the store
    /// </summary>
    public void Add(IStore newItem)
    {
        if (!_skip)
            _value = newItem;

    }

    private readonly bool _skip;
    private readonly bool _toReturn;
    private readonly IStackStore _parent;

    public string Path { get; }

    private IStore _value;
}
