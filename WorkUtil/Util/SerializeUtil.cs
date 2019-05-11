using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WorkUtil.Util
{
    class SerializeUtil<T>
    {
        public static T deSerializeNow(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                return (T)new BinaryFormatter().Deserialize(fileStream);
            }
        }


        public static void serializeNow(T t, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                new BinaryFormatter().Serialize(fileStream, t);
            }
        }

    }
}
