namespace Bb.Jslt.Services.MultiCsv
{
    public interface IVisitor<T>
    {

        T Visit(Block block);

    }


}
