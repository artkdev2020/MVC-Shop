using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShop.Models.NewEmailModel
{
    public class DesserializedCities
    {
        public bool success { get; set; }
        public List<City> data { get; set; }

        public DesserializedCities() { }

        public DesserializedCities(bool success, List<City> data)
        {
            this.success = success;
            this.data = data;
        }

        public static DesserializedCities DesserializeCollection(string pathFile)
        {
            try
            {
                using (FileStream fstream = File.OpenRead(pathFile))
                {
                    byte[] textFromFile = new byte[fstream.Length];
                    fstream.Read(textFromFile, 0, textFromFile.Length);

                    var readOnlySpan = new ReadOnlySpan<byte>(textFromFile);
                    DesserializedCities Desserialized =
                        JsonSerializer.Deserialize<DesserializedCities>(readOnlySpan);

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

