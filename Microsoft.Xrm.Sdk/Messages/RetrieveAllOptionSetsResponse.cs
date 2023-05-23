using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveAllOptionSetsResponse : OrganizationResponse
{
    public OptionSetMetadataBase[] OptionSetMetadata { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "OptionSetMetadata")
            {
                List<OptionSetMetadataBase> list = new List<OptionSetMetadataBase>();
                foreach (var item in result.Element(Util.ns.b + "value").Elements(Util.ns.h + "OptionSetMetadataBase"))
                {
                    list.Add(OptionSetMetadataBase.LoadFromXml(item));
                }
                OptionSetMetadata = list.ToArray();
            }
        }
    }
}