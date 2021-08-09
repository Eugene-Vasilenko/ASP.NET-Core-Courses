namespace WebApplication1
{
    public class MyLibraryConfig
    {
        public int Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }

        public NestedConfiguration GroupedConfig { get; set; }
    }
}