using PimaDoctor.Models;
using Xunit;

namespace XUnitTestProject1.Models
{
    public class Class1Tests
    {
        [Fact]
        public void TestClass1_Open_True()
        {
            var newClass = new Class1("true");
            Assert.True(newClass.Open);
        }
        
        [Fact]
        public void TestClass1_Open_False()
        {
            var newClass = new Class1("false");
            Assert.False(newClass.Open);
        }
    }
}