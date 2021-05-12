
namespace Bb.Factories
{

    /// <summary>
    /// factory provider provide a customized and optimized creator. Very factor that Activator class.
    /// </summary>
    /// <example>
    /// take the definition of the class user
    /// <code lang="C#">
    /// <![CDATA[
    /// public class User
    /// {
    /// 
    ///     public User()
    ///     {
    /// 
    ///     }
    /// 
    ///     public User(string name)
    ///     {
    ///         this.Name = name;
    ///     }
    /// 
    ///     string Name { get; set; }
    /// 
    /// }
    /// ]]>
    /// </code>
    /// </example>
    /// <example>
    /// Iterate properties
    /// <code lang="C#">
    /// <![CDATA[
    /// 
    /// // return a provider for create factories
    /// Factories.IFactoryProvider provider = new FactoryProvider();
    /// 
    /// // return factory for create user with the ctor 
    /// IFactory<User> factory = provider.Create<User>(typeof(string));
    /// 
    /// // Create user
    /// User user = factory.Create("name"); 
    ///                                       
    /// ]]>
    /// </code>
    /// </example>
    class NamespaceDoc
    {

        //public NamespaceDoc()
        //{
        //    // return a provider for create factories
        //    Factories.IFactoryProvider provider = new FactoryProvider();

        //    // return factory for create user with the ctor 
        //    IFactory<User> factory = provider.Create<User>(typeof(string));

        //    // Create user
        //    User user = factory.Create("name");

        //}


        //public class User
        //{

        //    public User()
        //    {

        //    }

        //    public User(string name)
        //    {
        //        this.Name = name;
        //    }

        //    string Name { get; set; }

        //}

    }

}
