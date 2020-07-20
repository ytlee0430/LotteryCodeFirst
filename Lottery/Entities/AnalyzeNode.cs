using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Entities
{
    public class AnalyzeNode
    {
        public int Number { get; set; }

        public int Point { get; set; }

        public Dictionary<int, AnalyzeNode> NextNodes { get; set; }
    }
}
