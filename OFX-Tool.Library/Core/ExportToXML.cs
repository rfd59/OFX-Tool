using System.Text;

namespace RFD.OFXTool.Library.Core
{
    internal class ExportToXml
    {
        internal string XmlFile { get; }
        internal string OfxFile { get; }

        internal ExportToXml(string ofxSourceFile) : this(ofxSourceFile, ofxSourceFile + ".xml")
        { }

        /// <summary>
        /// This method translate an OFX file to XML file, independent of the content.
        /// </summary>
        /// <param name="ofxSourceFile">Path of OFX source file</param>
        /// <param name="xmlNewFile">Path of the XML file, internally generated.</param>
        internal ExportToXml(string ofxSourceFile, string xmlNewFile)
        {
            OfxFile = ofxSourceFile;
            XmlFile = xmlNewFile;

            if (File.Exists(ofxSourceFile))
            {
                if (xmlNewFile.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    // Translating the OFX file to XML format
                    var ofxTranslated = TranslateToXml(ofxSourceFile);

                    // Verifying if target file exists
                    if (File.Exists(xmlNewFile))
                    {
                        File.Delete(xmlNewFile);
                    }

                    // Writing data into target file
                    StreamWriter sw = File.CreateText(xmlNewFile);
                    sw.WriteLine(@"<?xml version=""1.0""?>");
                    sw.WriteLine(ofxTranslated.ToString());
                    sw.Close();
                }
                else
                {
                    throw new ArgumentException("Name of new XML file is not valid: " + xmlNewFile);
                }
            }
            else
            {
                throw new FileNotFoundException("OFX source file not found: " + ofxSourceFile);
            }
        }


        /// <summary>
        /// This method translate an OFX file to XML tags, independent of the content.
        /// </summary>
        /// <param name="ofxSourceFile">OFX source file</param>
        /// <returns>XML tags in StringBuilder object.</returns>
        private StringBuilder TranslateToXml(string ofxSourceFile)
        {
            var result = new StringBuilder();
            int level = 0;
            string line;

            using (var sr = new StreamReader(ofxSourceFile, Encoding.Default))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (line.StartsWith("</") && line.EndsWith(">"))
                    {
                        AddTabs(result, level, true);
                        level--;
                        result.Append(line);
                    }
                    else if (line.StartsWith("<") && line.EndsWith(">"))
                    {
                        level++;
                        AddTabs(result, level, true);
                        result.Append(line);
                    }
                    else if (line.StartsWith("<") && !line.EndsWith(">"))
                    {
                        AddTabs(result, level + 1, true);
                        result.Append(line);
                        result.Append(ReturnFinalTag(line));
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// This method add tabs into lines of xml file, to best identation.
        /// </summary>
        /// <param name="stringObject">Line of content</param>
        /// <param name="lengthTabs">Length os tabs to add into content</param>
        /// <param name="newLine">Is it new line?</param>
        private void AddTabs(StringBuilder stringObject, int lengthTabs, bool newLine)
        {
            if (newLine)
            {
                stringObject.AppendLine();
            }
            for (int j = 1; j < lengthTabs; j++)
            {
                stringObject.Append("\t");
            }
        }

        /// <summary>
        /// This method return the correct closing tag string 
        /// </summary>
        /// <param name="content">Content of analysis</param>
        /// <returns>string with ending tag.</returns>
        private string ReturnFinalTag(string content)
        {
            var returnFinal = string.Empty;

            if ((content.IndexOf("<", StringComparison.InvariantCulture) != -1) && (content.IndexOf(">", StringComparison.InvariantCulture) != -1))
            {
                int position1 = content.IndexOf("<", StringComparison.InvariantCulture);
                int position2 = content.IndexOf(">", StringComparison.InvariantCulture);
                if ((position2 - position1) > 2)
                {
                    returnFinal = content.Substring(position1, (position2 - position1) + 1);
                    returnFinal = returnFinal.Replace("<", "</");
                }
            }

            return returnFinal;
        }

    }
}
