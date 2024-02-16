using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToText
{
    public class TranslateResult
    {
        public List<ResultOfJson> Result { get; set; }
        public string Text { get; set; }
    }
}
