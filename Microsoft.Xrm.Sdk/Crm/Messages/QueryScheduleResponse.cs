using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class QueryScheduleResponse : OrganizationResponse
{
    public TimeInfo[] TimeInfos { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "TimeInfos")
            {
                List<TimeInfo> list = new List<TimeInfo>();
                foreach (XElement item in result.Element(Util.ns.b + "value").Elements(Util.ns.g + "TimeInfo"))
                {
                    list.Add(TimeInfo.LoadFromXml(item));
                }
                //this.TimeInfos = EntityCollection.LoadFromXml(result.Element(Util.ns.b + "value"));
                this.TimeInfos = list.ToArray();
            }
        }
    }
}