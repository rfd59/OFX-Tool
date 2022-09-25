using RFD.OFXTool.Library.Attributes;

namespace RFD.OFXTool.Library.Entities
{
    public class HeaderDocument
    {
        [Header("OFXHEADER")]
        public string OfxHeader { get; set; }
        [Header("DATA")]
        public string Data { get; set; }
        [Header("VERSION")]
        public string Version { get; set; }
        [Header("SECURITY")]
        public string Security { get; set; }
        [Header("ENCODING")]
        public string Encoding { get; set; }
        [Header("CHARSET")]
        public string Charset { get; set; }
        [Header("COMPRESSION")]
        public string Compression { get; set; }
        [Header("OLDFILEUID")]
        public string OldFileUid { get; set; }
        [Header("NEWFILEUID")]
        public string NewFileUid { get; set; }

        public HeaderDocument()
        {
            OfxHeader = "100";
            Data = "OFXSGML";
            Version = "102";
            Security = "NONE";
            Encoding = "USASCII";
            Charset = "1252";
            Compression = "NONE";
            OldFileUid = "NONE";
            NewFileUid = "NONE";
        }


        // Determines whether the specified object is equal to the current object.
        public override bool Equals(object? obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                HeaderDocument e = (HeaderDocument)obj;

                return Entity.PropertyEquality(e.OfxHeader, OfxHeader) &&
                     Entity.PropertyEquality(e.Data, Data) &&
                     Entity.PropertyEquality(e.Version, Version) &&
                     Entity.PropertyEquality(e.Security, Security) &&
                     Entity.PropertyEquality(e.Encoding, Encoding) &&
                     Entity.PropertyEquality(e.Charset, Charset) &&
                     Entity.PropertyEquality(e.Compression, Compression) &&
                     Entity.PropertyEquality(e.OldFileUid, OldFileUid) &&
                     Entity.PropertyEquality(e.NewFileUid, NewFileUid);
            }
        }

        //Serves as the default hash function
        public override int GetHashCode() => new { OfxHeader, Data, Version, Security, Encoding, Charset, Compression, OldFileUid, NewFileUid }.GetHashCode();
    }
}
