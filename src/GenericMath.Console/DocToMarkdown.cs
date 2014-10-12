//  *************************************************************
// <copyright file="DocToMarkdown.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  12 / 10 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Console
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;

    using GenericMath.Common;

    public static class DocToMarkdown
    {
        #region fields

        private static IRegex _regex = new RegexAdapter();

        #endregion

        internal static void Parse(string path)
        {
            var test = @"C:\Users\andy\Documents\GitHub\Xamarin\GenericMath\src\Math.LinearAlgebra\bin\Debug";
            var test2 = "Math.LinearAlgebra.xml";
            var testPath = Path.Combine(test, test2);

            var writePath = "markdown.markdown"; 

            var xml = File.ReadAllText(testPath);
            var doc = XDocument.Parse(xml);
            var md = doc.Root.ToMarkDown();

            using (var str = new StreamWriter(Path.Combine(test, writePath)))
            {
                str.Write(md);
            }
        }

        internal static string ToMarkDown(this XNode e)
        {
            var templates = new Dictionary<string, string>
            {
                { "doc", "## {0} ##\n\n{1}\n\n" },
                { "type", "# {0}\n\n{1}\n\n---\n" },
                { "field", "##### {0}\n\n{1}\n\n---\n" },
                { "property", "##### {0}\n\n{1}\n\n---\n" },
                { "method", "##### {0}\n\n{1}\n\n---\n" },
                { "event", "##### {0}\n\n{1}\n\n---\n" },
                { "summary", "{0}\n\n" },
                { "remarks", "\n\n>{0}\n\n" },
                { "example", "_C# code_\n\n```c#\n{0}\n```\n\n" },
                { "seePage", "[[{1}|{0}]]" },
                { "seeAnchor", "[{1}]({0})" },
                { "param", "|Name | Description |\n|-----|------|\n|{0}: |{1}|\n" },
                { "exception", "[[{0}|{0}]]: {1}\n\n" },
                { "returns", "Returns: {0}\n\n" },
                { "none", "" },
                { "c", "{0}\n\n" }, // TODO change (<c>)
                { "typeparam", "|Name | Description |\n|-----|------|\n|{0}: |{1}|\n" }, // TODO change (<typeparam>)
                { "value", "{0}\n\n" }, // TODO change (<value>)
            };
            var d = new Func<string, XElement, string[]>((att, node) => new[]
                {
                    node.Attribute(att).Value, 
                    node.Nodes().ToMarkDown()
                });
            var methods = new Dictionary<string, Func<XElement, IEnumerable<string>>>
            {
                {"doc", x => new[]
                    {
                        x.Element("assembly").Element("name").Value,
                        x.Element("members").Elements("member").ToMarkDown()
                    }
                },
                { "type", x => d("name", x) },
                { "field", x => d("name", x) },
                { "property", x => d("name", x) },
                { "method",x => d("name", x) },
                { "event", x => d("name", x) },
                { "summary", x => new[]{ x.Nodes().ToMarkDown() } },
                { "remarks", x => new[]{ x.Nodes().ToMarkDown() } },
                { "example", x => new[]{ x.Value.ToCodeBlock() } },
                { "seePage", x => d("cref", x) },
                { "seeAnchor", x =>
                    {
                        var xx = d("cref", x);
                        xx[0] = xx[0].ToLower();
                        return xx;
                    }
                },
                { "param", x => d("name", x) },
                { "exception", x => d("cref", x) },
                { "returns", x => new[]{ x.Nodes().ToMarkDown() } },
                { "none", x => new string[0] },
                { "typeparam", x => d("name", x) }, // TODO change (<typeparam>)
                { "value", x => new[]{ x.Nodes().ToMarkDown() } }, // TODO change (<value>)
                { "c", x => new[]{ x.Nodes().ToMarkDown() } }, // TODO change (<c>)
            };

            string name;
            if (e.NodeType == XmlNodeType.Element)
            {
                var el = (XElement)e;
                name = el.Name.LocalName;
                if (name == "member")
                {
                    switch (el.Attribute("name").Value[0])
                    {
                        case 'F':
                            name = "field";
                            break;
                        case 'P':
                            name = "property";
                            break;
                        case 'T':
                            name = "type";
                            break;
                        case 'E':
                            name = "event";
                            break;
                        case 'M':
                            name = "method";
                            break;
                        default:
                            name = "none";
                            break;
                    }
                }

                if (name == "see")
                {
                    var anchor = el.Attribute("cref").Value.StartsWith("!:#");
                    name = anchor ? "seeAnchor" : "seePage";
                }

                var vals = methods[name](el).ToArray();
                string str = "";
                switch (vals.Length)
                {
                    case 1:
                        str = string.Format(templates[name], vals[0]);
                        break;
                    case 2:
                        str = string.Format(
                            templates[name],
                            vals[0],
                            vals[1]);
                        break;
                    case 3:
                        str = string.Format(
                            templates[name],
                            vals[0],
                            vals[1],
                            vals[2]);
                        break;
                    case 4:
                        str = string.Format(
                            templates[name],
                            vals[0],
                            vals[1],
                            vals[2],
                            vals[3]);
                        break;
                }

                return str;
            }

            if (e.NodeType == XmlNodeType.Text)
            {
                return _regex.Replace(
                    ((XText)e).Value.Replace('\n', ' '),
                    @"\s+",
                    String.Empty);

            }
                
            return String.Empty;
        }

        private static String ToMarkDown(this IEnumerable<XNode> es)
        {
            return es.Aggregate("", (current, x) => current + x.ToMarkDown());
        }

        private static String ToCodeBlock(this String s)
        {
            var lines = s.Split(
                            new char[] { '\n' },
                            StringSplitOptions.RemoveEmptyEntries);
            var blank = lines[0].TakeWhile(x => x == ' ').Count() - 4;
            return string.Join(
                "\n",
                lines.Select(x => new string(x.SkipWhile((
                                y,
                                i) => i < blank).ToArray())));
        }
    }
}