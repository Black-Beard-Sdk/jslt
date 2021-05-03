using System.Text;

namespace Bb
{
    public static class Helper
    {

        public static string PrintByteArray(this byte[] array)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
                sb.Append($"{array[i]:X2}");
            return sb.ToString();
        }

    }


}
