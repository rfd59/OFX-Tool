using RFD.OFXTool.Library.Core.Build;
using RFD.OFXTool.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFD.OFXTool.Library.Core
{
    public class BuildToFile
    {
        public string OfxFile { get; }

        public ResponseDocument OfxDocument { get; }

        public BuildToFile(ResponseDocument doc, string file)
        {
            OfxDocument = doc;
            OfxFile = file;

            Build();
        }

        private void Build()
        {
            // Writing data into target file
            StreamWriter sw = File.CreateText(OfxFile);
            sw.WriteLine(WriteStartObject(Entity.GetElementClass<ResponseDocument>().Name));

            //
            if (OfxDocument.SignonResponseMessageSetV1 != null)
                sw.WriteLine(new BuildSIGNONMSGSRSV1(OfxDocument.SignonResponseMessageSetV1).Element);

            //
            if (OfxDocument.BankResponseMessageSetV1 != null)
                sw.WriteLine(new BuildBANKMSGSRSV1(OfxDocument.BankResponseMessageSetV1).Element);
           
            sw.WriteLine(WriteEndObject(Entity.GetElementClass<ResponseDocument>().Name));
            sw.Close();

        }

        public static string WriteStartObject(string name, int level=0)
        {
            return $"{tabs(level)}<{name}>";
        }
        public static string WriteEndObject(string name, int level = 0)
        {
            return $"{tabs(level)}</{name}>";
        }
        public static string WriteProperty(string name, string value, int level = 0)
        {
            return $"{tabs(level)}\t<{name}>{value}";
        }

        private static string tabs(int level)
        {
            var t = "";
            for (int i = 0; i < level; i++)
            {
                t += "\t";
            }

            return t;
        }
    }
}
