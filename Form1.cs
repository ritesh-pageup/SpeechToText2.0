using System.Reflection;
using System.Speech;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using Humanizer;
using NAudio.Wave;
using Newtonsoft.Json;
using Vosk;

namespace SpeechToText
{
    public partial class Form1 : Form
    {
        /*------------------Vosk Code---------------------*/
       
        string modelPath = "G:\\Ritesh_WorkSpace\\VoskAISpeech\\Vosk\\vosk-model-small-hi-0.22";
        Model model;
        VoskRecognizer recognizer;
        WaveInEvent waveIn = new WaveInEvent
        {
            DeviceNumber = 0,
            WaveFormat = new WaveFormat(16000, 1) // Set the correct sample rate expected by the model
        };
        Dictionary<char, string> barnDict = new Dictionary<char, string> { { 'क', "k" }, { 'ख', "kh" }, { 'ग', "g" }, { 'घ', "gh" }, { 'च', "ch" }, { 'छ', "chh" }, { 'ज', "j" }, { 'झ', "jh" }, { 'ञ', "nya" }, { 'ट', "t" }, { 'ठ', "th" }, { 'ड', "d" }, { 'ढ', "dh" }, { 'ण', "n" }, { 'त', "t" }, { 'थ', "th" }, { 'द', "d" }, { 'ध', "dh" }, { 'न', "n" }, { 'प', "p" }, { 'फ', "ph" }, { 'ब', "b" }, { 'भ', "bh" }, { 'म', "m" }, { 'य', "ya" }, { 'र', "r" }, { 'ल', "l" }, { 'व', "v" }, { 'श', "sh" }, { 'ष', "shha" }, { 'स', "s" }, { 'ह', "h" }, { 'ा', "a" }, { 'ि', "i" }, { 'ी', "ee" }, { 'ु', "u" }, { 'ू', "oo" }, { 'ृ', "r" }, { 'ॄ', "rr" }, { 'ॅ', "e" }, { 'ॆ', "e" }, { 'े', "e" }, { 'ै', "ai" }, { 'ॉ', "o" }, { 'ॊ', "o" }, { 'ो', "o" }, { 'ौ', "au" }, { 'ऋ', "ri" }, { 'ॠ', "rr" }, { ' ', " " } };
        string[] qArray = {"pees","pee" };
        Dictionary<string, string> diffBarnDict = new Dictionary<string, string> {
                { "ड़", "ng" }, { "क्ष", "ksh" }, { "त्र", "tr" }, { "ज्ञ", "gy" }, { "श्र", "shr" },
            };
        Dictionary<char, string> IndepenVowelDict = new Dictionary<char, string> {
                {'\u0905', "a"}, {'\u0906', "aa"}, {'\u0907', "i"}, {'\u0908', "ee"}, {'\u0909', "u"}, {'\u090A', "oo"}, {'\u090B', "r"}, {'\u090C', "l"}, {'\u090D', "e"}, {'\u090E', "e"}, {'\u090F', "e"}, {'\u0910', "ai"}, {'\u0911', "o"}, {'\u0912', "o"}, {'\u0913', "o"}, {'\u0914', "au"},{'\u0931', "r"}, {'\u0902', "n"}, {'\u0903', "h"}, {'\u0901', "an"}, {'\u0950', "om"}, {'\u0958', "qa"}, {'\u0959', "khha"}, {'\u095A', "ghha"}, {'\u095B', "za"}, {'\u095C', "dddha"}, {'\u095D', "rha"}, {'\u095E', "fa"}, {'\u095F', "yya"}, {'\u0962', "l"}, {'\u0963', "ll"}, {'\u0955', "e"}, {'\u0956', "ue"}, {'\u0957', "uue"},{'\u0973',"am" }
            };
        /*-----------------------------------------------------*/

        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        PromptBuilder promptBuilder = new PromptBuilder();
        SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-IN"));
        public string[] WordsArr;
        public string[] FirstNames;
        Choices choiceQuantityList = new Choices();
        Choices productList = new Choices();
        Product product = new Product();
        GrammarBuilder grammarBuilder = new GrammarBuilder();
        Grammar grammar ;


