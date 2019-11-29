using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace netcore_session_redis.SessionHelpers
{
    public static class BinarySerializer
    {
        public static async Task<T> Deserialize<T>(this byte[] data)
        {
            object obj;
            BinaryFormatter bf = new BinaryFormatter();

            await using (MemoryStream ms = new MemoryStream(data))
            {
                obj = bf.Deserialize(ms);
            }

            return (T)obj;
        }

        public static async Task<byte[]> Serialize<T>(this T value)
        {
            byte[] arr;
            BinaryFormatter bf = new BinaryFormatter();
            await using(MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, value);
                arr= ms.ToArray();
            }

            return arr;
        }
    }
}
