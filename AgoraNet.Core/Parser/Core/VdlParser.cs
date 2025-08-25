using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AgoraNet.Core.Models;
using AgoraNet.Core.Parser.Diagnostics;
using AgoraNet.Core.Parser.Factories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgoraNet.Core.Parser.Core
{
    public static class VdlParser
    {
        public static ParseResult ParseFile(string path)
        {
            ParserConfig.RegisterElementsTypes();
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
            Dictionary<string, string> properties = new Dictionary<string, string>();
            string elementName = string.Empty;
            Element? element = null;

            foreach (string rawElement in rawElements)
            {
                elementName = GetElementNameFromRawElement(rawElement);
                properties = ParseProperties(rawElement);
                element = ElementsRegistry.Create(elementName, properties);
                elements.Add(element);
            }

            return elements;
        }

        private static Dictionary<string, string> ParseProperties(string rawElement)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            int startIndex = rawElement.IndexOf(':') + 1;
            string rawProperty = string.Empty;
            string cleanedRawProperty = string.Empty;
            string key = string.Empty;
            string value = string.Empty;

            for (int i = startIndex; i < rawElement.Length; i++)
            {
                if (rawElement[i] == ',' || rawElement[i] == ']')
                {
                    cleanedRawProperty = ParseHelpers.RemoveAllWhiteSpaces(rawProperty);
                    string[] parts = cleanedRawProperty.Split('=');
                    key = parts[0];
                    value = parts[1];
                    properties.Add(key, value);
                    rawProperty = string.Empty;

                    if (rawElement[i] == ',')
                        i++;
                    if (rawElement[i] == ']')
                        break;
                }

                rawProperty += rawElement[i];
            }

            return properties;
        }

        private static string GetElementNameFromRawElement(string rawElement)
        {
            char charac = '¤';
            int index = 0;
            string elementName = string.Empty;

            while (charac != ' ')
            {
                charac = rawElement[index];
                elementName += rawElement[index];
                index++;
            }

            return elementName;
        }
    }
}
