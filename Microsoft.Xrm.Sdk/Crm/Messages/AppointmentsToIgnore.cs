using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class AppointmentsToIgnore
{
    public Guid[] Appointments { get; set; }
    public Guid ResourceId { get; set; }
    public AppointmentsToIgnore()
    {
        Appointments = new List<Guid>().ToArray();
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(ResourceId, "g:ResourceId", true));
        sb.Append(Util.ObjectToXml(Appointments, "g:Appointments", true));
        return sb.ToString();
    }
}