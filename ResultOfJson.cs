using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToText
{
    public class ResultOfJson
    {
        public Decimal Conf { get; set; }
        public Decimal End { get; set; }
        public Decimal Start { get; set; }
        public string Word { get; set; }
    }
}
