using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures
{
    class BasicConnection
    {
        public string Data { get; set; }
        public int Weight { get; set; }

        public BasicConnection(string data, int weight)
        {
            Data = data;
            Weight = weight;
        }
    }
}
