using System.Text;

namespace RandomDataGenerator.Randomizers;

public interface IRandomizerBytes
{
    byte[] Generate();

    string GenerateAsUTF8String();

    string GenerateAsASCIIString();

    string GenerateAsBase64String();

    string GenerateAsString(Encoding? encoding = null);
}