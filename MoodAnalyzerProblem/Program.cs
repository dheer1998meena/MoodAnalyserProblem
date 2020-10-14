using System;

namespace MoodAnalyzerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to mood analyser");
            Console.WriteLine("Enter the state of mood");
            string message = Console.ReadLine();
            MoodAnalyser analyser = new MoodAnalyser(message);
            Console.WriteLine(analyser.AnalyserMethod());
            MoodAnalyserFactory.CreateMoodAnalyserDefaultObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
        }
    }
}
