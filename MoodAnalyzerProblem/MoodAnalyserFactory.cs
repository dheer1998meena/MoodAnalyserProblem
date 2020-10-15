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
        /// <summary>
        /// UC 7 Change Dynamically Mood
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static Object ChangeMoodDynamically(string message, string fieldName)
        {
            Type type = typeof(MoodAnalyser);
            object mood = Activator.CreateInstance(type);

            try
            {
                FieldInfo fieldInfo = type.GetField(fieldName);
                fieldInfo.SetValue(mood, message);
                MethodInfo method = type.GetMethod("AnalyseMood");
                object methodReturn = method.Invoke(mood, null);
                return methodReturn;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "No such field found");
            }
            catch
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Null mood not accepted");
            }
        }
    }
}
