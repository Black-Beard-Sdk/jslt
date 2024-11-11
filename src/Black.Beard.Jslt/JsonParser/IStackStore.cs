namespace Bb.JsonParser;

/// <summary>
/// Abstraction for store objects in stack
/// </summary>
public interface IStackStore
{
    /// <summary>
    /// Item to de-queue
    /// </summary>
    /// <param name="storeBase"></param>
    void Remove(IStore storeBase);


}
