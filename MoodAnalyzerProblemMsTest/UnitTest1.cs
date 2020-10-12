using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;

namespace MoodAnalyzerProblemMsTest
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyser analyser;

        [TestInitialize]
        public void SetUp()
        {
            analyser = new MoodAnalyser("I am in a sad mood");
        }

        [TestMethod]
        public void Given_Sad_Mood_Returning_Sad_Result()
        {
            // Act
            var actual = analyser.AnalyserMethod();
            // Assert
            Assert.AreEqual("sad", actual);
        }
    }
}
