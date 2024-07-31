using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class SampleTheoryTests
    {

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        [InlineData(-1, 1, 0)]
        public void AdditionTest(int a, int b, int expectedSum)
        {
            int actualSum = a + b;
            Assert.Equal(expectedSum, actualSum);
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void CanAdd(int value1, int value2, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(value1, value2);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData
        {
            get
            {
                return new List<object[]>
            {
                new object[] { 1, 2, 3 },
                new object[] { -4, -6, -10 },
                new object[] { -2, 2, 0 },
                new object[] { int.MinValue, -1, int.MaxValue },
            };
            }
        }

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void CanAddTheoryClassData(int value1, int value2, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(value1, value2);
            Assert.Equal(expected, result);
        }
    }

    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { -4, -6, -10 };
            yield return new object[] { -2, 2, 0 };
            yield return new object[] { int.MinValue, -1, int.MaxValue };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

}
