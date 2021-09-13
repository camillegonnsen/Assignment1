using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            foreach (string line in lines)
            {
                string[] wordsInLine = Regex.Split(line, @"\s+");
                foreach (string word in wordsInLine)
                {
                    yield return word;
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            Regex regex = new Regex(@"(?<x>\d+)x(?<y>\d+)");
            var resolutionItems = resolutions.Split(",");
            foreach (var item in resolutionItems)
            {
                Match match = regex.Match(item);
                if(match.Success){
                    var x = int.Parse(match.Groups["x"].Value);
                    var y = int.Parse(match.Groups["y"].Value);
                    yield return (x,y);
                }
            }
            
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            
            var regex = new Regex(string.Format(@"<[{0}][^>]*>(.+?)</[{0}]>", tag));
            var matches = regex.Matches(html);
            foreach (Match match in matches)
            {
                if(match.Success){
                    yield return Regex.Replace(match.Groups[1].Value, @"<[^>]*>", "");
                }
            }
        }
    }
}
