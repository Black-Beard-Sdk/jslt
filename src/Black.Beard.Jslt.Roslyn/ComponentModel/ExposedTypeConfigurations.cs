using Bb.ComponentModel.Attributes;
using System.Collections.Generic;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Configuration for manualy to register Exposition  
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{Bb.ComponentModel.ExposedTypeConfiguration}" />
    [ExposeClass(Context = ConstantsCore.Configuration, Name = ConstantsCore.ExposedTypes, LifeCycle = IocScopeEnum.Singleton)]
    public class ExposedTypeConfigurations : List<ExposedTypeConfiguration>
    {


    }

}
