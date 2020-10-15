using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;

namespace MoodAnalyzerProblemMsTest
{
    [TestClass]
    public class UnitTest1
    {
        // UC1.1 Given sad mood return sad mood.
        [DataRow("I am in a sad mood ")]
        [TestMethod]
        public void Given_Sad_Mood_Returning_Sad_Result(string message)
        {
                // Arrange
                string expected = "SAD";
                MoodAnalyser analyser = new MoodAnalyser(message);
                // Act
                var actual = analyser.AnalyserMethod();
                // Assert
                Assert.AreEqual(expected, actual);
        }

        // UC1.2 Given any mood return happy mood.
        [DataRow("I am in any mood ")]
        [TestMethod]
        public void Given_Any_Mood_Returning_Happy_Result(string message)
        {
            // Arrange
            string expected = "HAPPY";
            MoodAnalyser analyser = new MoodAnalyser(message);
            // Act
            var actual = analyser.AnalyserMethod();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        // UC3.1 Given null should throw CustomException null mood.
        [TestMethod]
        public void Given_Null_Mood_Should_Return_NullMood_Using_CustomException()
        {
            try
            {
                string message = null;
                MoodAnalyser analyser = new MoodAnalyser(message);
                var actual = analyser.AnalyserMethod();
            }
            catch(MoodAnalyserCustomException ex)
            {
                Assert.AreEqual("Mood should not be null", ex.Message);
            }
        }

        // UC3.2 Given empty should throw CustomException empty mood.
        [TestMethod]
        public void Given_Empty_Mood_Should_Return_EmptyMood_Using_CustomException()
        {
            try
            {
                string message = " ";
                MoodAnalyser analyser = new MoodAnalyser(message);
                var actual = analyser.AnalyserMethod();
            }
            catch (MoodAnalyserCustomException ex)
            {
                Assert.AreEqual("Mood should not be empty", ex.Message);
            }
        }

        // UC 4.1 Given MoodAnalyserFactory Should Return MoodAnalyser Object
        [TestMethod]
        public void GivenMoodAnalyserFactory_CreateDefaultObject_ShouldReturnObject()
        {
            object expected = new MoodAnalyser();
            object actual = MoodAnalyserFactory.CreateMoodAnalyserDefaultObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
            expected.Equals(actual);
        }

        // 5.1 Given MoodAnalyserFactory Should Return Parameterized Object
        [TestMethod]
        public void GivenMoodAnalyserFactory_CreateParameterizedObject_ShouldReturnObject()
        {
            object expected = new MoodAnalyser("HAPPY");
            object actual = MoodAnalyserFactory.CreateMoodAnalyserParameterizedObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser","HAPPY");
            expected.Equals(actual);
        }

        // 5.2 Given MoodAnalyserFactory Invalid Class Name Should Return 
        [DataRow("MoodAnalyse","MoodAnalyser","message")]
        [TestMethod]
        public void GivenMoodAnalyserFactory_InvalidClassName_CreateParameterizedObject_ShouldReturnObject( string className,string Constructor,string message)
        {
            
            object expected = new MoodAnalyser(message);
            try
            {
                object actual = MoodAnalyserFactory.CreateMoodAnalyserParameterizedObject(className, Constructor, message);
            }
            catch (MoodAnalyserCustomException ex)
            {

                Assert.AreEqual("no such constructor found", ex.Message);
            }
        }

        // 5.3 Given MoodAnalyserFactory Invalid Constructor Name Should Return 
        [DataRow("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyse", "message")]
        [TestMethod]
        public void GivenMoodAnalyserFactory_InvalidConstructorName_CreateParameterizedObject_ShouldReturnObject(string className, string Constructor, string message)
        {

            object expected = new MoodAnalyser(message);
            try
            {
                object actual = MoodAnalyserFactory.CreateMoodAnalyserParameterizedObject(className, Constructor, message);
            }
            catch (MoodAnalyserCustomException ex)
            {

                Assert.AreEqual("no such constructor found", ex.Message);
            }
        }

        // UC6.1 GivenMoodAnalyserFactory Happy Message Should InvokeAnalyserMood Method Return Happy Message.
        [TestMethod]
        public void GivenMoodAnalyserFactory_ShouldInvokeAnalyserMoodMethod_ReturnHappyMessage()
        {
            object expected = new MoodAnalyser("Happy"); ;
            string actual = MoodAnalyserFactory.InvokeAnalyserMethod("Happy", "AnalyserMethod");
            expected.Equals(actual);
        }

        // UC6.2 GivenMoodAnalyserFactory Happy Message Should InvokeAnalyserMood Method Return Exception.
        [TestMethod]
        public void GivenMoodAnalyserFactory_ShouldInvokeAnalyserMoodMethod_ReturnException()
        {
            object expected = new MoodAnalyser("Happy");
            try
            {
                string actual = MoodAnalyserFactory.InvokeAnalyserMethod("Happy", "AnalysMethod");
            }
            catch (MoodAnalyserCustomException ex)
            {
                Assert.AreEqual("no such method is found", ex.Message);
            }
        }
    }
}
