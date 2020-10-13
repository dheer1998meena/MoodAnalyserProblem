using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyser
    {
        private string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
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
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be null");
            }
        }
    }
}
