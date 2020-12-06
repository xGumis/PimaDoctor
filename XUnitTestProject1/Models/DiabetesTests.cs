using FluentAssertions;
using PimaDoctor.Models;
using Xunit;

namespace XUnitTestProject1.Models
{
    public class DiabetesTests
    {
        [Fact]
        public void CreateDiabetesTest()
        {
            var diabetes = new Diabetes
            {
                Age = 54,
                Glucose = 125,
                Insulin = 0,
                Outcome = 1,
                Pregnancies = 8,
                BloodPressure = 96,
                SkinThickness = 0,
                BMI = 0,
                DiabetesPedigreeFunction = 0.232
            };

            diabetes.Should().BeOfType<Diabetes>();
        }
    }
}