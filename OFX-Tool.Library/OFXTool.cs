using RFD.OFXTool.Library.Core;
using RFD.OFXTool.Library.Entities;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace RFD.OFXTool.Library
{
    public enum PartDateTime
    {
        DAY,
        MONTH,
        YEAR,
        HOUR,
        MINUTE,
        SECOND
    }

    public class OFXTool : IOFXTool
    {
        public static Extract GetExtract(string ofxSourceFile)
        {
            return new OFXTool().GenerateExtract(ofxSourceFile);
        }

        public Extract GenerateExtract(string ofxSourceFile)
        {
            // Translating to XML file
            var xml = new ExportToXml(ofxSourceFile);

            var elementoSendoLido = "";
            Transaction transacaoAtual = null;

            var header = new HeaderExtract();
            var bankAccount = new BankAccount();
            var extract = new Extract(header, bankAccount, "");

            // Lendo o XML efetivamente
            var xmlReader = new XmlTextReader(xml.XmlFile);
            try
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("STMTTRN") && transacaoAtual != null)
                    {
                        extract.AddTransaction(transacaoAtual);
                        transacaoAtual = null;
                    }
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        elementoSendoLido = xmlReader.Name;
                        if (xmlReader.Name.Equals("STMTTRN"))
                        {
                            transacaoAtual = new Transaction();
                        }
                    }
                    if (xmlReader.NodeType == XmlNodeType.Text)
                    {
                        switch (elementoSendoLido)
                        {
                            case "DTSERVER":
                                header.ServerDate = ConvertOfxDateToDateTime(xmlReader.Value, extract);
                                break;
                            case "LANGUAGE":
                                header.Language = xmlReader.Value;
                                break;
                            case "ORG":
                                header.BankName = xmlReader.Value;
                                break;
                            case "DTSTART":
                                extract.InitialDate = ConvertOfxDateToDateTime(xmlReader.Value, extract);
                                break;
                            case "DTEND":
                                extract.FinalDate = ConvertOfxDateToDateTime(xmlReader.Value, extract);
                                break;
                            case "BANKID":
                                bankAccount.Bank = new Bank(GetBankId(xmlReader.Value, extract), "");
                                break;
                            case "BRANCHID":
                                bankAccount.AgencyCode = xmlReader.Value;
                                break;
                            case "ACCTID":
                                bankAccount.AccountCode = xmlReader.Value;
                                break;
                            case "ACCTTYPE":
                                bankAccount.Type = xmlReader.Value;
                                break;
                            case "TRNTYPE":
                                transacaoAtual.Type = xmlReader.Value;
                                break;
                            case "DTPOSTED":
                                transacaoAtual.Date = ConvertOfxDateToDateTime(xmlReader.Value, extract);
                                break;
                            case "TRNAMT":
                                transacaoAtual.TransactionValue = GetTransactionValue(xmlReader.Value, extract);
                                break;
                            case "FITID":
                                transacaoAtual.Id = xmlReader.Value;
                                break;
                            case "CHECKNUM":
                                transacaoAtual.Checksum = Convert.ToInt64(xmlReader.Value);
                                break;
                            case "MEMO":
                                transacaoAtual.Description = string.IsNullOrEmpty(xmlReader.Value) ? string.Empty : Regex.Replace(xmlReader.Value.Trim(), "[^\\S\\n]+", " ");
                                break;
                        }
                    }
                }
            }
            catch (XmlException xe)
            {
                throw new OFXToolException($"Invalid OFX file", xe);
            }
            finally
            {
                xmlReader.Close();
            }
            return extract;
        }




        /// <summary>
        /// Method that return a part of date. Is is used internally when the dates are reading.
        /// </summary>
        /// <param name="ofxDate">Date</param>
        /// <param name="partDateTime">Part of date</param>
        /// <returns></returns>
        private int GetPartOfOfxDate(string ofxDate, PartDateTime partDateTime)
        {
            int result = 0;

            switch (partDateTime)
            {
                case PartDateTime.DAY:
                    result = int.Parse(ofxDate.Substring(6, 2));
                    break;
                case PartDateTime.MONTH:
                    result = int.Parse(ofxDate.Substring(4, 2));
                    break;
                case PartDateTime.YEAR:
                    result = int.Parse(ofxDate.Substring(0, 4));
                    break;
                case PartDateTime.HOUR:
                    if (ofxDate.Length >= 10)
                        result = int.Parse(ofxDate.Substring(8, 2));
                    else
                        result = 0;
                    break;
                case PartDateTime.MINUTE:
                    if (ofxDate.Length >= 12)
                        result = int.Parse(ofxDate.Substring(10, 2));
                    else
                        result = 0;
                    break;
                case PartDateTime.SECOND:
                    if (ofxDate.Length >= 14)
                        result = int.Parse(ofxDate.Substring(12, 2));
                    else
                        result = 0;
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// Method that convert a OFX date string to DateTime object.
        /// </summary>
        /// <param name="ofxDate"></param>
        /// <param name="extract"></param>
        /// <returns></returns>
        private DateTime ConvertOfxDateToDateTime(string ofxDate, Extract extract)
        {
            DateTime dateTimeReturned = DateTime.MinValue;
            try
            {
                int year = GetPartOfOfxDate(ofxDate, PartDateTime.YEAR);
                int month = GetPartOfOfxDate(ofxDate, PartDateTime.MONTH);
                int day = GetPartOfOfxDate(ofxDate, PartDateTime.DAY);
                int hour = GetPartOfOfxDate(ofxDate, PartDateTime.HOUR);
                int minute = GetPartOfOfxDate(ofxDate, PartDateTime.MINUTE);
                int second = GetPartOfOfxDate(ofxDate, PartDateTime.SECOND);

                dateTimeReturned = new DateTime(year, month, day, hour, minute, second);
            }
            catch (Exception ex)
            {
                extract.ImportingErrors.Add(string.Format("Invalid datetime {0}", ofxDate));
            }
            return dateTimeReturned;
        }

        private int GetBankId(string value, Extract extract)
        {
            int bankId;
            if (!int.TryParse(value, out bankId))
            {
                extract.ImportingErrors.Add(string.Format("Bank id isn't a numeric value: {0}", value));
                bankId = 0;
            }
            return bankId;
        }

        private double GetTransactionValue(string value, Extract extract)
        {
            double returnValue = 0;
            try
            {
                returnValue = Convert.ToDouble(value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                extract.ImportingErrors.Add(string.Format("Invalid transaction value: {0}", value));
            }
            return returnValue;
        }
    }
}
