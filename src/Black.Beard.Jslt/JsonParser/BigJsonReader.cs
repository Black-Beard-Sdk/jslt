using Bb.JPaths;
using Oldtonsoft.Json;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bb.JsonParser;

/// <summary>
/// Big json parser
/// </summary>
public class BigJsonReader : IDisposable, IStackStore
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <param name="jpath"></param>
    public BigJsonReader(string path, JsonPath? jpath = null)
        : this(new FileInfo(path), jpath)
    {

    }

    /// <summary>
    /// Initialize a new instance of <see cref="BigJsonReader"/>
    /// </summary>
    /// <param name="file"></param>
    /// <param name="jpath"></param>
    public BigJsonReader(FileInfo file, JsonPath? jpath = null)
    {
        _filterPath = jpath;
        _file = file;
        _path = new List<string>();
        _stack = new Stack<IStore>();
        _toPush = new Queue<IStore>(20);
    }

    /// <summary>
    /// Iterate on the json results
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IStore> Read()
    {

        var task = Task.Run(Parse);

        while (!task.IsCompleted || _toPush.Count > 0)
            lock (_lock)
                if (_toPush.Count > 0)
                    yield return _toPush.Dequeue();

    }

    /// <summary>
    /// Parse the json file
    /// </summary>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public IEnumerable<IStore> Parse()
    {

        _file.Refresh();
        if (!_file.Exists)
            throw new FileNotFoundException("File not found", _file.FullName);

        _sr = new StreamReader(_file.FullName);
        _reader = new JsonTextReader(_sr);

        _progress = new Progress(_file.Length, _reader);

        if (_reader.Read())
        {

            var type = _reader.TokenType;

            switch (type)
            {

                case JsonToken.StartObject:
                    LoadObject("$", false, true);
                    break;

                case JsonToken.StartArray:
                    LoadArray("$", false, true);
                    break;

                case JsonToken.Comment:
                    break;

                case JsonToken.EndConstructor:
                case JsonToken.StartConstructor:
                case JsonToken.EndObject:
                case JsonToken.EndArray:
                    break;

                case JsonToken.PropertyName:
                case JsonToken.Raw:
                case JsonToken.Integer:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Boolean:
                case JsonToken.Date:
                case JsonToken.Bytes:
                case JsonToken.Null:
                    break;

                case JsonToken.None:
                case JsonToken.Undefined:
                default:
                    break;

            }

        }

        if (_filterPath == null)
            yield return _current;

        else if (_toPush.Count > 0)
            foreach (var item in _toPush)
                yield return item;

        else
            yield return _current;

    }

    internal void LoadObject(string name, bool skipNextReading, bool evaluateNextSegments)
    {

        using (var current = AppendObject(name, skipNextReading))
            while (_reader.Read())
            {

                var type = _reader.TokenType;
                _progress.Append();

                switch (type)
                {

                    case JsonToken.EndObject:
                        return;

                    case JsonToken.PropertyName:
                        var propertyName = _reader.Value.ToString();
                        LoadProperty("." + propertyName, skipNextReading, evaluateNextSegments);
                        break;

                    case JsonToken.EndConstructor:
                    case JsonToken.StartConstructor:
                        break;

                    case JsonToken.Null:
                    case JsonToken.Raw:
                    case JsonToken.Integer:
                    case JsonToken.Float:
                    case JsonToken.String:
                    case JsonToken.Boolean:
                    case JsonToken.None:
                    case JsonToken.StartObject:
                    case JsonToken.StartArray:
                    case JsonToken.EndArray:
                    case JsonToken.Date:
                    case JsonToken.Bytes:
                        break;

                    case JsonToken.Undefined:
                    case JsonToken.Comment:
                    default:
                        break;

                }

            }

    }

    internal void LoadArray(string name, bool skipNextReading, bool evaluateNextSegments)
    {

        int index = -1;

        using (var current = AppendArray(name, skipNextReading))
            while (_reader.Read())
            {
                index++;
                var type = _reader.TokenType;
                _progress.Append();

                switch (type)
                {

                    case JsonToken.EndArray:
                        return;

                    case JsonToken.StartObject:
                        LoadObject("[" + index + "]", skipNextReading, evaluateNextSegments);
                        break;

                    case JsonToken.StartArray:
                        LoadArray("[" + index + "]", skipNextReading, evaluateNextSegments);
                        break;

                    case JsonToken.Integer:
                    case JsonToken.Float:
                    case JsonToken.String:
                    case JsonToken.Boolean:
                    case JsonToken.Null:
                    case JsonToken.Date:
                    case JsonToken.Bytes:
                        if (!skipNextReading)
                        {
                            var v = _reader.Value;
                            current.Add(new StoreValue(new JValue(v)));
                        }
                        break;

                    case JsonToken.Raw:
                        break;

                    case JsonToken.StartConstructor:
                    case JsonToken.PropertyName:
                    case JsonToken.EndObject:
                    case JsonToken.EndConstructor:
                        break;

                    case JsonToken.Comment:
                    case JsonToken.None:
                    case JsonToken.Undefined:
                    default:
                        break;
                }


            }

    }

    internal void LoadProperty(string propertyName, bool skipNextReading, bool evaluateNextSegments)
    {

        bool m = false;

        if (_reader.Read())
        {

            var type = _reader.TokenType;
            _progress.Append();
            var v = _reader.Value;

            using (var current = AppendProperty(propertyName, skipNextReading))
                switch (type)
                {

                    case JsonToken.Null:
                    case JsonToken.String:
                    case JsonToken.Boolean:
                    case JsonToken.Float:
                    case JsonToken.Integer:
                    case JsonToken.Date:
                        if (!skipNextReading)
                            current.Add(new StoreValue(new JValue(v)));
                        break;

                    case JsonToken.Bytes:
                        break;

                    case JsonToken.Raw:
                        break;

                    case JsonToken.StartObject:
                        LoadObject(string.Empty, skipNextReading, evaluateNextSegments);
                        break;

                    case JsonToken.StartArray:
                        LoadArray(string.Empty, skipNextReading, evaluateNextSegments);
                        break;

                    case JsonToken.StartConstructor:
                        break;

                    case JsonToken.Comment:
                    case JsonToken.None:
                    case JsonToken.PropertyName:
                    case JsonToken.EndObject:
                    case JsonToken.EndArray:
                    case JsonToken.EndConstructor:
                    case JsonToken.Undefined:
                    default:
                        break;
                }

        }

    }

    private StrategyEnum OnBefore(bool skip, bool toReturn)
    {

        if (OnObject == null)
            return StrategyEnum.Ok;

        if (!skip)
        {

            var arg = new JsonReaderArgs(_pathString, _current, EventEnum.PreparingToRead, _progress)
            {
                Skip = skip,
                ToReturn = toReturn
            };

            if (OnObject != null)
                OnObject.Invoke(this, arg);

            else
                OnBefore(arg);

            if (arg.Count > 0)
                lock (_lock)
                    foreach (var item in arg.Items)
                        _toPush.Enqueue(item);

            return arg.Strategy;

        }

        return StrategyEnum.Skip;

    }

    protected virtual void OnBefore(JsonReaderArgs arg)
    {

    }

    private StrategyEnum OnAfter(IStore removedStore)
    {

        if (_current == null)
            return StrategyEnum.Ok;

        if (!_current.Skip)
        {

            var arg = new JsonReaderArgs(_pathString, _current, EventEnum.EndedToRead, _progress)
            {
                Removed = removedStore
            };

            if (OnObject != null)
                OnObject.Invoke(this, arg);
            else
                OnAfter(arg);

            if (arg.Count > 0)
                lock (_lock)
                    foreach (var item in arg.Items)
                        _toPush.Enqueue(item);

            return arg.Strategy;

        }

        return StrategyEnum.Skip;

    }

    protected virtual void OnAfter(JsonReaderArgs arg)
    {

    }

    /// <summary>
    /// Object to follow the progressive reading
    /// </summary>
    public Progress Progress => _progress;

    /// <summary>
    /// Event raised when a new object is read
    /// </summary>
    public event EventHandler<JsonReaderArgs> OnObject;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private IStore AppendObject(string name, bool skipNextReading)
    {

        _path.Add(name);
        bool toReturn = EvaluatePath(_pathString = string.Concat(_path));

        if (!skipNextReading)
            skipNextReading |= OnBefore(skipNextReading, toReturn) == StrategyEnum.Skip;

        return Append(new StoreObject(skipNextReading, toReturn, name, this));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private IStore AppendArray(string name, bool skipNextReading)
    {

        bool toReturn = false;
        if (name != "[")
        {
            _path.Add(name);
            toReturn = EvaluatePath(_pathString = string.Concat(_path));
        }
        else
            toReturn = EvaluatePath(_pathString + "[0]");

        if (!skipNextReading)
            skipNextReading |= OnBefore(skipNextReading, toReturn) == StrategyEnum.Skip;

        return Append(new StoreArray(skipNextReading, toReturn, name, this));

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private IStore AppendProperty(string name, bool skipNextReading)
    {

        _path.Add(name);
        var toReturn = EvaluatePath(_pathString = string.Concat(_path));

        if (!skipNextReading)
            skipNextReading |= OnBefore(skipNextReading, toReturn) == StrategyEnum.Skip;

        return Append(new StoreProperty(skipNextReading, toReturn, name, this));

    }

    private bool EvaluatePath(string path)
    {

        if (_filterPath != null && _filterPath.TryToMatch(path))
            return true;

        return false;

    }

    private IStore Append(IStore newItem)
    {

        if (_current != null)
            _current.Add(newItem);

        _stack.Push(newItem);
        _current = newItem;

        if (_base == null)
            _base = newItem;

        return newItem;

    }

    /// <summary>
    /// Dispose method
    /// </summary>
    public void Dispose()
    {
        _reader.Close();
        _sr.Close();
        _sr.Dispose();
    }

    void IStackStore.Remove(IStore storeBase)
    {

        IStore last = null;
        while (last != _current)
        {
            last = _stack.Pop();
            if (_path.Count > 0)
                _path.RemoveAt(_path.Count - 1);
        }

        if (_stack.Count > 0)
            _current = _stack.Peek();

        if (!storeBase.Skip)
            OnAfter(last);

        _pathString = string.Concat(_path);

    }

    private readonly Stack<IStore> _stack;
    private readonly FileInfo _file;
    private IStore _current;
    private IStore _base;
    private List<string> _path;
    private string _pathString;
    private Queue<IStore> _toPush;
    private JsonPath _filterPath;

    private volatile object _lock = new object();

    private JsonTextReader _reader;
    private Progress _progress;
    private StreamReader _sr;

}
