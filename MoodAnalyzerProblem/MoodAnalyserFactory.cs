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
        /// <summary>
        /// Creating an object for mood analyser class using Default constructor
        /// </summary>
        /// <param name="className"></param>
        /// <param name="Constructor"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creating an object for mood analyser class using parameterised constructor
        /// </summary>
        /// <param name="className"></param>
        /// <param name="Constructor"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyserParameterizedObject(string className, string Constructor, string message)
        {
            string pattern = @"." + Constructor + "$";
            var result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyseType,message);
                    return res;
                }
                catch (NullReferenceException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "no such class found");
                }
            }
            else
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "no such constructor found");
        }

        /// THIS METHOD CAN ALSO BE USED FOR PARAMETRISED CONSTRUCTOR(ALTERNATIVE WAY)

        //public static object CreateMoodAnalyserParameterizedObject(string className, string constructor, string message)
        //{
        //    Type type = typeof(MoodAnalyser);
        //    if (type.Name == className || type.FullName == className)
        //    {
        //        if (type.Name.Equals(constructor))
        //        {
        //            ConstructorInfo construct = type.GetConstructor(new[] { typeof(string) });
        //            object obj = construct.Invoke(new object[] { message });
        //            return obj;
        //        }


        //        else
        //            throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "no such constructor found");
        //    }
        //    else
        //        throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "no such class is found");

        //} 

        /// <summary>
        /// Invoking Mood Analyser Method
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string InvokeAnalyserMethod(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                object moodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalyserParameterizedObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser",message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }

            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "no such method is found");

            }
        }
    }
}
