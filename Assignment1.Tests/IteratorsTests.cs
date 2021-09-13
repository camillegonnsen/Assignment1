using System;
using System.Collections.Generic;
using Xunit;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void returns_flattened_list()
        {
            //Given
            var input = new[] { new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 } };
            //When
            var output = Iterators.Flatten<int>(input);
            //Then
            IEnumerable<int> expected = new List<int>() { 1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 6 };
            Assert.Equal(expected, output);
        }
        [Fact]
        public void filter_returns_6()
        {
            //Given
            var input = new int[] { 1, 2, 3, 4, 5, 6 };
            var predicate = new Predicate<int>(isGreaterThan5);
            //When
            var output = Iterators.Filter<int>(input, predicate);
            //Then
            var expected = new List<int>() { 6 };
            Assert.Equal(expected, output);
        }

        bool isGreaterThan5(int i)
        {
            return i > 5;
        }
    }
}
