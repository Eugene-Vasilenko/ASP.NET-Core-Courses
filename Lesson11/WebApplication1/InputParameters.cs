using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    public class InputParameters
    {
        [FromQuery]
        public string SomeProp { get; set; }

        [FromQuery]
        public string EnotherProp { get; set; }

        [FromHeader]
        public int IntProperty { get; set; }
    }
}