using Bb.ComponentModel;
using Bb.ComponentModel.Factories;
using Bb.Json.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{




    public partial class TranformJsonAstConfiguration
    {

        public TranformJsonAstConfiguration(CultureInfo culture = null)
        {
            this.Culture = culture ?? CultureInfo.InvariantCulture;
            this.Services = new ServiceContainer();
        }

        public ServiceContainer Services { get; }

        public string Path { get; set; }

        public CultureInfo Culture { get; set; }

    }



}
