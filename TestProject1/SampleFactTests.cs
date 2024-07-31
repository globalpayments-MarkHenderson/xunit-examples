namespace TestProject1
{
    public class SampleFactTests
    {
        [Fact]
        public void EqualsTest()
        {
            int expected = 5;
            int actual = 2 + 3;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CollectionAsserts()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Assert that the collection contains a specific value
            Assert.Contains(3, numbers);

            // Assert that all elements in the collection meet a certain condition
            Assert.All(numbers, n => Assert.True(n > 0));

            // Assert the collection with specific expected elements
            Assert.Collection(numbers,
                n => Assert.Equal(1, n),
                n => Assert.Equal(2, n),
                n => Assert.Equal(3, n),
                n => Assert.Equal(4, n),
                n => Assert.Equal(5, n));
        }

        [Fact]
        public void AllElementsHaveSameValue()
        {
            var numbers = new List<int> { 5, 5, 5, 5, 5 };
            int firstValue = numbers[0];

            Assert.All(numbers, n => Assert.Equal(firstValue, n));
        }

        [Fact]
        public void CollectionContainsSpecificValue()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            int specificValue = 3;

            Assert.Contains(specificValue, numbers);
        }

        [Fact]
        public void ShouldThrowException()
        {
            // Arrange
            var exceptionType = typeof(InvalidOperationException);

            // Act and Assert
            Assert.Throws(exceptionType, () =>
            {
                throw new InvalidOperationException();
            });
        }

        [Fact]
        public void ShouldThrowArgumentException()
        {
            // Arrange
            string expectedParamName = "exampleParam";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => ThrowArgumentException(expectedParamName));

            // Assert
            Assert.Equal(expectedParamName, ex.ParamName);
        }

        private void ThrowArgumentException(string paramName)
        {
            throw new ArgumentException("Invalid argument", paramName);
        }
    }
}