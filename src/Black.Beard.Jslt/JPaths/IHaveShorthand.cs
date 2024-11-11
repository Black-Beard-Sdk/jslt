using System.Text;

namespace Bb.JPaths;

internal interface IHaveShorthand
{
    string ToShorthandString();
    void AppendShorthandString(StringBuilder builder);
}