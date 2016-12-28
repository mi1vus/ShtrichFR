using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ShtrihFR
{
    public static class DriveCacher<T> where T : class
    {
        private static readonly string CachFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ShtrihFRData", "cacheData.dat");

        public static bool Serialize(T dictionary)
        {
            try // try to serialize the collection to a file
            {
                CreateDirIfNotExist();
                using (var stream = new FileStream(CachFile, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, dictionary);
                }
            }
            catch (Exception e)
            {
                Console.Write("ERROR DriveCacher.Serialize " + e.ToString());
                return false;
            }
            return true;
        }
        public static T Deserialize()
        {
            try
            {
                CreateDirIfNotExist();
                T ret = CreateInstance();
                using (var stream = new FileStream(CachFile, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    ret = (T)bin.Deserialize(stream);
                }
                return ret;
            }
            catch (Exception e)
            {
                Console.Write("ERROR DriveCacher.Deserialize " + e.ToString());
                return null;
            }
        }

        // function to create instance of T
        private static T CreateInstance()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
        private static void CreateDirIfNotExist()
        {
            var dir = Path.GetDirectoryName(CachFile);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
