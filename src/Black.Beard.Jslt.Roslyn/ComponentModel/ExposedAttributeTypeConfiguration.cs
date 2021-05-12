using Bb.ComponentModel.Attributes;

namespace Bb.ComponentModel
{
    public class ExposedAttributeTypeConfiguration
    {

        public ExposedAttributeTypeConfiguration()
        {

        }

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public string Context { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the life cycle.
        /// </summary>
        /// <value>
        /// The life cycle.
        /// </value>
        public IocScopeEnum LifeCycle { get; set; }

                /// <summary>
        /// Gets or sets the exposition type.
        /// </summary>
        /// <value>
        /// The type of the exposed.
        /// </value>
        public string ExposedType { get; set; }
    }

}
