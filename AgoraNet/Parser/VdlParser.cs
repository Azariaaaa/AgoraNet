using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AgoraNet.Core.Models;

namespace AgoraNet.Core.Parser
{
    public static class VdlParser
    {
        public static ParseResult ParseFile(string path)
        {
            string fileContent = File.ReadAllText(path);
            List<string> rawElements = GetRawElements(fileContent);
            return new ParseResult();
        }

        private static List<string> GetRawElements(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"\[(.*?)\]");
            List<string> rawElements = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToList();
            return rawElements;
        }

        private static List<Element> ParseList(List<string> rawElements)
        {
            List<Element> elements = new List<Element>();
            foreach (string rawElement in rawElements)
            {
                Element element = ParseRawElement(rawElement);
                elements.Add(element);
            }
            return elements;
        }

        private static Element ParseRawElement(string rawElement)
        {
            char charac = '¤';
            int index = 1; //jump over first char because its always '['
            string elementName = "";
            while(charac != ' ')
            {
                charac = rawElement[index];
                elementName += rawElement[index];
                index++;
            }

            //A coder

            return new Square(1,1,1,1,"color");
        }
    }
}
