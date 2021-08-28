using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class PostParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Caltegory MyCaltegory { get; set; }
    }

    public class Caltegory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}