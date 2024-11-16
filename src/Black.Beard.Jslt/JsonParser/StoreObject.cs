using Bb.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Bb.JsonParser;

/// <summary>
/// /// Hierarchy object of the json model
/// </summary>
public readonly struct StoreObject : IStore
{

    static StoreObject()
    {
        __array = new List<IStore>(0);
    }

    /// <summary>
    /// Initialize the object
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="toReturn"></param>
    /// <param name="name"></param>
    /// <param name="reader"></param>
    public StoreObject(bool skip, bool toReturn, string name, IStackStore reader, bool pathToRemove, string path)
    {
        _skip = skip;
        _toReturn = toReturn;
        Name = name;
        _parent = reader;
        if (!_skip)
            _array = new List<IStore>(100);
        else
            _array = __array;
        PathToRemove = pathToRemove;
        this.Path = path;
    }

    /// <summary>
    /// Dispose the object
    /// </summary>
    public void Dispose()
    {
        _parent?.Remove(this);
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
            List<JProperty> properties = new List<JProperty>();
            foreach (var item in _array)
            {
                var property = item.JsonModel as JProperty;
                if (property != null)
                    properties.Add(property);
            }
            return new JObject(properties);
        }
    }

    /// <summary>
    /// Return the type of the store
    /// </summary>
    public StoreType Type => StoreType.Object;

    /// <summary>
    /// Add a new item child to the store
    /// </summary>
    /// <param name="newItem"></param>
    public void Add(IStore newItem)
    {
        //if (!_skip)
            _array.Add(newItem);
    }

    /// <summary>
    /// Return the children of the store
    /// </summary>
    public IEnumerable<IStore> GetChilds => _array;

    public bool PathToRemove { get; }
    public string Path { get; }

    private readonly bool _skip;
    private readonly bool _toReturn;
    private readonly IStackStore _parent;
    private readonly List<IStore> _array;
    private static readonly List<IStore> __array;
}
