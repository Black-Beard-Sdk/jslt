using Bb.JPaths;
using Bb.Json;
using Bb.Json.Linq;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bb.JsonParser;

/// <summary>
/// Big json parser
/// </summary>
public class BigJsonReader : IDisposable, IStackStore, IEnumerable<IStore>
{


    #region ctors

    /// <summary>
    /// initialize a new instance of <see cref="BigJsonReader"/>
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
        _slicerFilterPath = jpath;
        _file = file;
        _path = new List<string>();
        _stack = new Stack<IStore>();
    }

    #endregion ctors


    #region Parser

    /// <summary>
    /// Parse the json file
    /// </summary>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public void Parse(Action<IStore> action)
    {

        if (this._stateRunning != StatusEnum.NotStarted)
            throw new InvalidOperationException("The reader is already ran");

        Prepare(action);

        this._stateRunning = StatusEnum.Running;

        try
        {
            if (_reader.Read())
            {

                var type = _reader.TokenType;

                switch (type)
                {

                    case JsonToken.StartObject:
                        LoadObject("$", true);
                        break;

                    case JsonToken.StartArray:
                        LoadArray("$", true);
                        break;

                    case JsonToken.Comment:
                        break;

                    case JsonToken.Raw:
                    case JsonToken.Integer:
                    case JsonToken.Float:
                    case JsonToken.String:
                    case JsonToken.Boolean:
                    case JsonToken.Date:
                    case JsonToken.Bytes:
                    case JsonToken.Null:
                        var v = _reader.Value;
                        _arg.Append(new StoreValue(new JValue(v)));
                        break;

                    case JsonToken.EndConstructor:
                    case JsonToken.StartConstructor:
                    case JsonToken.EndObject:
                    case JsonToken.EndArray:
                    case JsonToken.PropertyName:
                    case JsonToken.None:
                    case JsonToken.Undefined:
                    default:
                        break;

                }

            }

            this._stateRunning = StatusEnum.Ended;

        }
        catch (Exception ex)
        {
            this._stateRunning = StatusEnum.Failed;
            throw;
        }
        finally
        {
            Dispose();
        }

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Prepare(Action<IStore> action)
    {
        _file.Refresh();
        if (!_file.Exists)
            throw new FileNotFoundException("File not found", _file.FullName);

        _sr = new StreamReader(_file.FullName);
        _reader = new JsonTextReader(_sr);
        _progress = new Progress(_file.Length, _reader);
        _arg = new JsonReaderArgs(_progress, action);
    }

    internal void LoadObject(string name, bool evaluateNextSegments)
    {

        if (_current != null && _current.Skip)
            Skip(JsonToken.EndObject);

        using (var current = AppendObject(name))
            if (current.Skip)
                Skip(JsonToken.EndObject);

            else

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
                            LoadProperty("." + propertyName, evaluateNextSegments);
                            break;

                        default:
                            break;

                    }

                }

    }

    internal void LoadArray(string name, bool evaluateNextSegments)
    {

        int index = -1;

        using (var current = AppendArray(name))
            if (current.Skip)
                Skip(JsonToken.EndArray);

            else
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
                            LoadObject("[" + index + "]", evaluateNextSegments);
                            break;

                        case JsonToken.StartArray:
                            LoadArray("[" + index + "]", evaluateNextSegments);
                            break;

                        case JsonToken.Integer:
                        case JsonToken.Float:
                        case JsonToken.String:
                        case JsonToken.Boolean:
                        case JsonToken.Null:
                        case JsonToken.Date:
                        case JsonToken.Raw:
                        case JsonToken.Bytes:
                            var v = _reader.Value;
                            current.Add(new StoreValue(new JValue(v)));
                            break;

                        default:
                            break;
                    }


                }

    }

    internal void LoadProperty(string propertyName, bool evaluateNextSegments)
    {

        bool m = false;

        if (_reader.Read())
        {

            var type = _reader.TokenType;
            _progress.Append();
            var v = _reader.Value;

            using (var current = AppendProperty(propertyName))
                switch (type)
                {

                    case JsonToken.Null:
                    case JsonToken.String:
                    case JsonToken.Boolean:
                    case JsonToken.Float:
                    case JsonToken.Integer:
                    case JsonToken.Date:
                        if (!current.Skip)
                            current.Add(new StoreValue(new JValue(v)));
                        break;

                    case JsonToken.Bytes:
                        break;

                    case JsonToken.Raw:
                        break;

                    case JsonToken.StartObject:
                        if (current.Skip)
                            Skip(JsonToken.EndObject);
                        else
                            LoadObject(string.Empty, evaluateNextSegments);
                        break;

                    case JsonToken.StartArray:
                        if (current.Skip)
                            Skip(JsonToken.EndArray);
                        else
                            LoadArray(string.Empty, evaluateNextSegments);
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

    private void Skip(JsonToken end)
    {
        while (_reader.Read())
        {

            var type = _reader.TokenType;

            if (type == end)
                return;

            switch (type)
            {

                case JsonToken.StartObject:
                    Skip(JsonToken.EndObject);
                    break;

                case JsonToken.StartArray:
                    Skip(JsonToken.EndArray);
                    break;

                case JsonToken.PropertyName:
                    SkipValue();
                    break;

                case JsonToken.Null:
                case JsonToken.Raw:
                case JsonToken.Integer:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Boolean:
                case JsonToken.None:
                case JsonToken.Date:
                case JsonToken.Bytes:
                    return;

                case JsonToken.StartConstructor:
                    Skip(JsonToken.EndConstructor);
                    break;

                case JsonToken.Undefined:
                case JsonToken.Comment:
                default:
                    break;

            }

        }

    }

    private void SkipValue()
    {

        if (_reader.Read())
        {
            var type = _reader.TokenType;
            switch (type)
            {

                case JsonToken.StartObject:
                    Skip(JsonToken.EndObject);
                    break;

                case JsonToken.StartArray:
                    Skip(JsonToken.EndArray);
                    break;

                case JsonToken.Null:
                case JsonToken.Raw:
                case JsonToken.Integer:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Boolean:
                case JsonToken.None:
                case JsonToken.Date:
                case JsonToken.Bytes:
                    return;

                case JsonToken.StartConstructor:
                    Skip(JsonToken.EndConstructor);
                    break;

                case JsonToken.PropertyName:
                case JsonToken.Undefined:
                case JsonToken.Comment:
                default:
                    break;

            }

        }

    }



    #region internal

    private StrategyEnum OnBefore(bool skip, bool toReturn)
    {

        if (OnObject == null)
            return StrategyEnum.Ok;

        if (!skip)
        {

            _arg.Event = EventEnum.PreparingToRead;
            _arg.Path = _pathString;
            _arg.Item = _current;
            _arg.Skip = skip;
            _arg.ToReturn = toReturn;
            _arg.Strategy = StrategyEnum.Ok;

            OnBefore(_arg);
            if (OnObject != null)
                OnObject.Invoke(this, _arg);

            return _arg.Strategy;

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

            _arg.Event = EventEnum.EndedToRead;
            _arg.Path = _pathString;
            _arg.Item = _current;
            _arg.Removed = removedStore;
            _arg.ToReturn = _current.ToReturn;
            _arg.Strategy = StrategyEnum.Ok;

            if (OnObject != null)
                OnObject.Invoke(this, _arg);

            OnAfter(_arg);

            return _arg.Strategy;

        }

        return StrategyEnum.Skip;

    }

    protected virtual void OnAfter(JsonReaderArgs arg)
    {
        if (arg.Removed.ToReturn)
            arg.Append(arg.Removed);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private IStore AppendObject(string name)
    {

        bool skipNextReading = _current != null && _current.Skip;
        bool toReturn = false;
        _path.Add(name);
        _pathString = string.Concat(_path);

        if (!skipNextReading)
        {

            var t = _slicerFilterPath == null && _stack.Count == 0;

            if (_slicerFilterPath != null)
            {
                if (!t)
                    toReturn = EvaluatePath(_pathString);
            }
            else if (t)
                toReturn = true;

            skipNextReading |= OnBefore(skipNextReading, toReturn) == StrategyEnum.Skip;

        }

        return Append(new StoreObject(skipNextReading, toReturn, name, this, true, _pathString));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private IStore AppendArray(string name)
    {

        bool skipNextReading = _current != null && _current.Skip;

        bool pathToRemove = false;
        bool toReturn = false;
        var t = _slicerFilterPath == null && _stack.Count == 0;
        if (name == "[")
        {
            if (!t)
                toReturn = EvaluatePath(_pathString + "[0]");
        }
        else
        {
            _path.Add(name);
            _pathString = string.Concat(_path);
            pathToRemove = true;
            if (!t)
                toReturn = EvaluatePath(_pathString);
        }

        if (t)
            toReturn = true;

        if (!skipNextReading)
            skipNextReading |= OnBefore(skipNextReading, toReturn) == StrategyEnum.Skip;

        return Append(new StoreArray(skipNextReading, toReturn, name, this, pathToRemove, _pathString));

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private IStore AppendProperty(string name)
    {

        bool skipNextReading = _current != null && _current.Skip;

        bool toReturn = false;
        _path.Add(name);
        _pathString = string.Concat(_path);

        if (!skipNextReading)
        {
            var t = _slicerFilterPath == null && _stack.Count == 0;
            if (!t && _slicerFilterPath != null)
                toReturn = EvaluatePath(_pathString);

            skipNextReading |= OnBefore(skipNextReading, toReturn) == StrategyEnum.Skip;

        }

        return Append(new StoreProperty(skipNextReading, toReturn, name, this, true, _pathString));

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool EvaluatePath(string path)
    {
        return _slicerFilterPath != null && _slicerFilterPath.TryToMatch(path);
    }

    private IStore Append(IStore newItem)
    {

        if (_current != null && !newItem.Skip)
            _current.Add(newItem);

        _stack.Push(newItem);
        _current = newItem;

        if (_base == null)
            _base = newItem;

        return newItem;

    }

    #endregion internal

    #endregion Parser



    /// <summary>
    /// Object to follow the progressive reading
    /// </summary>
    public Progress Progress => _progress;

    /// <summary>
    /// Event raised when a new object is read
    /// </summary>
    public event EventHandler<JsonReaderArgs> OnObject;

    public StatusEnum StateRunning => _stateRunning;


    #region Implementation interfaces

    public IEnumerator<IStore> GetEnumerator()
    {
        return new StoreEnumerator<IStore>(this, c => c);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new StoreEnumerator<IStore>(this, c => c);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _reader.Close();
                _sr.Close();
                _sr.Dispose();
            }

            disposedValue = true;
        }
    }

    // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
    // ~BigJsonReader()
    // {
    //     // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
    //     Dispose(disposing: false);
    // }

    /// <summary>
    /// Dispose method
    /// </summary>
    public void Dispose()
    {
        // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    void IStackStore.Remove(IStore storeBase)
    {

        IStore last = null;

        while (last != _current)
        {
            last = _stack.Pop();
            if (storeBase.PathToRemove)
            {
                if (_path.Count > 0)
                    _path.RemoveAt(_path.Count - 1);
            }
        }

        if (_stack.Count > 0)
            _current = _stack.Peek();

        if (!storeBase.Skip)
            OnAfter(last);

        _pathString = string.Concat(_path);

    }

    #endregion Implementation interfaces

    private readonly Stack<IStore> _stack;
    private readonly FileInfo _file;
    private IStore _current;
    private IStore _base;
    private List<string> _path;
    private string _pathString;
    private JsonPath _slicerFilterPath;
    private JsonTextReader _reader;
    private Progress _progress;
    private StreamReader _sr;
    private JsonReaderArgs _arg;
    private StatusEnum _stateRunning;
    private bool disposedValue;

}

public enum StatusEnum
{
    NotStarted,
    Running,
    Failed,
    Ended
}
