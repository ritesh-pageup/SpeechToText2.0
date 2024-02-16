using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpeechToText
{
    public class ToNumberConvert
    {
        private static Dictionary<string, long> numberTable = new Dictionary<string, long> { { "ek", 1 }, { "do", 2 }, { "teen", 3 }, { "char", 4 }, { "paanch", 5 }, { "chhh", 6 }, { "sat", 7 }, { "aath", 8 }, { "nau", 9 }, { "ds", 10 }, { "gyaarh", 11 }, { "barh", 12 }, { "terh", 13 }, { "chaudh", 14 }, { "pndrh", 15 }, { "solh", 16 }, { "strh", 17 }, { "attharh", 18 }, { "unnees", 19 }, { "bees", 20 }, { "ikkees", 21 }, { "baees", 22 }, { "teees", 23 }, { "chaubis", 24 }, { "pchchees", 25 }, { "chhbbees", 26 }, { "sttaees", 27 }, { "atthaees", 28 }, { "untees", 29 }, { "tees", 30 }, { "iktees", 31 }, { "bttees", 32 }, { "taintees", 33 }, { "chauntees", 34 }, { "paintees", 35 }, { "chhttees", 36 }, { "saintees", 37 }, { "adtees", 38 }, { "untalees", 39 }, { "chalees", 40 }, { "iktalees", 41 }, { "byaalees", 42 }, { "taintalees", 43 }, { "chauntalees", 44 }, { "paintalees", 45 }, { "chhiyaalees", 46 }, { "saintalees", 47 }, { "adtalees", 48 }, { "unchas", 49 }, { "pchas", 50 }, { "ikyaavn", 51 }, { "bavn", 52 }, { "tirepn", 53 }, { "chauvn", 54 }, { "pchpn", 55 }, { "chhppn", 56 }, { "sttavn", 57 }, { "atthavn", 58 }, { "unsth", 59 }, { "sath", 60 }, { "iksth", 61 }, { "basth", 62 }, { "tiresth", 63 }, { "chaunsth", 64 }, { "painsth", 65 }, { "chhyaasth", 66 }, { "adsth", 67 }, { "adsth", 68 }, { "unhttr", 69 }, { "sttr", 70 }, { "ikhttr", 71 }, { "bhttr", 72 }, { "tihttr", 73 }, { "chauhttr", 74 }, { "pchhttr", 75 }, { "chhihttr", 76 }, { "sthttr", 77 }, { "athhttr", 78 }, { "unnasee", 79 }, { "assee", 80 }, { "ikyaasee", 81 }, { "byaasee", 82 }, { "tirasee", 83 }, { "chaurasee", 84 }, { "pchasee", 85 }, { "chhiyaasee", 86 }, { "sttasee", 87 }, { "athasee", 88 }, { "nvasee", 89 }, { "nbbe", 90 }, { "ikyaanve", 91 }, { "banve", 92 }, { "tiranve", 93 }, { "chauranve", 94 }, { "pchanve", 95 }, { "chhiyaanve", 96 }, { "sttanve", 97 }, { "atthanve", 98 }, { "ninyaanve", 99 }, { "sau", 100 }, { "hjar", 1000 }, { "lakh", 100000 }, { "krod", 10000000 } };

        public static long ToNumber(string numberString)
        {
            numberString = numberString.Replace(" and ", " ");
            var wordList = numberString.Split(' ');
            
            long currNum = 0, total = 0L;
            foreach (var n in wordList)
            {
                if (numberTable[n] >= 1000)
                {
                    total += (currNum * numberTable[n]);
                    currNum = 0;
                }
                else if (numberTable[n] >= 100)
                {
                    currNum *= numberTable[n];
                }
                else currNum += numberTable[n];
            }
            return total + currNum;
        }
    }
}
