using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using MoodAnalyzerProblem;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyserDefaultObject(string className, string Constructor)
        {
            string pattern = @"." + Constructor + "$";
            var result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyseType);
                    return res;
                }
                catch(NullReferenceException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "no such class found");
                }
            }
            else
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "no such constructor found");
        }
    }
}
