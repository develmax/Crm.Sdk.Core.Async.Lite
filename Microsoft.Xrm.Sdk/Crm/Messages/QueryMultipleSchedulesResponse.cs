using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class QueryMultipleSchedulesResponse : OrganizationResponse
{
    public TimeInfo[][] TimeInfos { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "TimeInfos")
            {
                List<List<TimeInfo>> list = new List<List<TimeInfo>>();
                foreach (XElement item in result.Element(Util.ns.b + "value").Elements(Util.ns.g + "ArrayOfTimeInfo"))
                {
                    List<TimeInfo> childlist = new List<TimeInfo>();
                    foreach (XElement timeInfo in item.Elements(Util.ns.g + "TimeInfo"))
                    {
                        childlist.Add(TimeInfo.LoadFromXml(timeInfo));
                    }
                    list.Add(childlist);
                }
                List<TimeInfo>[] childarray = list.ToArray();
                this.TimeInfos = new TimeInfo[list.Count][];
                for (int i = 0; i < list.Count; i++)
                {
                    TimeInfos[i] = list[i].ToArray();
                }
                break;
            }
        }
    }
}