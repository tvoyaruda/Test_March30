using System.Reflection;
using FizzBuzzApp;

namespace FizzBuzzDetectorTest
{
    [TestClass]
    public class FizzBuzzDetectorTests
    {
        private FizzBuzzDetector detector;

        [TestInitialize]
        public void Setup()
        {
            detector = new FizzBuzzDetector();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void GetThrowArgumentNullExceptionIfInputIsNullOrEmpty(string input)
        {
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => detector.getOverlappings(input));
        }

        [TestMethod]
        [DataRow("ls t 7")]
        [DataRow("Mary had a little lamb Little lamb, little lamb Mary had a little lamb It's fleece was white as snow more 100")]
        public void GetThrowArgumentExceptionIfInputLengthOutOfRange(string input)
        {
            // Assert
            Assert.ThrowsException<ArgumentException>(() => detector.getOverlappings(input));
        }

        [TestMethod]
        [DataRow("Just simple text to text this function withount any meaning but long enought to text at all", "Just simple Fizz to Buzz Fizz function withount Fizz Buzz but Fizz enought to FizzBuzz at all", 7)]
        [DataRow("Just 32/ simple text234 to text 2354 this function withount any .. meaning", "Just simple Fizz to Buzz Fizz function withount Fizz Buzz", 5)]
        [DataRow("Mary had a little lamb Little lamb, little lamb Mary had a little lamb It's fleece was white as snow", "Mary had Fizz little Buzz Fizz lamb little Fizz Buzz had Fizz little lamb FizzBuzz fleece was Fizz as Buzz", 9)]
        public void GetCorrectOutputWhenWithValidInput(string input, string expectedString, int expectedCount)
        {
            // Assert
            Assert.AreEqual(detector.getOverlappings(input), new FizzBuzzDetectorResult { ResultString = expectedString , Count = expectedCount});
        }
    }
}