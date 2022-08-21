namespace RFD.OFXTool.Library.Ofx
{
    public class OfxElementType
    {
        //
        // Résumé :
        //     Gets or sets the custom element name.
        public string TagName { get; set; }
        //
        // Résumé :
        //     Gets or sets the user-friendly display name for the custom element
        public string Name { get; set; }
        //
        // Résumé :
        //     Gets or sets the any defined OFX type (date, amount, etc.) or standard format
        //     for defining an alpha or numeric field.
        public string TagType { get; set; }
        //
        // Résumé :
        //     Gets or sets the custom element data value.
        public string TagValue { get; set; }
    }
}