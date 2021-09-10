using Xunit;
using System.Collections.Generic;

using static Assignment1.RegExpr;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void SplitLine_Given_Lines_Returns_Single_Words()
        {
            IEnumerable<string> input = new List<string> {"Hello my", "name is", "Christoffer Gram"};

            IEnumerable<string> output = SplitLine(input);

            IEnumerable<string> expected = new List<string> {"Hello", "my", "name", "is", "Christoffer", "Gram"};
            Assert.Equal(expected, output);
        }
    }
}
