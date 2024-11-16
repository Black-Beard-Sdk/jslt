using Bb.JPaths;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Bb.JsonParser;

/// <summary>
/// Big json reader
/// </summary>
public class BigLoadJsonParser : IDisposable, IEnumerable<IStore>
{

    /// <summary>
    /// Initialize a new instance of <see cref="BigLoadJsonParser"/>
    /// </summary>
    /// <param name="reader"></param>
    public BigLoadJsonParser(BigJsonReader reader)
    {
        _reader = reader;
        _reader.OnObject += OnToken;
        _freeFilterPath = true;
    }

    private void OnToken(object? sender, JsonReaderArgs e)
    {

        if (e.Event == EventEnum.PreparingToRead)
        {

            if (!_freeFilterPath && e.Item != null)
            {

                if (!_filterPath.TryToMatch(e.Path, false))
                    e.Strategy = StrategyEnum.Skip;

            }

        }

        else if (e.Event == EventEnum.EndedToRead)
        {
            //if (e.ToReturn)
            //    e.Append(e.Removed);
            //e.Strategy = StrategyEnum.NotAddItem;
        }

    }

    /// <summary>
    /// Dispose method
    /// </summary>
    public void Dispose()
    {
        _reader.OnObject -= OnToken;
        _reader.Dispose();
    }

    /// <summary>
    /// Add a filter to the parser
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public BigLoadJsonParser Filter(JsonPath? path = null)
    {
        _filterPath = path;
        _freeFilterPath = _filterPath == null;
        return this;
    }

    public IEnumerator<IStore> GetEnumerator()
    {
        return _reader.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _reader.GetEnumerator();
    }

    private JsonPath? _filterPath;
    private JsonPath? _slicePath;
    private bool _freeFilterPath;
    private readonly BigJsonReader _reader;

    public JsonPath? SlicePath { get => _slicePath; set => _slicePath = value; }
}
