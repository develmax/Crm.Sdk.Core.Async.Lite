using System;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AddToQueueResponse : OrganizationResponse
{
    public Guid QueueItemId { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "QueueItemId")
                this.QueueItemId = Util.LoadFromXml<Guid>(result.Element(Util.ns.b + "value"));
        }
    }
}