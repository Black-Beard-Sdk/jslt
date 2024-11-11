using Bb.JPaths;
using System.IO;

namespace Bb.JsonParser;

/// <summary>
/// Big json importer
/// </summary>
public class BigJsonImporter : BigJsonReader
{

    /// <summary>
    /// Initialize a new instance of <see cref="BigJsonImporter"/>
    /// </summary>
    /// <param name="path"></param>
    /// <param name="jpath"></param>
    public BigJsonImporter(string path, JsonPath? jpath = null)
        : base(new FileInfo(path), jpath)
    {

    }

    /// <summary>
    /// Initialize a new instance of <see cref="BigJsonImporter"/>
    /// </summary>
    /// <param name="file"></param>
    /// <param name="jpath"></param>
    public BigJsonImporter(FileInfo file, JsonPath? jpath = null)
        : base(file, jpath)
    {

    }

    protected override void OnAfter(JsonReaderArgs arg)
    {
        if (arg.Removed.ToReturn)
            arg.Append(arg.Removed);
    }



}
