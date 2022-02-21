using System;
using System.IO;

namespace Bb.Maj
{
    [System.Diagnostics.DebuggerDisplay("{Version} / {Name}")]
    public class ArtefactItem
    {

        public string Name { get; internal set; }

        public Version Version { get; internal set; }

        public Uri UrlDownload { get; internal set; }
        
        public string Filename { get => Path.GetFileNameWithoutExtension(Name) + "_" + Version.ToString() + Path.GetExtension(Name); }
        
    }

}
