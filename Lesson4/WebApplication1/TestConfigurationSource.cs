using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public class TestConfigurationSource : IConfigurationSource
    {
        private readonly string _filePath;

        public TestConfigurationSource(string filePath)
        {
            _filePath = filePath;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var physicalPath = builder.GetFileProvider().GetFileInfo(_filePath).PhysicalPath;
            return new TestConfigurationProvider(physicalPath);
        }
    }
}