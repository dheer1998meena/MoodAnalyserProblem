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
            if (this.message.Contains("sad"))
                return "sad";
            else
                return "happy";
        }
    }
}
