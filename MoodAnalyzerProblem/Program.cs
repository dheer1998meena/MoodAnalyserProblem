﻿using System;

namespace MoodAnalyzerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            MoodAnalyser analyser = new MoodAnalyser(" I am in a any mood");
            Console.WriteLine(analyser.AnalyserMethod());
        }
    }
}