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
            IEnumerable<string> input = new List<string> { "Hello my", "name is", "Christoffer Gram" };

            IEnumerable<string> output = SplitLine(input);

            IEnumerable<string> expected = new List<string> { "Hello", "my", "name", "is", "Christoffer", "Gram" };
            Assert.Equal(expected, output);
        }
        [Fact]
        public void finds_resolutions()
        {
            //Given
            var input = "1024x768, 800x600, 640x480";
            //When
            var ouput = RegExpr.Resolution(input);
            //Then
            IEnumerable<(int, int)> expected = new List<(int, int)>() { (1024, 768), (800, 600), (640, 480) };
            Assert.Equal(expected, ouput);
        }

        [Fact]
        public void finds_inner_text_in_a_tag()
        {
            var input = "<b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href='/wiki/Theoretical_computer_science' title='Theoretical computer science'>theoretical computer science</a> and <a href='/wiki/Formal_language' title='Formal language'>formal language</a> theory, a sequence of <a href='/wiki/Character_(computing)' title='Character (computing)'>characters</a> that define a <i>search <a href='/wiki/Pattern_matching' title='Pattern matching'>pattern</a></i>. Usually this pattern is then used by <a href='/wiki/String_searching_algorithm' title='String searching algorithm'>string searching algorithms</a> for 'find' or 'find and replace' operations on <a href='/wiki/String_(computer_science)' title='String (computer science)'>strings</a>.</p>";

            var output = RegExpr.InnerText(input, "a");

            var expected = new List<string>(){
                "theoretical computer science",
                "formal language",
                "characters",
                "pattern",
                "string searching algorithms",
                "strings"
            };
            Assert.Equal(expected, output);
        }
    }
}
