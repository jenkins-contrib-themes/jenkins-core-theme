using System.IO;

namespace GetCompliance.Domain
{
    public static class StreamExtensions
    {
        public static byte[] ReadAsBytes(this Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var memoryStream = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, read);
                }
                return memoryStream.ToArray();
            }
        }
    }
}