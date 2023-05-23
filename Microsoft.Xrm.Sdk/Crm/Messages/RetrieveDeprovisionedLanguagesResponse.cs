using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveDeprovisionedLanguagesResponse : OrganizationResponse
{
    public int[] RetrieveDeprovisionedLanguages { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "RetrieveDeprovisionedLanguages")
            {
                List<int> list = new List<int>();
                foreach (var item in result.Element(Util.ns.b + "value").Elements(Util.ns.g + "RetrieveDeprovisionedLanguage"))
                {
                    list.Add(Util.LoadFromXml<int>(item));
                }
                this.RetrieveDeprovisionedLanguages = list.ToArray();
            }
        }
    }
}