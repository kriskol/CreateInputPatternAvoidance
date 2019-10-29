using System;
using System.IO;
using System.Text;

namespace CreateInputPatternAvoidance
{
    internal class Program
    {
        public static StreamReader GetReader(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            return streamReader;
        }

        public static string ProcessInputPattern(string inputPattern)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int number;

            for (int i = 0; i < inputPattern.Length - 1; i++)
            {
                number = Int32.Parse(inputPattern[i].ToString()) - 1;
                stringBuilder.Append(number.ToString() + '-');
            }

            number = Int32.Parse(inputPattern[inputPattern.Length-1].ToString())-1;
            
            stringBuilder.Append(number);

            return stringBuilder.ToString();
        }
        
        public static void ProcessInputPatterns(string inputPatterns, StreamWriter streamWriter)
        {
            string[] patterns = inputPatterns.Split(new char[] {'#', ' ', '\t','\n'}, 
                                                        StringSplitOptions.RemoveEmptyEntries);
            string patternProcessed;
            
            foreach (var pattern in patterns)
            {
                patternProcessed = ProcessInputPattern(pattern);
                streamWriter.WriteLine(patternProcessed);
            }
        }

        public static void ProcessCorrectOutputs(string correctOutput, StreamWriter streamWriter)
        {
            string[] correctOutputsSplited  = correctOutput.Split(new char[] {'#', ' ', '\t','\n'}, 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var correctOutputSplitted in correctOutputsSplited)
                streamWriter.WriteLine(correctOutputSplitted);
                
        }
        
        public static void CreateInput(StreamReader streamReader, int order, string path)
        {
            StreamWriter streamWriterInputPatterns = new StreamWriter(path+order+".in");
            StreamWriter streamWriterCorrectOutput = new StreamWriter(path+"c"+order+".out");
            ProcessInputPatterns(streamReader.ReadLine(), streamWriterInputPatterns);
            ProcessCorrectOutputs(streamReader.ReadLine(), streamWriterCorrectOutput);
            streamWriterInputPatterns.Close();
            streamWriterCorrectOutput.Close();
        }
        
        public static void CreateInputs(StreamReader streamReader, int start, int end, string path = "")
        {
            int order = 0;

            while (order < start && streamReader.EndOfStream == false)
            {
                streamReader.ReadLine();
                streamReader.ReadLine();
                order++;
            }

            if (end < start)
                while (streamReader.EndOfStream == false)
                {
                    CreateInput(streamReader, order, path);
                    order++;
                }
            else
                while (streamReader.EndOfStream == false && order < end)
                {
                    CreateInput(streamReader, order, path);
                    order++;
                }
        }
        
        public static void Main(string[] args)
        {
            StreamReader streamReader = GetReader(args[0]);
            int start = Int32.Parse(args[1]);
            int end = Int32.Parse(args[2]);
            CreateInputs(streamReader, start, end);
            streamReader.Close();
        }
    }
}