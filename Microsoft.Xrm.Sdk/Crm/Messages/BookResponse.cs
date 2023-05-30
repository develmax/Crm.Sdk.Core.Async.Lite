using System;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class BookResponse : OrganizationResponse
{
    public Object Notifications { get; set; }
    public ValidationResult ValidationResult { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "ValidationResult")
                this.ValidationResult = ValidationResult.LoadFromXml(result.Element(Util.ns.b + "value"));
            else if (result.Element(Util.ns.b + "key").Value == "Notifications")
                this.Notifications = result.Element(Util.ns.b + "value").Value;
        }
    }
}