using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShop.Models.NewEmailModel
{
    public class DesserializedWarehouses
    {
        public bool success { get; set; }
        public List<Warehouse> data { get; set; }

        public DesserializedWarehouses() { }

        public DesserializedWarehouses(bool success, List<Warehouse> data)
        {
            this.success = success;
            this.data = data;
        }

        public static DesserializedWarehouses DesserializeCollection(string pathFile)
        {

            try
            {
                using (FileStream fstream = File.OpenRead(pathFile))
                {
                    byte[] textFromFile = new byte[fstream.Length];
                    fstream.Read(textFromFile, 0, textFromFile.Length);

                    var readOnlySpan = new ReadOnlySpan<byte>(textFromFile);
                    DesserializedWarehouses Desserialized =
                        JsonSerializer.Deserialize<DesserializedWarehouses>(readOnlySpan);

                    return Desserialized;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
