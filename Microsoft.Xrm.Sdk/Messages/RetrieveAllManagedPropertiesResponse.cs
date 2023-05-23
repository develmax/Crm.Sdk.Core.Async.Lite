using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveAllManagedPropertiesResponse : OrganizationResponse
{
    public ManagedPropertyMetadata[] ManagedPropertyMetadata { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "ManagedPropertyMetadata")
            {
                List<ManagedPropertyMetadata> list = new List<ManagedPropertyMetadata>();
                foreach (var item in result.Element(Util.ns.b + "value").Elements(Util.ns.h + "ManagedPropertyMetadata"))
                {
                    list.Add(Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata.LoadFromXml(item));
                }
                ManagedPropertyMetadata = list.ToArray();
            }
        }
    }
}