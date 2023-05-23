using System.Collections.Generic;
using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class RelatedEntityCollection : DataCollection<Relationship, EntityCollection>
{
    internal string ToXml()
    {
        StringBuilder sb = new StringBuilder();

        if (this.Count == 0)
        {
            return sb.Append("<a:RelatedEntities/>").ToString();
        }
        sb.Append("<a:RelatedEntities>");
        foreach (var item in this)
        {
            sb.Append(RelatedEntityToXml(item));
        }
        sb.Append("</a:RelatedEntities>");
        return sb.ToString();
    }
    internal string RelatedEntityToXml(KeyValuePair<Relationship, EntityCollection> item)
    {
        return "<a:KeyValuePairOfRelationshipEntityCollectionX_PsK4FkN>"
               + Util.ObjectToXml(item.Key, "b:key", true)
               + Util.ObjectToXml(item.Value, "b:value", true)
               + "</a:KeyValuePairOfRelationshipEntityCollectionX_PsK4FkN>";
    }
}