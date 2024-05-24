using Microsoft.VisualStudio.TestPlatform.TestHost;
using Review1;
namespace NumberProblems
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Arrange
        [DataRow(3, true)]
        [DataRow(7, true)]
        [DataRow(11, true)]
        [DataRow(8, false)]
        [DataRow(10, false)]
        public void TestMethod1(int n,bool expected)
        {
            //Action
            bool Actual = Review1.Program.Prime(n);
            //Assert
            Assert.AreEqual(expected, Actual);
        }
        
    }
}