        Dictionary<string, int> numDict = new Dictionary<string, int> { { "ek", 1 }, { "do", 2 }, { "teen", 3 }, { "char", 4 }, { "paanch", 5 }, { "chhh", 6 }, { "sat", 7 }, { "aath", 8 }, { "nau", 9 }, { "ds", 10 }, { "gyaarh", 11 }, { "barh", 12 }, { "terh", 13 }, { "chaudh", 14 }, { "pndrh", 15 }, { "solh", 16 }, { "strh", 17 }, { "attharh", 18 }, { "unnees", 19 }, { "bees", 20 }, { "ikkees", 21 }, { "baees", 22 }, { "teees", 23 }, { "chaubis", 24 }, { "pchchees", 25 }, { "chhbbees", 26 }, { "sttaees", 27 }, { "atthaees", 28 }, { "untees", 29 }, { "tees", 30 }, { "iktees", 31 }, { "bttees", 32 }, { "taintees", 33 }, { "chauntees", 34 }, { "paintees", 35 }, { "chhttees", 36 }, { "saintees", 37 }, { "adtees", 38 }, { "untalees", 39 }, { "chalees", 40 }, { "iktalees", 41 }, { "byaalees", 42 }, { "taintalees", 43 }, { "chauntalees", 44 }, { "paintalees", 45 }, { "chhiyaalees", 46 }, { "saintalees", 47 }, { "adtalees", 48 }, { "unchas", 49 }, { "pchas", 50 }, { "ikyaavn", 51 }, { "bavn", 52 }, { "tirepn", 53 }, { "chauvn", 54 }, { "pchpn", 55 }, { "chhppn", 56 }, { "sttavn", 57 }, { "atthavn", 58 }, { "unsth", 59 }, { "sath", 60 }, { "iksth", 61 }, { "basth", 62 }, { "tiresth", 63 }, { "chaunsth", 64 }, { "painsth", 65 }, { "chhyaasth", 66 }, { "sdsth", 67 }, { "adsth", 68 }, { "unhttr", 69 }, { "sttr", 70 }, { "ikhttr", 71 }, { "bhttr", 72 }, { "tihttr", 73 }, { "chauhttr", 74 }, { "pchhttr", 75 }, { "chhihttr", 76 }, { "sthttr", 77 }, { "athhttr", 78 }, { "unnasee", 79 }, { "assee", 80 }, { "ikyaasee", 81 }, { "byaasee", 82 }, { "tirasee", 83 }, { "chaurasee", 84 }, { "pchasee", 85 }, { "chhiyaasee", 86 }, { "sttasee", 87 }, { "athasee", 88 }, { "nvasee", 89 }, { "nbbe", 90 }, { "ikyaanve", 91 }, { "banve", 92 }, { "tiranve", 93 }, { "chauranve", 94 }, { "pchanve", 95 }, { "chhiyaanve", 96 }, { "sttanve", 97 }, { "atthanve", 98 }, { "ninyaanve", 99 }, { "sau", 100 }, { "hjar", 1000 }, { "lakh", 100000 }, { "krod", 10000000 } };

        long Price =0;
        long Quantity = 0;
        string ProductName = "";
        string newResult = "";

