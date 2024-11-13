using Bb.Json;
using System.Reflection;

namespace Bb.JsonParser;

public struct Progress
{

    static Progress()
    {
        _indexField = typeof(JsonTextReader).GetField("_charPos", BindingFlags.Instance | BindingFlags.NonPublic);
    }

    public Progress(long max, JsonTextReader reader)
    {
        //_progress = 0;
        _length = max;
        _reader = reader;
    }

    public long LinePosition => _reader.LinePosition;

    public long LineNumber => _reader.LineNumber;

    //public int CurrentPosition
    //{
    //    get
    //    {

    //        if (toRefresh)
    //        {
    //            _currentIndex = (int)_indexField.GetValue(_reader);
    //            toRefresh = false;
    //        }

    //        return _currentIndex;

    //    }
    //}

    //public decimal GetProgress()
    //{

    //    if (toRefresh && CurrentPosition > 0)
    //        _progress = ((decimal)CurrentPosition / _length) * 100;

    //    return _progress;

    //}

    public void Append()
    {
        toRefresh = true;
    }


    private bool toRefresh = true;
    private readonly long _length;
    private readonly JsonTextReader _reader;
    private static readonly FieldInfo _indexField;
    //private int _currentIndex;
    //private decimal _progress;

}
