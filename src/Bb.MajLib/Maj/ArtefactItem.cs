using System;

namespace Bb.Maj
{
    [System.Diagnostics.DebuggerDisplay("{Version} / {Name}")]
    public class ArtefactItem
    {
        public Uri UrlDownload { get; internal set; }
        public Version Version { get; internal set; }
        public string Name { get; internal set; }
    }

}
