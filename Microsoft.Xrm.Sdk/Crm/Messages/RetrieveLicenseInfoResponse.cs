using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveLicenseInfoResponse : OrganizationResponse
{
    public int AvailableCount { get; set; }
    public int GrantedLicenseCount { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "AvailableCount")
                this.AvailableCount = Util.LoadFromXml<int>(result.Element(Util.ns.b + "value"));
            if (result.Element(Util.ns.b + "key").Value == "GrantedLicenseCount")
                this.GrantedLicenseCount = Util.LoadFromXml<int>(result.Element(Util.ns.b + "value"));
        }
    }
}