using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Calculation c;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            c = new Calculation(10, 5);
        }

        [TestMethod]
        public void TestAddOperator()
        {
            int expected, actual;
            //Calculation c = new Calculation(10, 5);
            expected = 15;
            actual = c.Execute("+");
            Assert.AreEqual(expected, actual);

            //Assert.AreEqual(c.Execute("+"), 15);
        }

        [TestMethod]
        public void TestSubOperator()
        {
            int expected, actual;
            //Calculation c = new Calculation(10, 5);
            expected = 5;
            actual = c.Execute("-");  
            Assert.AreEqual(expected, actual);

            //Assert.AreEqual(c.Execute("-"), 5);
        }

        [TestMethod]
        public void TestMulOperator()
        {
            int expected, actual;
            //Calculation c = new Calculation(10, 5);
            expected = 50;
            actual = c.Execute("*");
            Assert.AreEqual(expected, actual);

            //Assert.AreEqual(c.Execute("*"), 50);
        }

        [TestMethod]
        public void TestDivOperator()
        {
            int expected, actual;
            //Calculation c = new Calculation(10, 5);
            expected = 2;
            actual = c.Execute("/");
            Assert.AreEqual(expected, actual);

            //Assert.AreEqual(c.Execute("/"), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivByZero()
        {
            Calculation c = new Calculation(2, 0);
            c.Execute("/");
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    @".\Data\TestData1.csv", "TestData1#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSource1()
        {
            int a, b, expected, actual;
            a = int.Parse(TestContext.DataRow[0].ToString());
            b = int.Parse(TestContext.DataRow[1].ToString());
            expected = int.Parse(TestContext.DataRow[2].ToString());
            Calculation c = new Calculation(a, b);
            actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                   @".\Data\TestData2.csv", "TestData2#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSource2()
        {
            int a, b, expected, actual;
            string operation;
            a = int.Parse(TestContext.DataRow[0].ToString());
            b = int.Parse(TestContext.DataRow[1].ToString());
            operation = TestContext.DataRow[2].ToString();
            operation = operation.Remove(0, 1);
            expected = int.Parse(TestContext.DataRow[3].ToString());
            Calculation c = new Calculation(a, b);
            actual = c.Execute(operation);
            Assert.AreEqual(expected, actual);
        }
    }
}