        public Form1()
        {
            InitializeComponent();
            StopBtn.Enabled = false;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            MemoryStream audioStream = new MemoryStream();
            StartBtn.Enabled = false;
            StopBtn.Enabled = true;
            List<string> tempList = new List<string>();
            try
            {
                waveIn.DataAvailable += (sender, args) =>
                {
                    audioStream.Write(args.Buffer, 0, args.BytesRecorded);
                    if (recognizer.AcceptWaveform(args.Buffer, args.BytesRecorded))
                    {
                        textBox1.Text = "";
                        string result = recognizer.Result();
                        var result1 = JsonConvert.DeserializeObject<TranslateResult>(result);
                        
                        
                        if (result1 != null)
                        {
                            foreach (var item in result1.Text)
                            {
                                if (barnDict.ContainsKey(item))
                                {
                                    newResult += barnDict[item];
                                }else if (IndepenVowelDict.ContainsKey(item))
                                {
                                    newResult += barnDict[item];
                                }
                            }
                            var resArr = newResult.Split(' ');
                            string tmp = "";
                            foreach(string s in resArr )
                            {
                                if (numDict.ContainsKey(s))
                                {
                                    tmp += s;
                                }
                                else
                                {
                                    tempList.Add(tmp);
                                    tmp = "";
                                }
                            }
                            int resCount = resArr.Count();
                            if (resCount >= 2)
                            {
                                Price = ToNumberConvert.ToNumber(resArr.ElementAt(resCount-1));
                                Quantity = ToNumberConvert.ToNumber(resArr.ElementAt(resCount - 2));
                            }
                            //else
                            //{
                            //    textBox1.Text = "Please try Again";
                            //}
                        }
                    }
                    //else
                    //{
                    //    Console.WriteLine(recognizer.PartialResult());
                    //}
                };

                waveIn.RecordingStopped += (sender, e) =>
                {
                    audioStream.Position = 0; 

                    recognitionEngine.SetInputToAudioStream(audioStream, new SpeechAudioFormatInfo(16000, AudioBitsPerSample.Sixteen, AudioChannel.Mono));
                    recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
                    if (recognizer.FinalResult() != "")
                    {
                        var result = recognizer.FinalResult();

                        //Console.WriteLine(result);
                    }
                };
                waveIn.StartRecording();
                grammar = new Grammar(grammarBuilder);
                recognitionEngine.SpeechRecognized += Sre_SpeechRecogniged;
                recognitionEngine.LoadGrammarAsync(grammar);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Sre_SpeechRecogniged(object? sender, SpeechRecognizedEventArgs e)
        {
            textBox1.Text = "";
            if(e.Result.Text != "")
            {
                ProductName = e.Result.Text;
                if(Price != 0 && Quantity != 0)
                {
                    AddProductInList(ProductName, Price, Quantity);
                }
            }
            textBox1.Text += (newResult + Environment.NewLine+$"Product: {ProductName}");
            newResult = "";
            //string NewString = "";
            //var resArr = e.Result.Text.ToString().Split(' ');
            //foreach (var s in resArr)
            //{
            //    if (numDict.ContainsKey(s) || s == "and")
            //    {
            //        NewString += s + " ";
            //    }
            //    else
            //    {
            //        if (NewString != "")
            //        {
            //            if (Quantity == 0)
            //            {
            //                Quantity = ToNumberConvert.ToNumber(NewString.Trim());
            //                ProductName += s + " ";
            //                textBox1.Text += (Quantity + " " + ProductName);
            //            }
            //            else
            //            {
            //                Price = ToNumberConvert.ToNumber(NewString.Trim());
            //                textBox1.Text += (Price + " " + s + " ");
            //            }
            //        }
            //        else
            //        {
            //            ProductName += s + " ";
            //            textBox1.Text += (ProductName);
            //        }
            //        NewString = "";
            //    }
            //}

            //AddProductInList(ProductName, Price, Quantity);
            //textBox1.Text += (e.Result.Text.ToString() + Environment.NewLine);
        }

        private void AddProductInList(string productName, long price, long quantity)
        {
            dataGridView1.Rows.Add(productName, quantity, price);
            Quantity = 0;
            Price = 0;
            ProductName = "";
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsyncStop();
            waveIn.StopRecording();
            StartBtn.Enabled = true;
            StopBtn.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*--------------------------Vosk onload-----------------------------*/
            Vosk.Vosk.SetLogLevel(0);
            this.model = new Model(this.modelPath);
            this.recognizer = new VoskRecognizer(model, 16000.0f);
            /*------------------------------------------------------------------*/

            string[] pro = product.Products;
            foreach (string p in pro)
            {
                productList.Add(p);
            }


            //grammarBuilder.Append(opt1Builder);
            grammarBuilder.Append(productList);
            //grammarBuilder.Append(opt1Builder);
            //grammarBuilder.Append("rupees");


            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
