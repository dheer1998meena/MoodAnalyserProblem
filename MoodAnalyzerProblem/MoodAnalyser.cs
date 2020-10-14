using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyser
    {
        private string message;

        public MoodAnalyser()
        {
            Console.WriteLine("Default Constructor");
        }
        public MoodAnalyser(string message)
        {
            this.message = message;
            Console.WriteLine("Parameterized Constructor");
        }
        public string AnalyserMethod()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                else if (this.message.Contains("sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }
        }
    }
}
