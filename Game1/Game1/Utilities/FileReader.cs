using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Utilities
{
    class FileReader
    {
        public static string GetDataFromFile(string fileName)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader reader = new StreamReader($"Data/{fileName}.json"))
                {
                    string file = reader.ReadToEnd();
                    // Read the stream to a string, and write the string to the console.
                    return file; 
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
