using Bb.JPaths;
using System;
using System.Collections.Generic;

namespace Bb.JsonParser;

/// <summary>
/// Big json reader
/// </summary>
public class BigLoadJsonParser : IDisposable
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

            if (!_freeFilterPath)
            {
                var m = e.Item.JsonModel;
                if (!_filterPath.TryToMatch(e.Path))
                    e.Strategy = StrategyEnum.Skip;
            }

        }

        else if (e.Event == EventEnum.EndedToRead)
        {

            //foreach (var item in _slicePath.Evaluate(e.Item.JsonModel).Matches)
            //    e.Append(item.Value);

            if (e.Count > 0)
                e.Strategy = StrategyEnum.NotAddItem;

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

    public IEnumerable<IStore> Load()
    {
        return _reader.Read();
    }

    private JsonPath? _filterPath;
    private JsonPath? _slicePath;
    private bool _freeFilterPath;
    private readonly BigJsonReader _reader;

    public JsonPath? SlicePath { get => _slicePath; set => _slicePath = value; }
}
