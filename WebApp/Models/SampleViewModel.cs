using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SampleViewModel
    {
        public string Name { get; set; }
        public int ModifyIdx { get; set; }
        public List<FruitModel> Fruits { get; set; }
        
    }
}
