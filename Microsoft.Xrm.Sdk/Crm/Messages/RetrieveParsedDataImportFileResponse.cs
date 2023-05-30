using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveParsedDataImportFileResponse : OrganizationResponse
{
    public string[][] Values { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "Values")
            {
                List<List<string>> list = new List<List<string>>();
                foreach (XElement item in result.Element(Util.ns.b + "value").Elements(Util.ns.f + "ArrayOfstring"))
                {
                    List<string> childlist = new List<string>();
                    foreach (XElement value in item.Elements(Util.ns.f + "string"))
                    {
                        childlist.Add(value.Value);
                    }
                    list.Add(childlist);
                }
                List<string>[] childarray = list.ToArray();
                this.Values = new string[list.Count][];
                for (int i = 0; i < list.Count; i++)
                {
                    Values[i] = list[i].ToArray();
                }
                break;
            }
        }
    }
}