namespace Bb.Json.Jslt.CustomServices.MultiCsv
{
    public interface IVisitor<T>
    {

        T Visit(Block block);

    }


}
