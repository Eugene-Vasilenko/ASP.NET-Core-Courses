using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace WebApplication1
{
    public class TestConfigurationProvider : ConfigurationProvider
    {
        private readonly string _filePath;

        public TestConfigurationProvider(string filePath)
        {
            _filePath = filePath;
        }

        public override void Load()
        {
            var result = new Dictionary<string, string>();

            FileStream fileStream = new FileStream(_filePath, FileMode.Open);

            var streamreader = new StreamReader(fileStream);

            string dataString;

            while ((dataString = streamreader.ReadLine()) != null)
            {
                var configPair = dataString.Split("=");
                if (configPair.Length == 2)
                {
                    result[configPair[0]] = configPair[1];
                }
            }

            Data = result;
        }
    }
}