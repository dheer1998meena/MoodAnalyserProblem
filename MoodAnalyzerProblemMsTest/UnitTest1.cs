using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;

namespace MoodAnalyzerProblemMsTest
{
    [TestClass]
    public class UnitTest1
    {
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

        [DataRow(null)]
        [TestMethod]
        public void Given_Null_Expecting_Happy(string message)
        {
            // Arrange
            string expected ="HAPPY";
            MoodAnalyser analyser = new MoodAnalyser(message);
            // Act
            var actual = analyser.AnalyserMethod();
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
