using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Questions
    {
        public int id { get; set; }
        public string text { get; set; }
        public List<Answer> answers { get; set; } = new List<Answer>();
        public Difficult dif { get; set; }
    }
}
