using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prakticheskaya4
{
    internal class SerDeser
    {
        public static void MySerialize<T>(T zametochi)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string json = JsonConvert.SerializeObject(zametochi);
            File.WriteAllText(desktop + "\\Zametka1.json", json);
        }
        public static T MyDeserialize<T>()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string json = File.ReadAllText(desktop + "\\Zametka1.json");
            T zametochi = JsonConvert.DeserializeObject<T>(json);
            return zametochi;
        }
    }
}
