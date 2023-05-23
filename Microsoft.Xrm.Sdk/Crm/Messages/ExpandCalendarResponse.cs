using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ExpandCalendarResponse : OrganizationResponse
{
    public TimeInfo[] result { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "result")
            {
                List<TimeInfo> list = new List<TimeInfo>();
                foreach (XElement item in result.Element(Util.ns.b + "value").Elements(Util.ns.g + "TimeInfo"))
                {
                    list.Add(TimeInfo.LoadFromXml(item));
                }
                this.result = list.ToArray();
            }
        }
    }
}