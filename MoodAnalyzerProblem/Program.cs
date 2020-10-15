using System;

namespace MoodAnalyzerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to mood analyser");
            // Ask the user to enter his mood
            Console.WriteLine("Enter the state of mood");
            string message = Console.ReadLine();
            //Call AnalyseMood method to check for mood
            MoodAnalyser analyser = new MoodAnalyser(message);
            Console.WriteLine(analyser.AnalyserMethod());
            //Creating MoodAnalyser object at run time
            MoodAnalyserFactory.CreateMoodAnalyserDefaultObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
            MoodAnalyserFactory.CreateMoodAnalyserParameterizedObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser","HAPPY");
            MoodAnalyserFactory.InvokeAnalyserMethod("Happy", "AnalyserMethod");
        }
    }
}
