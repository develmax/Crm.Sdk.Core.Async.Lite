using System;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveFormXmlResponse : OrganizationResponse
{
    public string FormXml { get; set; }
    public int CustomizationLevel { get; set; }
    public int ComponentState { get; set; }
    public Guid SolutionId { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "FormXml")
                this.FormXml = result.Element(Util.ns.b + "value").Value;
            if (result.Element(Util.ns.b + "key").Value == "CustomizationLevel")
                this.CustomizationLevel = Util.LoadFromXml<int>(result.Element(Util.ns.b + "value"));
            if (result.Element(Util.ns.b + "key").Value == "ComponentState")
                this.ComponentState = Util.LoadFromXml<int>(result.Element(Util.ns.b + "value"));
            if (result.Element(Util.ns.b + "key").Value == "SolutionId")
                this.SolutionId = Util.LoadFromXml<Guid>(result.Element(Util.ns.b + "value"));
        }
    }
}