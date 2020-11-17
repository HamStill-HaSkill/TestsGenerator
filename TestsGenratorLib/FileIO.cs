using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestsGeneratorLib
{
    class FileIO
    {
        public async Task<string> ReadFileAsync(string sourceFile)
        {
            using (StreamReader reader = new StreamReader(sourceFile))
            {
                return await reader.ReadToEndAsync();
            }
        }
        public async Task WriteFileAsync(string destinationFile, string text)
        {
            using (StreamWriter writer = new StreamWriter(destinationFile, false))
            {
                await writer.WriteAsync(text);
            }
        }
    }
}
