using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyser
    {
        private string message;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MoodAnalyser()
        {
            Console.WriteLine("Default Constructor");
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="message"></param>
        public MoodAnalyser(string message)
        {
            this.message = message;
            Console.WriteLine("Parameterized Constructor");
        }
        /// <summary>
        /// To analyse the mood
        /// </summary>
        /// <returns></returns>
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
