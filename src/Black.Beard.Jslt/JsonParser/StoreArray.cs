using Bb.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Bb.JsonParser;

/// <summary>
/// /// Hierarchy array of the json model
/// </summary>
public class StoreArray : IStore
{

    /// <summary>
    /// Initialize the array
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="toReturn"></param>
    /// <param name="name"></param>
    /// <param name="reader"></param>
    public StoreArray(bool skip, bool toReturn, string name, IStackStore reader)
    {
        _skip = skip;
        _toReturn = toReturn;
        Name = name;
        _parent = reader;
        if (!_skip)
            _array = new List<IStore>(100);

    }

    /// <summary>
    /// Dispose the array
    /// </summary>
    public void Dispose()
    {
        _parent?.Remove(this);
    }

    /// <summary>
    /// Return the type of the store
    /// </summary>
    public StoreType Type => StoreType.Array;

    /// <summary>
    /// Return true if the store should be skipped
    /// </summary>
    public bool Skip => _skip;

    /// <summary>
    /// Return true if the store should be keep
    /// </summary>
    public bool ToReturn => _toReturn;

    /// <summary>
    /// Return the json model
    /// </summary>
    public JToken? JsonModel
    {
        get
        {
            if (_skip)
                return null;
            return new JArray(_array.Select(c => c.JsonModel));
        }
    }

    /// <summary>
    /// Return the name of the store
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Return the children of the store
    /// </summary>
    public IEnumerable<IStore> GetChilds => _array;

    public void Add(IStore newItem)
    {
        if (!_skip)
            _array.Add(newItem);
    }

    private readonly bool _skip;
    private readonly bool _toReturn;
    private readonly IStackStore _parent;
    private readonly List<IStore> _array;

}
