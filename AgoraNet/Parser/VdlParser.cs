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
            Element? element = null;
            string elementName = string.Empty;

            foreach (string rawElement in rawElements)
            {
                elementName = GetElementNameFromRawElement(rawElement);

                switch (elementName)
                {
                    case "Square":
                        element = BuildSquare(rawElement);
                        break;

                    case "Text":
                        element = BuildText(rawElement); 
                        break;

                    default: 
                        throw new Exception("Element not reconized");
                }

                elements.Add(element);
            }

            return elements;
        }

        private static string GetElementNameFromRawElement(string rawElement)
        {
            char charac = '¤';
            int index = 0;
            string elementName = string.Empty;

            while(charac != ' ')
            {
                charac = rawElement[index];
                elementName += rawElement[index];
                index++;
            }

            return elementName;
        }

        private static Square BuildSquare(string rawElement)
        {
            throw new NotImplementedException();
        }
        private static Text BuildText(string rawElement)
        {
            throw new NotImplementedException();
        }
    }
}
