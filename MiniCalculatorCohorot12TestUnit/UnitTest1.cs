using MiniCalculatorCohort12.Models;
using System.Security.RightsManagement;

namespace MiniCalculatorCohorot12TestUnit
{
    public class Tests
    {
        // Initialize the class we are going to test
        Calculator calc { get; set; } = null;
        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [Test]
        public void getAdditionTest()
        {
            /**
             * Inside each test method, we need to perform three operations:
             * A: Arrange the Code
             * A: Act on the Code
             * A: Assert on the code: Try to find out whether the method is logically correct or not.
             */

            // A: Arrange
            double expected_Results=25, actual_Results, a = 20, b = 5;

            // A: Act
            actual_Results = calc.getAddition(a,b);

            // A: Assert
            Assert.AreEqual(expected_Results, actual_Results);
            // on the upper line we created the arequal Assertion to find out whether two variables are
            // similar to each other, if not the test will fail
            Assert.That(actual_Results, Is.TypeOf<double>());
            // on the upper line we create the Type assertaion for the actual_results you are getting
            // from the code. If the type mismatches, it will fail the test
        }

        [Test]
        public void getSubtractionTest()
        {
            // Arrange
            double expectedResults=15, actual_Results, a = 20, b = 5;
            //Act
            actual_Results = calc.getSubstraction(a, b);
            // Assert
            Assert.AreEqual(expectedResults, actual_Results);
            Assert.That(actual_Results, Is.TypeOf<double>());
        }

        [Test]
        public void getMultiplicationTest()
        {
            double expectedResults = 100, actualResults, a = 20, b = 5;

            actualResults = calc.getMultiplication(a,b);

            Assert.AreEqual(expectedResults, actualResults);
            Assert.That(actualResults, Is.TypeOf<double>());
        }

        [Test]
        public void getDivisionTest() { 
        
            double expectedResults=4, actualResult, a=20, b = 5;

            actualResult = calc.getDivision(a,b);

            Assert.AreEqual(expectedResults, actualResult);
            Assert.That(actualResult, Is.TypeOf<double>());
        }

        [Test]
        public void getModulartest()
        {
            double expectedResults=0, actualResults, a=20, b = 5;

            actualResults = calc.getModulus(a,b);   
            Assert.AreEqual(expectedResults, actualResults);
            Assert.That(actualResults, Is.TypeOf<double>());
        }
    }
}